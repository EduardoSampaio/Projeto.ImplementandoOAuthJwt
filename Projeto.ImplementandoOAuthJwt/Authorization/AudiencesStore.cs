using Microsoft.Owin.Security.DataHandler.Encoder;
using Projeto.ImplementandoOAuthJwt.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Projeto.ImplementandoOAuthJwt.Authorization
{
    public static class AudiencesStore
    {
        public static ConcurrentDictionary<string, AudienceModel> AudiencesList = new ConcurrentDictionary<string, AudienceModel>();

        static AudiencesStore()
        {
            AudiencesList.TryAdd("099153c2625149bc8ecb3e85e03f0022",
                                new AudienceModel
                                {
                                    ClientId = "099153c2625149bc8ecb3e85e03f0022",
                                    SecretKey = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                                    ApplicationName = "ResourceServer.Api 1"
                                });
        }

        public static AudienceModel AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            AudienceModel newAudience = new AudienceModel { ClientId = clientId, SecretKey = base64Secret, ApplicationName = name };
            AudiencesList.TryAdd(clientId, newAudience);
            return newAudience;
        }

        public static AudienceModel FindAudience(string clientId)
        {
            AudienceModel audience = null;
            if (AudiencesList.TryGetValue(clientId, out audience))
            {
                return audience;
            }
            return null;
        }
    }
}