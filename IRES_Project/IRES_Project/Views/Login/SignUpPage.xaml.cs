using Model.Models.Order;
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
	public partial class SignUpPage : ContentPage
	{
        LoginViewModel viewModel = new LoginViewModel();
		public SignUpPage ()
		{
			InitializeComponent ();
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegister.Clicked += BtnSignUp_Clicked;
		}

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            int temp = 0;
            if (txbEmail.Text == null || txbEmail.Text.Contains("@"))
            {
                await DisplayAlert("Thông báo", "Email không đúng!", "OK");
                return;
            } else if(txbphone.Text == null || int.TryParse(txbphone.Text, out temp) == false)
            {
                await DisplayAlert("Thông báo", "Số điện thoạt không đúng!", "OK");
                return;
            }
            else if (string.IsNullOrEmpty(txbName.Text) || string.IsNullOrEmpty(txbEmail.Text) || string.IsNullOrEmpty(txbphone.Text) || string.IsNullOrEmpty(txbPassWord.Text) || string.IsNullOrEmpty(txbConfirmPassword.Text))
            {
                await DisplayAlert("Thông báo", "Vui lòng điền dầy đủ thông tin!", "OK");
                return;
            }
            else if (txbPassWord.Text != txbConfirmPassword.Text)
            {
                await DisplayAlert("Thông báo", "Password nhập lại không khớp!", "OK");
                return;
            }
            Customer cus = new Customer()
            {
                password = txbPassWord.Text,
                userInfo = new UserInfo()
                {
                    email = txbEmail.Text,
                    displayName = txbName.Text,
                    phone = txbphone.Text
                }
            };
            gridWaiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += async (s, z) =>
            {
                await viewModel.SignUp(cus);
            };

            wk.RunWorkerCompleted += (s, z) =>
            {
                gridWaiting.IsVisible = false;
                BtnLogin_Clicked(sender, e);
            };
            wk.RunWorkerAsync();
            
        }
    }
}