using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IRES_Project.Controls
{
    public class ButtonWithContent: Frame
    {
        //IsEffect
        public static readonly BindableProperty IsHasEffectProperty =
        BindableProperty.Create(
            nameof(IsHasEffect),
            typeof(bool),
            typeof(ButtonWithContent),
            true);

        public bool IsHasEffect
        {
            get { return (bool)GetValue(IsHasEffectProperty); }
            set { SetValue(IsHasEffectProperty, value); }
        }

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
                Command = new Command(async() => {
                    await Preferences_Clicked();
                    Clicked?.Invoke(this, EventArgs.Empty);
                    if (Command != null)
                    {
                        if (Command.CanExecute(CommandParameter))
                            Command.Execute(CommandParameter);
                    }
                })
            });
        }
        public async Task<bool>  Preferences_Clicked()
        {
            if (!IsHasEffect) return true;
            const int _animationTime = 50;
            try
            {
                await this.FadeTo(0.5, _animationTime);
                await this.FadeTo(1, _animationTime);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
