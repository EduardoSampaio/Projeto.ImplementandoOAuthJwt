using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.ImplementandoOAuthJwt.Models
{
    public class AudienceModel
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public string ApplicationName { get; set; }
    }
}