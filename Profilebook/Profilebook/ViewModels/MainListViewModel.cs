using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Profilebook.ViewModels
{
    public class MainListViewModel : BindableBase
    {
        #region --- NavigationService --- 

        INavigationService _navigationService;


        public MainListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion

         Command _exitToolBarCommand = new Command(ExitToolBarItem);
        Command _settingsToolBarCommand = new Command(SettingsToolBarItem);
        public Command ExitToolBarCommand
        {
            get { return _exitToolBarCommand; }
            protected set { _exitToolBarCommand = value; }
        }

        public Command SettingsToolBarCommand
        {
            get { return _settingsToolBarCommand; }
            protected set { _settingsToolBarCommand = value; }
        }

        static void ExitToolBarItem(object obj)
        {
            Acr.UserDialogs.UserDialogs.Instance.Alert("Exit");
        }

        static void SettingsToolBarItem(object obj)
        {
            Acr.UserDialogs.UserDialogs.Instance.Alert("Settings");
        }



    }
}
