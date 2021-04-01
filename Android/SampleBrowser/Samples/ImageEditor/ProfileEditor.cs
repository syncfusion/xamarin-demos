#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
    public class ProfileEditor : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }

        public static  ImageView ImageView { get; set; }

        Context con { get; set; }

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            con = context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.ImageEditorProfileEditor, null);
            Button button = view.FindViewById<Button>(Resource.Id.profileEditButton);
            ImageView = view.FindViewById<ImageView>(Resource.Id.profileImageView);
            button.Click += Button_Click;
            button.SetTextColor(Color.White);

            ListView listView = view.FindViewById<ListView>(Resource.Id.ProfileEditorListView);
            listView.Adapter = new ProfileEditorAdapter(ProfileFields.Fields);

            return view;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ProfileEditorActivity));
        }

        [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
             Icon = "@drawable/icon")]
        public class ProfileEditorActivity : Activity
        {
            SfImageEditor imageEditor;
            
            protected override void OnCreate(Bundle savedInstanceState)
            {
                imageEditor = new SfImageEditor(this);
                imageEditor.ToolbarSettings.ToolbarItemSelected += OnToolbarItemSelected;
                imageEditor.ImageSaving += ImageEditor_ImageSaving;
                imageEditor.ImageLoaded += ImageEditor_ImageLoaded;

                Android.Graphics.Drawables.BitmapDrawable bd = (Android.Graphics.Drawables.BitmapDrawable)ProfileEditor.ImageView.Drawable;
                imageEditor.Bitmap = bd.Bitmap;
                SetContentView(imageEditor);
                base.OnCreate(savedInstanceState);

                imageEditor.SetToolbarItemVisibility("Text, Shape, Brightness, Effects, Bradley Hand, Path, 3:1, 3:2, 4:3, 5:4, 16:9, Undo, Redo, Transform", false);

                // Add the custom tool bar items
                var item = new FooterToolbarItem()
                {
                    Text = "Crop",
                    TextHeight = 20,
                };
                imageEditor.ToolbarSettings.ToolbarItems.Add(item);

               
            }

            private async void ImageEditor_ImageLoaded(object sender, ImageLoadedEventArgs e)
            {
                await System.Threading.Tasks.Task.Delay(25);

                imageEditor.ToggleCropping(true, 3);
            }

            private void ImageEditor_ImageSaving(object sender, ImageSavingEventArgs e)
            {
                e.Cancel = true;
                Bitmap bitmap = BitmapFactory.DecodeStream(e.Stream);
                ProfileEditor.ImageView.SetImageBitmap(bitmap);
                Finish();
            }

            private void OnToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
            {
               if(e.ToolbarItem.Text=="Crop")
                {
                    imageEditor.ToggleCropping(true, 3);
                    e.Cancel = true;
                }
            }
        }

        public class ProfileEditorAdapter : BaseAdapter<ProfileModel>
        {
            List<ProfileModel> fields;

            public ProfileEditorAdapter(List<ProfileModel> collection)
            {
                this.fields = collection;
            }

            public override ProfileModel this[int position]
            {
                get
                {
                    return fields[position];
                }
            }

            public override int Count
            {
                get
                {
                    return fields.Count;
                }
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = convertView;

                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ImageEditorProfileListViewItem, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var field = view.FindViewById<TextView>(Resource.Id.fieldTextView);
                var content = view.FindViewById<TextView>(Resource.Id.contentTextView);

                field.Text = fields[position].Field;
                content.Text = fields[position].Content;
                photo.SetBackgroundResource(fields[position].Icon);

                return view;

            }
        }

        public static class ProfileFields
        {
            public static List<ProfileModel> Fields { get; private set; }

            static ProfileFields()
            {
                Fields = new List<ProfileModel>();

                AddFields(Fields);
            }

            static void AddFields(List<ProfileModel> fields)
            {
                fields.Add(new ProfileModel()
                {
                    Field = "Name",
                    Content = "Alison Doody",
                    Icon= Resource.Drawable.LabelContactName
                });

                fields.Add(new ProfileModel()
                {
                    Field = "Email",
                    Content = "alison.doody@syncfusion.com",
                    Icon= Resource.Drawable.Email
                });

                fields.Add(new ProfileModel()
                {
                    Field = "Phone",
                    Content = "+1-123-456-7890",
                    Icon= Resource.Drawable.Phone
                });

                fields.Add(new ProfileModel()
                {
                    Field = "Address",
                    Content = "Avenue 2nd street, NW SY",
                    Icon= Resource.Drawable.Address
                });
            }
        }

        public class ProfileModel
        {
            public int Icon { get; set; }

            public string Field { get; set; }

            public string Content { get; set; }
        }
    }
}

