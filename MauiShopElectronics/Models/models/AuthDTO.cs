namespace MauiShopElectronics.Models.models
{
    public class AuthDTO
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public AuthDTO(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
