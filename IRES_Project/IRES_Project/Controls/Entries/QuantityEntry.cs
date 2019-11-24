using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class QuantityEntry: Grid, INotifyPropertyChanged
    {
        private int _Quantity = 1;
        public int Quantity { get => _Quantity;set { _Quantity = value; OnPropertyChanged(); } }
        public QuantityEntry()
        {
            this.ColumnSpacing = 0;
            this.ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition() { Width = GridLength.Auto }, new ColumnDefinition() { Width = GridLength.Star }, new ColumnDefinition() { Width = GridLength.Auto } };
            Button minus = new Button()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                BackgroundColor = Color.FromHex("#ffdaa6"),
                Text = "\uef9a",
                TextColor = Color.FromHex("#00DFF7"),
                WidthRequest = 35,
                BorderColor = Color.LightGray,
                Padding =2
            };
            minus.Clicked += (s, e) => { if (Quantity != 0) Quantity--; };
            Button add = new Button()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                BackgroundColor = Color.FromHex("#ffdaa6"),
                Text = "\uefc2",
                TextColor = Color.FromHex("#00DFF7"),
                WidthRequest = 35,
                BorderColor = Color.LightGray,
                Padding = 2
            };
            add.Clicked += (s, e) => { Quantity++; };
            Frame frame = new Frame()
            {
                Padding = new Thickness(2),
                BorderColor = Color.LightGray,
                HasShadow = false,
                CornerRadius = 0
            };

            BorderEntry entry = new BorderEntry()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsCurvedCornersEnabled = true,
                CornerRadius = 0,
                BorderWidth = 0,
                BorderColor = add.BorderColor,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 14,
                isCustomPading = true,
                Top = 2,
                Left = 5,
                Right = 5,
                Bottom = 2,
                Keyboard = Keyboard.Numeric,
            };
            frame.Content = entry;
            
            entry.SetBinding(Entry.TextProperty, new Binding() {Source  = this, Path="Quantity", Mode=BindingMode.TwoWay});

            this.Children.Add(minus);
            Grid.SetColumn(minus, 0);

            this.Children.Add(add);
            Grid.SetColumn(add, 2);

            this.Children.Add(frame);
            Grid.SetColumn(frame, 1);

        }
    }
}
