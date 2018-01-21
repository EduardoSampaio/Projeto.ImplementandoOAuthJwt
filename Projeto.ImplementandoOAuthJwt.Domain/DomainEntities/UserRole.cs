using System;

namespace Projeto.ImplementandoOAuthJwt.Domain.DomainEntities
{
    public class UserRole
    {
        public UserRole()
        {
            UserRoleId = Guid.NewGuid();
        }

        public Guid UserRoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}