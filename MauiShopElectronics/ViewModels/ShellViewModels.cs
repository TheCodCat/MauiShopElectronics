using CommunityToolkit.Mvvm.ComponentModel;
using MauiShopElectronics.Services;

namespace MauiShopElectronics.ViewModels
{
    public partial class ShellViewModels : ObservableObject
    {
        private readonly UserController userController;
        public ShellViewModels(UserController userController)
        {
            this.userController = userController;
        }
    }
}
