using System;

namespace Projeto.ImplementandoOAuthJwt.Domain.DomainEntities
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Users { get; set; }
    }
}