using IRES_Project.Controls.Pages;
using Model.Models.Menu;
using Model.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ViewModel.Table;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace IRES_Project.Views.Table
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableOrderView : ContentView
    {
        TableOrderViewModel viewModel;
        public TableOrderView()
        {
            InitializeComponent();
            viewModel = new TableOrderViewModel();
            CreateContent();
            BindingContext = viewModel;
            cbbListFloor.SelectionChanged += CbbListFloor_SelectionChanged;
        }

        private void CbbListFloor_SelectionChanged(object sender, EventArgs e)
        {
            viewModel.GetListTable(cbbListFloor.SelectedItem.ToString());
        }

        public async void CreateContent()
        {

            await Task.Delay(200);
            waitting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                cbbListFloor.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { "Tầng 1", "Tầng 2"};
                cbbListFloor.Picker.SelectedIndex = 0;
                //lsMenu.FlowItemsSource = new System.Collections.ObjectModel.ObservableCollection<object> { new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 1" , Number  = 1},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 2", Number  = 1 },
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 3", Number  = 2 },
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 4" , Number  = 3},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 5", Number  = 4},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 6" , Number  = 5},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 7" , Number  = 6},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 8" , Number  = 7},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 9" , Number  = 8},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 10", Number  = 9},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 11" , Number  = 10},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 12" , Number  = 11},
                //new TabMenuItemModel() { IconFont = "\ueb60", LabName= "Bàn 13" , Number  = 12}
                //};
                waitting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        private void btnOrderClick(object sender, EventArgs e)
        {
            contentQrCode.Children.Add(GenerateQR("Demo Code"));
            DateTime dt = new DateTime(pkDatePicker.Picker.Date.Year, pkDatePicker.Picker.Date.Month, pkDatePicker.Picker.Date.Day,
                pkTime.Picker.Time.Hours, pkTime.Picker.Time.Minutes, pkTime.Picker.Time.Seconds );
            
            viewModel.OrderTable(dt);
            qrCode.IsVisible = true;
        }

        ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            // Workaround for iOS
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }

        private async void btnOkClick(object sender, EventArgs e)
        {
            //DateTime dt = new DateTime(pkDatePicker.Picker.Date.Year, pkDatePicker.Picker.Date.Month, pkDatePicker.Picker.Date.Day,
            //   pkTime.Picker.Time.Hours, pkTime.Picker.Time.Minutes, pkTime.Picker.Time.Seconds);
            //var res = await viewModel.OrderTable();
            MultiContentPages.Instance.ClearAll();
        }

        private void Itemtaped(object sender, ItemTappedEventArgs e)
        {
            var tapItem = e.Item as TableModel;
            if (tapItem.Status == "ĐANG DÙNG") return;
            if (tapItem.IsActived == true)
            {
                tapItem.IsActived = false;
                return;
            }
            var fist = viewModel.ListTables.FirstOrDefault(x => x.IsActived == true);
            if (cbMultiSelect.IsChecked)
            {
                var item = viewModel.ListTables.Count(x => x.IsActived == true && Math.Abs(tapItem.Number - x.Number) == 1);
                if (item != 0) tapItem.IsActived = true;
                else if(fist == null) tapItem.IsActived = true;
                else
                {
                    DisplayAlert("Làm ơn chọn bàn gần nhau!");
                }
            }
            else
            {
                if(fist != null) fist.IsActived = false;

                tapItem.IsActived = true;
            }
        }

        private async void DisplayAlert(string v)
        {
            await MultiContentPages.Instance.DisplayAlert("Thông báo", v, "Ok");
        }
    }
}