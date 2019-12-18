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
using System.Text;
namespace SampleBrowser
{
    public class BannerCreator : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }
        public static int Image { get; set; }
        ImageButton imageview1;
        ImageButton imageview2;
        ImageButton imageview3;
        Context con { get; set; }
        public static String Name;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            con = context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.ImageEditorBannercreator, null);
            imageview1 = view.FindViewById<ImageButton>(Resource.Id.banner1);
            imageview2 = view.FindViewById<ImageButton>(Resource.Id.banner2);
            imageview3 = view.FindViewById<ImageButton>(Resource.Id.banner3);
            imageview1.Click += pictureOnClick1;
            imageview2.Click += pictureOnClick2;
            imageview3.Click += pictureOnClick3;
            return view;
        }
        public void pictureOnClick1(object sender, EventArgs e)
        {
            Name = "Coffee";
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ImageEditorActivity));
            Image = Resource.Drawable.editordashboard;
        }

        public void pictureOnClick2(object sender, EventArgs e)
        {
            Name = "Food";
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ImageEditorActivity));
            Image = Resource.Drawable.editorsuccinity;
        }

        public void pictureOnClick3(object sender, EventArgs e)
        {
            Name = "Syncfusion";
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ImageEditorActivity));
            Image = Resource.Drawable.editortwitter;
        }
    }

    [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
           Icon = "@drawable/icon")]
    public class ImageEditorActivity : Activity
    {
        View view { get; set; }
        SfImageEditor editor;
        Share share;
        string location = "";
        ViewModel viewModel;
        AssetManager assets;
        LinearLayout visibilityLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            viewModel = new ViewModel();
            assets = this.Assets;
            LayoutInflater layoutInflater = LayoutInflater.From(this);
            view = layoutInflater.Inflate(Resource.Layout.EditorBannerMain, null);
            SetContentView(view);
            LinearLayout mainLayout = FindViewById<LinearLayout>
                (Resource.Id.editor_layout);
            visibilityLayout = FindViewById<LinearLayout>
                (Resource.Id.visibility_layout);
            visibilityLayout.Visibility = ViewStates.Gone;
            Button ok = FindViewById<Button>
                (Resource.Id.button);
            Button cancel = FindViewById<Button>
                (Resource.Id.button2);
            ok.Click += Ok_Click;
            cancel.Click += Cancel_Click;
            editor = new SfImageEditor(this);
            var bitmap = BitmapFactory.DecodeResource(Resources, BannerCreator.Image);
            editor.Bitmap = bitmap;
            mainLayout.AddView(editor);

            editor.ToolbarSettings.ToolbarItems.Clear();
            FooterToolbarItem banner = new FooterToolbarItem()
            {
                Text = "Banner Types",
                SubItems = new List<ToolbarItem>()
                {
                    new ToolbarItem(){Text="Facebook Post"},
                    new ToolbarItem(){Text="Facebook Cover"},
                    new ToolbarItem(){Text="Twitter Cover"},
                    new ToolbarItem(){Text="Twitter Post"},
                    new ToolbarItem(){Text="YouTubeChannel Cover"},

                },
            };


            HeaderToolbarItem item2 = new HeaderToolbarItem();
            item2.Text = "Share";
            item2.Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.share);
            HeaderToolbarItem crop = new HeaderToolbarItem();
            crop.Text = "Banner Types";
            editor.ToolbarSettings.ToolbarItems.Add(item2);
            editor.ToolbarSettings.ToolbarItems.Add(banner);
            editor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {
                if (e.ToolbarItem is HeaderToolbarItem)
                if ((e.ToolbarItem as HeaderToolbarItem).Text == "Share")
                    {
                        ShareImage();
                    }
                if (e.ToolbarItem is ToolbarItem)
                {
                    var toolitem = e.ToolbarItem as ToolbarItem;
                    if (toolitem.Text != "Banner Types" && toolitem.Text != "Share")
                    {
                        visibilityLayout.Visibility = ViewStates.Visible;

                    }
                    if (toolitem.Text == "Facebook Post")
                        editor.ToggleCropping(1200, 900);
                    else if (toolitem.Text == "Facebook Cover")
                        editor.ToggleCropping(851, 315);
                    else if (toolitem.Text == "Twitter Cover")
                        editor.ToggleCropping(1500, 500);
                    else if (toolitem.Text == "Twitter Post")
                        editor.ToggleCropping(1024, 512);
                    else if (toolitem.Text == "YouTubeChannel Cover")
                        editor.ToggleCropping(2560, 1440);
                }
            };
           


            base.OnCreate(savedInstanceState);
        }



        async void ShareImage()
        {
            editor.Save();
            editor.ImageSaving += (sender, e) =>
            {
                e.Cancel = false;
            };
            editor.ImageSaved += (sender, e) =>
            {
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
            share.Show("Share", "Message", location);
        }

        void Ok_Click(object sender, EventArgs e)
        {
            editor.Crop();
            visibilityLayout.Visibility = ViewStates.Gone;
        }

        void Cancel_Click(object sender, EventArgs e)
        {
            editor.ToggleCropping();
            visibilityLayout.Visibility = ViewStates.Gone;

        }
    }

    public class Share
    {
        private readonly Context _context;
        public Share()
        {
            _context = Application.Context;
        }

        public Task Show(string title, string message, string filePath)
        {
            var extension = filePath.Substring(filePath.LastIndexOf(".") + 1).ToLower();
            var contentType = string.Empty;

            switch (extension)
            {
                case "pdf":
                    contentType = "application/pdf";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                case "jpg":
                    contentType = "image/jpg";
                    break;
                default:
                    contentType = "application/octetstream";
                    break;
            }

            var intent = new Intent(Intent.ActionSend);
            intent.SetType(contentType);
            intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.Parse("file://" + filePath));
            intent.PutExtra(Intent.ExtraText, message ?? string.Empty);
            intent.PutExtra(Intent.ExtraSubject, title ?? string.Empty);

            var chooserIntent = Intent.CreateChooser(intent, title ?? string.Empty);
            chooserIntent.SetFlags(ActivityFlags.ClearTop);
            chooserIntent.SetFlags(ActivityFlags.NewTask);
            _context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}

