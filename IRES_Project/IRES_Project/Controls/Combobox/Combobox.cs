using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private bool isFirst = true;
        public Combobox()
        {
            Padding = new Thickness(5,2,0,2);
            CornerRadius = 10;
            Grid content = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition() { Width = GridLength.Star}, new ColumnDefinition() { Width = GridLength.Auto} }
            };
            Picker = new PickerLessBorder()
            {
                ItemsSource = ItemSource,                
            };
            content.Children.Add(Picker);
            Grid.SetColumn(Picker, 0);
            Label lb = new Label()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                Text = "\uea67",
                VerticalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.White,
                
            };
            lb.GestureRecognizers.Clear();
            lb.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Console.WriteLine("ádddddddddddddddd");
                        Picker.Focus();
                    });
                })
            });
            content.Children.Add(lb);
            Grid.SetColumn(lb, 0);
            Content = content;
            
        }
    }
}
