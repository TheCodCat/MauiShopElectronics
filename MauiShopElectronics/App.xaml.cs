using MauiShopElectronics.Services;

namespace MauiShopElectronics
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var usercontroller = serviceProvider.GetService<UserController>();
            usercontroller.SetUser(usercontroller.GetUser().GetAwaiter().GetResult());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}