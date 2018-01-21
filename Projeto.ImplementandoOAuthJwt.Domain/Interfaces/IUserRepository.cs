using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;

namespace Projeto.ImplementandoOAuthJwt.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);

        bool Authentication(string email, string password);
    }
}