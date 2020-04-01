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
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Syncfusion.Android.PopupLayout;
using Android.Graphics.Drawables;
using System.Threading.Tasks;
using Android.Util;

namespace SampleBrowser
{
    public class PopupCustomizations : SamplePage
    {
        SfPopupLayout initialPopup;
        SfPopupLayout animationPopup;
        FrameLayout mainView;
        List<TableItem> items;
        internal static ListView movieList;
        ListView theatreList;
        LinearLayout dateSelectionView;
        LinearLayout dateView;
        internal static RelativeLayout secondPage;
        TextView dayLabel;
        TextView dateLabel;
        Context cont;
        float density;
        bool pageExited = false;

        public override View GetSampleContent(Context context)
        {
            cont = context;
            density = cont.Resources.DisplayMetrics.Density;
            CreateMainView();
            CreateMovieSelectionPage();
            CreateDateSelectionPage();
            (context as AllControlsSamplePage).ActionBar.CustomView.SetBackgroundColor(Color.DarkGray);
            (context as AllControlsSamplePage).ActionBar.SetBackgroundDrawable(new ColorDrawable(Color.DarkGray));
            TheaterAdapter.counter = 0;
            return mainView;
        }

        private void CreateDateSelectionPage()
        {
            secondPage = new RelativeLayout(cont);
            LinearLayout secondPageContent = new LinearLayout(cont);
            secondPageContent.Orientation = Orientation.Vertical;
            secondPage.Id = 2;
            TouchObserverView rel = new TouchObserverView(cont);
            rel.Alpha = 0.8f;
            rel.ViewAttachedToWindow += async delegate
            {
                for (int i = 0; i < 3; i++)
                {
                    if (pageExited)
                        return;
                    if (TheaterAdapter.counter == 0)
                    {
                        rel.Visibility = ViewStates.Visible;
                        CreateAnimationPopup();
                        animationPopup.Show(10, 0);
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                    }
                    else if (TheaterAdapter.counter == 1)
                    {
                        animationPopup.Dismiss();
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Visible;                      
                        var image = new ImageView(cont);
                        animationPopup.PopupView.AnimationMode = AnimationMode.SlideOnLeft;
                        image.SetImageResource(Resource.Drawable.Popup_TheatrInfo);
                        animationPopup.PopupView.ContentView = image;
                        animationPopup.Show((int)(cont.Resources.DisplayMetrics.WidthPixels / density - 40), 135);
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                    }
                    else if (TheaterAdapter.counter == 2)
                    {
                        animationPopup.Dismiss();
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Visible;                      
                        var image = new ImageView(cont);
                        animationPopup.PopupView.AnimationMode = AnimationMode.SlideOnTop;
                        image.SetImageResource(Resource.Drawable.Popup_SelectSeats);
                        animationPopup.PopupView.ContentView = image;
                        animationPopup.Show(10, 80);
                        TheaterAdapter.counter++;
                        await Task.Delay(700);
                        rel.Visibility = ViewStates.Gone;
                        animationPopup.StaysOpen = false;
                        animationPopup.Dismiss();
                    }
                    if (TheaterAdapter.counter >= 4)
                    {
                        animationPopup.StaysOpen = false;
                        animationPopup.Dismiss();
                    }
                }
                animationPopup.StaysOpen = false;
                rel.Visibility = ViewStates.Gone;
                animationPopup.Dismiss();
                TheaterAdapter.counter = 0;
            };
            dateSelectionView = new LinearLayout(cont);
            dateSelectionView.Orientation = Orientation.Horizontal;
            dateSelectionView.AddView(CreateDateView(0, 0), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(1), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(2), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(3), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(4), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(5), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);
            dateSelectionView.AddView(CreateDateView(6), cont.Resources.DisplayMetrics.WidthPixels / 7, ViewGroup.LayoutParams.MatchParent);

            theatreList = new ListView(cont);
            PopulateTheatreList();
            theatreList.Adapter = new TheaterAdapter((cont as AllControlsSamplePage), items, mainView);
            theatreList.ItemClick += MovieList_ItemClick;
            theatreList.ViewDetachedFromWindow += TheatreList_ViewDetachedFromWindow;

            secondPageContent.AddView(dateSelectionView, ViewGroup.LayoutParams.MatchParent, (int)(62 * density));
            secondPageContent.AddView(theatreList, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            secondPage.AddView(secondPageContent, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            secondPage.AddView(rel, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            rel.SetBackgroundColor(Color.Black);
        }

        private void TheatreList_ViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e)
        {
            if (animationPopup != null)
            {
                animationPopup.Dismiss();
                animationPopup.Visibility = ViewStates.Gone;
            }
            pageExited = true;
        }

        public override void Destroy()
        {
            base.Destroy();
            theatreList.ViewDetachedFromWindow -= TheatreList_ViewDetachedFromWindow;
            dateView.Click -= DateView_Click;
            movieList.ViewAttachedToWindow -= ListViewLoaded;
            movieList.ViewDetachedFromWindow -= MovieList_ViewDetachedFromWindow;
            movieList.ItemClick -= MovieList_ItemClick;
        }

        private void CreateAnimationPopup()
        {
            var image = new ImageView(cont);
            image.SetImageResource(Resource.Drawable.Popup_DateSelected);
            animationPopup = new SfPopupLayout(cont);
            animationPopup.PopupView.AnimationMode = AnimationMode.Zoom;
            animationPopup.PopupView.ShowHeader = false;
            animationPopup.PopupView.ShowFooter = false;
            animationPopup.PopupView.ContentView = image;
            animationPopup.PopupView.HeightRequest = 200;
            animationPopup.PopupView.WidthRequest = 200;
            animationPopup.PopupView.SetBackgroundColor(Color.Transparent);
            animationPopup.PopupView.SetBackgroundColor(Color.Transparent);
            animationPopup.PopupView.ContentView.SetBackgroundColor(Color.Transparent);
            animationPopup.PopupView.PopupStyle.BorderColor = Color.Transparent;
        }

        private void PopulateTheatreList()
        {
            items = new List<TableItem>();
            items.Add(new TableItem() { Heading = "ABC Cinemas Dolby Atmos", SubHeading = "No.15, 12th Main Road, Sector 1", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="10:00 AM",Timing2="4:00 PM" });
            items.Add(new TableItem() { Heading = "XYZ Theater 4K Dolby Atmos", SubHeading = "No.275, 3rd Cross Road,Area 27", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="11:00 AM",Timing2="6:00 PM" });
            items.Add(new TableItem() { Heading = "QWERTY Theater", SubHeading = "No.275, 3rd Cross Road,Sector North", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="10:30 AM"});
            items.Add(new TableItem() { Heading = "FYI Cinemas 4K", SubHeading = "No.15, 12th Main Road,Sector South", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="3:00 PM" ,});
            items.Add(new TableItem() { Heading = "The Cinemas Dolby Digital", SubHeading = "No.275, 3rd Cross Road,Layout 71", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="2:30 PM" ,Timing2="9:00 PM"});
            items.Add(new TableItem() { Heading = "SF Theater Dolby Atmos RDX", SubHeading = "North West Layout", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="1:30 PM" ,Timing2="6:00 PM"});
            items.Add(new TableItem() { Heading = "Grid Cinemas 4K Dolby Atmos", SubHeading = "No.15, 12th Main Road,Area 33", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="3:30 PM"});
            items.Add(new TableItem() { Heading = "Grand Theater", SubHeading = "No.275, 3rd Cross Road,South Sector", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="6:00 PM"});
            items.Add(new TableItem() { Heading = "Layout Cinemas Dolby Atmos RDX", SubHeading = "No.15, 12th Main Road,Area 152", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="6:00 PM" ,Timing2="10:30 PM"});
            items.Add(new TableItem() { Heading = "Xamarin Cinemas Dolby Atmos RDX", SubHeading = "No.275, 3rd Cross Road,Sector 77", ImageResourceId = Resource.Drawable.Popup_Info, Timing1="2:30 PM" ,Timing2="6:30 PM" });
        }

        private LinearLayout CreateDateView(int date, object selected = null)
        {
            dateView = new LinearLayout(cont);
            if (selected == null)
                dateView.SetBackgroundColor(Color.White);
            else
                dateView.SetBackgroundColor(Color.ParseColor("#007CEE"));
            dateView.Click += DateView_Click;
            dateView.Orientation = Orientation.Vertical;

            dayLabel = new TextView(cont);
            dayLabel.SetBackgroundColor(Color.Transparent);
            dayLabel.Text = DateTime.Now.AddDays(date).DayOfWeek.ToString().Substring(0, 3).ToUpper();
            if (selected == null)
                dayLabel.SetTextColor(Color.Argb(54, 00, 00, 00));
            else
                dayLabel.SetTextColor(Color.White);
            dayLabel.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            dayLabel.SetTextSize(Android.Util.ComplexUnitType.Dip, 12);
            dayLabel.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;

            dateLabel = new TextView(cont);
            dateLabel.SetBackgroundColor(Color.Transparent);
            dateLabel.Text = DateTime.Now.AddDays(date).Day.ToString();
            dateLabel.TextAlignment = TextAlignment.Center;
            if (selected == null)
                dateLabel.SetTextColor(Color.Black);
            else
                dateLabel.SetTextColor(Color.White);
            dateLabel.SetTextSize(Android.Util.ComplexUnitType.Dip, 14);
            dateLabel.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
            dateLabel.Gravity = GravityFlags.CenterHorizontal;

            dateView.AddView(dayLabel, ViewGroup.LayoutParams.MatchParent, (int)(31 * density));
            dateView.AddView(dateLabel, ViewGroup.LayoutParams.MatchParent, (int)(31 * density));
            return dateView;
        }

        private void DateView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ((sender as LinearLayout).Parent as LinearLayout).ChildCount; i++)
            {
                // Remove selection color to other date views
                (((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).SetBackgroundColor(Color.White);
                ((((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).GetChildAt(0) as TextView).SetTextColor(Color.Argb(54, 00, 00, 00));
                ((((sender as LinearLayout).Parent as LinearLayout).GetChildAt(i) as LinearLayout).GetChildAt(1) as TextView).SetTextColor(Color.Black);
            }
            ((sender as LinearLayout).GetChildAt(0) as TextView).SetTextColor(Color.White);
            ((sender as LinearLayout).GetChildAt(1) as TextView).SetTextColor(Color.White);
            (sender as LinearLayout).SetBackgroundColor(Color.ParseColor("#007CEE"));
        }

        private void CreateMovieSelectionPage()
        {
            movieList = new ListView(cont);
            movieList.ViewAttachedToWindow += ListViewLoaded;
            movieList.ViewDetachedFromWindow += MovieList_ViewDetachedFromWindow;
            movieList.Id = 1;
            PopulateMovieList();
            movieList.Adapter = new MovieAdapter((cont as AllControlsSamplePage), items, mainView);
            movieList.ItemClick += MovieList_ItemClick;
            mainView.AddView(movieList);
        }

        private void MovieList_ViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e)
        {
            if (initialPopup != null)
            {
                initialPopup.Dispose();
                initialPopup = null;
            }
        }

        private void ListViewLoaded(object sender, View.ViewAttachedToWindowEventArgs e)
        {
            DisplayInitialPopup();
        }

        private void CreateMainView()
        {
            mainView = new FrameLayout(cont);
        }

        private void PopulateMovieList()
        {
            items = new List<TableItem>();
            items.Add(new TableItem() { Heading = "Longest Run", SubHeading = "Liam Kneeson | Dean Kruger", ImageResourceId = Resource.Drawable.Popup_Movie1 });
            items.Add(new TableItem() { Heading = "AA-Team", SubHeading = "Dirk Benedict | Liam Kneeson", ImageResourceId = Resource.Drawable.Popup_Movie2});
            items.Add(new TableItem() { Heading = "Configuring 2", SubHeading = "Vera Farmigan | Pat Wilson", ImageResourceId = Resource.Drawable.Popup_Movie3});
            items.Add(new TableItem() { Heading = "Inside Us 2", SubHeading = "Pat Wilson | Rose Bryane", ImageResourceId = Resource.Drawable.Popup_Movie4});
            items.Add(new TableItem() { Heading = "Safer House", SubHeading = "Regan Reynolds | Denzol Washington", ImageResourceId = Resource.Drawable.Popup_Movie5});
            items.Add(new TableItem() { Heading = "Run All Day", SubHeading = "Liam Kneeson | Jeniffer Rodriguez", ImageResourceId = Resource.Drawable.Popup_Movie6});
            items.Add(new TableItem() { Heading = "Code Red", SubHeading = "Jake Gylle | Michelle Manhatan", ImageResourceId = Resource.Drawable.Popup_Movie7});
            items.Add(new TableItem() { Heading = "Clash Of The Dragons", SubHeading = "Gemma Verteron | Sam Worthonn", ImageResourceId = Resource.Drawable.Popup_Movie8});
            items.Add(new TableItem() { Heading = "A Run Among The TombStones", SubHeading = "Liam Kneeson | Daniel Stevens", ImageResourceId = Resource.Drawable.Popup_Movie9});
            items.Add(new TableItem() { Heading = "Error 404", SubHeading = "Liam Kneeson | Dene Kruger", ImageResourceId = Resource.Drawable.Popup_Movie10});
        }

        private void MovieList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var backbutton = ((((this.cont as AllControlsSamplePage).SettingsButton.Parent as RelativeLayout).GetChildAt(1) as LinearLayout).GetChildAt(0) as RelativeLayout).GetChildAt(0);
            backbutton.Click += backbutton_Click;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            var child = this.mainView.GetChildAt(0);
            if (child.Id == 2)
            {
                this.mainView.RemoveView(child);
                if (this.mainView.IndexOfChild(PopupCustomizations.movieList) == -1)
                    this.mainView.AddView(movieList);
            }
        }

        internal void DisplayInitialPopup()
        {
            if (pageExited)
                return;
            initialPopup = new SfPopupLayout(cont);
            initialPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            initialPopup.PopupView.ShowFooter = true;
            initialPopup.PopupView.ShowCloseButton = false;
            initialPopup.PopupView.HeaderTitle = "Book tickets !";
            initialPopup.PopupView.AcceptButtonText = "OK";
            initialPopup.PopupView.PopupStyle.HeaderTextSize = 16;
            initialPopup.StaysOpen = true;
            TextView messageView = new TextView(this.cont);
            messageView.Text = "Click on the book button to start booking tickets";
            messageView.SetTextColor(Color.Black);
            messageView.SetBackgroundColor(Color.White);
            messageView.TextSize = 14;
            initialPopup.PopupView.ContentView = messageView;
            initialPopup.PopupView.ContentView.SetPadding((int)(10 * density), (int)(10 * density), (int)(10 * density), (int)(10 * density));
            initialPopup.PopupView.PopupStyle.CornerRadius = 3;
            initialPopup.PopupView.HeightRequest = 180;
            initialPopup.Show();
        }
    }

    internal class TouchObserverView : View
    {
        public TouchObserverView(Context context) : base(context)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public TouchObserverView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected TouchObserverView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return true;
        }
    }
}