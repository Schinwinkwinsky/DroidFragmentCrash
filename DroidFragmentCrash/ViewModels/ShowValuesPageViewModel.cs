using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using DroidFragmentCrash.Data;
using DroidFragmentCrash.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class ShowValuesPageViewModel : BaseTabViewModel
    {
        private List<Information> infoList;
        public List<Information> InfoList
        {
            get => infoList;
            set => SetProperty(ref infoList, value);
        }

        public ShowValuesPageViewModel(INavigationService navigationService,
                                       IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            Title = "Show Values";
        }

		protected override void HandleIsActiveTrue(object sender, EventArgs e)
		{
            if (!IsActive) return;


		}

		public async override void OnNavigatedTo(NavigationParameters parameters)
		{
            try
            {
                InfoList = await InformationManager.DefaultInstance.GetInformationListAsync();
            }
            catch (Exception ex)
            {
                IsBusy = false;

                if (ex.Message.Contains("Unauthorized"))
                    await _navigationService.NavigateAsync("/NavigationPage/SignInPage");
            }
        }
	}
}
