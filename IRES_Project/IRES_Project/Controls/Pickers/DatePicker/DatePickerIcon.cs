using IRES_Project.Controls.Picker;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class DatePickerIcon: Frame
    {
        public DatePickerLessBorder Picker { get; set; }
        public DatePickerIcon()
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
                Text = "\uec45",
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White,
                Margin = new Thickness(0,2,0,0),
                FontSize = 17
            };

            content.Children.Add(lb);
            Grid.SetColumn(lb, 0);

            Picker = new DatePickerLessBorder()
            {
                WidthRequest = this.Width,
                HeightRequest = this.Height,
                FontSize = 14,
                Format = "dd/MM/yyyy",
                Date = DateTime.Now.Date
            };
            
            content.Children.Add(Picker);
            Grid.SetColumn(Picker, 0);

            Content = content;
        }
    }
}
