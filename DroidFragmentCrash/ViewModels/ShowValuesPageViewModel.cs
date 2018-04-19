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

        private readonly DataManager<Information> _informationManager;

        public ShowValuesPageViewModel(INavigationService navigationService,
                                       IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            _informationManager = new DataManager<Information>("informations");

            Title = "Show Values";
        }

		public async override void OnNavigatedTo(NavigationParameters parameters)
		{
            try
            {
                InfoList = await _informationManager.GetAllAsync();
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
