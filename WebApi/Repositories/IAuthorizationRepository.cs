using Models.DTO;
using Models.models;

namespace WebApi.Repositories
{
    public interface IAuthorizationRepository
    {
        public Task<User> GetUser(AuthDTO authDTO);
        public Task<bool> CreateUser(AuthDTO authDTO);
    }
}
