using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Prism;
using Prism.Ioc;
using Android.Content.PM;
using Acr.UserDialogs;

namespace DroidFragmentCrash.Droid
{
    [Activity(Label = "Droid Frag Crash", MainLauncher = true, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);

            UserDialogs.Init(this);

            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    internal class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}

