using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class Waitting: ContentView
    {
        public Waitting()
        {
            Grid grid = new Grid() { };

            grid.RowDefinitions.Clear();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });

            grid.ColumnDefinitions.Clear();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });

            var ac = new ActivityIndicator() { IsRunning = true, Color = Color.LightBlue };
            grid.Children.Add(ac);
            Grid.SetColumn(ac, 1);
            Grid.SetRow(ac, 1);
            Content = grid;
        }
        public void Show() { this.IsVisible = true; }
        public void Hide() { this.IsVisible = false; }
    }
}
