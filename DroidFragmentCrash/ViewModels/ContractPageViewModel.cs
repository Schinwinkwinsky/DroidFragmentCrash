using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class ContractPageViewModel : BaseViewModel
    {
        public DelegateCommand AcceptContractCommand { get; set; }

        public ContractPageViewModel(INavigationService navigationService,
                                     IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Contract";

            AcceptContractCommand = new DelegateCommand(async () => await AcceptContract());
        }

        public async Task AcceptContract()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("Contract", true);

            await _navigationService.GoBackAsync(navigationParams);
        }
    }
}
