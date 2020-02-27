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
                if(IRES_Global.GlobalInfo.Order != null)
                {
                    contentQrCode.Children.Add(GenerateQR("ORDER" + IRES_Global.GlobalInfo.Order.code));
                    qrCode.IsVisible = true;
                }
                else
                {
                    cbbListFloor.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { "Tầng 1", "Tầng 2" };
                    cbbListFloor.Picker.SelectedIndex = 0;
                }
                waitting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        private async void btnOrderClick(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(pkDatePicker.Picker.Date.Year, pkDatePicker.Picker.Date.Month, pkDatePicker.Picker.Date.Day,
                        pkTime.Picker.Time.Hours, pkTime.Picker.Time.Minutes, pkTime.Picker.Time.Seconds);

            var order = await viewModel.OrderTable(dt, quantityPeople.Quantity);
            if(order == null)
            {
                await MultiContentPages.Instance.DisplayAlert("Thông báo", "Order không thành công?", "Không");
            }
            else
            {
                contentQrCode.Children.Add(GenerateQR("ORDER" + order.code));
            }
            var res =  await MultiContentPages.Instance.DisplayAlert("Thông báo", "Bạn có muốn đặt món trước không?", "Có", "Không");
            if(res == true)
            {
                BackgroundWorker wk = new BackgroundWorker();
                wk.DoWork += (s, z) =>
                {
                    z.Result = new MenuFood.MenuPage(true);
                };
                MultiContentPages.Instance.PushPage(wk);
            }
            
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

        private void btnDatMonTrcClicked(object sender, EventArgs e)
        {
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) =>
            {
                z.Result = new MenuFood.MenuPage(true);
            };
            MultiContentPages.Instance.PushPage(wk);
        }
    }
}