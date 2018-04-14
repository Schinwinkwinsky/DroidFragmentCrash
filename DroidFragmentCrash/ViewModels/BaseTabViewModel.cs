using System;
using Acr.UserDialogs;
using Prism;
using Prism.Navigation;

namespace DroidFragmentCrash.ViewModels
{
    public class BaseTabViewModel : BaseViewModel, IActiveAware
    {
        private bool isActive;
        public bool IsActive 
        { 
            get => isActive;
            set => SetProperty(ref isActive, value, RaiseIsActiveChanged);
        }

        public event EventHandler IsActiveChanged;

        public BaseTabViewModel(INavigationService navigationService,
                               IUserDialogs userDialogs) 
            : base(navigationService, userDialogs)
        {
            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;
        }

        protected virtual void HandleIsActiveTrue(object sender, EventArgs e) { }

        protected virtual void HandleIsActiveFalse(object sender, EventArgs e) { }

        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public override void Destroy()
        {
            base.Destroy();

            IsActiveChanged -= HandleIsActiveTrue;
            IsActiveChanged -= HandleIsActiveFalse;
        }
    }
}
