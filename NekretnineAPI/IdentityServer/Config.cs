using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string>{"role"}
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
       new[] { new ApiScope("NekretnineAPI.read"), new ApiScope("NekretnineAPI.write") };

    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("NekretnineAPI")
            {
                Scopes = new List<string>{ "NekretnineAPI.read", "NekretnineAPI.write"},
                ApiSecrets = new List<Secret>{ new Secret("ScopeSecret".Sha256()) },
                UserClaims = new List<string>{"role"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("ClientSecret1".Sha256())},
                AllowedScopes = {"NekretnineAPI.read","NekretnineAPI.write"}
            },

            new Client
            {
                ClientId = "interactive",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("ClientSecret1".Sha256())},
                AllowedScopes = {"NekretnineAPI.read","openid","profile"},
                RedirectUris = {"https://localhost:5001/signin-oidc"},
                FrontChannelLogoutUri =  "https://localhost:5001/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },
                AllowOfflineAccess = true,
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false,
                AllowAccessTokensViaBrowser = true,
            },
            new Client
            {
                ClientId = "angular",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "https://localhost:4200" },
                    PostLogoutRedirectUris = { "https://localhost:4200" },
                    AllowedCorsOrigins = { "https://localhost:4200" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "NekretnineAPI.read","NekretnineAPI.write"
                    },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
            }
        };


}
