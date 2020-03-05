using Model.Models.Menu;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Model.Models.Order;
using System.Threading.Tasks;

namespace ViewModel.ViewModel.FoodMenu
{
    public class FoodMenuViewModel : BaseViewModel
    {
        WebServices.Services.MenuService service;
        private ObservableCollection<Food> _ListFoods;
        public ObservableCollection<Food> ListFoods { get => _ListFoods; set { _ListFoods = value; OnPropertyChanged(); } }

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
                _SelectedCatagory = value; OnPropertyChanged();
            }
        }

        private string _SelectedType;

        public string SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnPropertyChanged(); }
        }

        //public ObservableCollection<Food> GetSelectedFood()
        //{
        //    var result = new ObservableCollection<Food>();
        //    var list = ListFoods?.Where(x => x.IsSelected == true);
        //    foreach (var item in list)
        //    {
        //        result.Add(item);
        //    }
        //    return result;
        //}
        public ObservableCollection<Food> SelectedFood { get; set; }

        public ICommand ItemTappedCommand { get; set; }

        public ICommand LastTappedItem { get; set; }

        private ObservableCollection<object> _ListObjects;

        public ObservableCollection<object> ListObjects
        {
            get { return _ListObjects; }
            set { _ListObjects = value; OnPropertyChanged(); }
        }
        private bool _IsRefresh;
        public bool IsRefresh { get => _IsRefresh; set { _IsRefresh = value; OnPropertyChanged(); } }

        public FoodMenuViewModel()
        {
            ListFoods = new ObservableCollection<Food>();
            SelectedFood = new ObservableCollection<Food>();
            service = new WebServices.Services.MenuService();
        }

        public void LoadData()
        {
            IsRefresh = true;
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


            IsRefresh = false;
        }
        public async void GetAll()
        {
            ListFoods = await service.GetAllFood();
        }

        public async void GetFoodByType()
        {
            IsRefresh = true;
            if (SelectedCatagory == null) return;
            if (SelectedCatagory.ToString() == "Tất cả") GetAll();
            else ListFoods = await service.GetFoodByType(SelectedCatagory.ToString().ToUpper());
            UpdateListFood();
            IsRefresh = false;
        }

        public void UpdateListFood()
        {
            foreach (var item in SelectedFood)
            {
                var check = ListFoods.FirstOrDefault(x => x.Id == item.Id);
                if (check != null) check.IsSelected = true;
            }
        }

        public async void GetFoodByName(string name)
        {
            IsRefresh = true;
            ListFoods = await service.GetFoodByName(name);
            UpdateListFood();
            IsRefresh = false;
        }

        public async Task<Order> PutOrder(Order order, List<Food> foods)
        {
            return await service.PutOrder(order, foods);
        }

        public async Task<bool> Payment(int total)
        {
            return await service.Payment(total);
        }
    }
}
