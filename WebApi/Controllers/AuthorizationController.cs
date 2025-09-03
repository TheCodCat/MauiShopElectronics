using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationRepository authorizationRepository;

        public AuthorizationController(IAuthorizationRepository authorizationRepository)
        {
            this.authorizationRepository = authorizationRepository;
        }

        [HttpPost("/registration")]
        public async Task<ActionResult> Registration([FromBody] AuthDTO authDTO)
        {
            var result = await authorizationRepository.CreateUser(authDTO);

            return result ? Ok(result) : BadRequest(result);
        }

        [HttpPost("/authorization")]
        public async Task<ActionResult> Authorization([FromBody] AuthDTO authDTO)
        {
            var result = await authorizationRepository.GetUser(authDTO);

            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost("/editProfile")]
        public async Task<ActionResult> EditProfile([FromBody] User user)
        {
            var result = await authorizationRepository.EditUser(user);

            return Ok(result);
        }
    }
}
