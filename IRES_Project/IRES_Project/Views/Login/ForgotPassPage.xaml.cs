using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPassPage : ContentPage
	{
		public ForgotPassPage ()
		{
			InitializeComponent ();
            btnLogin.Clicked += BtnLogin_Clicked;
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }

		private async void btnSend_Clicked(object sender, EventArgs e)
		{
			IRES_Global.GlobalInfo.BaseUrl = txbMailOrPhone.Text;
			await this.Navigation.PopModalAsync();
		}
	}
}