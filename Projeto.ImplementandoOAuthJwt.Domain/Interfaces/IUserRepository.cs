using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.ImplementandoOAuthJwt.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);

        bool Authentication(string email, string password);

    }
}
