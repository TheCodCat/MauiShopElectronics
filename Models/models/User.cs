using System.ComponentModel.DataAnnotations;

namespace Models.models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string UserName { get; set; } = "Нет данных";
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
