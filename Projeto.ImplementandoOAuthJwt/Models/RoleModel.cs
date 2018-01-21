using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.ImplementandoOAuthJwt.Models
{
    public class RoleRegisterModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }

    public class RoleModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
