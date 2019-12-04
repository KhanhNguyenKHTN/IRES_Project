using System;
using System.Collections.Generic;
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
		public MainCartPage ()
		{
			InitializeComponent ();
            lsFoods.ItemsSource = IRES_Global.GlobalClass.ListOrders;
            LoadTotal();
		}

        private void LoadTotal()
        {
            int total = 0;
            foreach (var item in IRES_Global.GlobalClass.ListOrders)
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

        }
    }
}