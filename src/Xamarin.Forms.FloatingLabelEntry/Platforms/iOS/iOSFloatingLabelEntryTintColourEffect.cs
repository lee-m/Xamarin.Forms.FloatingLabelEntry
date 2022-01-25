using System.ComponentModel;

using UIKit;

using Xamarin.Forms.FloatingLabelEntry.Extensions;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class iOSFloatingLabelEntryTintColourEffect : PlatformEffect
    {
        public iOSFloatingLabelEntryTintColourEffect()
        { }

        protected override void OnAttached()
        {
            FloatingLabelEntry.PropertyChanged += Element_PropertyChanged;
            UpdateTintColour();
        }

        protected override void OnDetached()
        {
            FloatingLabelEntry.PropertyChanged -= Element_PropertyChanged;
            ClearTintColour();
        }


        private void UpdateTintColour()
        {
            if (FloatingLabelEntry.TintColour == null)
                ClearTintColour();
            else
                SetTintColour();
        }

        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(FloatingLabelEntry.TintColour))
                return;

            UpdateTintColour();
        }

        private void ClearTintColour()
        {
            if (Control is UIImageView imageView)
                imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
            else 
                Control.TintColor = null;
        }

        private void SetTintColour()
        {
            if(Control is UIImageView imageView && FloatingLabelEntry.TintIcon)
                imageView.Image = imageView.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

            Control.TintColor = FloatingLabelEntry.TintColour?.ToUIColor();
        }

        private FloatingLabelEntry FloatingLabelEntry => Element.GetParent<FloatingLabelEntry>();
    }
}
