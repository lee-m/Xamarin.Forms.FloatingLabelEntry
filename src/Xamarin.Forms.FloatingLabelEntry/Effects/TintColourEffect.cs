using Xamarin.Forms;

[assembly: ResolutionGroupName("Xamarin.Forms.FloatingLabelEntry")]

namespace Xamarin.Forms.FloatingLabelEntry.Effects
{
    public class TintColourEffect : RoutingEffect
    {
        public TintColourEffect() : base($"Xamarin.Forms.FloatingLabelEntry.{nameof(TintColourEffect)}")
        { }
    }
}
