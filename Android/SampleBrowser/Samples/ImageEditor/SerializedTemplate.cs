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
    public class SerializedTemplate : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }
        public static Bitmap Image { get; set; }
        ImageButton imageview1;
        ImageButton imageview2;
        ImageButton imageview3;
        Context con { get; set; }
        public static String Name;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            con = context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.ImageEditorSerialization, null);
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
            Image = ((BitmapDrawable)imageview1.Drawable).Bitmap;
        }

        public void pictureOnClick2(object sender, EventArgs e)
        {
            Name = "Food";
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ImageEditorActivity));
            Image = ((BitmapDrawable)imageview2.Drawable).Bitmap;
        }

        public void pictureOnClick3(object sender, EventArgs e)
        {
            Name = "Syncfusion";
            Activity = con as Activity;
            Activity?.StartActivity(typeof(ImageEditorActivity));
            Image = ((BitmapDrawable)imageview3.Drawable).Bitmap;
        }

        [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
         Icon = "@drawable/icon")]
        public class ImageEditorActivity : Activity
        {
            View view { get; set; }
            LinearLayout contentView { get; set; }
            private DrawerLayout mDrawerLayout;
            List<TableItem> tableItems = new List<TableItem>();
            ListView listView;
            SfImageEditor editor;
            Share share;
            string location = "";
            string content;
            ViewModel viewModel;
            AssetManager assets;
          
            protected override void OnCreate(Bundle savedInstanceState)
            {
                viewModel = new ViewModel();
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                view = layoutInflater.Inflate(Resource.Layout.EditorSerializationMain, null);
                SetContentView(view);
                LinearLayout mainLayout = FindViewById<LinearLayout>
                    (Resource.Id.ContentView);
                listView = FindViewById<ListView>(Resource.Id.right_drawer);
                mDrawerLayout = (DrawerLayout) FindViewById(Resource.Id.drawer_layout);
                tableItems.Add(new TableItem() { ImageResourceId = viewModel.ModelList[0].Name,ImageName ="Coffee"});
                tableItems.Add(new TableItem() { ImageResourceId = viewModel.ModelList[1].Name,ImageName ="Food"});
                tableItems.Add(new TableItem() { ImageResourceId = viewModel.ModelList[2].Name,ImageName ="Syncfusion"});

                listView.Adapter = new HomeScreenAdapter(this, tableItems);

                listView.ItemClick += OnListItemClick;
                editor  = new SfImageEditor(this);
                editor.ImageSaving+= Editor_ImageSaving;

                editor.Bitmap = SerializedTemplate.Image;
                assets = this.Assets;
                LoadStream();
                DelayActionAsync(500, LoadStreamToEditor);
               
                //Add ToolBar items

                HeaderToolBarItem item1 = new HeaderToolBarItem();
                item1.Text = "Settings";
                item1.Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.sett);
                HeaderToolBarItem item2 = new HeaderToolBarItem();
                item2.Text = "Share";
                item2.Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.share);
                HeaderToolBarItem item3 = new HeaderToolBarItem();
                item3.Icon = BitmapFactory.DecodeResource(Resources, Resource.Drawable.info_24);

                editor.ToolbarSettings.ToolbarItems.Add(item1);
                editor.ToolbarSettings.ToolbarItems.Add(item2);
                editor.ToolbarSettings.ToolbarItems.Add(item3);

                editor.ToolbarSettings.ToolbarItemSelected += (sender, e) => {

                    if (e.Toolbar is HeaderToolBarItem)
                    {

                        var text = (e.Toolbar as HeaderToolBarItem).Text;
                        if (e.Toolbar is HeaderToolBarItem)
                        {
                            if ((e.Toolbar as HeaderToolBarItem).Text == "Share")
                            {
                                ShareImage();
                            }

                            if ((e.Toolbar as HeaderToolBarItem).Text == "Settings")
                            {
                                mDrawerLayout.OpenDrawer(listView);
                            }
                            if ((text != "Reset" && text != "undo" && text != "redo" && text != "Save" && text != "Settings" && text != "Share"))
                            {
                                string strin = "ImageEditor allows you to serialize and deserialize any custom edits(Shapes,Text,Path) over an image. In this sample we have deserialized some custom edits and loaded in to the editor.";
                                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                alert.SetTitle("About this sample");
                                alert.SetMessage(strin.ToString());
                                alert.SetNegativeButton("Ok", (senderAlert, args) => {
                                });
                                Dialog dialog = alert.Create();
                                dialog.Show();

                            }
                        }
                    }
                };
                mainLayout.AddView(editor);
                base.OnCreate(savedInstanceState);
            }

            void LoadStreamToEditor()
            {
                for (int i = 0; i < viewModel.ModelList.Count(); i++)
                {
                    if (SerializedTemplate.Name == viewModel.ModelList[i].ImageName)
                    {
                        using (StreamReader sr = new StreamReader(assets.Open(viewModel.ModelList[i].Imagestream)))
                        {
                            content = sr.ReadToEnd();
                            byte[] byteArray = Encoding.ASCII.GetBytes(content);
                            MemoryStream stream = new MemoryStream(byteArray);
                            editor.LoadAsJson(stream);
                            viewModel.ModelList[i].Strm = stream;
                        }
                    }

                }
            }


            void LoadStream()
            {
                for (int i = 0; i < viewModel.ModelList.Count(); i++)
                {
                    using (StreamReader sr = new StreamReader(assets.Open(viewModel.ModelList[i].Imagestream)))
                    {
                        content = sr.ReadToEnd();
                        byte[] byteArray = Encoding.ASCII.GetBytes(content);
                        MemoryStream stream = new MemoryStream(byteArray);
                        viewModel.ModelList[i].Strm = stream;
                    }
                }
            }

            void Editor_ImageSaving(object sender, ImageSavingEventArgs e)
            {
                for (int i = 0; i < viewModel.ModelList.Count(); i++)
                {
                    if (SerializedTemplate.Name == viewModel.ModelList[i].ImageName)
                    {
                        var stream= editor.GetSerializedObject();
                        viewModel.ModelList[i].Strm=stream;
                    }

                }
            }

            void ShareImage()
            {
                editor.Save();
                editor.ImageSaving+= (sender, e) => {
                    e.Cancel = false;
                };
                editor.ImageSaved+= (sender, e) => {
                    location = e.Location;
                };
                DelayActionAsync(2500, Sharing);
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



            protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
            {
                var listView = sender as ListView;
                var t = tableItems[e.Position];
                editor.Bitmap = BitmapFactory.DecodeResource(Resources, t.ImageResourceId);
                for (int i = 0; i < viewModel.ModelList.Count(); i++)
                {
                    if (t.ImageResourceId == viewModel.ModelList[i].Name)
                    {
                        Stream str = viewModel.ModelList[i].Strm;
                        editor.LoadAsJson(str);
                        SerializedTemplate.Name = t.ImageName;
                    }
                }
                mDrawerLayout.CloseDrawer(listView);
            }
        }

        public class TableItem
        {
            public int ImageResourceId { get; set; }

            public int Name { get; set; }

            public string ImageName { get; set; }
        }

        public class HomeScreenAdapter : BaseAdapter<TableItem>
        {
            List<TableItem> items;
            Activity context;
            public HomeScreenAdapter(Activity context, List<TableItem> items)
                : base()
            {
                this.context = context;
                this.items = items;
            }
            public override long GetItemId(int position)
            {
                return position;
            }
            public override TableItem this[int position]
            {
                get { return items[position]; }
            }
            public override int Count
            {
                get { return items.Count; }
            }
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var item = items[position];

                View view = convertView;
                if (view == null) // no view to re-use, create new
                    view = context.LayoutInflater.Inflate(Resource.Layout.CustomListView, null);
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

                return view;
            }
        }
    }


    //public class Share 
    //{
    //    private readonly Context _context;
    //    public Share()
    //    {
    //        _context = Application.Context;
    //    }

    //    public Task Show(string title, string message, string filePath)
    //    {
    //        var extension = filePath.Substring(filePath.LastIndexOf(".") + 1).ToLower();
    //        var contentType = string.Empty;

    //        switch (extension)
    //        {
    //            case "pdf":
    //                contentType = "application/pdf";
    //                break;
    //            case "png":
    //                contentType = "image/png";
    //                break;
    //            case "jpg":
    //                contentType = "image/jpg";
    //                break;
    //            default:
    //                contentType = "application/octetstream";
    //                break;
    //        }

    //        var intent = new Intent(Intent.ActionSend);
    //        intent.SetType(contentType);
    //        intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.Parse("file://" + filePath));
    //        intent.PutExtra(Intent.ExtraText, message ?? string.Empty);
    //        intent.PutExtra(Intent.ExtraSubject, title ?? string.Empty);

    //        var chooserIntent = Intent.CreateChooser(intent, title ?? string.Empty);
    //        chooserIntent.SetFlags(ActivityFlags.ClearTop);
    //        chooserIntent.SetFlags(ActivityFlags.NewTask);
    //        _context.StartActivity(chooserIntent);

    //        return Task.FromResult(true);
    //    }
    //}
}
  

   
