using IRES_Project.Controls;
using IRES_Project.Views.MainPage;
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
		public HomePage ()
		{
			InitializeComponent ();
            LoadFirstContent();
            Console.WriteLine("Het Khoi tao!!!!!!!!");
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
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    break;
                default:
                    LoadSettingPage();
                    break;
            }
            Console.WriteLine("Het ham change!!!!!!!!");
            
        }

        private void LoadMainPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork += (s, z) => {
                z.Result = new MainPage.MainScreen();
                Console.WriteLine("Chay background!!!!!!!");
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as MainScreen);
                waiting.IsVisible = false;
                Console.WriteLine("Het background!!!!!!!!");
            };
            wk.RunWorkerAsync();
        }

        void LoadSettingPage()
        {
            waiting.IsVisible = true;
            BackgroundWorker wk = new BackgroundWorker();
            wk.DoWork +=  (s,z) => {
                z.Result = new Settings.SettingPage();
                Console.WriteLine("Chay background!!!!!!!");
            };
            wk.RunWorkerCompleted += (s, z) =>
            {
                gridContent.Children.Add(z.Result as Settings.SettingPage);
                waiting.IsVisible = false;
                Console.WriteLine("Het background!!!!!!!!");
            };
            wk.RunWorkerAsync();
        }
    }
}