using IRES_Project.Controls.Pages;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.CartPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentView
	{
        ObservableCollection<CardItemModel> currentList;
        public CartPage (ObservableCollection<CardItemModel> selectedFood)
		{
			InitializeComponent ();
            currentList = selectedFood;
            lsFoods.ItemsSource = currentList;
            LoadTotal();
		}

        private void QuantityChange(object sender, EventArgs e)
        {
            Console.WriteLine("Quantity change");
            LoadTotal();
        }

        private void LoadTotal()
        {
            int total = 0;
            foreach (var item in currentList)
            {
                total += item.TotalQuantity;
            }
            lbTotal.Text = total.ToString("C").Remove(total.ToString("C").Length - 2, 2);
        }

        private void BtnCheckInClick(object sender, EventArgs e)
        {
            foreach (var item in currentList)
            {
                var check = IRES_Global.GlobalClass.ListOrders.FirstOrDefault(x => x.LabName == item.LabName);
                if (check == null)
                    IRES_Global.GlobalClass.ListOrders.Add(item);
                else check.Quantity += item.Quantity;
            }
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) =>
            {
                z.Result = new MainCartPage();
            };
            MultiContentPages.Instance.PushPage(wk);
            //MultiContentPages.Instance.ClearAll();
            //MultiContentPages.Instance.PopModalAsync();

        }

        private void BackClick(object sender, EventArgs e)
        {
            MultiContentPages.Instance.PopPage();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)   
        {
            var button = sender as MenuItem;

            if (button != null)
            {
                var item = button.BindingContext as CardItemModel;
                this.currentList.Remove(item);
                LoadTotal();
            }
        }
    }
}