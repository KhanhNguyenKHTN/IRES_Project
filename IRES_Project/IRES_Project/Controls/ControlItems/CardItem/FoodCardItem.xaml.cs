using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Controls.ControlItems.CardItem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodCardItem : ContentView
	{
        public event EventHandler<EventArgs> ClickAddCard;
        
		public FoodCardItem ()
		{
			InitializeComponent ();
            btnAddCart.Clicked += BtnAddCart_Clicked;
		}

        private void BtnAddCart_Clicked(object sender, EventArgs e)
        {
            ClickAddCard?.Invoke(this, null);
        }
    }
}