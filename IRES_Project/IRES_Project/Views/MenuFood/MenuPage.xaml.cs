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

namespace IRES_Project.Views.MenuFood
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentView
	{
        FoodMenuViewModel viewModel;
        public MenuPage ()
		{
			InitializeComponent ();
            viewModel = new FoodMenuViewModel();
            GenerateData();
            //LoadData();
            BindingContext = viewModel;
            // layoutTest.Children.Add(new StackLayout() { BackgroundColor = Color.Black, HeightRequest = 100 });
        }

        //public void LoadData()
        //{
        //    GenerateData();
        //}
        private void GenerateData()
        {
            viewModel.LoadData();
        }

        private  void ButtonWithContent_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var card = button.BindingContext as CardItemModel;

            card.IsSelected = !card.IsSelected;
        }

        private void BtnCheckInClick(object sender, EventArgs e)
        {
            var list = viewModel.GetSelectedFood();
            if(list.Count == 0)
            {
                var check = Navigation.ModalStack[Navigation.ModalStack.Count - 1] as MultiContentPages;
                if(check != null)
                {
                    MultiContentPages.Instance.DisplayAlert("Thông báo!", "Vui lòng chọn món!", "OK");
                }
                return;
            }
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) =>
            {
                z.Result = new CartPage.CartPage(list);
            };
            MultiContentPages.Instance.PushPage(wk);
        }
    }
}