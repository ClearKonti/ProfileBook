using Prism.Ioc;
using Prism.Unity;
using Profilebook.ViewModels;
using Profilebook.Views;
using Xamarin.Forms;

namespace Profilebook
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("SignInPage");
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
