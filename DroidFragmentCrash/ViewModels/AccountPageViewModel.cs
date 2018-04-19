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
        private readonly IAccountManager _accountManager;

        public DelegateCommand SignOutCommand { get; set; }

        public AccountPageViewModel(IAccountManager accountManager,
                                    INavigationService navigationService,
                                    IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            _accountManager = accountManager;

            Title = "Account";

            SignOutCommand = new DelegateCommand(async () => await SignOut());
        }

        private async Task SignOut()
        {
            IsBusy = true;

            _accountManager.SignOut();

            IsBusy = false;

            await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
        }
    }
}
