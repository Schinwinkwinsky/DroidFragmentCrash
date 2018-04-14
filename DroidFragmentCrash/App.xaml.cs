using System;
using System.Collections.Generic;
using Acr.Settings;
using Acr.UserDialogs;
using DroidFragmentCrash.ViewModels;
using DroidFragmentCrash.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace DroidFragmentCrash
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null)
            : base(initializer) { }

		protected override void OnInitialized()
		{
            InitializeComponent();

            NavigationService.NavigateAsync("PrincipalTabbedPage");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AccountPage, AccountPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractPage, ContractPageViewModel>();
            containerRegistry.RegisterForNavigation<ShowValuesPage, ShowValuesPageViewModel>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<PrincipalTabbedPage>();

            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
            containerRegistry.RegisterInstance<ISettings>(Settings.Current);
		}
	}
}
