using IRES_Project.Controls;
using IRES_Project.Interfaces;
using IRES_Project.Views.MainPage;
using IRES_Project.WebScokets;
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

namespace IRES_Project.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        WebScokets.RabitConnect rabbit;
        public HomePage ()
		{
			InitializeComponent ();
            LoadFirstContent();
            MessagingCenter.Subscribe<RabitConnect, string>(this, "CashSuccess", (s, e) => {
                DependencyService.Get<IAudioNoti>().NotifiMessage();
            });
        }

        private async void LoadFirstContent()
        {
            await Task.Delay(500);
            waiting.IsVisible = true;
            CreatMenu();
            LoadMainPage();
           // await DisplayAlert( IRES_Global.GlobalInfo.ScreenWidth + ":" + IRES_Global.GlobalInfo.ScreenHeight, "a", "s");
        }

        private void CreatMenu()
        {
            tmvMainMenu.ItemSource = new ObservableCollection<object>
            {
                new TabMenuItemModel() { IconFont = "\uef47", IsActived = true, LabName= "Trang chủ" },
                new TabMenuItemModel() { IconFont = "\ueeec", LabName= "Khám phá" },
                new TabMenuItemModel() { IconFont = "\uef3c", LabName= "Ưu đãi" },
                new TabMenuItemModel() { IconFont = "\ueea3", LabName= "Thông báo" },
                new TabMenuItemModel() { IconFont = "\uecfd", LabName= "Tài khoản"}
            };
            tmvMainMenu.SelectionChanged += TmvMainMenu_SelectionChanged;
            
        }

        private void TmvMainMenu_SelectionChanged(object sender, EventArgs e)
        {
            var tab = sender as TabMenu;
            gridContent.Children.Clear();
            switch (tab.SelectedIndex)
            {
                case 0:
                    LoadMainPage();
                    break;
                case 1:
                    LoadDiscoverPage();
                    break;
                case 2:
                    LoadGiftPage();
                    break;
                case 3:
                    LoadNotificationPage();
                    break;
                default:
                    LoadSettingPage();
                    break;
            }
            
        }

        private void LoadDiscoverPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                z.Result = new DiscoveryPage.DiscoveryPage();
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as DiscoveryPage.DiscoveryPage);
                waiting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        private void LoadNotificationPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                z.Result = new NotificationPage.NotificationPage();
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as NotificationPage.NotificationPage);
                waiting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        private void LoadGiftPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                z.Result = new GiftPage.GiftPage();
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as GiftPage.GiftPage);
                waiting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        private void LoadMainPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                var item = new MainPage.MainScreen();
                item.HasAlert += async (mess, e) =>
                {
                    await DisplayAlert("Thông báo", mess.ToString(), "OK");
                };
                z.Result = item;
                rabbit = new WebScokets.RabitConnect();
                rabbit.ReceiveNotifyRabbitMQ();
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as MainScreen);
                waiting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }

        void LoadSettingPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork +=  (s,z) => {
                z.Result = new Settings.SettingPage();
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as Settings.SettingPage);
                waiting.IsVisible = false;
            };
            wk.RunWorkerAsync();
        }
    }
}