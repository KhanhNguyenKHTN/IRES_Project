using IRES_Project.Controls.ControlItems.TabMenuItem;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class TabMenu: ContentView
    {
        public static readonly BindableProperty ItemSourceProperty =
       BindableProperty.Create(
       nameof(ItemSource),
       typeof(ObservableCollection<object>),
       typeof(TabMenu),
       new ObservableCollection<object>());

        public ObservableCollection<object> ItemSource
        {
            get { return (ObservableCollection<object>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); DrawItems(); }
        }



        protected virtual void DrawItems()
        {
            Grid tempGrid = new Grid() { Padding = new Thickness(0), Margin = new Thickness(0), ColumnSpacing = 0, RowSpacing = 0 };
            for (int i = 0; i < ItemSource.Count; i++)
            {
                var curItem = ItemSource[i] as TabMenuItemModel;
                TabMenuItem item = new TabMenuItem() { Data = curItem };
                item.Clicked += Item_Clicked;
                if (Orientation == StackOrientation.Horizontal)
                {
                    tempGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
                    tempGrid.Children.Add(item);
                    Grid.SetColumn(item, i);
                }
                else
                {
                    tempGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
                    tempGrid.Children.Add(item);
                    Grid.SetRow(item, i);
                }

            }
            Content = tempGrid;
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            var curSender = sender as TabMenuItem;
            SelectedViewItem = sender;
            SelectedItem = curSender.Data;
        }

        #region Binding Item Source (Will Update Later)

        //IEnumerable<object> ItemSource { get; set; }

        private StackOrientation _Origitation = StackOrientation.Horizontal;
        public StackOrientation Orientation { get => _Origitation; set { _Origitation = value; } }




        #endregion
        public static readonly BindableProperty SelectedItemProperty =
        BindableProperty.Create(
          nameof(SelectedItem),
          typeof(object),
          typeof(TabMenu),
          null);
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); SetSelectedItem(value); }
        }

        private void SetSelectedItem(object curSender)
        {
            var Item = ItemSource.FirstOrDefault(x => (x as TabMenuItemModel).IsActived == true);
            if (Item != null) (Item as TabMenuItemModel).IsActived = false;
            (curSender as TabMenuItemModel).IsActived = true;
            SelectedIndex = ItemSource.IndexOf(curSender);
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public object SelectedViewItem { get; set; }

        public int SelectedIndex { get; set; }

        public event EventHandler<EventArgs> SelectionChanged;
    }
}
