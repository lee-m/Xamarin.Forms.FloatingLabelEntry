using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.FloatingLabelEntry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingLabelEntry : ContentView
    {
        private readonly double _floatingFontSize;
        private readonly double _floatingTranslationAmount;
        private readonly bool _initialised;

        private Color? _tintColour;
        private bool _isFocused;

        private static readonly Color SeventyPercentGrey = Color.FromHex("#B2B2B2");
        private static readonly Color DefaultErrorColour = Color.FromHex("#C46B6B");

        private const double AndroidDefaultFontSize = 14;
        private const double iOSDefaultFontSize = 17;

        private const string FocusedFloatingLabelTransition = "FocusedFloatingLabelTransition";
        private const string UnfocusedFloatingLabelTransition = "UnfocusedFloatingLabelTransition";

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingLabelEntry), null, BindingMode.TwoWay);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(FloatingLabelEntry),
                                    defaultValueCreator: bindable => Device.RuntimePlatform == Device.Android ? AndroidDefaultFontSize : iOSDefaultFontSize);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FloatingLabelEntry));

        public static readonly BindableProperty PlaceholderColourProperty =
            BindableProperty.Create(nameof(PlaceholderColour), typeof(Color), typeof(FloatingLabelEntry), SeventyPercentGrey);

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FloatingLabelEntry));

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingLabelEntry));

        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(FloatingLabelEntry));

        public static readonly BindableProperty BeginEditCommandProperty =
            BindableProperty.Create(nameof(BeginEditCommand), typeof(ICommand), typeof(FloatingLabelEntry));

        public static readonly BindableProperty BeginEditCommandParameterProperty =
            BindableProperty.Create(nameof(BeginEditCommandParameter), typeof(object), typeof(FloatingLabelEntry));

        public static readonly BindableProperty EndEditCommandProperty =
            BindableProperty.Create(nameof(EndEditCommand), typeof(ICommand), typeof(FloatingLabelEntry));

        public static readonly BindableProperty EndEditCommandParameterProperty =
            BindableProperty.Create(nameof(EndEditCommandParameter), typeof(object), typeof(FloatingLabelEntry));

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(FloatingLabelEntry), int.MaxValue);

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(FloatingLabelEntry));

        public static readonly BindableProperty ClearButtonVisibilityProperty =
            BindableProperty.Create(nameof(ClearButtonVisibility), typeof(ClearButtonVisibility), typeof(FloatingLabelEntry));

        public static readonly BindableProperty BorderColourProperty =
            BindableProperty.Create(nameof(BorderColour), typeof(Color), typeof(FloatingLabelEntry), SeventyPercentGrey);

        public static readonly BindableProperty HighlightColourProperty =
            BindableProperty.Create(nameof(HighlightColour), typeof(Color), typeof(FloatingLabelEntry));

        public static readonly BindableProperty TextColourProperty =
            BindableProperty.Create(nameof(TextColour), typeof(Color), typeof(FloatingLabelEntry));

        public static readonly BindableProperty ClearButtonColourProperty =
            BindableProperty.Create(nameof(ClearButtonColour), typeof(Color), typeof(FloatingLabelEntry));

        public static readonly BindableProperty ErrorColourProperty =
            BindableProperty.Create(nameof(ErrorColour), typeof(Color), typeof(FloatingLabelEntry), DefaultErrorColour);

        public static readonly BindableProperty IsErrorProperty =
            BindableProperty.Create(nameof(IsError), typeof(bool), typeof(FloatingLabelEntry), false);

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(FloatingLabelEntry));

        public static readonly BindableProperty TintIconProperty =
            BindableProperty.Create(nameof(TintIcon), typeof(bool), typeof(FloatingLabelEntry), true, propertyChanged: OnTintIconPropertyChanged);

        public FloatingLabelEntry()
        {
            InitializeComponent();

            _floatingFontSize = 11f;
            _floatingTranslationAmount = Device.RuntimePlatform == Device.iOS ? -8 : -10;
            _initialised = true;
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public Color PlaceholderColour
        {
            get => (Color)GetValue(PlaceholderColourProperty);
            set => SetValue(PlaceholderColourProperty, value);
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public ICommand TextChangedCommand
        {
            get => (ICommand)GetValue(TextChangedCommandProperty);
            set => SetValue(TextChangedCommandProperty, value);
        }

        public ICommand BeginEditCommand
        {
            get => (ICommand)GetValue(BeginEditCommandProperty);
            set => SetValue(BeginEditCommandProperty, value);
        }

        public object BeginEditCommandParameter
        {
            get => GetValue(BeginEditCommandParameterProperty);
            set => SetValue(BeginEditCommandParameterProperty, value);
        }

        public ICommand EndEditCommand
        {
            get => (ICommand)GetValue(EndEditCommandProperty);
            set => SetValue(EndEditCommandProperty, value);
        }

        public object EndEditCommandParameter
        {
            get => GetValue(EndEditCommandParameterProperty);
            set => SetValue(EndEditCommandParameterProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public ClearButtonVisibility ClearButtonVisibility
        {
            get => (ClearButtonVisibility)GetValue(ClearButtonVisibilityProperty);
            set => SetValue(ClearButtonVisibilityProperty, value);
        }

        public Color BorderColour
        {
            get => (Color)GetValue(BorderColourProperty);
            set => SetValue(BorderColourProperty, value);
        }

        public Color HighlightColour
        {
            get => (Color)GetValue(HighlightColourProperty);
            set => SetValue(HighlightColourProperty, value);
        }

        public Color TextColour
        {
            get => (Color)GetValue(TextColourProperty);
            set => SetValue(TextColourProperty, value);
        }

        public Color ClearButtonColour
        {
            get => (Color)GetValue(ClearButtonColourProperty);
            set => SetValue(ClearButtonColourProperty, value);
        }

        public Color ErrorColour
        {
            get => (Color)GetValue(ErrorColourProperty);
            set => SetValue(ErrorColourProperty, value);
        }

        public bool IsError
        {
            get => (bool)GetValue(IsErrorProperty);
            set => SetValue(IsErrorProperty, value);
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public bool TintIcon
        {
            get => (bool)GetValue(TintIconProperty);
            set => SetValue(TintIconProperty, value);
        }

        public Thickness EntryMargin
        {
            get
            {
                if (!string.IsNullOrEmpty(Icon))
                    return Device.RuntimePlatform == Device.Android
                        ? new Thickness(0, 16, 8, 0)
                        : new Thickness(4, 18, 0, 2);

                return Device.RuntimePlatform == Device.Android
                    ? new Thickness(8, 16, 8, 0)
                    : new Thickness(4, 18, 0, 2);
            }
        }

        public Thickness PlaceholderPadding
        {
            get
            {
                if (!string.IsNullOrEmpty(Icon))
                    return new Thickness(4, 0, 0, 0);

                return Device.RuntimePlatform == Device.Android
                    ? new Thickness(12, 0, 0, 0)
                    : new Thickness(4, 0, 0, 0);
            }
        }

        public Color? TintColour
        {
            get => _tintColour;
            set
            {
                _tintColour = value;
                OnPropertyChanged();
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (!_initialised)
                return;

            if (propertyName == nameof(Text))
                UpdateText();
            else if (propertyName == nameof(IsError))
                UpdateErrorState();
            else if (propertyName == nameof(TextColour))
                UpdateTextColour();
            else if (propertyName == nameof(ClearButtonColour))
                UpdateClearButtonColour();
            else if (propertyName == nameof(BackgroundColor))
                UpdateBackgroundColour();
            else if (propertyName == nameof(Icon))
                UpdateIconVisibility();
            else if (propertyName == nameof(IsError)
                    || propertyName == nameof(IsFocused)
                    || propertyName == nameof(ErrorColour)
                    || propertyName == nameof(HighlightColour)
                    || propertyName == nameof(TintIcon))
            {
                UpdateTintColour();
            }
        }

        private void UpdateTintColour()
        {
            if (IsError)
                TintColour = ErrorColour;
            else if (_isFocused)
                TintColour = HighlightColour;
            else
                TintColour = null;
        }

        private void OnEntryViewFocused(object sender, FocusEventArgs e)
        {
            _isFocused = e.IsFocused;

            if (string.IsNullOrEmpty(EntryView.Text))
                FloatPlaceholderLabel(true);

            UpdateTintColour();
            ContainerFrame.BorderColor = IsError ? ErrorColour : HighlightColour;

            if (IsError)
                return;

            PlaceholderLabel.Opacity = 0;

            if (BeginEditCommand?.CanExecute(BeginEditCommandParameter) ?? false)
                BeginEditCommand.Execute(BeginEditCommandParameter);
        }

        private void OnEntryViewUnfocused(object sender, FocusEventArgs e)
        {
            _isFocused = e.IsFocused;

            if (string.IsNullOrEmpty(EntryView.Text))
                UnfloatPlaceholderLabel(true);

            UpdateTintColour();

            ContainerFrame.BorderColor = IsError ? ErrorColour : BorderColour;
            PlaceholderLabel.Opacity = 1;

            if (EndEditCommand?.CanExecute(EndEditCommandParameter) ?? false)
                EndEditCommand.Execute(EndEditCommandParameter);
        }

        private static void OnTintIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //If the value of TintIcon changes whilst we are focused we need to clear the tint on the icon whilst 
            //preserving the other tints so communicate to the platform effects that the tint needs updating
            ((FloatingLabelEntry)bindable).OnPropertyChanged(nameof(TintColour));
        }

        private void OnEntryViewTextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangedCommand?.Execute(null);

            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                //May be unfloating the placeholder from losing focus. If any sort of validation is being
                //done and a new value being set then things get a bit wonky
                this.AbortAnimation(UnfocusedFloatingLabelTransition);
                FloatPlaceholderLabel(false);
            }
        }

        private void OnContainerFrameTapped(object sender, EventArgs e)
        {
            EntryView.Focus();
        }

        private void UpdateText()
        {
            if (EntryView.IsFocused)
                return;

            if (!string.IsNullOrEmpty(Text))
                FloatPlaceholderLabel(false);
            else
                UnfloatPlaceholderLabel(false);
        }

        private void UpdateErrorState()
        {
            if (IsError)
                SetErrorState();
            else
                ClearError();

            UpdateTintColour();
        }

        private void UpdateTextColour()
        {
            EntryView.TextColor = TextColour;
        }

        private void UpdateClearButtonColour()
        {
            EntryView.ClearButtonColour = ClearButtonColour;
        }

        private void UpdateBackgroundColour()
        {
            ContainerFrame.BackgroundColor = BackgroundColor;
        }

        private void UpdateIconVisibility()
        {
            IconImage.IsVisible = !string.IsNullOrEmpty(Icon);

            OnPropertyChanged(nameof(EntryMargin));
            OnPropertyChanged(nameof(PlaceholderPadding));
        }

        private void FloatPlaceholderLabel(bool animated)
        {
            //If we're focused, "hide" the placeholder label by making it invisible so that the 
            //tinted highlight label shows through
            var placeholderOpacity = _isFocused ? 0 : 1;

            if (animated)
            {
                //We overlay another label with its text colour set to the highlight value. To achieve an animated transition between the default
                //and highlight colour we animate both labels to the floating position but also animate the placeholder label's opacity to gradually 
                //show the highlight label
                var transitionAnimation = new Animation
                {
                    { 0, 1, new Animation(t => PlaceholderLabel.TranslationY = t, 0, _floatingTranslationAmount) },
                    { 0, 1, new Animation(t => PlaceholderLabel.FontSize = t, PlaceholderLabel.FontSize, _floatingFontSize) },
                    { 0, 1, new Animation(t => PlaceholderLabel.Opacity = t, PlaceholderLabel.Opacity, placeholderOpacity) },

                    { 0, 1, new Animation(t => HighlightPlaceholderLabel.TranslationY = t, 0, _floatingTranslationAmount) },
                    { 0, 1, new Animation(t => HighlightPlaceholderLabel.FontSize = t, HighlightPlaceholderLabel.FontSize, _floatingFontSize) }
                };

                transitionAnimation.Commit(this, FocusedFloatingLabelTransition, 16, 250, Easing.SinInOut);
            }
            else
            {
                PlaceholderLabel.TranslationY = _floatingTranslationAmount;
                PlaceholderLabel.FontSize = _floatingFontSize;
                PlaceholderLabel.Opacity = placeholderOpacity;

                HighlightPlaceholderLabel.TranslationY = _floatingTranslationAmount;
                HighlightPlaceholderLabel.FontSize = _floatingFontSize;
            }
        }

        private void UnfloatPlaceholderLabel(bool animated)
        {
            if (animated)
            {
                var transitionAnimation = new Animation
                {
                    { 0, 1, new Animation(t => PlaceholderLabel.TranslationY = t, PlaceholderLabel.TranslationY, 0) },
                    { 0, 1, new Animation(t => PlaceholderLabel.FontSize = t, PlaceholderLabel.FontSize, FontSize) },
                    { 0, 1, new Animation(t => PlaceholderLabel.Opacity = t, PlaceholderLabel.Opacity, 1) },

                    { 0, 1, new Animation(t => HighlightPlaceholderLabel.TranslationY = t, HighlightPlaceholderLabel.TranslationY, 0) },
                    { 0, 1, new Animation(t => HighlightPlaceholderLabel.FontSize = t, HighlightPlaceholderLabel.FontSize, FontSize) }
                };

                transitionAnimation.Commit(this, UnfocusedFloatingLabelTransition, 16, 250, Easing.SinInOut);
            }
            else
            {
                PlaceholderLabel.TranslationY = 0;
                PlaceholderLabel.FontSize = FontSize;
                PlaceholderLabel.Opacity = 1;

                HighlightPlaceholderLabel.TranslationY = 0;
                HighlightPlaceholderLabel.FontSize = FontSize;
            }
        }

        private void SetErrorState()
        {
            ContainerFrame.BorderColor = ErrorColour;
            PlaceholderLabel.TextColor = ErrorColour;
            HighlightPlaceholderLabel.TextColor = ErrorColour;
            EntryView.ClearButtonColour = ErrorColour;
        }

        private void ClearError()
        {
            ContainerFrame.BorderColor = _isFocused ? HighlightColour : BorderColour;
            PlaceholderLabel.TextColor = BorderColour;
            HighlightPlaceholderLabel.TextColor = HighlightColour;
            EntryView.ClearButtonColour = HighlightColour;
        }
    }
}