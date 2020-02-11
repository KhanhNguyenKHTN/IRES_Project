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
        public static BindableProperty QuantityProperty =
       BindableProperty.Create(
       nameof(Quantity),
       typeof(int),
       typeof(QuantityEntry),
       1, propertyChanged: OnItemSourceChanged);

        static void OnItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as QuantityEntry;
            entry.QuantityChange?.Invoke(null, null);
        }


        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set
            {
                SetValue(QuantityProperty, value);
            }
        }
        public event EventHandler QuantityChange;

        public QuantityEntry()
        {
            this.ColumnSpacing = 0;
            this.ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition() { Width = GridLength.Auto }, new ColumnDefinition() { Width = GridLength.Star }, new ColumnDefinition() { Width = GridLength.Auto } };
            Button minus = new Button()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                BackgroundColor = Color.LightGray,
                Text = "\uef9a",
                TextColor = Color.Black,//.FromHex("#00DFF7"),
                WidthRequest = 35,
                FontAttributes = FontAttributes.Bold,
                BorderColor = Color.LightGray,
                Padding =2,
                BorderWidth = 1
            };
            minus.Clicked += (s, e) => { if (Quantity != 1) Quantity--; };
            Button add = new Button()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                BackgroundColor = Color.LightGray,
                Text = "\uefc2",
                TextColor = Color.Black,//.FromHex("#00DFF7"),
                WidthRequest = 35,
                BorderColor = Color.LightGray,
                Padding = 2,
                BorderWidth = 1
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
                Padding = new Thickness(5,2,5,2),
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
