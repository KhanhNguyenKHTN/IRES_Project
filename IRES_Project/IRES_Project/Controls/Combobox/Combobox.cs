using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class Combobox: Frame
    {
        public static readonly BindableProperty ItemSourceProperty =
        BindableProperty.Create(
        nameof(ItemSource),
        typeof(ObservableCollection<object>),
        typeof(Combobox),
        new ObservableCollection<object>());

        public ObservableCollection<object> ItemSource
        {
            get { return (ObservableCollection<object>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); Picker.ItemsSource = value; }
        }


        public PickerLessBorder Picker { get; set; }
        public Combobox()
        {
            base.Padding = 0;
            Padding = new Thickness(7,0,2,0);

            CornerRadius = 5;
            Grid content = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition() { Width = GridLength.Star}, new ColumnDefinition() { Width = GridLength.Auto} },
                ColumnSpacing = 0
            };
            Label lb = new Label()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                Text = "\uea67",
                VerticalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.White,
                Margin = new Thickness(0)
            };
            content.Children.Add(lb);
            Grid.SetColumn(lb, 0);

            Picker = new PickerLessBorder()
            {
                ItemsSource = ItemSource,             
                WidthRequest = this.Width,
                HeightRequest = this.Height,
                FontSize = 17
            };
            content.Children.Add(Picker);
            Grid.SetColumn(Picker, 0);
            
            Content = content;
            
        }
    }

}
