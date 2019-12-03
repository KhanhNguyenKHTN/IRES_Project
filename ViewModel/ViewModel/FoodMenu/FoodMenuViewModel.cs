using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ViewModel.ViewModel.FoodMenu
{
    public class FoodMenuViewModel: BaseViewModel
    {
        private ObservableCollection<CardItemModel> _ListFoods;
        public ObservableCollection<CardItemModel> ListFoods { get => _ListFoods; set { _ListFoods = value; OnPropertyChanged(); } }

        private ObservableCollection<object> _ListCatogorys;

        public ObservableCollection<object> ListCatogorys
        {
            get { return _ListCatogorys; }
            set { _ListCatogorys = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _ListTypes;

        public ObservableCollection<object> ListTypes
        {
            get { return _ListTypes; }
            set { _ListTypes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<object> _ListBanners;

        public ObservableCollection<object> ListBanners
        {
            get { return _ListBanners; }
            set { _ListBanners = value; OnPropertyChanged(); }
        }

        private string _SelectedCatagory;

        public string SelectedCatagory
        {
            get { return _SelectedCatagory; }
            set {
                _SelectedCatagory = value; OnPropertyChanged(); }
        }

        private string _SelectedType;

        public string SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }



        public ICommand ItemTappedCommand { get; set; }

        public ICommand LastTappedItem { get; set; }

        public FoodMenuViewModel()
        {
            
        }

        public void LoadData()
        {
            ListFoods = new ObservableCollection<CardItemModel>()
            {
                        new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", Cost="5.000 đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên dương châu" , ImagesSource="bannerFood2.jpg", Cost="5.000 đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                         new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi", Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },
                        new CardItemModel() { IconFont = "\uee4a", LabName= "Đia điểm" , Likes = 123,ImagesSource="food1.jpg", Cost="5.000 đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

            };

            ListBanners = new ObservableCollection<object>()
            {
                 new CardItemModel() { IsActived = true, LabName= "Tất cả" , ImagesSource = "bannerFood1.jpg" },
                 new CardItemModel() {  LabName="Khai vị", ImagesSource = "bannerFood2.jpg"},
                 new CardItemModel() { LabName= "Món chính" , ImagesSource = "bannerFood3.jpg"},
                 new CardItemModel() { LabName= "Tráng miệng", ImagesSource = "bannerFood4.jpg"},
            };
            ListCatogorys = new ObservableCollection<object>()
            {
                 "Tất cả",
                 "Khai vị",
                 "Món chính",
                 "Tráng miệng",
            };

            SelectedCatagory = ListCatogorys[0].ToString();

            ListTypes = new ObservableCollection<object>()
            {
                 "Tất cả",
                 "Món nướng",
                 "Món trộn",
                 "Cơm",
                 "Lẩu",
                 "Rau củ",
            };
            SelectedType = ListTypes[0].ToString();
        }
    }
}
