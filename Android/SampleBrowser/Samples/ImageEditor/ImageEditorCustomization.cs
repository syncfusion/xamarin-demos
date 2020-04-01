#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Views;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.Widget;
using System.Threading.Tasks;
using System.IO;
using Android.Content.Res;
using Android.Util;

namespace SampleBrowser
{
    public class ImageEditorCustomization : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }
        public static Bitmap Image { get; set; }
        Context con { get; set; }
        public static String Name;
        SfImageEditor editor; 
        bool isRect, isText, isPath = false;
        string location = "";
        Share share;
        EditText editText;
        object Settings;

        void Editor_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            Settings = e.Settings;
        }

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {

            var deviceDensity = (int)context.Resources.DisplayMetrics.Density;
            // Set our view from the "main" layout resource
            var layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.EditorCustomization, null);


            FrameLayout mainLayout = view.FindViewById<FrameLayout>
                (Resource.Id.CustomizationMain);

            editor = new SfImageEditor(context);
            editor.Bitmap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.Customize);
            editor.ItemSelected += Editor_ItemSelected;
            editor.ToolbarSettings.IsVisible = false;
            editor.SetBackgroundColor(Color.Black);


            var bottomview = layoutInflater.Inflate(Resource.Layout.BottomView, mainLayout, true);
            var topview = layoutInflater.Inflate(Resource.Layout.TopView, mainLayout, true);
            var rightview = layoutInflater.Inflate(Resource.Layout.RightView, mainLayout, true);


            //Bottom View------------------------------------
            var bottomView = bottomview.FindViewById<LinearLayout>(Resource.Id.bottomView);
            bottomView.SetGravity(GravityFlags.Bottom);
            var bParams = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, 50 * deviceDensity, GravityFlags.Bottom);
            bottomView.SetBackgroundColor(Color.Transparent);
            bParams.SetMargins(0, 0, 0, 10 * deviceDensity);
            bottomView.LayoutParameters = bParams;


            //Top View------------------------------------
            var topView = topview.FindViewById<LinearLayout>(Resource.Id.topView);
            var tParams = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, 50 * deviceDensity, GravityFlags.Top);
            tParams.SetMargins(0, 10 * deviceDensity, 0, 0);
            topView.LayoutParameters = tParams;


            //Right View------------------------------------

            var rightView = rightview.FindViewById<LinearLayout>(Resource.Id.rightView);
            var rParams = new FrameLayout.LayoutParams(65 * deviceDensity, FrameLayout.LayoutParams.MatchParent, GravityFlags.Right);
            rParams.SetMargins(0, 250, 0, 250);
            rightView.SetBackgroundColor(Color.Transparent);
            rightView.SetPadding(0, 0, 15 * deviceDensity, 15 * deviceDensity);
            rightView.LayoutParameters = rParams;
            rightView.Visibility = ViewStates.Invisible;
            topView.Visibility = ViewStates.Invisible;
            mainLayout.RemoveAllViews();
            (mainLayout.Parent as ViewGroup)?.RemoveAllViews();


            mainLayout.AddView(editor);
            mainLayout.AddView(topView);
            mainLayout.AddView(bottomView);
            mainLayout.AddView(rightView);

            Button dummyLayout = new Button(context);
            dummyLayout.SetBackgroundColor(Color.Transparent);
            dummyLayout.Alpha = 0.5F;
            mainLayout.AddView(dummyLayout);
            dummyLayout.Click += (sender, e) =>
            {
                topView.Visibility = ViewStates.Visible;
                dummyLayout.Visibility = ViewStates.Invisible;

            };


            //Top view

            var reset = topView.FindViewById<ImageButton>(Resource.Id.resetButton);
            var undo = topView.FindViewById<ImageButton>(Resource.Id.undoButton);
            var rect = topView.FindViewById<ImageButton>(Resource.Id.rectButton);
            var text = topView.FindViewById<ImageButton>(Resource.Id.textButton);
            var path = topView.FindViewById<ImageButton>(Resource.Id.pathButton);

            reset.Click += (sender, e) =>
            {

                if (editor.IsImageEdited)
                {
                    editor.Reset();
                }
                rightView.Visibility = ViewStates.Invisible;
                topView.Visibility = ViewStates.Invisible;
                dummyLayout.Visibility = ViewStates.Visible;
                isPath = false;
                isText = false;
                isRect = false;

            };
            undo.Click += (sender, e) =>
            {

                if (editor.IsImageEdited)
                {
                    editor.Undo();
                }
            };
            rect.Click += (sender, e) =>
            {
                isPath = false;
                isText = false;
                isRect = true;
                AddShapes();
                rightView.Visibility = ViewStates.Visible;

            };
            text.Click += (sender, e) =>
            {
                isPath = false;
                isRect = false;
                isText = true;
                AddShapes();
                rightView.Visibility = ViewStates.Visible;
            };
            path.Click += (sender, e) =>
            {
                isPath = true;
                isRect = false;
                isText = false;
                rightView.Visibility = ViewStates.Visible;
                editor.AddShape();


            };



            // colorLayout
            var firstBut = rightview.FindViewById<Button>(Resource.Id.firstButton);
            var secondBut = rightview.FindViewById<Button>(Resource.Id.secondButton);
            var thirdBut = rightview.FindViewById<Button>(Resource.Id.thirdButton);
            var fourthBut = rightview.FindViewById<Button>(Resource.Id.fourthButton);
            var fifthBut = rightview.FindViewById<Button>(Resource.Id.fifthButton);
            var sixthBut = rightview.FindViewById<Button>(Resource.Id.sixthButton);
            var seventhBut = rightview.FindViewById<Button>(Resource.Id.seventhButton);
            var eightBut = rightview.FindViewById<Button>(Resource.Id.eightButton);
            var ninthBut = rightview.FindViewById<Button>(Resource.Id.ninthButton);
            var tenthBut = rightview.FindViewById<Button>(Resource.Id.tenthButton);

            firstBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#4472c4");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            secondBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#ed7d31");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            thirdBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#ffc000");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            fourthBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#70ad47");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            fifthBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#5b9bd5");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            sixthBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#c1c1c1");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            seventhBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#6f6fe2");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            eightBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#e269ae");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            ninthBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#9e480e");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };
            tenthBut.Click += (sender, e) =>
            {
                var color = Color.ParseColor("#997300");
                if (isText || isRect)
                {
                    setting(Settings, color);
                }
                else if (isPath)
                {
                    editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Path, new PenSettings() { Color = color });
                }
            };


            //Share

            var share = bottomView.FindViewById<ImageButton>(Resource.Id.sharecustomization);
            editText = bottomView.FindViewById<EditText>(Resource.Id.captionText);
            share.Click += async (sender, e) =>
            {
                await ShareImageAsync();
            };
            return mainLayout;
        }


        void setting(object Settings,Color color)
        {
            if (Settings is TextSettings)
                (Settings as TextSettings).Color = color;
            else if(Settings is PenSettings)
                (Settings as PenSettings).Color = color;
        }


        public static bool IsTabletDevice(Android.Content.Context context)
        {
            try
            {
                DisplayMetrics displayMetrics = context.Resources.DisplayMetrics;
                float screenWidth = displayMetrics.WidthPixels / displayMetrics.Xdpi;
                float screenHeight = displayMetrics.HeightPixels / displayMetrics.Ydpi;
                double size = System.Math.Sqrt(System.Math.Pow(screenWidth, 2) + System.Math.Pow(screenHeight, 2));
                return size >= 6;
            }
            catch
            {
                return false;
            }
        }

        async Task ShareImageAsync()
        {
            editor.Save();
            editor.ImageSaving += (sender, e) => {
                e.Cancel = false;
            };
            editor.ImageSaved += (sender, e) => {
                location = e.Location;
            };
            await DelayActionAsync(2500, Sharing);
        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }

        void Sharing()
        {
            share = new Share();
            share.Show("Title", string.IsNullOrEmpty(editText.Text) ? "Message" : editText.Text.ToString(), location);

        }

        void AddShapes()
        {
            if (isRect)
            {
                editor.AddShape(Syncfusion.SfImageEditor.Android.ShapeType.Rectangle, new PenSettings());
                isRect = true;
                isText = false;
                isPath = false;
            }
            else if (isText)
            {
                editor.AddText("Enter Text", new TextSettings());
                isRect = false;
                isText = true;
                isPath = false;

            }
        }

      
    }


}
