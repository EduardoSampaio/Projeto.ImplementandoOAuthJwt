using Projeto.ImplementandoOAuthJwt.Authorization;
using Projeto.ImplementandoOAuthJwt.Models;
using System.Web.Http;

namespace Projeto.ImplementandoOAuthJwt.Controllers
{
    public class AudiencesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(AudienceModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAudience = AudiencesStore.AddAudience(audienceModel.ApplicationName);

            return Ok(newAudience);
        }
    }
}