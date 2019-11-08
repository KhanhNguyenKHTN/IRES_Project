using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IRES_Project.Controls.PickerLessBorder), typeof(IRES_Project.iOS.Renderers.PickerLessBorderRenderer))]
namespace IRES_Project.iOS.Renderers
{
    class PickerLessBorderRenderer: PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (IRES_Project.Controls.PickerLessBorder)Element;
                Control.Layer.BorderWidth = 0;
                Control.LeftView = new UIView(new CGRect(1f, 1f, 35f, 1f));
                Control.ClipsToBounds = true;
            }
        }
    }
}