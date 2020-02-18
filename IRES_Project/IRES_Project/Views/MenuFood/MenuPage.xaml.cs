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
        public MenuPage()
		{
			InitializeComponent ();
            viewModel = new FoodMenuViewModel();
            GenerateData();
            //LoadData();
            lsListCatagory.SelectionChanged += LsListCatagory_SelectionChanged;
            BindingContext = viewModel;
            // layoutTest.Children.Add(new StackLayout() { BackgroundColor = Color.Black, HeightRequest = 100 });
        }
        bool order = false;
        public MenuPage(bool isOrder)
        {
            order = true;
            InitializeComponent();
            viewModel = new FoodMenuViewModel();
            GenerateData();
            //LoadData();
            lsListCatagory.SelectionChanged += LsListCatagory_SelectionChanged;
            BindingContext = viewModel;
            // layoutTest.Children.Add(new StackLayout() { BackgroundColor = Color.Black, HeightRequest = 100 });
        }


        private void LsListCatagory_SelectionChanged(object sender, EventArgs e)
        {
            viewModel.GetFoodByType();
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
            var card = button.BindingContext as Food;

            card.IsSelected = !card.IsSelected;
            if (card.IsSelected)
            {
                viewModel.SelectedFood.Add(card);
            } else
            {
                var check = viewModel.SelectedFood.FirstOrDefault(x => x.Id == card.Id);
                if (check != null) viewModel.SelectedFood.Remove(card);
            }
        }

        private void BtnCheckInClick(object sender, EventArgs e)
        {
            if(viewModel.SelectedFood.Count == 0)
            {
                MultiContentPages.Instance.DisplayAlert("Thông báo!", "Vui lòng chọn món!", "OK");
                return;
            }

            //if (order) { IRES_Global.GlobalClass.ListOrders = list; MultiContentPages.Instance.PopPage(); return; }
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) =>
            {
                z.Result = new CartPage.CartPage(viewModel.SelectedFood, order);
            };
            MultiContentPages.Instance.PushPage(wk);
        }

        private void txbSearchReturn(object sender, EventArgs e)
        {
            viewModel.GetFoodByName(txbSearch.Text);
        }
    }
}