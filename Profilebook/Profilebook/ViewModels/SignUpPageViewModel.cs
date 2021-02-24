using Prism.Mvvm;
using Prism.Navigation;
using Profilebook.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Profilebook.ViewModels
{
    public class SignUpPageViewModel : BindableBase
    {

        #region --- Fields ---

        private string _signUpLogin;
        public string SignUpLogin
        {
            get => _signUpLogin;
            set => SetProperty(ref _signUpLogin, value);
        }

        private string _signUpPassword;
        public string SignUpPassword
        {
            get => _signUpPassword;
            set => SetProperty(ref _signUpPassword, value);
        }

        private string _signUpPasswordConfirm;
        public string SignUpPasswordConfirm
        {
            get => _signUpPasswordConfirm;
            set => SetProperty(ref _signUpPasswordConfirm, value);
        }

        #endregion

        #region --- NavigationService --- 

        INavigationService _navigationService;
        public SignUpPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        public ICommand SignUpProcessCommand => new Command(SignUpProcess);
        async void SignUpProcess()
        {
            var IsUsernameTaken = App.UsersDatabase.UsernameCheck(SignUpLogin);
            if (IsUsernameTaken)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("This username is already taken");
            }

            else
            {
                if (SignUpPassword == SignUpPasswordConfirm)
                {
                    var newUser = new User()
                    {
                        Username = SignUpLogin,
                        Password = SignUpPassword,
                        ConfirmPassword = SignUpPasswordConfirm
                    };

                    App.UsersDatabase.SaveItem(newUser);

                    Acr.UserDialogs.UserDialogs.Instance.Alert("Registration successful");

                    await _navigationService.NavigateAsync("SignInPage");
                }

                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Password doesn't match the congirmation");
                }
            }
            
        }
    }
}
