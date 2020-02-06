using IRES_Project.Controls.ControlItems.TabMenuItem;
using Model.Models.Menu;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class TableMaps: TabMenu
    {
        private int widthItem = 70;

        public int WidthItem
        {
            get { return widthItem; }
            set { widthItem = value; }
        }

        private int _HeightItem = 70;
        public int HeightItem { get=>_HeightItem; set { _HeightItem = value; } }

        private int _CornerItem = 5;
        public int CornerItem { get => _CornerItem; set { _CornerItem = value; } }

        private int _Spacing = 5;
        public int Spacing { get => _Spacing; set { _Spacing = value; } }
        public event EventHandler<EventArgs> ShowMessage;
        public int MarginItem { get; set; }
        protected override void DrawItems()
        {
            Grid tempGrid = new Grid() { Padding = new Thickness(0), Margin = new Thickness(0,5,0,5), ColumnSpacing = Spacing, RowSpacing = Spacing, HorizontalOptions = LayoutOptions.FillAndExpand};
            int coloums = (IRES_Global.GlobalInfo.ScreenWidth  - MarginItem) / (WidthItem + Spacing);
            int rows = ItemSource.Count % coloums == 0 ? ItemSource.Count /coloums: (ItemSource.Count /coloums + 1);
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < coloums; j++)
                {
                    if(index < ItemSource.Count)
                    {
                        var curItem = ItemSource[index] as TabMenuItemModel;
                        TabMenuItem item = new TabMenuItem() { Data = curItem, WidthRequest = WidthItem, HorizontalOptions = LayoutOptions.Center, CornerRadius= CornerItem };
                        
                        item.Clicked += Item_Clicked;
                        if(j == 0) tempGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                        tempGrid.Children.Add(item);
                        Grid.SetColumn(item, j);
                        Grid.SetRow(item, i);
                    }
                    index++;
                }
                tempGrid.RowDefinitions.Add(new RowDefinition() { Height =  HeightItem});
            }
            //for (int i = 0; i < ItemSource.Count; i++)
            //{
                
            //    var curItem = ItemSource[i] as TabMenuItemModel;
            //    TabMenuItem item = new TabMenuItem() { Data = curItem };
            //    item.Clicked += Item_Clicked;
            //    if (Orientation == StackOrientation.Horizontal)
            //    {
            //        tempGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            //        tempGrid.Children.Add(item);
            //        Grid.SetColumn(item, i);
            //        Grid.SetRow(item, rows);
            //    }
            //    else
            //    {
            //        tempGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
            //        tempGrid.Children.Add(item);
            //        Grid.SetRow(item, i);
            //    }

            //}
            Content = tempGrid;
        }

        public static readonly BindableProperty MultiSelectProperty =
        BindableProperty.Create(
        nameof(MultiSelect),
        typeof(bool),
        typeof(TableMaps),
        false);

        public bool MultiSelect
        {
            get { return (bool)GetValue(MultiSelectProperty); }
            set { SetValue(MultiSelectProperty, value);  }
        }

        private List<object> _ListSelectedItems;
        public List<object> ListSelectedItems { get => _ListSelectedItems; set { _ListSelectedItems = value; OnPropertyChanged(); } }

        private void Item_Clicked(object sender, EventArgs e)
        {
            var Item = sender as TabMenuItem;

            if (Item.Data.IsActived) { Item.Data.IsActived = !Item.Data.IsActived; ListSelectedItems.Remove(Item); SelectedItem = null; return; }
            var first = ItemSource.FirstOrDefault(x => (x as TabMenuItemModel).IsActived == true) as TabMenuItemModel;
            if (MultiSelect)
            {
                if(first != null)
                {
                    if( Math.Abs( first.Number - Item.Data.Number) == 1)
                    {
                        ListSelectedItems.Add(Item);
                        Item.Data.IsActived = !Item.Data.IsActived; return;
                    }
                    else { ShowMessage?.Invoke("Làm ơn chọn bàn gần nhau!", EventArgs.Empty); return; }
                }
            }
            else
            {
                if (first != null) first.IsActived = false;
                SelectedItem = Item;
            }
            Item.Data.IsActived = !Item.Data.IsActived;
        }
    }
}
