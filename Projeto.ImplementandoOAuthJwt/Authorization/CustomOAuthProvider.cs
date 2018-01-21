using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Projeto.ImplementandoOAuthJwt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.ImplementandoOAuthJwt.Authorization
{
    internal class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private string[] roles = new string[] { "user", "admin" }; // roles mocks
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
           
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("Username", context.Identity.Name);
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (context.UserName != context.Password)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return Task.FromResult<object>(null);
            }

            var identity = AddIdentity(context.UserName, roles);
            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", context.ClientId ??string.Empty                     }
                });
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }

        private ClaimsIdentity AddIdentity(string userName, string[] roles)
        {
            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("sub", userName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //identity.AddClaim(new Claim("uid", user.UserId.ToString()));
            //identity.AddClaim(new Claim("umail", user.Email));
            //identity.AddClaim(new Claim("cid", clientId.ToString()));
            //identity.AddClaim(new Claim("ctype", ((int)client.Type).ToString()));
            //identity.AddClaim(new Claim("ufnm", user.FirstName));
            //identity.AddClaim(new Claim("ulnm", user.LastName));
            //identity.AddClaim(new Claim("uacd", user.AreaCode));
            //identity.AddClaim(new Claim("uph", user.Phone));
            //identity.AddClaim(new Claim("ucdt", user.CreateDate.ToString()));
            GenericPrincipal principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;
            return identity;
        }
    }
}