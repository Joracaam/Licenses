using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Licenses.CustomRenderer
{
    public class CustomPicker: Picker
    {
        public static BindableProperty PaddingPropertyProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomEntry), new Thickness(5));
        public static BindableProperty BackgroundPopupColorProperty = BindableProperty.Create(nameof(BackgroundPopupColor), typeof(Color), typeof(CustomEntry), Color.Transparent);


        public Thickness Padding { get => (Thickness)GetValue(PaddingPropertyProperty); set => SetValue(PaddingPropertyProperty, value); }
        public Color BackgroundPopupColor { get => (Color)GetValue(BackgroundPopupColorProperty); set => SetValue(BackgroundPopupColorProperty, value); }
    }
}
