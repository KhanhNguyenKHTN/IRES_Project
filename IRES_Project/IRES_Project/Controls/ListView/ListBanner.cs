using IRES_Project.Controls.ControlItems.CardItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using Model.Models.Menu;

namespace IRES_Project.Controls
{
    public class ListBanner: TabMenu
    {
        protected override void DrawItems()
        {
            StackLayout st = new StackLayout() { Orientation = StackOrientation.Horizontal };
            if (ItemSource == null) return;
            foreach (var item in ItemSource)
            {
                var add = new BannerItem() { BindingContext = item };
                st.Children.Add(add);
            }
            Content = st;
        }
    }

    public class Banner : TabMenu
    {
        ListBanner banner;
        Image image;
        protected override void DrawItems()
        {
            banner = new ListBanner() { ItemSource = this.ItemSource, VerticalOptions = LayoutOptions.End, Margin = new Thickness(0, 5), HorizontalOptions = LayoutOptions.Center };
            var first = this.ItemSource.FirstOrDefault(x => (x as CardItemModel).IsActived == true);
            Frame fr = new Frame()
            {
                Padding = new Thickness(0),
                CornerRadius = 10,
                HeightRequest = 200
            };
            var left = new SwipeGestureRecognizer() { Direction = SwipeDirection.Left };
            left.Swiped += Left_Swiped;
            var right = new SwipeGestureRecognizer() { Direction = SwipeDirection.Right };
            right.Swiped += Right_Swiped;

            image = new Image()
            {
                Aspect = Aspect.AspectFill,
                Source = (first as CardItemModel).ImagesSource
            };

            Grid gr = new Grid();
            gr.Children.Add(image);
            gr.Children.Add(banner);
            var gridMa = new Grid() { VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };
            gr.Children.Add(gridMa);
            gridMa.GestureRecognizers.Add(left);
            gridMa.GestureRecognizers.Add(right);
            fr.Content = gr;

            Content = fr;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                Right_Swiped(null, null);
                return true;
            });
            base.SelectionChanged += Banner_SelectionChanged;
        }
    
        private void Banner_SelectionChanged(object sender, EventArgs e)
        {
            image.Source = (base.SelectedItem as CardItemModel).ImagesSource;
        }

        private void Right_Swiped(object sender, SwipedEventArgs e)
        {
            if (SelectedIndex == ItemSource.Count - 1)
            {
                SelectedIndex = 0;
            }
            else
            {
                SelectedIndex++;
            }
            SelectedItem = ItemSource[SelectedIndex];
        }

        private void Left_Swiped(object sender, SwipedEventArgs e)
        {
            if(SelectedIndex == 0)
            {
                SelectedIndex = ItemSource.Count - 1;
            }
            else
            {
                SelectedIndex--;
            }
            SelectedItem = ItemSource[SelectedIndex];
        }
    }

}
