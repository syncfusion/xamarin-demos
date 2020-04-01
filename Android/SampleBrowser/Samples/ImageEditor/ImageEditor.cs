#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Syncfusion.SfImageEditor.Android;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Content;
using Android.Provider;
using Java.IO;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;


namespace SampleBrowser
{
    public class ImageEditor : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }
        public static int Image { get; set; }
        ImageButton imageview3;
        ImageButton imageview4;
        ImageButton imageview5;
        Context con { get; set; }

    
        void View_LayoutChange(object sender, View.LayoutChangeEventArgs e)
        {
            var height = GetImageHeight(imageview3, view.Width / 3);
            imageview3.LayoutParameters=new TableRow.LayoutParams((int)view.Width / 3,(int)height);
            imageview4.LayoutParameters = new TableRow.LayoutParams((int)view.Width / 3, (int)height);
            imageview5.LayoutParameters = new TableRow.LayoutParams((int)view.Width / 3, (int)height);
        }


        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            con = context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.GettingStartedImageEditor, null);

            imageview3 = view.FindViewById<ImageButton>(Resource.Id.imageview3);
            imageview4 = view.FindViewById<ImageButton>(Resource.Id.imageview4);
            imageview5 = view.FindViewById<ImageButton>(Resource.Id.imageview5);
            view.LayoutChange -= View_LayoutChange;
            view.LayoutChange+= View_LayoutChange;
            imageview3.Click += pictureOnClick1;
            imageview4.Click += pictureOnClick2;
            imageview5.Click += pictureOnClick3;
            LinearLayout layout = new LinearLayout(context);
            return view;
        }


        public void pictureOnClick1(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(SfImageEditorActivity));
            Image = Resource.Drawable.imageedit2;
        }

        public void pictureOnClick2(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(SfImageEditorActivity));
            Image = Resource.Drawable.imageedit3;
        }

        public void pictureOnClick3(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(SfImageEditorActivity));
            Image = Resource.Drawable.imageedit4;
        }

        private float GetImageHeight(ImageButton button, float renderWidth)
        {
            float originalWidth = 216;

            float originalHeight = 319;

            float renderedHeight = (renderWidth * originalHeight) / originalWidth;

            return renderedHeight;
        }

        [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
          Icon = "@drawable/icon")]
        public class SfImageEditorActivity : Activity
        {

            protected override void OnCreate(Bundle savedInstanceState)
            {
                SfImageEditor editor = new SfImageEditor(this);
                var bitmap = BitmapFactory.DecodeResource(Resources, ImageEditor.Image);
                editor.Bitmap = bitmap;
                SetContentView(editor);
                base.OnCreate(savedInstanceState);
            }

        }
    }
}
