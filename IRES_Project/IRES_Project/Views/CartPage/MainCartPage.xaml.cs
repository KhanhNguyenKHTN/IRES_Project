using IRES_Project.Controls.Pages;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel.FoodMenu;
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
                    IsSelected = false,
                    IconFont="\uf024",
                    LabName = "Ví Momo",
                },
                new CardItemModel()
                {
                    IsSelected = true,
                    IconFont="\uecc8",
                    LabName = "Tiền mặt",
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
        int total = 0;

        private void LoadTotal()
        {
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

        private void AcceptPaymentClick(object sender, EventArgs e)
        {
           
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) =>
            {
                z.Result = new PaymentPage(total, listItem.IndexOf(listItem.FirstOrDefault(x=>x.IsSelected)));
            };
            MultiContentPages.Instance.PushPage(wk);
        }

        private void OkOrderClicked(object sender, EventArgs e)
        {
            MultiContentPages.Instance.DisplayPage(0);
        }
    }
}