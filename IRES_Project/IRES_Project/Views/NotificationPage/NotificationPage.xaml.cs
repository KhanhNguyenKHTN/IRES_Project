using Model.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.NotificationPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotificationPage : ContentView
	{
		public NotificationPage ()
		{
			InitializeComponent ();
            lvThongBao.ItemsSource = IRES_Global.GlobalInfo.ListNotis;
            //    new List<NotificationModel>() {
            //    new NotificationModel(){ Lable= "Message from M_BackPacker", Description = "Hãy tham gia chương trình khuyến mãi của chúng tôi nhé!"},
            //    new NotificationModel(){Lable= "Đặt xe của bạn", Description = "Đơn của bạn đang đước duyệt!"},
            //    new NotificationModel(){Lable= "Bảo Mật", Description = "Thiết lập mật khẩu và mã pin để bảo vệ tài khoản của bạn nha!"},
            //    new NotificationModel(){Lable= "Message from M_BackPacker", Description = "Tặng bạn gói khuyến mãi hấp dẫn"},
            //    new NotificationModel(){Lable= "Đăng ký hợp tác", Description = "Đơn đăng ký của bạn đã được duyệt!"},
            //    new NotificationModel(){Lable= "Đăng ký hợp tác", Description = "Đã gửi đơn đăng ký!"},
            //    new NotificationModel(){Lable= "Đăng ký tài khoản", Description = "Bạn đã đăng ký tài khoản thành công!"},
            //};
        }
	}
}