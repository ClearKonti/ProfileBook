using Acr.UserDialogs;
using Prism.Ioc;
using Prism.Unity;
using Profilebook.Tables;
using Profilebook.ViewModels;
using Profilebook.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace Profilebook
{
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        public static UsersRepository usersDatabase;
        public static UsersRepository UsersDatabase
        {
            get
            {
                if (usersDatabase == null)
                {
                    usersDatabase = new UsersRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "users.db"));
                }
                return usersDatabase;
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<MainList>();
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
