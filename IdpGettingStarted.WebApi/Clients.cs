using IdentityServer4;
using IdentityServer4.Models;

internal static class Clients
{
    public static IEnumerable<Client> Get()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "oauthClient",
                ClientName = "Example client application using client credentials",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                AllowedScopes = new List<string> {"api1.read"}
            },
            new Client
            {
                ClientId = "oidcClient",
                ClientName = "Example Client Application",
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string> {"https://localhost:7273/signin-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "api1.read"
                },
                RequirePkce = true,
                AllowPlainTextPkce = false
            }
        };
    }
}
