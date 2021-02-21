using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace Profilebook.ViewModels
{
    public class SignInPageViewModel : BindableBase
    {
        INavigationService _navigationService;
        public SignInPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand SignUpHyperlinkCommand => new Command(SignUpHyperlink);
        async void SignUpHyperlink()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }

    }
}
