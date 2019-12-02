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
	public partial class BannerItem : ContentView
	{
        public event EventHandler<EventArgs> SwipeLeft;
        public event EventHandler<EventArgs> SwipeRight;
        public BannerItem ()
		{
			InitializeComponent ();
		}

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            //left
            SwipeLeft?.Invoke(this, null);
        }

        private void SwipeGestureRecognizer_Swiped_1(object sender, SwipedEventArgs e)
        {
            //right
            SwipeRight?.Invoke(this, null);
        }
    }
}