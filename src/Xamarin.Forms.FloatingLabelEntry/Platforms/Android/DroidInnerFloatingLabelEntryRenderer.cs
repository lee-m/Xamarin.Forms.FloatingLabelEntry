using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;

using Xamarin.Forms;
using Xamarin.Forms.FloatingLabelEntry;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(InnerFloatingLabelEntry), typeof(DroidInnerFloatingLabelEntryRenderer))]

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class DroidInnerFloatingLabelEntryRenderer : EntryRenderer
    {
        public DroidInnerFloatingLabelEntryRenderer(Context context) : base(context)
        { }

        protected override FormsEditText CreateNativeControl()
        {
            //Get rid of the underline
            var nativeControl = base.CreateNativeControl();
            nativeControl.SetBackground(null);

            return nativeControl;
        }
        protected override Drawable GetCloseButtonDrawable()
        {
            var ctrl = (InnerFloatingLabelEntry)Element;

            var drawable = base.GetCloseButtonDrawable();
            drawable.SetColorFilter(new PorterDuffColorFilter(ctrl.ClearButtonColour.ToAndroid(), PorterDuff.Mode.SrcAtop));

            return drawable;
        }
    }
}
