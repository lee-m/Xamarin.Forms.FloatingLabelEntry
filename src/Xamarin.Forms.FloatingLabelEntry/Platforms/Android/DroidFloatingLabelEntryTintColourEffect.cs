using System.ComponentModel;

using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;

using AndroidX.Core.Graphics;

using Xamarin.Forms.FloatingLabelEntry.Extensions;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class DroidFloatingLabelEntryTintColourEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            FloatingLabelEntry.PropertyChanged += Element_PropertyChanged;
            UpdateTintColour();
        }

        protected override void OnDetached()
        {
            FloatingLabelEntry.PropertyChanged -= Element_PropertyChanged;
            ClearDrawableTintColour();
        }

        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(FloatingLabelEntry.TintColour))
                return;

            UpdateTintColour();
        }

        private void UpdateTintColour()
        {
            if (FloatingLabelEntry.TintColour == null)
                ClearDrawableTintColour();
            else
                SetDrawableTintColour(FloatingLabelEntry.TintColour.Value);
        }

        private void SetDrawableTintColour(Color tintColour)
        {
            var tintColourARGB = tintColour.ToAndroid().ToArgb();

            if (Control is ImageView imageView)
            {
                //We may want to tint the entry itself but not the icon in some cases
                if (FloatingLabelEntry.TintIcon)
                    imageView.SetColorFilter(BlendModeColorFilterCompat.CreateBlendModeColorFilterCompat(tintColourARGB, BlendModeCompat.SrcAtop));
                else
                    imageView.SetColorFilter(null);
            }
            else if (Control is EditText editText && Build.VERSION.SdkInt >= BuildVersionCodes.Q)
            {
                var textDrawable = (GradientDrawable)editText.TextCursorDrawable;
                textDrawable.SetColorFilter(BlendModeColorFilterCompat.CreateBlendModeColorFilterCompat(tintColourARGB, BlendModeCompat.SrcAtop));
            }
        }

        private void ClearDrawableTintColour()
        {
            if (Control is ImageView imageView)
                imageView.SetColorFilter(null);
            else if (Control is EditText editText && Build.VERSION.SdkInt >= BuildVersionCodes.Q)
            {
                var textDrawable = (GradientDrawable)editText.TextCursorDrawable;
                textDrawable.SetColorFilter(null);
            }
        }

        private FloatingLabelEntry FloatingLabelEntry => Element.GetParent<FloatingLabelEntry>();
    }
}
