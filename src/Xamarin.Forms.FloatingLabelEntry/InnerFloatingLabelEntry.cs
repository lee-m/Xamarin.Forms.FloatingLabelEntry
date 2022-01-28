namespace Xamarin.Forms.FloatingLabelEntry
{
    internal class InnerFloatingLabelEntry : Entry
    {
        private static readonly Color NinetyPercentGrey = Color.FromHex("#2D2D2D");

        public static readonly BindableProperty ClearButtonColourProperty =
            BindableProperty.Create(nameof(ClearButtonColour), typeof(Color), typeof(InnerFloatingLabelEntry), NinetyPercentGrey, BindingMode.OneTime);

        public Color ClearButtonColour
        {
            get => (Color)GetValue(ClearButtonColourProperty);
            set => SetValue(ClearButtonColourProperty, value);
        }
    }
}
