using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;
using Projeto.ImplementandoOAuthJwt.Infra.Data.Repository;
using Projeto.ImplementandoOAuthJwt.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Projeto.ImplementandoOAuthJwt.Controllers
{
    [RoutePrefix("api/v1")]
    public class RolesController : ApiController
    {
        private readonly RoleRepository _roleRepository;

        public RolesController()
        {
            _roleRepository = new RoleRepository();
        }

        [HttpPost]
        [Route("roles")]
        public IHttpActionResult CreateRole(RoleModel model)
        {
            try
            {
                var roles = new Role() { Name = model.Name };
                _roleRepository.Save(roles);
                return Ok(roles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("roles")]
        public IHttpActionResult UpdateRole(RoleModel model)
        {
            try
            {
                var roles = _roleRepository.GetById(model.Id);
                roles.Name = model.Name;
                _roleRepository.Update(roles);
                return Ok(roles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("roles")]
        public IHttpActionResult DeleteRole(Guid id)
        {
            try
            {
                _roleRepository.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("roles")]
        public IHttpActionResult ListURoles(int skip = 0, int take = 50)
        {
            var list = _roleRepository.GetAll(skip, take).Select(x => new RoleModel() { Id = x.Id, Name = x.Name });
            return Ok(list);
        }

        [HttpGet]
        [Route("roles/{id:Guid}")]
        public IHttpActionResult GetByRoleId(Guid id)
        {
            var role = _roleRepository.GetById(id);
            var model = new RoleModel() { Id = role.Id, Name = role.Name };
            return Ok(model);
        }
    }
}