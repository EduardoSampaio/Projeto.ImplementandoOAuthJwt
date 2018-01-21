using Projeto.ImplementandoOAuthJwt.Domain.DomainEntities;
using Projeto.ImplementandoOAuthJwt.Infra.Data.Repository;
using Projeto.ImplementandoOAuthJwt.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Projeto.ImplementandoOAuthJwt.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        [Route("users")]
        public IHttpActionResult CreateUser(UserRegisterModel model)
        {
            try
            {
                var user = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                _userRepository.Save(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("users")]
        public IHttpActionResult UpdateUser(UserUpdateModel model)
        {
            try
            {
                var user = _userRepository.GetById(model.Id);
                user.Password = model.Password;
                user.Email = model.Email;
                user.Username = model.Username;
                _userRepository.Update(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("users")]
        public IHttpActionResult DeleteUser(Guid id)
        {
            try
            {
                _userRepository.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("users")]
        public IHttpActionResult ListUser(int skip = 0, int take = 50)
        {
            var listModel = _userRepository.GetAll(skip, take)
                .Select(x =>
                new UserModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    Username = x.Username
                });
            return Ok(listModel);
        }

        [HttpGet]
        [Route("users/{id:Guid}")]
        public IHttpActionResult GetByUserId(Guid id)
        {
            var user = _userRepository.GetById(id);
            var model = new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username
            };

            return Ok(model);
        }

        [HttpGet]
        [Route("users/{email}/email")]
        public IHttpActionResult GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            var model = new UserModel()
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(user);
        }
    }
}