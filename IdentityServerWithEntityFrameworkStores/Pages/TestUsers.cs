// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

using Duende.IdentityServer;
using Duende.IdentityServer.Test;

using IdentityModel;

namespace IdentityServerWithEntityFrameworkStores
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Kenyatta Road, Ruiru",
                    locality = "Nairobi",
                    postal_code = 01000,
                    country = "Kenya"
                };

                return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "kelsey",
                    Password = "kelsey",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Kelsey Githithu"),
                        new Claim(JwtClaimTypes.GivenName, "Kelsey"),
                        new Claim(JwtClaimTypes.FamilyName, "Githithu"),
                        new Claim(JwtClaimTypes.Email, "KelseyGithithu@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://kelsey.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "daniel",
                    Password = "daniel",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Daniel Githithu"),
                        new Claim(JwtClaimTypes.GivenName, "Daniel"),
                        new Claim(JwtClaimTypes.FamilyName, "Githithu"),
                        new Claim(JwtClaimTypes.Email, "DanielGithithu@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://daniel.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };
            }
        }
    }
}