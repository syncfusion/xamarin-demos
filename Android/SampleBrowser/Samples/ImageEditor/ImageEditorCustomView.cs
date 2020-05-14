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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SampleBrowser
{
    public class ImageEditorCustomView : SamplePage
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
            imageview3.LayoutParameters = new TableRow.LayoutParams((int)view.Width / 3, (int)height);
            imageview4.LayoutParameters = new TableRow.LayoutParams((int)view.Width / 3, (int)height);
            imageview5.LayoutParameters = new TableRow.LayoutParams((int)view.Width / 3, (int)height);
        }

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            con = context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.ImageEditorCustomView, null);
            imageview3 = view.FindViewById<ImageButton>(Resource.Id.imageview3);
            imageview4 = view.FindViewById<ImageButton>(Resource.Id.imageview4);
            imageview5 = view.FindViewById<ImageButton>(Resource.Id.imageview5);
            view.LayoutChange -= View_LayoutChange;
            view.LayoutChange += View_LayoutChange;
            imageview3.Click += pictureOnClick1;
            imageview4.Click += pictureOnClick2;
            imageview5.Click += pictureOnClick3;
            LinearLayout layout = new LinearLayout(context);
            return view;
        }

        public void pictureOnClick1(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(CustomViewActivity));
            Image = Resource.Drawable.CustomViewImage1;
        }

        public void pictureOnClick2(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(CustomViewActivity));
            Image = Resource.Drawable.CustomViewImage2;
        }

        public void pictureOnClick3(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(CustomViewActivity));
            Image = Resource.Drawable.CustomViewImage3;
        }

        private float GetImageHeight(ImageButton button, float renderWidth)
        {
            float originalWidth = 572;
            float originalHeight = 860;
            float renderedHeight = (renderWidth * originalHeight) / originalWidth;
            return renderedHeight;
        }

        [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
             Icon = "@drawable/icon")]
        public class CustomViewActivity : Activity
        {
            CustomViewSettings customViewSettings;

            void ImageEditor_ItemSelected(object sender, ItemSelectedEventArgs e)
            {
                if (e.Settings != null && e.Settings is CustomViewSettings)
                {
                    customViewSettings = e.Settings as CustomViewSettings;
                }

            }

            List<ToolbarItem> CustomViewItems;
            SfImageEditor imageEditor;
            bool isReplaced; string imageName;
            protected override void OnCreate(Bundle savedInstanceState)
            {
                imageEditor = new SfImageEditor(this);
                var bitmap = BitmapFactory.DecodeResource(Resources, ImageEditorCustomView.Image);
                imageEditor.Bitmap = bitmap;
                imageEditor.ItemSelected += ImageEditor_ItemSelected;
                SetContentView(imageEditor);
                base.OnCreate(savedInstanceState);

                imageEditor.SetToolbarItemVisibility("text,transform,shape,path,effects", false);

                CustomViewItems = new List<ToolbarItem>()
            {
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy1),CustomName = "ITypogy1",IconHeight=70 },
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy2),CustomName = "ITypogy2",IconHeight=70  },
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy3),CustomName = "ITypogy3",IconHeight=70  },
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy4),CustomName = "ITypogy4",IconHeight=70  },
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy5),CustomName = "ITypogy5",IconHeight=70  },
                new CustomToolbarItem(){Icon=BitmapFactory.DecodeResource(Resources, Resource.Drawable.ITypogy6),CustomName = "ITypogy6",IconHeight=70  }
        
            };

                // Add the custom tool bar items
                var item = new FooterToolbarItem()
                {
                    Text = "Add",
                    Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.AddIcon),
                    SubItems = CustomViewItems,
                    TextHeight = 20,
                };
                imageEditor.ToolbarSettings.ToolbarItems.Add(item);

                item = new FooterToolbarItem()
                {
                    Text = "Replace",
                    Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.ReplaceIcon),
                    SubItems = CustomViewItems,
                    TextHeight = 20
                };
                imageEditor.ToolbarSettings.ToolbarItems.Add(item);

                item = new FooterToolbarItem()
                {
                    Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.BringFrontIcon),
                    Text = "Bring Front",
                    TextHeight = 20
                };
                imageEditor.ToolbarSettings.ToolbarItems.Add(item);

                item = new FooterToolbarItem()
                {
                    Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.SendBack),
                    Text = "Send Back",
                    TextHeight = 20
                };
                imageEditor.ToolbarSettings.ToolbarItems.Add(item);
                imageEditor.ToolbarSettings.SubItemToolbarHeight = 70;
                imageEditor.ToolbarSettings.ToolbarItemSelected += OnToolbarItemSelected;
            }

            private void OnToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
            {
                string text = string.Empty; //e.ToolbarItem.Name;
                if (text != "back")
                {
                    if (e.ToolbarItem is FooterToolbarItem)
                    {
                        text = e.ToolbarItem.Text;
                        e.MoveSubItemsToFooterToolbar = true;
                    }
                    else if (e.ToolbarItem is CustomToolbarItem)
                        text = (e.ToolbarItem as CustomToolbarItem).CustomName;
                    else
                        text = e.ToolbarItem.Text;

                    if (text == "Replace")
                    {
                        isReplaced = true;
                        //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
                    }
                    else if (text == "back")
                    {
                        isReplaced = false;
                        //imageEditor.ToolbarSettings.FooterToolbarHeight = 50;
                    }
                    else if (text == "Add")
                    {
                        isReplaced = false;
                        //imageEditor.ToolbarSettings.FooterToolbarHeight = 70;
                    }
                    if (isReplaced && imageEditor.IsSelected && (text == "ITypogy1" ||
                                                                 text == "ITypogy2" || text == "ITypogy3" || text == "ITypogy4" || text == "ITypogy5" || text == "ITypogy6"))
                    {
                        imageEditor.Delete();
                        AddImage(text);
                    }
                    if (!isReplaced)
                        AddImage(text);
                    if (text == "Bring Front")
                        imageEditor.BringToFront();
                    else if (text == "Send Back")
                        imageEditor.SendToBack();
                }
                else
                {
                    isReplaced = false;
                }
            }



            private void AddImage(string text)
            {
                if (text == "ITypogy1")
                    SetSVGImage("ITypogy1");

                else if (text == "ITypogy2")
                    SetSVGImage("ITypogy2");

                else if (text == "ITypogy3")
                    SetSVGImage("ITypogy3");

                else if (text == "ITypogy4")
                    SetSVGImage("ITypogy4");

                else if (text == "ITypogy5")
                    SetSVGImage("ITypogy5");

                else if (text == "ITypogy6")
                    SetSVGImage("ITypogy6");
            }

            private void SetSVGImage(string name)
            {
                imageName = name;
                ImageView view = new ImageView(this);
                view.LayoutParameters = new ViewGroup.LayoutParams(200, 200);
                if (imageName == "ITypogy1")
                    view.SetImageResource(Resource.Drawable.Typogy1);
                else if (imageName == "ITypogy2")
                    view.SetImageResource(Resource.Drawable.Typogy2);
                else if (imageName == "ITypogy3")
                    view.SetImageResource(Resource.Drawable.Typogy3);
                else if (imageName == "ITypogy4")
                    view.SetImageResource(Resource.Drawable.Typogy4);
                else if (imageName == "ITypogy5")
                    view.SetImageResource(Resource.Drawable.Typogy5);
                else if (imageName == "ITypogy6")
                    view.SetImageResource(Resource.Drawable.Typogy6);
                if (isReplaced)
                    imageEditor.AddCustomView(view, new CustomViewSettings() { Bounds = customViewSettings.Bounds });
                else
                {
                    imageEditor.AddCustomView(view, new CustomViewSettings() { });
                }
            }

        }
        public class CustomToolbarItem : ToolbarItem
        {
            public string CustomName { get; set; }
            public CustomToolbarItem()
            {

            }
        }
    }
}
