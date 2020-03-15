using IRES_Project.Controls.Pages;
using Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel;
using ViewModel.ViewModel.FoodMenu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.CartPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentView
	{
        FoodMenuViewModel Serviceviewmodel;
        PaymentModel viewmodel;
        public PaymentPage(int total, int method)
		{
			InitializeComponent();
            Serviceviewmodel = new FoodMenuViewModel();
            viewmodel = new PaymentModel()
            {
                Total = total,
                Type = (method == 0 ? "Momo" : "Tiền mặt")
            };
            txbKM.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeCharacter);
            txbTip.Keyboard = Keyboard.Numeric;
            BindingContext = viewmodel;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            gridWaiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += async (s, z) =>
            {
                var res = await Serviceviewmodel.Payment(viewmodel);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (res)
                    {
                        await MultiContentPages.Instance.DisplayAlert("Thông báo!", "Yêu cầu thanh toán được gửi đi. Vui lòng ra quầy để thực hiên bức còn lại", "OK");
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await MultiContentPages.Instance.DisplayAlert("Thông báo", "Không thành công!", "Ok");
                    }
                    gridWaiting.IsVisible = false;
                });

            };
            wk.RunWorkerAsync();
        }

        private void TxbKM_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txbKM.Text == "KM001")
            {
                viewmodel.KM = 35000;
            } else if (txbKM.Text == "KM002")
            {
                viewmodel.KM = 50000;
            }
            else
            {
                viewmodel.KM = 0;
            }
        }

        private void TxbTip_TextChanged(object sender, TextChangedEventArgs e)
        {
            int t = 0;
            int.TryParse(txbTip.Text, out t);
            viewmodel.Tip = t;
        }
    }
}