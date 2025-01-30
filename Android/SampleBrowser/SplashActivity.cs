using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SampleBrowser
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, Icon = "@drawable/icon",
        ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(100);
            StartActivity(typeof(MainActivity));
        }
    }
}