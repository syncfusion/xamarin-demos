#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomControls = SampleBrowser.SfImageEditor.CustomControls;
using Xamarin.Forms;
using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms.Platform.Android;
using Syncfusion.SfImageEditor.XForms.Droid;
using SampleBrowser.SfImageEditor.Droid.Renderers;
using Android.Support.V4.App;
using Android;
using Android.Content.PM;
using System.Threading.Tasks;
using System.IO;
#if COMMONSB
using Resource = SampleBrowser.Droid.Resource;
#endif


[assembly:ExportRenderer(typeof(CustomControls.CustomEditor), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomEditorRenderer))]
[assembly:ExportRenderer(typeof(CustomControls.RoundedColorButton), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.ColorButtonRenderer))]
[assembly: ExportRenderer(typeof(CustomControls.CustomButton), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomButtonRenderer))]
[assembly: Dependency(typeof(CustomImageView))]
[assembly: ExportRenderer(typeof(CustomControls.CustomImageView),typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomImageViewRenderer))]
[assembly: ExportRenderer(typeof(SampleBrowser.SfImageEditor.CustomImageEditor), typeof(SampleBrowser.SfImageEditor.Droid.Renderers.CustomViewEditorRenderer))]

namespace SampleBrowser.SfImageEditor.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var element = (CustomControls.CustomEditor)e.NewElement;
                Control.Hint = element.WatermarkText;
                Control.Gravity = GravityFlags.Center;
                Control.SetHintTextColor(Color.White.ToAndroid());
                GradientDrawable gd = new GradientDrawable();
                float density = (float)Context.Resources.DisplayMetrics.Density;
                gd.SetCornerRadius(15 * density);
                gd.SetStroke(2, Color.LightGray.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }

    public class ColorButtonRenderer : ButtonRenderer
    {
        public ColorButtonRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = (CustomControls.RoundedColorButton)e.NewElement;
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(30);
                gd.SetColor(element.BackgroundColor.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }


    public class CustomButtonRenderer : ButtonRenderer
    {

        public CustomButtonRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = (CustomControls.CustomButton)e.NewElement;
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(0);
                gd.SetColor(element.BackgroundColor.ToAndroid());
                this.Control.SetBackground(gd);
            }
        }
    }
    public class CustomImageViewRenderer:ImageRenderer
    {
        private static int PERMISSION_REQUEST_CODE = 200;
        string permission =  Manifest.Permission.ReadExternalStorage;
        string writePermission = Manifest.Permission.WriteExternalStorage;
        static bool permissionEnabled = false;
        public CustomImageViewRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (!permissionEnabled)
            {
                EnableReadWritePermission();
                permissionEnabled = true;
            }
        }
        public void EnableReadWritePermission()
        {
            if (ActivityCompat.CheckSelfPermission(this.Context, permission) != Permission.Granted && ActivityCompat.CheckSelfPermission(this.Context, writePermission) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this.Context as Activity, new String[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, PERMISSION_REQUEST_CODE);
            }
        }
    }
    public class CustomViewEditorRenderer : SfImageEditorRenderer
    {
        internal static Context NativeContext;
        public CustomViewEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.SfImageEditor.XForms.SfImageEditor> e)
        {
            base.OnElementChanged(e);
            NativeContext = this.Context;
        }
    }
    public class CustomImageView : ICustomViewDependencyService
    {
        public Context  CustomContext { get; set; }
        public object GetCustomView(string imageName, object context)
        {
            ImageView view = new ImageView(CustomViewEditorRenderer.NativeContext);
            view.LayoutParameters = new ViewGroup.LayoutParams(200, 200);
            if (imageName == "Typogy1")
                view.SetImageResource(Resource.Drawable.Typogy1);
            else if (imageName == "Typogy2")
                view.SetImageResource(Resource.Drawable.Typogy2);
            else if (imageName == "Typogy3")
                view.SetImageResource(Resource.Drawable.Typogy3);
            else if (imageName == "Typogy4")
                view.SetImageResource(Resource.Drawable.Typogy4);
            else if (imageName == "Typogy5")
                view.SetImageResource(Resource.Drawable.Typogy5);
            else if (imageName == "Typogy6")
                view.SetImageResource(Resource.Drawable.Typogy6);
            return view;
        }

        public Task<Stream> GetImageSource(string uri)
        {
            return null;
        }
    }

}