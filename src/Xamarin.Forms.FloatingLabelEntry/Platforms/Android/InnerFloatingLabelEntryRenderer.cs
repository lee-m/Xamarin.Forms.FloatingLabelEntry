using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;

using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class InnerFloatingLabelEntryRenderer : EntryRenderer
    {
        public InnerFloatingLabelEntryRenderer(Context context) : base(context)
        { }

        protected override Drawable GetCloseButtonDrawable()
        {
            var ctrl = (InnerFloatingLabelEntry)Element;

            var drawable = base.GetCloseButtonDrawable();
            drawable.SetColorFilter(new PorterDuffColorFilter(ctrl.ClearButtonColour.ToAndroid(), PorterDuff.Mode.SrcAtop));

            return drawable;
        }
    }
}
