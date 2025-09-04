using Models.DTO;
using Models.models;

namespace WebApi.Repositories
{
    public interface IAuthorizationRepository
    {
        public Task<User> GetUser(AuthDTO authDTO);
        public Task<bool> CreateUser(AuthDTO authDTO);
        public Task<User> EditUser(User user);
        public Task<LocalAdressDTO> EditLocalAdress(LocalAdressDTO localAdressDTO);
    }
}
