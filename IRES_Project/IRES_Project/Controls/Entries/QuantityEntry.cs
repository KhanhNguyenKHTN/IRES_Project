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
                BackgroundColor = this.BackgroundColor,
                Text = "\uef9a",
                TextColor = Color.FromHex("#00DFF7"),
                WidthRequest = 35,
                BorderColor = Color.LightGray
            };
            minus.Clicked += (s, e) => { if (Quantity != 0) Quantity--; };
            Button add = new Button()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                BackgroundColor = this.BackgroundColor,
                Text = "\uefc2",
                TextColor = Color.FromHex("#00DFF7"),
                WidthRequest = 35,
                BorderColor = Color.LightGray
            };
            add.Clicked += (s, e) => { Quantity++; };
            BorderEntry entry = new BorderEntry()
            {
                IsCurvedCornersEnabled = true,
                CornerRadius = 0,
                BorderWidth = 1,
                BorderColor = add.BorderColor,
                HorizontalTextAlignment = TextAlignment.Center,    
                Keyboard = Keyboard.Numeric
            };
            
            entry.SetBinding(Entry.TextProperty, new Binding() {Source  = this, Path="Quantity", Mode=BindingMode.TwoWay});

            this.Children.Add(minus);
            Grid.SetColumn(minus, 0);

            this.Children.Add(add);
            Grid.SetColumn(add, 2);

            this.Children.Add(entry);
            Grid.SetColumn(entry, 1);

        }
    }
}
