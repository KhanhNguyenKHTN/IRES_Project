using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using IRES_Project.Interfaces;

namespace IRES_Project.Droid
{
    [Activity(Label = "IRES_Project", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            GlobalAndroidClass.Player = new Android.Media.MediaPlayer();// Android.Media.MediaPlayer.Create(this, Assets.);
            var file = Assets.OpenFd("bell.mp3");
            GlobalAndroidClass.Player.SetDataSource(file.FileDescriptor, file.StartOffset, file.Length);
            GlobalAndroidClass.Player.Prepare();

            DependencyService.Register<IAudioNoti, Notication>();
            IRES_Global.GlobalInfo.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            IRES_Global.GlobalInfo.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
        }

    }
}