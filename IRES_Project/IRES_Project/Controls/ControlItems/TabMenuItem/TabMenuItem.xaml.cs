using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Controls.ControlItems.TabMenuItem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabMenuItem : ContentView
	{
        private TabMenuItemModel _Data;
        public TabMenuItemModel Data { get => _Data; set { if (value == null) return; _Data = value; BindingContext = Data; } }

        public event EventHandler<EventArgs> Clicked;
        public TabMenuItem ()
		{
			InitializeComponent ();
            BindingContext = Data;
            CurTabViewItem.Clicked += CurTabViewItem_Clicked;
        }

        private void CurTabViewItem_Clicked(object sender, EventArgs e)
        {
            this.Clicked?.Invoke(this, e);
        }
    }
}