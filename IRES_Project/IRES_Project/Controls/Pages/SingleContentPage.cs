using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls.Pages
{
    public class  SingleContentPage: ContentPage
    {
        private static SingleContentPage _Instance;

        public static SingleContentPage Instance
        {
            get
            {
                if (_Instance == null) _Instance = new SingleContentPage();
                return _Instance;
            }
        }

        public void ClearPage()
        {
            _Instance = null;
        }
    }
}
