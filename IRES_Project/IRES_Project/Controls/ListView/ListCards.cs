using IRES_Project.Controls.ControlItems.CardItem;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class ListCards: TabMenu
    {
       // public static readonly BindableProperty ItemSourceProperty =
       //BindableProperty.Create(
       //nameof(ItemSource),
       //typeof(ObservableCollection<object>),
       //typeof(TabMenu),
       //new ObservableCollection<object>());

       // public View Content
       // {
       //     get { return (ObservableCollection<object>)GetValue(ItemSourceProperty); }
       //     set { SetValue(ItemSourceProperty, value); DrawItems(); }
       // }


        protected override void DrawItems()
        {
            StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            for (int i = 0; i < ItemSource.Count; i++)
            {
                var curItem = ItemSource[i] as CardItemModel;
                CardItem item = new CardItem() { BindingContext = curItem, HorizontalOptions = LayoutOptions.FillAndExpand };
                item.Clicked += Item_Clicked;
                stack.Children.Add(item);
            }
            Content = stack;
            //base.DrawItems();
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            var curSender = sender as CardItem;
            SelectedViewItem = curSender;
            SelectedItem = curSender.BindingContext;
        }
    }
}
