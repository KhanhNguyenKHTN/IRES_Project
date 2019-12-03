using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IRES_Project.Views.GiftPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GiftPage : ContentView
	{
		public GiftPage ()
		{
			InitializeComponent ();
            lsSimpleCard.ItemSource = new ObservableCollection<object>
            {
                new TabMenuItemModel() { IconFont = "\ue8e2", IsActived = true, LabName= "Tất cả" },
                new TabMenuItemModel() { IconFont = "\uee26",  LabName="Khuyến mãi"},
                new TabMenuItemModel() { IconFont = "\uee31", LabName= "Của tôi" }
            };
            lvGilf.ItemsSource = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\ue8e2", IsActived = true, LabName= "Khuyến mãi đặc biệt", Likes = 123, ImagesSource="banner1.jpg",
                                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Hot", Likes = 21,ImagesSource="banner2.jpg",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Tin tức",ImagesSource="banner3.jpg"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Giải trí", Likes = 123,ImagesSource="banner2.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên " },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="banner1.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\ue96f", LabName= "Deal" , Likes = 123,ImagesSource="banner3.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\ueec1", LabName= "Tổng hợp", Likes = 123,ImagesSource="banner1.jpg", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" }
                    };
        }
	}
}