using Coravel.Invocable;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using OikosPortal.Common;

namespace OikosPortal.Infra.BackgroundJobs;

public class VerificarAssinantesAtivos : IInvocable
{
    public readonly ApplicationDbContext _dbContext;
    public readonly UserManager<IdentityUser> _userManager;
    public readonly IEmailSender _emailSender;

    public VerificarAssinantesAtivos(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IEmailSender emailSender)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _emailSender = emailSender;
    }

    public async Task Invoke()
    {
        var assinantes = await _dbContext.UserClaims.Where(x => x.ClaimType == ApplicationClaims.DataAssinatura).ToListAsync();

        foreach (var assinante in assinantes)
        {
            var dataAssinatura = DateTime.Parse(assinante.ClaimValue);

            if (dataAssinatura.AddMonths(1) > DateTime.UtcNow)
            {
                var user = await _userManager.FindByIdAsync(assinante.UserId);

                if (user != null)
                {
                    if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Assinante))
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, ApplicationRoles.Assinante);
                    }

                    var claims = await _userManager.GetClaimsAsync(user);

                    if (claims.Any(x => x.Type == ApplicationClaims.DataAssinatura))
                    {
                        await _userManager.RemoveClaimAsync(user, claims.FirstOrDefault(x => x.Type == ApplicationClaims.DataAssinatura));
                    }
                }
            }

            if (dataAssinatura.AddMonths(1).AddDays(-5) > DateTime.UtcNow)
            {
                var user = await _userManager.FindByIdAsync(assinante.UserId);

                if (user != null)
                {
                    await _emailSender.SendEmailAsync(user.Email, "Renovação de Assinatura", "Sua assinatura está prestes a vencer, renove para continuar utilizando nossos serviços.");
                }
            }
        }


    }
}
