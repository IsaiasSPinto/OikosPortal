using Coravel.Mailer.Mail;
using Microsoft.AspNetCore.Identity;

namespace OikosPortal;

public class CreatedAccountMailable : Mailable<IdentityUser>
{

    private IdentityUser _user;

    public CreatedAccountMailable(IdentityUser user)
    {
        this._user = user;
    }

    public override void Build()
    {
        To(this._user.Email)
            .From(new MailRecipient("isaiascxs10@gmail.com", "Oikos Portal"))
            .Subject("Welcome to Oikos Portal!")
            .View("~/Views/Mail/CreatedAccount.cshtml", this._user);
    }

}
