using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.ImplementandoOAuthJwt.Models
{
    public class UserRegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}