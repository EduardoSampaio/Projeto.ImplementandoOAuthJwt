using System;
using System.Collections.Generic;

namespace Projeto.ImplementandoOAuthJwt.Domain.DomainEntities
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
