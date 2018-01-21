using Projeto.ImplementandoOAuthJwt.Infra.Data.Repository;
using System;
using System.Web.Http;
using System.Web.Http.Description;

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
        public IHttpActionResult CreateRole()
        {
            try
            {
                //_roleRepository.Save();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("roles")]    
        public IHttpActionResult UpdateRole()
        {
            try
            {

                //_roleRepository.Update(roleCommand);
                return Ok();
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
                //_roleAppService.Delete(id);
                return Ok();
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
            return Ok(_roleRepository.GetAll(skip, take));
        }

        [HttpGet]
        [Route("roles/{id:Guid}")]
        public IHttpActionResult GetByRoleId(Guid id)
        {
            return Ok(_roleRepository.GetById(id));
        }
    }
}
