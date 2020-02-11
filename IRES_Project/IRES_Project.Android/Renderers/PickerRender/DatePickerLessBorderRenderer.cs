using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IRES_Project.Controls.Picker;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePickerLessBorder), typeof(IRES_Project.Droid.Renderers.DatePickerLessBorderRenderer))]
namespace IRES_Project.Droid.Renderers
{
    public class DatePickerLessBorderRenderer : DatePickerRenderer
    {
        public DatePickerLessBorderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            var picker = e.NewElement;
            //DatePickerLessBorder date = (DatePickerLessBorder)this.Element;

            if (Control != null)
            {
                // Remove borders
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.LightGray);

                Control.SetBackground(gd);
                Control.SetPadding(65, 1, 1, 1);
            }
        }
    }
}