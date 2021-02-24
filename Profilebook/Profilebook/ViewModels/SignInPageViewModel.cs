using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using Profilebook.Tables;

namespace Profilebook.ViewModels
{
    public class SignInPageViewModel : BindableBase
    {

        #region --- Fields ---

        private string _signInLogin;
        public string SignInLogin
        {
            get => _signInLogin;
            set => SetProperty(ref _signInLogin, value);
        }

        private string _signInPassword;
        public string SignInPassword
        {
            get => _signInPassword;
            set => SetProperty(ref _signInPassword, value);
        }

        #endregion

        #region --- NavigationService --- 

        INavigationService _navigationService;
        public SignInPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        
        public ICommand SignUpHyperlinkCommand => new Command(SignUpHyperlink);
        public ICommand SignInButtonCommand => new Command(SignInButton);

        async void SignUpHyperlink()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }

        async void SignInButton()
        {

            var IsUsernameTaken = App.UsersDatabase.UsernameCheck(SignInLogin);

            if (!IsUsernameTaken)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("This user doesn't exist");
            }

            else
            {
                var IsUserAuthorised = App.UsersDatabase.ValidateUser(SignInLogin, SignInPassword);

                if (IsUserAuthorised)
                {
                    await _navigationService.NavigateAsync("MainList");
                }

                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Invalid password");
                }
            }
        }
    }
}
