using IRES_Project.Controls.Pages;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.CartPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainCartPage : ContentView
	{
        ObservableCollection<CardItemModel> listItem;
        public MainCartPage ()
		{
			InitializeComponent ();
            lsFoods.ItemsSource = IRES_Global.GlobalInfo.ListOrders;
            listItem = new ObservableCollection<CardItemModel>()
            {
                new CardItemModel()
                {
                    IsSelected = true,
                    IconFont="\uecc8",
                    LabName = "Tiền mặt",
                },
                new CardItemModel()
                {
                    IsSelected = false,
                    IconFont = "\uece7",
                    LabName = "Thẻ visa",
                },
                new CardItemModel()
                {
                    IsSelected = false,
                    IconFont="\uf024",
                    LabName = "Ví Momo",
                }
            };
            paymentMethod.ItemsSource = listItem;
            LoadTotal();
		}
        bool IsOrder = false;
        public MainCartPage(bool isOrder)
        {
            InitializeComponent();
            lsFoods.ItemsSource = IRES_Global.GlobalInfo.ListOrders;
            gridDefault.IsVisible = false;
            gridOrder.IsVisible = true;
            LoadTotal();
        }

        private void LoadTotal()
        {
            int total = 0;
            foreach (var item in IRES_Global.GlobalInfo.ListOrders)
            {
                total += item.TotalQuantity;
            }
            lbTotal.Text = total.ToString("C").Remove(total.ToString("C").Length - 2, 2);
        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
                
        }

        private void BtnPay(object sender, EventArgs e)
        {
            PopUp.IsVisible = true;
        }

        private void PaymentMethod_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = listItem.Where(x => x.IsSelected == true);
            foreach (var item in list)
            {
                item.IsSelected = false;
            }

            (paymentMethod.SelectedItem as CardItemModel).IsSelected = true;
        }

        private void CancelPaymentClick(object sender, EventArgs e)
        {
            PopUp.IsVisible = false;
        }

        private async void AcceptPaymentClick(object sender, EventArgs e)
        {
            await SingleContentPage.Instance.DisplayAlert("Thông báo!", "Yêu cầu thanh toán được gửi đi. Vui lòng đợi nhân viên xác nhận", "OK");
            await Navigation.PopModalAsync();
        }

        private void OkOrderClicked(object sender, EventArgs e)
        {
            MultiContentPages.Instance.DisplayPage(0);
        }
    }
}