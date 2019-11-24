using Model.Models.Menu;
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
            CreateContent();
        }

        public async void CreateContent()
        {
           
            await Task.Delay(200);
            waitting.IsVisible = true;
            cbbListFloor.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { "Tầng 1", "Tầng 2", "Tầng 3", "Tầng 4" };
            cbbListFloor.Picker.SelectedIndex = 0;
            tableMap.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 1" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 2" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 3" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 4" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 5"},
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 6" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 7" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 8" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 9" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 10"},
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 11" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 12" },
                new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 13" },
                //new TabMenuItemModel() { IconFont = "\ueea3", LabName= "Thông báo" },
                //new TabMenuItemModel() { IconFont = "\uecfd", LabName= "Tài khoản"}
                };
            waitting.IsVisible = false;
        }
    }
}