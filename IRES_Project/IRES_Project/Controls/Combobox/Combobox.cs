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
        public static BindableProperty ItemSourceProperty =
        BindableProperty.Create(
        nameof(ItemSource),
        typeof(ObservableCollection<object>),
        typeof(Combobox),
        new ObservableCollection<object>(),
        propertyChanged: OnItemSourceChanged);

        static void OnItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var cbb = bindable as Combobox;
            if (cbb == null) return;
            if (cbb.Picker != null) cbb.Picker.ItemsSource = cbb.ItemSource;
        }

        public ObservableCollection<object> ItemSource
        {
            get { return (ObservableCollection<object>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value);}
        }

        //public static BindableProperty SelectedIndexProperty =
        //BindableProperty.Create(
        //nameof(SelectedIndex),
        //typeof(int),
        //typeof(Combobox),
        //0);

        //public int SelectedIndex
        //{
        //    get { return (int)GetValue(SelectedIndexProperty); }
        //    set { SetValue(SelectedIndexProperty, value); if (Picker != null) Picker.SelectedIndex = value; }
        //}

        public static BindableProperty SelectedItemProperty =
        BindableProperty.Create(
        nameof(SelectedItem),
        typeof(object),
        typeof(Combobox),
        0,
        propertyChanged: OnSelectedItemChanged);

        static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var cbb = bindable as Combobox;
            if (cbb == null) return;
            if (cbb.Picker != null) cbb.Picker.SelectedItem = cbb.SelectedItem;
        }
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public event EventHandler<EventArgs> SelectionChanged;
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
                WidthRequest = this.Width,
                HeightRequest = this.Height,
                FontSize = 14
            };
            Picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            content.Children.Add(Picker);
            Grid.SetColumn(Picker, 0);
            
            Content = content;
            
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemSource != null) SelectedItem = ItemSource[Picker.SelectedIndex];

            SelectionChanged?.Invoke(SelectedItem, null);
        }
    }

}
