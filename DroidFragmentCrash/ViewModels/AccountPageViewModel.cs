using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DroidFragmentCrash.Data;
using Prism.Commands;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class AccountPageViewModel : BaseTabViewModel
    {
        public DelegateCommand SignOutCommand { get; set; }

        public AccountPageViewModel(INavigationService navigationService,
                                       IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Account";

            SignOutCommand = new DelegateCommand(async () => await SignOut());
        }

        private async Task SignOut()
        {
            IsBusy = true;

            AccountManager.DefaultInstance.SignOut();

            IsBusy = false;

            await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
        }
    }
}
