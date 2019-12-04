using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel.FoodMenu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.DiscoveryPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiscoveryPage : ContentView
    {
        FoodMenuViewModel viewModel;
        public DiscoveryPage ()
		{
			InitializeComponent ();
            viewModel = new FoodMenuViewModel();
            viewModel.LoadData();
            BindingContext = viewModel;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var card = button.BindingContext as CardItemModel;

            card.IsSelected = !card.IsSelected;

        }

        private void ButtonWithContent_Clicked(object sender, EventArgs e)
        {

        }
    }
}