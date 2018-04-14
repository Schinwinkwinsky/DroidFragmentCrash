using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using DroidFragmentCrash.Data;
using Prism.Commands;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private bool contractSwitch;
        public bool ContractSwitch
        {
            get => contractSwitch;
            set => SetProperty(ref contractSwitch, value);
        }

        public DelegateCommand GoToContractPageCommand { get; set; }

        public DelegateCommand SignUpCommand { get; set; }

        public SignUpPageViewModel(INavigationService navigationService,
                                   IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Sign Up";

            GoToContractPageCommand = new DelegateCommand(async () => await GoToContractPage());

            SignUpCommand = new DelegateCommand(async () => await SignUp(), CanSignUp)
                .ObservesProperty(() => ContractSwitch);
        }

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
            if (!parameters.ContainsKey("Contract"))
            {
                ContractSwitch = false;
            }
		}

		private async Task GoToContractPage()
        {
            if (ContractSwitch)
            {
                await _navigationService.NavigateAsync("ContractPage");
            }
        }

        private async Task SignUp()
        {
            IsBusy = true;

            await AccountManager.DefaultInstance.SignInAsync();

            IsBusy = false;

            await _navigationService.NavigateAsync("/PrincipalTabbedPage");
        }

        private bool CanSignUp()
        {
            return ContractSwitch;
        }
    }
}
