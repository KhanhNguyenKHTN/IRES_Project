using IRES_Project.Views.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            gridWaiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += async (s, z) =>
            {
                var res = await viewmodel.Login(txbUserName.Text, txbPass.Text);
                Device.BeginInvokeOnMainThread( async() =>
                {
                    if (res)
                    {

                        await Navigation.PushModalAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Thông báo", "Username hoặc password không đúng!", "Ok");
                    }
                    gridWaiting.IsVisible = false;
                });
                
            };
            wk.RunWorkerAsync();

            
            
        }

        private async void BtnForgotPass_Clicked(object sender, EventArgs e)
        {
            gridWaiting.IsVisible = true;
            await this.Navigation.PushModalAsync(new ForgotPassPage());
            gridWaiting.IsVisible = false;
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            gridWaiting.IsVisible = true;
            await this.Navigation.PushModalAsync(new SignUpPage());
            gridWaiting.IsVisible = false;
        }
    }
}