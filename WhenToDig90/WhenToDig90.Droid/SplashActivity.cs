
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace WhenToDig90.Droid
{
    [Activity(Label ="WhenToDig",
        MainLauncher = true,
        NoHistory = true, 
        Theme ="@style/Theme.Splash", 
        ConfigurationChanges =ConfigChanges.ScreenSize|ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //System.Threading.Sleep(3000);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}