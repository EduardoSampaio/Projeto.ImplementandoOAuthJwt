using Dapper;
using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;
using Projeto.ImplementandoOAuthJwt.Domain.Interfaces;
using Projeto.ImplementandoOAuthJwt.Infra.Data.Datasource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.ImplementandoOAuthJwt.Infra.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private DapperContext _context;

        public RoleRepository()
        {
            _context = new DapperContext();
        }

        public void Delete(Guid id)
        {
            _context.DbConnection.Execute("DELETE FROM [Roles] WHERE Id = @Id", param: new { id });
        }

        public IList<Role> GetAll(int skip = 0, int take = 50)
        {
            return _context.DbConnection.Query<Role>(
               "SELECT r.id,r.name FROM [Roles] r order by name OFFSET @Skip ROWS FETCH NEXT @take ROWS ONLY ",
                 param: new { skip, take })
                 .ToList();
        }

        public Role GetById(Guid id)
        {
            return _context.DbConnection.Query<Role>(
               "SELECT r.id,r.name FROM [Roles] r  WHERE id = @id",
               param: new { id }
           ).FirstOrDefault();
        }

        public void Save(Role entity)
        {
            _context.DbConnection.Execute(
             "INSERT INTO [Roles] (Id,Name) VALUES (@Id,@Name)",
             entity
         );
        }

        public void Update(Role entity)
        {
            _context.DbConnection.Execute(
             "UPDATE Roles SET Name = @Name WHERE Id = @Id",
             entity);
        }
    }
}