using Coravel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using OikosPortal.Infra;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();

    builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = builder.Configuration["GoogleAuth:ClientId"];
            googleOptions.ClientSecret = builder.Configuration["GoogleAuth:ClientSecret"];

        });

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


    builder.Services.AddDefaultIdentity<IdentityUser>(opt =>
    {
        opt.SignIn.RequireConfirmedEmail = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddMailer(builder.Configuration);

    builder.Services.AddTransient<IEmailSender, EmailSender>();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

