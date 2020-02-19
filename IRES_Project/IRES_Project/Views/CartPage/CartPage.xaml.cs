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
	public partial class CartPage : ContentView
	{
        ObservableCollection<Food> currentList;
        FoodMenuViewModel viewmodel;
        bool IsOrder = false;
        public CartPage(ObservableCollection<Food> selectedFood, bool isOrder = false)
		{
			InitializeComponent ();
            currentList = selectedFood;
            lsFoods.ItemsSource = currentList;
            LoadTotal();
            IsOrder = isOrder;
            viewmodel = new FoodMenuViewModel();
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

        private async void BtnCheckInClick(object sender, EventArgs e)
        {
            foreach (var item in currentList)
            {
                var check = IRES_Global.GlobalInfo.ListOrders.FirstOrDefault(x => x.LabName == item.LabName);
                if (check == null)
                    IRES_Global.GlobalInfo.ListOrders.Add(item);
                else check.OrderQuantity += item.OrderQuantity;
            }
            var order = await viewmodel.PutOrder(IRES_Global.GlobalInfo.Order, currentList.ToList());
            if(order == null)
            {
                await MultiContentPages.Instance.DisplayAlert("Thông báo", "Kết nối lỗi!", "Ok");
                return;
            }
            BackgroundWorker wk = new BackgroundWorker();
            if (IsOrder)
            {
                wk.DoWork += (s, z) =>
                {
                    z.Result = new MainCartPage(true);
                };
            }
            else
            {
                wk.DoWork += (s, z) =>
                {
                    z.Result = new MainCartPage();
                };
            }
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
                var item = button.BindingContext as Food;
                this.currentList.Remove(item);
                LoadTotal();
            }
        }

        int Index = -1;
        private void itemTaped(object sender, EventArgs e)
        {
            var label = sender as Label;

            var data = label.BindingContext as Food;
            Index = currentList.IndexOf(data);

            lbNote.Text = data.Note;

            lbNote.IsVisible = true;
            lbNote.Focus();

        }
        
        private void LbNote_Unfocused(object sender, FocusEventArgs e)
        {
            if (Index == -1) return;
            try
            {
                currentList[Index].Note = lbNote.Text;
                lbNote.IsVisible = false;
            }
            catch (Exception)
            {

            }
        }
    }
}