using Model.Models.Menu;
using System;
using System.Linq;
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

        public ObservableCollection<CardItemModel> GetSelectedFood()
        {
            var result = new ObservableCollection<CardItemModel>();
            var list = ListFoods.Where(x => x.IsSelected == true);
            foreach (var item in list)
            {
                result.Add(item);
            }
            return result;
        }

        public ICommand ItemTappedCommand { get; set; }

        public ICommand LastTappedItem { get; set; }

        private ObservableCollection<object> _ListObjects;

        public ObservableCollection<object> ListObjects
        {
            get { return _ListObjects; }
            set { _ListObjects = value; OnPropertyChanged(); }
        }

        public FoodMenuViewModel()
        {
            
        }

        public void LoadData()
        {
            ListFoods = new ObservableCollection<CardItemModel>()
            {
                new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi cuốn", Likes = 21,ImagesSource="bannerFood1.jpg", RealCost=5000, Unit = "đ/dĩa",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uefa6", LabName= "Cơm chiên" , ImagesSource="bannerFood2.jpg", RealCost=10000, Unit = "đ/dĩa"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uec9e", LabName= "Rau xào", Likes = 123,ImagesSource="food1.jpg",  RealCost=15000, Unit = "đ/dĩa",
                             Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },


                new CardItemModel() { IconFont = "\uee4a", LabName= "Tôm chiên" , Likes = 123,ImagesSource="food1.jpg", RealCost=35000, Unit = "đ/cái" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uef2b",  LabName="Lẩu thái", Likes = 21,ImagesSource="bannerFood1.jpg",  RealCost=150000, Unit = "đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uefa6", LabName= "Lẩu hải sản" , ImagesSource="bannerFood2.jpg", RealCost=175000, Unit = "đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi tôm yump", Likes = 123,ImagesSource="food1.jpg",  RealCost=55000, Unit = "đ/dĩa", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uee4a", LabName= "Bún thêm" , Likes = 123,ImagesSource="food1.jpg",  RealCost=5000, Unit = "đ/dĩa" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi đu đủ", Likes = 21,ImagesSource="bannerFood1.jpg", RealCost=45000, Unit = "đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uefa6", LabName= "Lẩu cá lóc" , ImagesSource="bannerFood2.jpg",  RealCost=215000, Unit = "đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uec9e", LabName= "Heo quay", Likes = 123,ImagesSource="food1.jpg",  RealCost=500000, Unit = "đ/con", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uee4a", LabName= "Vịt quay" , Likes = 123,ImagesSource="food1.jpg", RealCost=350000, Unit = "đ/con" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

            };
            ListObjects = new ObservableCollection<object>()
            {
               new CardItemModel() { IconFont = "\uefa6", LabName= "Lẩu hải sản" , ImagesSource="bannerFood2.jpg", RealCost=175000, Unit = "đ/cái"
                             , Likes = 123, Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uec9e", LabName= "Gỏi tôm yump", Likes = 123,ImagesSource="food1.jpg",  RealCost=55000, Unit = "đ/dĩa", Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lênTừ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uee4a", LabName= "Bún thêm" , Likes = 123,ImagesSource="food1.jpg",  RealCost=5000, Unit = "đ/dĩa" ,Description="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" },

                new CardItemModel() { IconFont = "\uef2b",  LabName="Gỏi đu đủ", Likes = 21,ImagesSource="bannerFood1.jpg", RealCost=45000, Unit = "đ/cái",
                            Description ="Từ ngày 20/10 - 20/11 khuyến mãi đặc biệt dành cho khách hàng thuê xe ô tô 4 chỗ trở lên" }
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
