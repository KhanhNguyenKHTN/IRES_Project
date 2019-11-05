using IRES_Project.Views.Home;
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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            btnSignUp.Clicked += BtnSignUp_Clicked;
            btnForgotPass.Clicked += BtnForgotPass_Clicked;
            btnLogin.Clicked += BtnLogin_Clicked;
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void BtnForgotPass_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushModalAsync(new ForgotPassPage());
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
           await this.Navigation.PushModalAsync(new SignUpPage());
        }
    }
}