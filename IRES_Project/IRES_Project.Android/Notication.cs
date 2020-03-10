using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IRES_Project.Droid
{
    public class Notication : IRES_Project.Interfaces.IAudioNoti
    {
        public void NotifiMessage()
        {
            GlobalAndroidClass.Player.Start();
            Toast.MakeText(Xamarin.Forms.Forms.Context, "Đơn hàng của bạn đã thanh toán thành công!", ToastLength.Short).Show();
        }
    }
}