using IRES_Project.Controls.ControlItems.CardItem;
using Model.Models.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class ListSimpleCard: TabMenu
    {
        protected override void DrawItems()
        {
            StackLayout stack = new StackLayout() { Orientation = StackOrientation.Horizontal };
            for (int i = 0; i < ItemSource.Count; i++)
            {
                var curItem = ItemSource[i] as TabMenuItemModel;
                SimpleCardItem item = new SimpleCardItem() { BindingContext = curItem, HorizontalOptions = LayoutOptions.FillAndExpand };
                item.Clicked += Item_Clicked;
                stack.Children.Add(item);
                if (curItem.IsActived) SelectedViewItem = item;
            }
            Content = stack;
        }
        private void Item_Clicked(object sender, EventArgs e)
        {
            var curSender = sender as SimpleCardItem;
            SelectedViewItem = curSender;
            SelectedItem = curSender.BindingContext;
        }
    }
}
