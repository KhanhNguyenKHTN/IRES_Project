﻿using IRES_Project.Controls;
using IRES_Project.Controls.ControlItems.CardItem;
using IRES_Project.Views.Table;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace IRES_Project.Views.MainPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainScreen : ContentView
	{
        //public event EventHandler<EventArgs> ScanSuccessEvent;
		public MainScreen ()
		{
			InitializeComponent ();
            RegisterEvent();
            GenarateData();
            Button a = new Button();            
        }

        private void RegisterEvent()
        {
            lsSimpleCard.SelectionChanged += LsSimpleCard_SelectionChanged;
            lsCard.SelectionChanged += LsCard_SelectionChanged;
            lsCard2.SelectionChanged += LsCard2_SelectionChanged;
            btnTable.Clicked += BtnTable_Clicked;
            btnMenu.Clicked += BtnMenu_Clicked;
            btnScan.Clicked += BtnScan_Clicked;
            btnCart.Clicked += BtnCart_Clicked;
        }

        private void BtnCart_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Cart click");
        }

        private void BtnScan_Clicked(object sender, EventArgs e)
        {
            Scan();
        }

        private void BtnMenu_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Menu click");
        }

        private async void BtnTable_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TableOrderPage());
            Console.WriteLine("Table click");
        }

        private void GenarateData()
        {
            lsSimpleCard.ItemSource = new ObservableCollection<object>
                    {
                        new TabMenuItemModel() { IconFont = "\ue8e2", IsActived = true, LabName= "Tất cả" },
                        new TabMenuItemModel() { IconFont = "\uef2b",  LabName="Hot"},
                         new TabMenuItemModel() { IconFont = "\uefa6", LabName= "Tin tức" },
                         new TabMenuItemModel() { IconFont = "\uec9e", LabName= "Giải trí"},
                        new TabMenuItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" },
                        new TabMenuItemModel() { IconFont = "\ue96f", LabName= "Deal" },
                        new TabMenuItemModel() { IconFont = "\ueec1", LabName= "Tổng hợp"}
                    };
            lsCard.ItemSource = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\ue8e2", IsActived = true, LabName= "Khuyến mãi đặc biệt", Likes = 123, ImagesSource="banner1.jpg",
                                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Hot", Likes = 21,ImagesSource="banner2.jpg",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Tin tức",ImagesSource="banner3.jpg"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Giải trí", Likes = 123,ImagesSource="banner2.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="banner1.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\ue96f", LabName= "Deal" , Likes = 123,ImagesSource="banner3.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\ueec1", LabName= "Tổng hợp", Likes = 123,ImagesSource="banner1.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" }
                    };
            lsCard2.ItemSource = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Hot", Likes = 21,ImagesSource="banner2.jpg",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Tin tức",ImagesSource="banner3.jpg"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Giải trí", Likes = 123,ImagesSource="banner2.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="banner1.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                    };
        }

        private void LsCard2_SelectionChanged(object sender, EventArgs e)
        {
            scrollHot.ScrollToAsync((sender as TabMenu).SelectedViewItem as CardItem, ScrollToPosition.Start, true);
        }

        private void LsCard_SelectionChanged(object sender, EventArgs e)
        {
            scrollMix.ScrollToAsync((sender as TabMenu).SelectedViewItem as CardItem, ScrollToPosition.Start, true);
        }

        private void LsSimpleCard_SelectionChanged(object sender, EventArgs e)
        {
            scrListSimpleCard.ScrollToAsync((sender as TabMenu).SelectedViewItem as SimpleCardItem, ScrollToPosition.Start, true);
        }

        public async void Scan()
        {
            try
            {
                var options = new MobileBarcodeScanningOptions
                {
                    AutoRotate = false,
                    UseFrontCameraIfAvailable = false,
                    TryHarder = true,
                   
                };

                var overlay = new ZXingDefaultOverlay
                {
                    TopText = "Please scan QR code",
                    BottomText = "Align the QR code within the frame"
                };
                var grid = new Grid();
                RowDefinition row1 = new RowDefinition() { Height = 200 };
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition() { Height = 200 };

                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
                grid.RowDefinitions.Add(row3);
                Label edit = new Label()
                {
                    Text = "Test layout Scan" + Environment.NewLine + "(Mr.Khanh)",
                    FontSize = 24,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    TextColor = Color.Red,
                };
                Grid.SetRow(edit, 0);
                grid.Children.Add(edit);

                var QRScanner = new ZXingScannerPage(options, null);

                await Navigation.PushModalAsync(QRScanner);

                QRScanner.OnScanResult += (result) =>
                {
                    // Stop scanning
                    QRScanner.IsScanning = false;
                    
                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {
                            MessagingCenter.Send<MainScreen>(this, result.Text);
                            Console.WriteLine("daaaaaaaaaaaaaaaa" + result.Text);
                            await Navigation.PopModalAsync(true);
                            //strAccessToken.Text = result.Text.ToUpper().Trim();
                            // DisplayAlert("Scanned Barcode", result.Text, "OK");
                           // txtBarcode.Text = result.Text;
                            //Navigation.PushModalAsync(new ScanQRPage() { txtBarcode.Text = result.Text;});
                        }
                        catch
                        {
                            MessagingCenter.Send<MainScreen>(this, result.Text);
                            Console.WriteLine("daaaaaaaaaaaaaaaa" + result.Text);
                            await Navigation.PopModalAsync(true);
                        }


                    });

                };

            }
            catch (Exception ex)
            {
                // GlobalScript.SeptemberDebugMessages("ERROR", "BtnScanQR_Clicked", "Opening ZXing Failed: " + ex);
                Device.BeginInvokeOnMainThread(() => {
                   
                   // DisplayAlert("Scanned Barcode", ex.ToString(), "OK");
                });
            }
        }
        
    }
}