using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.Table
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableOrderPage : ContentPage
    {
        public TableOrderPage()
        {
            InitializeComponent();
            cbbListFloor.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { "Tầng 1", "Tầng 2", "Tầng 3", "Tầng 4" };                     
        }
        
    }
}