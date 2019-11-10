using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class CheckBoxLabel: StackLayout
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
        
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; lb.Text = Text; }
        }

        public event EventHandler<EventArgs> Checked;
        public event EventHandler<EventArgs> UnChecked;
        private CheckBox checkBox;
        private Label lb;
        public CheckBoxLabel()
        {
            Orientation = StackOrientation.Horizontal;
            checkBox = new CheckBox();
            checkBox.UnChecked += CheckBox_UnChecked;
            checkBox.Checked += CheckBox_Checked;
            Children.Add(checkBox);
            lb = new Label()
            {
                Margin = new Thickness(0),
            };
            Children.Add(lb);

            this.GestureRecognizers.Add(new TapGestureRecognizer() {
                Command = new Command(()=> {
                    checkBox.HandleCheck();
                })
            });
            
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            IsChecked = checkBox.IsChecked;
            Checked?.Invoke(this, e);
        }

        private void CheckBox_UnChecked(object sender, EventArgs e)
        {
            IsChecked = checkBox.IsChecked;
            UnChecked?.Invoke(this, e);
        }
    }
}
