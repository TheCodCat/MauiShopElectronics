using MauiShopElectronics.Services;
using MauiShopElectronics.ViewModels;

namespace MauiShopElectronics
{
    public partial class AppShell : Shell
    {
        public AppShell(UserController userController)
        {
            InitializeComponent();
            BindingContext = new ShellViewModels(userController);
        }
	}
}
