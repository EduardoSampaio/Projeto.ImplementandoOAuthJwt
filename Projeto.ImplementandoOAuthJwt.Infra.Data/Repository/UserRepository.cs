using Dapper;
using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;
using Projeto.ImplementandoOAuthJwt.Domain.Interfaces;
using Projeto.ImplementandoOAuthJwt.Infra.Data.Datasource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.ImplementandoOAuthJwt.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private DapperContext _context;

        public UserRepository()
        {
            _context = new DapperContext();
        }

        public bool Authentication(string email, string password)
        {
            return _context.DbConnection.Query<User>(
            "SELECT u.Email,u.Password FROM [Users] u WHERE Email = @Email and Password = @Password",
            param: new { email, password }
            ).Any();
        }

        public void Delete(Guid id)
        {
            _context.DbConnection.Execute("DELETE FROM [Users] WHERE Id = @Id", param: new { id });
        }

        public IList<User> GetAll(int skip = 0, int take = 50)
        {
            return _context.DbConnection.Query<User>(
                "SELECT u.id, u.UserName,u.Email FROM [Users] u order by UserName OFFSET @Skip ROWS FETCH NEXT @take ROWS ONLY ",
                  param: new { skip, take })
                  .ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.DbConnection.Query<User>(
               "SELECT u.UserName,u.Email FROM [Users] u WHERE Email = @Email",
               param: new { email }
           ).FirstOrDefault();
        }

        public User GetById(Guid id)
        {
            return _context.DbConnection.Query<User>(
                "SELECT u.id,u.UserName,u.Email FROM [Users] u WHERE Id = @Id",
                param: new { id }
            ).FirstOrDefault();

        }

        public void Save(User entity)
        {
            _context.DbConnection.Execute(
               "INSERT INTO [Users] (Id,UserName,Email,Password) VALUES (@Id, @UserName, @Email,@Password)",
               entity
           );
        }

        public void Update(User entity)
        {
            _context.DbConnection.Execute(
              "UPDATE User SET UserName = @UserName,Email = @Email,Password = @Password WHERE Id = @Id",
              entity
          );
        }
    }
}
