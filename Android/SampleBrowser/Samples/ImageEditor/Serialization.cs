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
using Android.Util;
using Java.Lang;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Android.Views.InputMethods;

namespace SampleBrowser
{
    public class Serialization : SamplePage
    {
        internal static Activity Activity { get; set; }
        View view { get; set; }
        public static Bitmap Image { get; set; }
        Context con { get; set; }
        public static Stream ImageStream { get; set; }
        public static Item SelectedItem { get; set; }
        public static GridView gridview { get; set; }
        ImageView notSelected { get; set; }
        public static List<Item> mSelectedItems;
        ImageButton deleteButton { get; set; }
        public static bool isLongPressEnabled { get; set; }
        public static bool isDeleted { get; set; }


        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            mSelectedItems = new List<Item>();
            con = context;
            isLongPressEnabled = false;
            isDeleted = false;
            Activity = con as Activity;
            LayoutInflater layoutInflater = LayoutInflater.From(context);
            view = layoutInflater.Inflate(Resource.Layout.SerializationFirstPage, null);
            gridview = view.FindViewById<GridView>(Resource.Id.gridview);
			
              var deviceDensity = (int)context.Resources.DisplayMetrics.Density;
            if (IsTabletDevice(context))
            {
                gridview.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 650);
                gridview.NumColumns = 3;
            }
            else if(deviceDensity>=3 && deviceDensity<4 && !IsTabletDevice(context))
            {
                gridview.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 310 * deviceDensity);
            }
            else if(deviceDensity < 3 && !IsTabletDevice(context))
            {
                gridview.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 400 * deviceDensity);

            }


            deleteButton = view.FindViewById<ImageButton>(Resource.Id.editordelete);
            deleteButton.Click+= DeleteButton_Click;
            gridview.Adapter  = new ImageAdapter(Activity);

            deleteButton.Visibility = ViewStates.Invisible;
            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                isDeleted = false;
                SelectedItem = (gridview.Adapter as ImageAdapter).mItems[args.Position];
                if (!SelectedItem.IsLongPressedEnabled)
                {
                    isLongPressEnabled = false;
                    Activity = con as Activity;
                    Activity?.StartActivity(typeof(SerializationActivity));
                    if (SelectedItem.ImageName != "Create New")
                    {
                        ImageStream = SelectedItem.Strm;
                        SelectedItem.IsItemChecked = false;
                        SelectedItem.IsLongPressedEnabled = false;
                    }
                }
                else if(!SelectedItem.IsItemChecked) {
                    SelectedItem.IsItemChecked = true;
                    mSelectedItems.Add(SelectedItem);
                }
                else if(SelectedItem.IsItemChecked)
                {
                    SelectedItem.IsItemChecked = false;
                    if(mSelectedItems.Count>0)
                    mSelectedItems.Remove(SelectedItem);
                }
                (gridview.Adapter as ImageAdapter).NotifyDataSetChanged();
            };

            gridview.ItemLongClick+= (object sender, AdapterView.ItemLongClickEventArgs e) => {
                deleteButton.Visibility = ViewStates.Visible;
                SelectedItem = (gridview.Adapter as ImageAdapter).mItems[e.Position];
                if (SelectedItem.ImageName != "CreateNew")
                {
                    SelectedItem.IsLongPressedEnabled = true;
                    isLongPressEnabled = true;
                    isDeleted = false;
                    (gridview.Adapter as ImageAdapter).NotifyDataSetChanged();
                }
            };

           
            return view;
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



        void DeleteButton_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < mSelectedItems.Count; i++)
            {
                if ((gridview.Adapter as ImageAdapter).mItems.Contains(mSelectedItems[i]))
                {
                    (gridview.Adapter as ImageAdapter).mItems.Remove(mSelectedItems[i]);
                }
            }
            (gridview.Adapter as ImageAdapter).NotifyDataSetChanged();
            isDeleted = true;
            deleteButton.Visibility = ViewStates.Invisible;
        }
    }


    [Activity(Label = "SfImageEditor", ScreenOrientation = ScreenOrientation.Portrait,
       Icon = "@drawable/icon")]
    public class SerializationActivity : Activity
    {
        SfImageEditor editor;
        View view { get; set; }
        EditText entry;
        string name="";
        LinearLayout popipView;
        FrameLayout overView;
        InputMethodManager imm;
        int height = 500;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(this);
            view = layoutInflater.Inflate(Resource.Layout.editorSavePopup, null);
            popipView = view.FindViewById<LinearLayout>(Resource.Id.editorPopUp);

            var deviceDensity = (int)this.Resources.DisplayMetrics.Density;

          
            popipView.Visibility = ViewStates.Invisible;
            var SaveButton = view.FindViewById<Button>(Resource.Id.Savebutton);
            var CancelButton = view.FindViewById<Button>(Resource.Id.Cancelbutton);
            entry = view.FindViewById<EditText>(Resource.Id.editTextDialogUserInput);
            SaveButton.Click += SaveButton_Click;
            CancelButton.Click += CancelButton_Click;

            imm= (InputMethodManager)GetSystemService(Context.InputMethodService);
            if (IsTabletDevice(this))
            {
                height = 150;
            }
            else
                height = 200*deviceDensity;
            var Params = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent - 100, height, GravityFlags.CenterHorizontal);
            Params.SetMargins(0, 300, 0, 0);
            popipView.LayoutParameters = Params;
            FrameLayout mainLayout = new FrameLayout(this);
            var tParams = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent, GravityFlags.Fill);
            mainLayout.SetBackgroundColor(Color.Transparent);
            editor = new SfImageEditor(this);
            RunTimer();
            editor.ImageSaving+= Editor_ImageSaving;
            base.OnCreate(savedInstanceState);

            editor.SetToolbarItemVisibility("save", false);
            HeaderToolbarItem item1 = new HeaderToolbarItem();
            item1.Text = "Save";
            editor.SetBackgroundColor(Color.White);
            editor.ToolbarSettings.ToolbarItems.Add(item1);

            editor.ToolbarSettings.ToolbarItemSelected += (sender, e) =>
            {
                if (e.ToolbarItem is HeaderToolbarItem)
                {

                    var text = (e.ToolbarItem as HeaderToolbarItem).Text;
                    if (text == "Save")
                    {
                        if (Serialization.SelectedItem.Name == "CreateNew")
                        {
                            overView.Visibility = ViewStates.Visible;
                            popipView.Visibility = ViewStates.Visible;
                        }
                        else
                            editor.Save();
                    }
                }
            };

            overView = new FrameLayout(this);
            var overViewParams = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent, GravityFlags.Fill);
            overView.LayoutParameters = overViewParams;
            overView.Alpha = 0.5f;
            overView.Visibility = ViewStates.Invisible;
            overView.SetBackgroundColor(Color.Black);

            mainLayout.AddView(editor);
            mainLayout.AddView(overView);
            mainLayout.AddView(popipView);
            SetContentView(mainLayout);

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


        void SaveButton_Click(object sender, EventArgs e)
        {
            name = entry.Text;
            editor.Save();
            popipView.Visibility = ViewStates.Invisible;
            overView.Visibility = ViewStates.Invisible;
            entry.Text="";
            this.imm?.HideSoftInputFromWindow(this.entry.WindowToken, HideSoftInputFlags.None);

        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            popipView.Visibility = ViewStates.Invisible;
            overView.Visibility = ViewStates.Invisible;
            entry.Text = "";
            this.imm?.HideSoftInputFromWindow(this.entry.WindowToken, HideSoftInputFlags.None);
        }

        void Editor_ImageSaving(object sender, ImageSavingEventArgs e)
        {
            var serializedStream = editor.SaveEdits();
            var mStream = e.Stream;
            mStream.Position = 0;
            Bitmap bitmap = BitmapFactory.DecodeStream(mStream);
            var bitMap = bitmap;             if (Serialization.SelectedItem.Name != "CreateNew")             {                 Serialization.SelectedItem.Strm = serializedStream;                 Serialization.SelectedItem.BitMap = bitmap;             }             else             {
                (Serialization.gridview.Adapter as ImageAdapter).mItems.Add(new Item
                {
                    Name = name != "" ? name : ValidateName(),
                    BitMap = bitMap,
                    Strm = serializedStream,
                    IsLongPressedEnabled = false,
                    IsItemChecked = false,
                        
                });

            }             (Serialization.gridview.Adapter as ImageAdapter).NotifyDataSetChanged();
        }

        string ValidateName()
        {
            string Name = "NewItem";
            int j = 1;
            for (int i = 0; i < (Serialization.gridview.Adapter as ImageAdapter).mItems.Count; i++)
            {
                if ((Serialization.gridview.Adapter as ImageAdapter).mItems[i].Name == Name)
                {
                    Name = "NewItem " + j;
                    j++;
                }
            }
            return Name;
        }

        async void RunTimer()
        {
            await DelayActionAsync(500, LoadStreamToEditor);
        }

        public async Task DelayActionAsync(int delay, Action action)
        {
            await Task.Delay(delay);

            action();
        }
        void LoadStreamToEditor()
        {
            editor.LoadEdits(Serialization.ImageStream);
        }
    }


    public class Item : INotifyPropertyChanged
    {
        public string Name { get; set; }
     
        public ImageButton Image { get; set; }


        private int _resource;
        public int Resource
        {
            get { return _resource; }
            set
            {
                _resource = value;
                RaisePropertyChanged("Resource");
            }
        }


        private bool _isLongPressedEnabled;
        public bool IsLongPressedEnabled
        {
            get { return _isLongPressedEnabled; }
            set
            {
                _isLongPressedEnabled = value;
                RaisePropertyChanged("IsLongPressedEnabled");
            }
        }


        private bool _isItemChecked;
        public bool IsItemChecked
        {
            get { return _isItemChecked; }
            set
            {
                _isItemChecked = value;
                RaisePropertyChanged("IsItemChecked");
            }
        }

        private bool _isDeleted;
        public bool ISDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                RaisePropertyChanged("ISDeleted");
            }
        }


        private Bitmap _bitMap;
        public Bitmap BitMap
        {
            get { return _bitMap; }
            set
            {
                _bitMap = value;
                RaisePropertyChanged("BitMap");
            }
        }
        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }


        private Stream _stream = null;
        public Stream Strm
        {
            get { return _stream; }
            set
            {
                _stream = value;
                RaisePropertyChanged("Strm");
            }
        }

        private string _imagestream;
        public string Imagestream
        {
            get { return _imagestream; }
            set
            {
                _imagestream = value;
                RaisePropertyChanged("Imagestream");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }


    public class SquareImageView : ImageView
    {
        public SquareImageView(Context context, IAttributeSet atrs) : base(context, atrs)
        {
        }
        public SquareImageView(Context context, IAttributeSet atrs, int defStyle) : base(context, atrs, defStyle)
        {
        }
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            SetMeasuredDimension(MeasuredWidth, MeasuredHeight);
        }
    }

   

    public class ImageAdapter : BaseAdapter
    {
        private Activity curvedActivity;
        public List<Item> mItems;
        AssetManager assets;
        string content;
        View v;

        public ImageAdapter(Activity curvedActivity)
        {
            assets = curvedActivity.Assets;
            this.curvedActivity = curvedActivity;
            mItems = new List<Item>();
            mItems.Add(new Item { Name = "CreateNew", Resource = Resource.Drawable.CreateNew,ImageName="CreateNew",Strm=null,Imagestream = "Ban1.txt",BitMap= BitmapFactory.DecodeResource(curvedActivity.Resources,Resource.Drawable.CreateNew),IsLongPressedEnabled=false,IsItemChecked=false,ISDeleted=false});
            mItems.Add(new Item { Name = "Chart", Resource = Resource.Drawable.ChartImage, ImageName = "Chart", Strm = null, Imagestream = "Chart.txt", BitMap = BitmapFactory.DecodeResource(curvedActivity.Resources, Resource.Drawable.ChartImage), IsLongPressedEnabled = false,IsItemChecked = false,ISDeleted = false});
            mItems.Add(new Item { Name = "Venn Diagram", Resource = Resource.Drawable.VennImage,ImageName = "Venn",Strm=null,Imagestream = "Venn.txt", BitMap = BitmapFactory.DecodeResource(curvedActivity.Resources, Resource.Drawable.VennImage),IsLongPressedEnabled = false, IsItemChecked = false,ISDeleted = false});
            mItems.Add(new Item { Name = "Freehand", Resource = Resource.Drawable.Freehand, ImageName = "Freehand", Strm = null, Imagestream = "FreeHand.txt", BitMap = BitmapFactory.DecodeResource(curvedActivity.Resources, Resource.Drawable.Freehand), IsLongPressedEnabled = false, IsItemChecked = false, ISDeleted = false });

            for (int i = 0; i < mItems.Count;i++)
            {
                if (i != 0)
                {
                    using (StreamReader sr = new StreamReader(assets.Open(mItems[i].Imagestream)))
                    {
                        content = sr.ReadToEnd();
                        byte[] byteArray = Encoding.ASCII.GetBytes(content);
                        MemoryStream stream = new MemoryStream(byteArray);
                        mItems[i].Strm = stream;
                    }
                }
              
            }     
        }

        public override int Count => mItems.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }



        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            v = convertView;

            if (v == null)
            {
                v = curvedActivity.LayoutInflater.Inflate(Resource.Layout.SerializationGriditem, null);
            }
           
            if (mItems[position].ImageName == "CreateNew")
            {
                v.SetBackgroundColor(Color.ParseColor("#065DC7"));
                v.FindViewById<ImageView>(Resource.Id.picture).SetImageBitmap(mItems[position].BitMap);
                v.FindViewById<TextView>(Resource.Id.text).Text = mItems[position].Name;
                v.FindViewById<TextView>(Resource.Id.createNew).Visibility = ViewStates.Visible;
                v.FindViewById<TextView>(Resource.Id.text).Visibility = ViewStates.Invisible;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Invisible;
                v.FindViewById<ImageView>(Resource.Id.picture).SetScaleType(ImageView.ScaleType.Center);
            }
            else
            {
                v.SetBackgroundColor(Color.ParseColor("#ffffff"));
                v.FindViewById<ImageView>(Resource.Id.picture).Alpha = 1f;
                v.FindViewById<ImageView>(Resource.Id.picture).SetScaleType(ImageView.ScaleType.FitXy);
                v.FindViewById<ImageView>(Resource.Id.picture).SetImageBitmap(mItems[position].BitMap);
                v.FindViewById<TextView>(Resource.Id.text).Text = mItems[position].Name;
                v.FindViewById<TextView>(Resource.Id.createNew).Visibility = ViewStates.Invisible;
                v.FindViewById<TextView>(Resource.Id.text).Visibility = ViewStates.Visible;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Invisible;

            }



            if (Serialization.isLongPressEnabled && mItems[position].ImageName != "CreateNew" && !Serialization.isDeleted)
            {
                v.SetBackgroundColor(Color.ParseColor("#ffffff"));
                mItems[position].IsLongPressedEnabled = true;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Visible;
            }

            if (mItems[position].IsLongPressedEnabled && mItems[position].IsItemChecked &&  mItems[position].ImageName != "CreateNew" && ! Serialization.isDeleted)
            {
                v.SetBackgroundColor(Color.ParseColor("#ffffff"));
                v.FindViewById<ImageView>(Resource.Id.picture).Alpha = 0.5f;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Visible;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).SetImageResource(Resource.Drawable.Selected);
            }
            if (mItems[position].IsLongPressedEnabled && !mItems[position].IsItemChecked && mItems[position].ImageName != "CreateNew" && ! Serialization.isDeleted)
            {
                v.SetBackgroundColor(Color.ParseColor("#ffffff"));
                v.FindViewById<ImageView>(Resource.Id.picture).Alpha = 1f;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Visible;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).SetImageResource(Resource.Drawable.NotSelected);
            }
            if(Serialization.isDeleted)
            {
                v.FindViewById<ImageView>(Resource.Id.picture).Alpha = 1f;
                mItems[position].IsLongPressedEnabled = false;
                v.FindViewById<ImageView>(Resource.Id.itemSelected).Visibility = ViewStates.Invisible;       
            }

            return v;
        }

       
    }
}


