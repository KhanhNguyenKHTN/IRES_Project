using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class ButtonWithContent: Frame
    {
        //get comamnd
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ButtonWithContent),
            null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        //get comamnd Parameter
        public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(object),
            typeof(ButtonWithContent),
            null);

        public object CommandParameter
        {
            get { return (ICommand)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public event EventHandler<EventArgs> Clicked;

        public ButtonWithContent()
        {
            base.Padding = new Thickness(0);
            base.BorderColor = BackgroundColor;


            this.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => {
                    Clicked?.Invoke(this, EventArgs.Empty);

                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParameter))
                            Command.Execute(CommandParameter);
                    }
                })
            });
        }
    }
}
