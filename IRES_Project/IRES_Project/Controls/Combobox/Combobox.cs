using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls.Combobox
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
            set { SetValue(ItemSourceProperty, value); }
        }

        public Combobox()
        {
            Padding = 0;
            Grid content = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection() { new ColumnDefinition() { Width = GridLength.Star}, new ColumnDefinition() { Width = GridLength.Auto} }
            };
            Picker pk = new Picker()
            {
                ItemsSource = ItemSource
            };
            
        }
    }
}
