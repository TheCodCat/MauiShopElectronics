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
        public async Task<bool> Registration([FromBody] AuthDTO authDTO)
        {
            var result = await authorizationRepository.CreateUser(authDTO);

            return result;
        }

        [HttpPost("/authorization")]
        public async Task<User> Authorization([FromBody] AuthDTO authDTO)
        {
            var result = await authorizationRepository.GetUser(authDTO);

            return result;
        }
    }
}
