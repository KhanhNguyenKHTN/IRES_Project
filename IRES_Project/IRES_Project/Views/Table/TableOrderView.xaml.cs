using IRES_Project.Controls.Pages;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public TableOrderView()
        {
            InitializeComponent();
            CreateContent();
        }


        public async void CreateContent()
        {

            await Task.Delay(200);
            waitting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                cbbListFloor.ItemSource = new System.Collections.ObjectModel.ObservableCollection<object> { "Tầng 1", "Tầng 2" };
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
            };
            wk.RunWorkerAsync();
        }

        private void btnOrderClick(object sender, EventArgs e)
        {
            contentQrCode.Children.Add(GenerateQR("Demo Code"));
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

        private void btnOkClick(object sender, EventArgs e)
        {
            MultiContentPages.Instance.ClearAll();
        }
    }
}