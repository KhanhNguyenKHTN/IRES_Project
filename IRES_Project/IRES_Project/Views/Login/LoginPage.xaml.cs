using IRES_Project.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        LoginViewModel viewmodel = new LoginViewModel();
		public LoginPage ()
		{
			InitializeComponent ();
            
            btnSignUp.Clicked += BtnSignUp_Clicked;
            btnForgotPass.Clicked += BtnForgotPass_Clicked;
            btnLogin.Clicked += BtnLogin_Clicked;
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var res = await viewmodel.Login(txbUserName.Text, txbPass.Text);
            if (res)
            {
                await Navigation.PushModalAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Thông báo", "Username hoặc password không đúng!", "Ok");
            }
            
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