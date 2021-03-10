using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Licenses.CustomRenderer;
using Licenses.Droid.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(handler: typeof(CustomEntry), target: typeof(CustomEntryDroid))]

namespace Licenses.Droid.CustomRenderer
{
    public class CustomEntryDroid: EntryRenderer
    {
        public CustomEntryDroid(Context context) : base(context)
        {

        }

        public CustomEntry ElementV2 => Element as CustomEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var grad = new GradientDrawable();
                //grad.SetColor(Element.BackgroundColor.ToAndroid());

                grad.SetCornerRadius(60);
                grad.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
                grad.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());

                #region Padding
                //Padding

                var padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
                var padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
                var padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
                var padRight = (int)Context.ToPixels(ElementV2.Padding.Right);

                Control.SetPadding(padLeft, padTop, padRight, padBottom);
                #endregion

                #region Background
                //Background
                Control.SetBackground(grad);
                #endregion

                #region PlaceholderColor
                //PlaceHolderColor
                Control.SetHintTextColor(Android.Graphics.Color.DarkGray);
                #endregion

                //Set Solid Background Color
                //Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);

                #region Cursor
                //Cursor Color
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

                // my_cursor is the xml file name which we defined above
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.MyCursor);
                #endregion

                Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Neris-Light.otf");
                Control.TextSize = 14f;
                Control.Typeface = font;
            }
        }
    }
}