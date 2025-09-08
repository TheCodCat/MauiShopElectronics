using Models.DTO;
using Models.models;
using System.Security.Cryptography;
using System.Text;
using WebApi.Repositories.Interface;
using WebApiDatabase;

namespace WebApi.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly ApiDatabaseContext apiDatabaseContext;

        public AuthorizationRepository(ApiDatabaseContext apiDatabaseContext)
        {
            this.apiDatabaseContext = apiDatabaseContext;
        }

        public async Task<bool> CreateUser(AuthDTO authDTO)
        {
            if(apiDatabaseContext.Users.Contains(apiDatabaseContext.Users.FirstOrDefault(x => x.Login == authDTO.Login)))
            {
                return false;
            }

            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(authDTO.Password);
            string hash = Convert.ToHexString(sha256.ComputeHash(bytes));

            User newUser = new User(authDTO.Login, hash);

            await apiDatabaseContext.Users.AddAsync(newUser);
            apiDatabaseContext.SaveChanges();
            return true;
        }

        public async Task<User?> GetUser(AuthDTO authDTO)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(authDTO.Password);
            string hash = Convert.ToHexString(sha256.ComputeHash(bytes));

            if (!apiDatabaseContext.Users.Contains(apiDatabaseContext.Users.FirstOrDefault(x => x.Login == authDTO.Login && x.Password == hash)))
            {
                return null;
            }

            var user = apiDatabaseContext.Users.FirstOrDefault(x => x.Login == authDTO.Login && x.Password == hash);
            return user;
        }

        public async Task<User> EditUser(User user)
        {
            var currentUser = apiDatabaseContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (currentUser == null) return user;

            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.UserName = user.UserName;
            apiDatabaseContext.SaveChanges();
            return currentUser;
        }

        public async Task<LocalAdressDTO> EditLocalAdress(LocalAdressDTO localAdressDTO)
        {
            var user = apiDatabaseContext.Users.FirstOrDefault(x => x.Id == localAdressDTO.UserId);
            if (user != null)
            {
                user.LocalAdress = localAdressDTO.NewLocalAdress;
                apiDatabaseContext.SaveChanges();
                return localAdressDTO;
            }
            else
                return new LocalAdressDTO();
        }
    }
}
