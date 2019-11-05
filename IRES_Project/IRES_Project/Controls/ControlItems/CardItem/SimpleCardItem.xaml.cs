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
	public partial class SimpleCardItem : ContentView
	{
        public event EventHandler<EventArgs> Clicked;
        public SimpleCardItem ()
		{
			InitializeComponent ();
            CurTabViewItem.Clicked += CurTabViewItem_Clicked;
        }

        private void CurTabViewItem_Clicked(object sender, EventArgs e)
        {
            this.Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}