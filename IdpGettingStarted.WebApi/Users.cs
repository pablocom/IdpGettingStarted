using IdentityModel;
using System.Security.Claims;
using IdentityServer4.Test;

namespace IdentityServer.WebApi;

internal static class Users
{
    public static List<TestUser> Get()
    {
        return new List<TestUser> 
        {
            new TestUser 
            {
                SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                Username = "scott",
                Password = "password",
                Claims = new List<Claim> 
                {
                    new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                    new Claim(JwtClaimTypes.Role, "admin")
                }
            }
        };
    }
}