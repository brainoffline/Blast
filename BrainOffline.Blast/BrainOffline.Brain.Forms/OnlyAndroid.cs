using Xamarin.Forms;

namespace BrainOffline.Brain.Forms
{
    public static class OnlyAndroid
    {
        private static readonly bool IsAndroid = Device.RuntimePlatform == Device.Android;

        public static readonly BindableProperty MarginProperty = BindableProperty.CreateAttached(
            propertyName: "Margin",
            returnType: typeof(Thickness),
            declaringType: typeof(OnlyAndroid),
            defaultValue: default(Thickness),
            propertyChanged: MarginPropertyChanged);

        public static Thickness GetMargin(View view) => (Thickness)view.GetValue(MarginProperty);
        public static void SetMargin(View view, Thickness value) => view.SetValue(MarginProperty, value);

        public static void MarginPropertyChanged(BindableObject obj, object _, object newValue)
        {
            if (IsAndroid)
                ((View)obj).Margin = (Thickness)newValue;
        }

        public static readonly BindableProperty PaddingProperty = BindableProperty.CreateAttached(
            propertyName: "Padding",
            returnType: typeof(Thickness),
            declaringType: typeof(OnlyAndroid),
            defaultValue: default(Thickness),
            propertyChanged: PaddingPropertyChanged);

        public static Thickness GetPadding(Layout layout) => (Thickness)layout.GetValue(PaddingProperty);
        public static void SetPadding(Layout layout, Thickness value) => layout.SetValue(PaddingProperty, value);

        public static void PaddingPropertyChanged(BindableObject obj, object _, object newValue)
        {
            if (IsAndroid)
                ((Layout)obj).Padding = (Thickness)newValue;
        }
    }
}
