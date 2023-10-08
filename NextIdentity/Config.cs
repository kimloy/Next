using Duende.IdentityServer.Models;
using IdentityModel;

namespace NextIdentity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("nextRole",
                new [] { JwtClaimTypes.Role })
        };

    public static IEnumerable<ApiResource> ApiResources =>
       new ApiResource[]
       {
            new ApiResource("nextapi")
            {
                Scopes = { "nextapi_fullaccess"},
            }
       };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("nextapi_fullaccess")
            {
                UserClaims = new[] { JwtClaimTypes.Email, JwtClaimTypes.Role }
            },
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "scope1" }
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "next",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = new []{ "https://localhost:7247/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7247/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7247/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "nextRole", "nextapi_fullaccess" }
            },
        };
}
