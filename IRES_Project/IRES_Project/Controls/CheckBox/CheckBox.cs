using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class CheckBox: Frame
    {
        public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(CheckBox),
        false);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); if (value == true) Checked?.Invoke(this, EventArgs.Empty); else UnChecked?.Invoke(this, EventArgs.Empty); }
        }

        public static readonly BindableProperty CheckedColorProperty =
        BindableProperty.Create(
        nameof(CheckedColor),
        typeof(Color),
        typeof(CheckBox),
        Color.FromHex("#13c200"));

        public Color CheckedColor
        {
            get { return (Color)GetValue(CheckedColorProperty); }
            set { SetValue(CheckedColorProperty, value);}
        }

        public static readonly BindableProperty UnCheckedColorProperty =
        BindableProperty.Create(
        nameof(UnCheckedColor),
        typeof(Color),
        typeof(CheckBox),
        Color.White);

        public Color UnCheckedColor
        {
            get { return (Color)GetValue(UnCheckedColorProperty); }
            set { SetValue(UnCheckedColorProperty, value); }
        }

        public event EventHandler<EventArgs> Checked;
        public event EventHandler<EventArgs> UnChecked;

        private string priText = "\uf021";
        private Label label;
        
        public CheckBox()
        {
            IsChecked = false;
            Padding = new Thickness(0);
            Margin = new Thickness(0);
            HeightRequest = 20;
            WidthRequest = 20;
            BorderColor = CheckedColor;
            BackgroundColor = UnCheckedColor;
            //BorderWidth = 2;
            VerticalOptions = LayoutOptions.End;
            HorizontalOptions = LayoutOptions.Center;
            CornerRadius = 5;
            //FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont";
            //this.Clicked += CheckBox_Clicked;

            label = new Label()
            {
                FontFamily = Device.RuntimePlatform == Device.Android ? "icofont.ttf#icofont" : "icofont",
                Margin = new Thickness(0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 15
            };
            Content = label;
            this.GestureRecognizers.Add(new TapGestureRecognizer() {
                Command = new Command(()=> {
                    HandleCheck();
                })
            });

        }

        public void HandleCheck()
        {
            IsChecked = !IsChecked;
            if (IsChecked)
            {
                label.Text = priText;
                BackgroundColor = CheckedColor;
                label.TextColor = UnCheckedColor;
            }
            else
            {
                label.Text = "";
                BackgroundColor = UnCheckedColor;
                label.TextColor = CheckedColor;
            }
        }
    }
}
