
using Android.Content;
using Android.Graphics.Drawables;
using IRES_Project.Controls.Pickers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TimePickerLessBorder), typeof(IRES_Project.Droid.Renderers.TimePickerLessBorderRenderer))]
namespace IRES_Project.Droid.Renderers
{
    public class TimePickerLessBorderRenderer : TimePickerRenderer
    {
        public TimePickerLessBorderRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                // Remove borders
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.LightGray);

                Control.SetBackground(gd);
                Control.SetPadding(50, 1, 1, 1);
            }
        }
    }
}