using UIKit;

using Xamarin.Forms.FloatingLabelEntry.Extensions;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class InnerFloatingLabelEntryRenderer : EntryRenderer
    {
        public InnerFloatingLabelEntryRenderer()
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
           base.OnElementChanged(e);

            if (Element == null)
                return;

            var floatingEntry = Element.GetParent<FloatingLabelEntry>();
            var highlightColour = floatingEntry.HighlightColour;

            Control.TintColor = highlightColour.ToUIColor();
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}
