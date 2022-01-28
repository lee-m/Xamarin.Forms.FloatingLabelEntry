using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.FloatingLabelEntry;
using Xamarin.Forms.FloatingLabelEntry.Extensions;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(InnerFloatingLabelEntry), typeof(iOSInnerFloatingLabelEntryRenderer))]

namespace Xamarin.Forms.FloatingLabelEntry
{
    public class iOSInnerFloatingLabelEntryRenderer : EntryRenderer
    {
        public iOSInnerFloatingLabelEntryRenderer()
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
