using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;

namespace NekretnineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public async Task<string> GetToken()
        {
            var client = new HttpClient();
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5001/connect/token",
                ClientId = "interactive",
                ClientSecret = "ClientSecret1",
                Scope = "NekretnineAPI.read"
            });
            return response.AccessToken;    
        }

    }
}
