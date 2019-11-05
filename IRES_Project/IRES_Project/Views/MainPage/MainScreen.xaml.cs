using IRES_Project.Controls;
using IRES_Project.Controls.ControlItems.CardItem;
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

namespace IRES_Project.Views.MainPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainScreen : ContentView
	{
		public MainScreen ()
		{
			InitializeComponent ();
            RegisterEvent();
            GenarateData();
        }

        private void RegisterEvent()
        {
            lsSimpleCard.SelectionChanged += LsSimpleCard_SelectionChanged;
            lsCard.SelectionChanged += LsCard_SelectionChanged;
            lsCard2.SelectionChanged += LsCard2_SelectionChanged;
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
    }
}