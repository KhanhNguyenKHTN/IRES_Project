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
	public partial class CardItem : ContentView
	{
        public event EventHandler<EventArgs> Clicked;
        public CardItem ()
		{
			InitializeComponent ();
            curCard.Clicked += CurCard_Clicked;
        }

        private void CurCard_Clicked(object sender, EventArgs e)
        {
            this.Clicked?.Invoke(this, e);
        }
    }
}