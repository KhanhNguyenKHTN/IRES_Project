using IRES_Project.Controls.Pickers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class TimePickerIcon:Frame
    {
        public TimePickerLessBorder Picker { get; set; }
        public TimePickerIcon()
        {
            base.Padding = 0;
            Padding = new Thickness(5, 0, 5, 0);

            CornerRadius = 5;
            Grid content = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition() { Width = GridLength.Star }, new ColumnDefinition() { Width = GridLength.Auto } },
                ColumnSpacing = 0
            };
            Label lb = new Label()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                Text = "\uf022",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White,
                Margin = new Thickness(0),
                FontSize = 17
            };

            content.Children.Add(lb);
            Grid.SetColumn(lb, 0);

            Picker = new TimePickerLessBorder()
            {
                WidthRequest = this.Width,
                HeightRequest = this.Height,
                FontSize = 14,
                Time = DateTime.Now.AddHours(1).TimeOfDay

            };

            content.Children.Add(Picker);
            Grid.SetColumn(Picker, 0);

            Content = content;
        }
    }
}
