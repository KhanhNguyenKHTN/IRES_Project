using IRES_Project.Controls.ControlItems.CardItem;
using System.Linq;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class ListFoodCards: TabMenu
    {
        private ObservableCollection<CardItemModel> _SelectedItems;
        public ObservableCollection<CardItemModel> SelectedItems { get => _SelectedItems; set { _SelectedItems = value; OnPropertyChanged(); } }

        public event EventHandler<EventArgs> ItemsChange;

        public StackLayout stackContent;
        public ListFoodCards()
        {
            SelectedItems = new ObservableCollection<CardItemModel>();
            stackContent = new StackLayout() { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.FillAndExpand, };
            Content = stackContent;
            ItemSourceChange += ListFoodCards_ItemSourceChange;
        }

        public void UpdateUI()
        {
            foreach (var item in stackContent.Children)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    stackContent.RaiseChild(item);
                });
            }            
        }
        public void UpdateUI(object item)
        {
            var addItem = stackContent.Children.FirstOrDefault(x => x.BindingContext == item);
            if(addItem != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    stackContent.RaiseChild(addItem);
                });
            }
        }
        private void ListFoodCards_ItemSourceChange(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Adddlllllddd: ");
                foreach (var curItem in e.NewItems)
                {
                    FoodCardItem item = new FoodCardItem() { BindingContext = curItem, HorizontalOptions = LayoutOptions.FillAndExpand };
                    item.ClickAddCard += Item_ClickAddCard;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        stackContent.Children.Add(item);
                    });
                } 

 
            };
        }

        protected override void DrawItems()
        {
            foreach (var curItem in ItemSource)
            {
                FoodCardItem item = new FoodCardItem() { BindingContext = curItem, HorizontalOptions = LayoutOptions.FillAndExpand };
                item.ClickAddCard += Item_ClickAddCard;
                Device.BeginInvokeOnMainThread(() =>
                {
                    stackContent.Children.Add(item);
                });
               
            }
        }

        private void Item_ClickAddCard(object sender, EventArgs e)
        {
            var foodCard = sender as FoodCardItem;
            var data = foodCard.BindingContext as CardItemModel;
            var check = SelectedItems.FirstOrDefault(x => x == data);
            
            if (!data.IsSelected)
            {
                if (check == null)
                    SelectedItems.Add(data);
                data.IsSelected = true;
            }
            else
            {
                if (check != null)
                    SelectedItems.Remove(data);
                data.IsSelected = false;
            }
            
            ItemsChange?.Invoke(data, null);
        }
    }
}
