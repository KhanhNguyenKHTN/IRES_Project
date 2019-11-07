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
using IRES_Project.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PickerLessBorder), typeof(IRES_Project.Droid.Renderers.PickerLessBorderRenderer))]
namespace IRES_Project.Droid.Renderers
{
    class PickerLessBorderRenderer : PickerRenderer
    {
        public PickerLessBorderRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var picker = e.NewElement;
            PickerLessBorder cbb = (PickerLessBorder)this.Element;

            if(Control != null)
            {
                // Remove borders
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.LightGray);
                Control.SetBackground(gd);
                Control.SetPadding(1, 1, 1, 1);
            }
        }
    }
}