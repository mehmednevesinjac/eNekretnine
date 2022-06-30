using Microsoft.AspNetCore.Authentication;


namespace IdentityServer.Controllers
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
    }
}
