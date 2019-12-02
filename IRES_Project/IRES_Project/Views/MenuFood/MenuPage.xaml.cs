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

namespace IRES_Project.Views.MenuFood
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentView
	{
		public MenuPage ()
		{
			InitializeComponent ();
            LoadData();
            // GenerateData();
           // layoutTest.Children.Add(new StackLayout() { BackgroundColor = Color.Black, HeightRequest = 100 });
        }

        public void LoadData()
        {
            GenerateData();
        }
        private void GenerateData()
        {
            var listBanner = new ObservableCollection<object>()
            {
                 new CardItemModel() { IsActived = true, LabName= "Tất cả" , ImagesSource = "bannerFood1.jpg" },
                        new CardItemModel() {  LabName="Khai vị", ImagesSource = "bannerFood2.jpg"},
                         new CardItemModel() { LabName= "Món chính" , ImagesSource = "bannerFood3.jpg"},
                         new CardItemModel() { LabName= "Tráng miệng", ImagesSource = "bannerFood4.jpg"},
            };
            var listSimpleCard = new ObservableCollection<object>()
            {
                 new TabMenuItemModel() { IsActived = true, LabName= "Tất cả" },
                        new TabMenuItemModel() {  LabName="Khai vị"},
                         new TabMenuItemModel() { LabName= "Món chính" },
                         new TabMenuItemModel() { LabName= "Tráng miệng"},
            };

            var listType = new ObservableCollection<object>()
            {
                 new TabMenuItemModel() { IsActived = true, LabName= "Tất cả" },
                        new TabMenuItemModel() {  LabName="Món nướng"},
                         new TabMenuItemModel() { LabName= "Món trộn" },
                         new TabMenuItemModel() { LabName= "Cơm"},
                         new TabMenuItemModel() { LabName= "Lẩu"},
                         new TabMenuItemModel() { LabName= "Rau củ"},
            };

            var listFood = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                    };
            var listFood2 = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                    };
            var listFood3 = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                    };
            var listFood4 = new ObservableCollection<object>
                    {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                    };
            lsFoodCard1.ItemSource = listFood;
            lsFoodCard2.ItemSource = listFood2;
            lsFoodCard3.ItemSource = listFood3;
            lsFoodCard4.ItemSource = listFood4;
            lsListCatagory.ItemSource = listSimpleCard;
            lsListType.ItemSource = listType;
            banner.ItemSource = listBanner;
            //lsFoodCard1.UpdateUI();
            //lsFoodCard2.UpdateUI();
            //lsFoodCard3.UpdateUI();
            //lsFoodCard4.UpdateUI();
            //waiting.Hide();
        }

        private  void ButtonWithContent_Clicked(object sender, EventArgs e)
        {
            //var li = lsFoodCard1.ItemSource;
            //await AddItemz();
            //lsFoodCard1.UpdateUI();
            //UpdateChildrenLayout();
            //this.UpdateChildrenLayout();
            var item = new CardItemModel()
            {
                IconFont = "\uef2b",
                LabName = "AAA",
                Likes = 21,
                ImagesSource = "bannerFood1.jpg",
                Cost = "5.000 đ/cái",
                Description = "Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên"
            };
            lsFoodCard1.ItemSource.Add(item);
            //lsFoodCard1.UpdateUI(item);
        }
        private async Task AddItemz()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var item = new StackLayout() { BackgroundColor = Color.Black, HeightRequest = 100 };
                layoutTest.Children.Add(item);
                layoutTest.RaiseChild(item);
            });
            await Task.Delay(100);
        }

    }
}