using MauiShopElectronics.Models.models;
using MauiShopElectronics.Reactive;

namespace MauiShopElectronics.Services
{
    public class UserController
    {
        public ReactiveProperty<User> User { get; set; } = new ReactiveProperty<User>();
    }
}
