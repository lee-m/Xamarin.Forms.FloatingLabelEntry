using Xamarin.Forms;

namespace Xamarin.Forms.FloatingLabelEntry.Extensions
{
    public static class ElementExtensions
    {
        public static TParent GetParent<TParent>(this Element element) where TParent: Element
        {
            var parent = element.Parent;

            while (!(parent is TParent))
                parent = parent.Parent;

            return (TParent)parent;
        }
    }
}
