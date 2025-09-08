using MauiShopElectronics.Models.models;
using MauiShopElectronics.Reactive;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MauiShopElectronics.Services
{
    public class UserController : IDisposable
    {
        public ReactiveProperty<User> User { get; set; } = new ReactiveProperty<User>();

        public UserController()
        {
            User.OnChanged += User_OnChanged;
        }


        public void Dispose()
        {
            User.OnChanged -= User_OnChanged;
        }

        private async void User_OnChanged(User arg1, User arg2)
        {
            string json = JsonConvert.SerializeObject(arg2);

            await SecureStorage.Default.SetAsync("user", json);
        }

        public async Task<User> GetUser()
        {
            string json = await SecureStorage.Default.GetAsync("user") ?? string.Empty;

            User user = JsonConvert.DeserializeObject<User>(json);
            User.Value = user;
            return User.Value;
        }

        public async Task SetUser(User user)
        {
            User.Value = user;
        }
    }
}
