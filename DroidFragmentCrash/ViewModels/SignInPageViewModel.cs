using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DroidFragmentCrash.Data;
using Prism.Commands;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        public DelegateCommand SignUpCommand { get; set; }

        public SignInPageViewModel(INavigationService navigationService,
                                   IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Sign In";

            SignUpCommand = new DelegateCommand(async () => await GoToSignUpPage());
        }

        private async Task GoToSignUpPage()
        {
            await _navigationService.NavigateAsync("SignUpPage");
        }
    }
}
