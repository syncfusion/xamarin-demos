#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;
using System.Globalization;
using Syncfusion.Android.PopupLayout;
using Android.Widget;
using Android.Views.Animations;
using Android;
using System.Reflection;
using System.Linq;
using Android.Graphics;
using Android.Animation;
using Java.Util;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Text.Method;
using Android.Runtime;
using Android.Text;

namespace SampleBrowser
{
    public class PopupGettingStarted : SamplePage
    {
        int clickCount = 0;
        RelativeLayout mainView;
        SfDataGrid sfGrid;
        SfPopupLayout sfPopUp;
        SwipingViewModel viewModel;
        Context cont;
        float density;
        View backgroundView;
        ImageView imageView;
        Animation anim;
        TextView nextButton;

        SwipeView leftSwipeView;
        LinearLayout deleteView;

        private int swipedRowindex;

        CheckBox allowsorting;
        CheckBox allowResizing;
        CheckBox allowEditing;
        CheckBox allowRowDragAndDrop;
        System.Drawing.Point popupLayoutpoint;
        bool pageExited = false;

        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            mainView = new RelativeLayout(context);
            cont = context;
            density = cont.Resources.DisplayMetrics.Density;
            CreatePopup();
            CreateDataGrid();
            mainView.AddView(sfGrid);
            AddBackgroundView();
            CreateNextButton();
            sfPopUp.Content = mainView;
            return sfPopUp;
        }

        private void CreateNextButton()
        {
            if (mainView.IndexOfChild(nextButton) == -1)
            {
                nextButton = new TextView(cont);
                nextButton.SetTypeface(Typeface.Default, TypefaceStyle.Bold);
                nextButton.TextSize = 20;
                nextButton.Gravity = GravityFlags.CenterVertical;
                nextButton.SetTextColor(Color.White);
                nextButton.Click += BackgroundView_Click;
                if (MainActivity.IsTablet)
                    nextButton.SetX((cont.Resources.DisplayMetrics.WidthPixels / 10) * 8);
                else
                    nextButton.SetX((cont.Resources.DisplayMetrics.WidthPixels / 10) * 7);
                nextButton.SetY((cont.Resources.DisplayMetrics.HeightPixels / 10) * 7);
                mainView.AddView(nextButton, (int)(100 * density), (int)(50 * density));
            }
            if (clickCount == 4)
                nextButton.Text = "Ok.Got it !";
            else
                nextButton.Text = "Next";
        }

        private void CreateDataGrid()
        {
            deleteView = new LinearLayout(cont);
            deleteView.TextAlignment = TextAlignment.Center;
            deleteView.Orientation = Android.Widget.Orientation.Horizontal;
            deleteView.Click += swipeViewImage_Click;

            ImageView deleteImage = new ImageView(cont);
            deleteImage.SetImageResource(Resource.Drawable.Delete);
            deleteImage.SetBackgroundColor(Color.ParseColor("#EF5350"));

            TextView delete = new TextView(cont);
            delete.Text = "DELETE";
            delete.Gravity = GravityFlags.Center;
            delete.TextAlignment = TextAlignment.Center;
            delete.SetTextColor(Color.White);
            delete.SetBackgroundColor(Color.ParseColor("#EF5350"));

            viewModel = new SwipingViewModel();
            viewModel.SetRowstoGenerate(100);

            sfGrid = new SfDataGrid(cont);
            sfGrid.ViewDetachedFromWindow += SfGrid_ViewDetachedFromWindow;
            sfGrid.AutoGenerateColumns = false;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            sfGrid.AllowSwiping = true;
            sfGrid.AllowSorting = true;
            sfGrid.AllowResizingColumn = true;
            sfGrid.AllowDraggingRow = true;
            sfGrid.AllowEditing = true;
            sfGrid.ColumnSizer = ColumnSizer.Star;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.NavigationMode = NavigationMode.Cell;
            sfGrid.EditTapAction = TapAction.OnDoubleTap;
            sfGrid.GridLoaded += SfGrid_GridLoaded;
            sfGrid.SwipeEnded += SfGrid_SwipeEnded;
            sfGrid.RowHeight = 60;

            int width = cont.Resources.DisplayMetrics.WidthPixels;

            sfGrid.MaxSwipeOffset = (int)(120 * density);
            leftSwipeView = new SwipeView(cont);

            deleteView.AddView(deleteImage, (int)(30 * density), (int)sfGrid.RowHeight);
            deleteView.AddView(delete, sfGrid.MaxSwipeOffset - 30, (int)sfGrid.RowHeight);

            leftSwipeView.AddView(deleteView, sfGrid.MaxSwipeOffset, (int)sfGrid.RowHeight);

            sfGrid.LeftSwipeView = leftSwipeView;

            GridTextColumn CustomerID = new GridTextColumn();
            CustomerID.MappingName = "CustomerID";
            CustomerID.HeaderText = "Customer ID";
            GridTextColumn OrderID = new GridTextColumn();
            OrderID.MappingName = "OrderID";
            OrderID.HeaderText = "Order ID";
            OrderID.TextMargin = new Thickness(16, 0, 0, 0);
            OrderID.HeaderTextMargin = new Thickness(16, 0, 0, 0);

            GridTextColumn EmployeeID = new GridTextColumn();
            EmployeeID.MappingName = "EmployeeID";
            EmployeeID.HeaderText = "Employee ID";
            GridTextColumn Name = new GridTextColumn();
            Name.MappingName = "FirstName";
            Name.HeaderText = "Name";

            sfGrid.Columns.Add(OrderID);
            sfGrid.Columns.Add(CustomerID);
            sfGrid.Columns.Add(EmployeeID);
            sfGrid.Columns.Add(Name);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
        }

        private void SfGrid_ViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e)
        {
            pageExited = true;
            sfPopUp.Opened -= SfPopUp_PopupOpened;
            sfPopUp.Closed -= SfPopUp_PopupClosed;
            sfPopUp.PopupView.ClearAnimation();
            sfPopUp.Dispose();
            sfPopUp = null;
        }

        private void SfGrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            if (MainActivity.IsTablet)
                sfPopUp.Show((int)(cont.Resources.DisplayMetrics.WidthPixels / density - 50), 0);
            else
                sfPopUp.Show((int)(cont.Resources.DisplayMetrics.WidthPixels / density - 25), 0);
        }

        private void CreatePopup()
        {
            sfPopUp = new SfPopupLayout(cont);
            sfPopUp.PopupView.AnimationMode = AnimationMode.Fade;
            sfPopUp.PopupView.AnimationDuration = 50;
            sfPopUp.PopupView.PopupStyle.BorderThickness = 0;
            sfPopUp.PopupView.PopupStyle.BorderColor = Color.Transparent;
            sfPopUp.PopupView.ShowFooter = false;
            sfPopUp.PopupView.ShowHeader = false;
            sfPopUp.Opened += SfPopUp_PopupOpened;
            sfPopUp.Closed += SfPopUp_PopupClosed;
            sfPopUp.SetBackgroundColor(Color.Transparent);
            sfPopUp.PopupView.SetBackgroundColor(Color.Transparent);
            sfPopUp.StaysOpen = true;
            sfPopUp.PopupView.WidthRequest = 250;
            sfPopUp.PopupView.HeightRequest = 100;

            ImageView img = new ImageView(cont);
            img.SetImageResource(Resource.Drawable.Popup_InfoNotification);
            img.SetScaleType(ImageView.ScaleType.FitEnd);
            sfPopUp.PopupView.ContentView = img;
        }

        private void SfPopUp_PopupClosed(object sender, EventArgs e)
        {
            if (clickCount == 5)
            {
                mainView.RemoveView(backgroundView);
                mainView.RemoveView(nextButton);
            }
        }

        private  void SfPopUp_PopupOpened(object sender, EventArgs e)
        {
            sfPopUp.PopupView.AnimationMode = AnimationMode.None;
            try
            {
                if (clickCount == 0)
                {
                    anim = new TranslateAnimation(sfPopUp.GetX(), sfPopUp.GetX(), sfPopUp.GetY(), sfPopUp.GetY() + 30);
                    anim.Duration = 500; //You can manage the time of the blink with this parameter
                    anim.RepeatMode = RepeatMode.Reverse;
                    anim.RepeatCount = int.MaxValue;
                    sfPopUp.PopupView.StartAnimation(anim);
                }
                else if (clickCount == 1)
                {
                    sfPopUp.PopupView.ClearAnimation();
                    anim = new TranslateAnimation(popupLayoutpoint.X, popupLayoutpoint.X + (50 * density), popupLayoutpoint.Y, popupLayoutpoint.Y);
                    anim.Duration = 2000; //You can manage the time of the blink with this parameter
                    anim.RepeatMode = RepeatMode.Restart;
                    anim.RepeatCount = int.MaxValue;
                    sfPopUp.PopupView.StartAnimation(anim);
                }
                else if (clickCount == 2)
                {
                    sfPopUp.PopupView.ClearAnimation();
                    anim = new AlphaAnimation(0.0f, 1.0f);
                    anim.Duration = 250;
                    anim.RepeatCount = 1; //You can manage the time of the blink with this parameter
                    anim.RepeatMode = RepeatMode.Restart;
                    sfPopUp.PopupView.StartAnimation(anim);
                    anim.AnimationEnd += async (s, ev) =>
                     {
                         await Task.Delay(1000);
                         if(!pageExited)
                         sfPopUp.PopupView.StartAnimation(anim);
                     };
                }
                else if (clickCount == 3)
                {
                    sfPopUp.PopupView.ClearAnimation();
                    anim = null;
                    anim = new TranslateAnimation(popupLayoutpoint.X / density, (popupLayoutpoint.X / density) + 50 * density, popupLayoutpoint.Y / density, popupLayoutpoint.Y / density);
                    anim.Duration = 2000;
                    anim.RepeatCount = int.MaxValue; //You can manage the time of the blink with this parameter
                    anim.RepeatMode = RepeatMode.Restart;
                    sfPopUp.PopupView.StartAnimation(anim);
                }
                else if (clickCount == 4)
                {
                    DrawArc test;
                    sfPopUp.PopupView.ClearAnimation();
                    anim = null;
                    var handSymbol = (sfPopUp.PopupView.ContentView as RelativeLayout).GetChildAt(1);
                    if (MainActivity.IsTablet)
                        test = new DrawArc(2000, 1, -10, 1, 150, 1, -100);
                    else
                        test = new DrawArc(2000, 1, -50, 1, 350, 1, -300);
                    test.RepeatCount = int.MaxValue; //You can manage the time of the blink with this parameter
                    test.RepeatMode = RepeatMode.Restart;
                    handSymbol.StartAnimation(test);
                }
            }
            catch
            {

            }
        }

        private void AddBackgroundView()
        {
            if (mainView.IndexOfChild(backgroundView) == -1)
            {
                backgroundView = new View(cont);
                backgroundView.SetBackgroundColor(Color.Black);
                backgroundView.Alpha = 0.8f;
                backgroundView.Click += BackgroundView_Click;
                this.mainView.AddView(backgroundView, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            }
        }

        private void BackgroundView_Click(object sender, EventArgs e)
        {
            clickCount++;
            sfPopUp.IsOpen = false;
            if (imageView == null)
            {
                imageView = new ImageView(cont);
            }
            if (clickCount == 1)
            {
                LinearLayout linear = new LinearLayout(cont);
                linear.Orientation = Orientation.Horizontal;
                ImageView img = new ImageView(cont);
                img.SetImageResource(Resource.Drawable.Popup_ResizingIllustration);
                linear.AddView(img, (int)(150 * density), ViewGroup.LayoutParams.MatchParent);
                linear.AddView(new View(cont));
                sfPopUp.PopupView.HeightRequest = 150;
                sfPopUp.PopupView.WidthRequest = 250;
                sfPopUp.PopupView.ContentView = linear;
                sfPopUp.PopupView.AnimationMode = AnimationMode.Fade;
                popupLayoutpoint = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(0, 1));
                sfPopUp.Show(popupLayoutpoint.X, popupLayoutpoint.Y);
                sfPopUp.StaysOpen = true;
                img = null;
                linear = null;
            }
            else if (clickCount == 2)
            {
                imageView.SetImageResource(Resource.Drawable.Popup_EditIllustration);
                sfPopUp.PopupView.ContentView = imageView;
                var point = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(3, 3));
                sfPopUp.PopupView.AnimationMode = AnimationMode.Fade;
                sfPopUp.Show((int)(point.X / density), (int)(point.Y / density));
                sfPopUp.StaysOpen = true;
            }
            else if (clickCount == 3)
            {
                LinearLayout linear = new LinearLayout(cont);
                linear.Orientation = Orientation.Horizontal;
                ImageView img = new ImageView(cont);
                img.SetBackgroundColor(Color.Transparent);
                img.SetImageResource(Resource.Drawable.Popup_SwipeIllustration);
                linear.AddView(img, (int)(250 * density), ViewGroup.LayoutParams.MatchParent);
                linear.AddView(new View(cont));
                sfPopUp.PopupView.HeightRequest = 150;
                sfPopUp.PopupView.WidthRequest = 350;
                sfPopUp.PopupView.ContentView = linear;
                popupLayoutpoint = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(3, 0));
                sfPopUp.PopupView.AnimationMode = AnimationMode.Fade;
                sfPopUp.Show((int)(popupLayoutpoint.X / density), (int)(popupLayoutpoint.Y / density));
                img = null;
                linear = null;
            }
            else if (clickCount == 4)
            {
                RelativeLayout linear = new RelativeLayout(cont);

                ImageView img = new ImageView(cont);
                img.SetBackgroundColor(Color.Transparent);
                img.SetImageResource(Resource.Drawable.Popup_DragAndDropIllustration);

                ImageView img2 = new ImageView(cont);
                img2.SetBackgroundColor(Color.Transparent);
                img2.SetImageResource(Resource.Drawable.Popup_HandSymbol);

                linear.AddView(img, (int)(250 * density), ViewGroup.LayoutParams.MatchParent);
                linear.AddView(img2, (int)(50 * density), ViewGroup.LayoutParams.MatchParent);
                linear.AddView(new View(cont));
                if (MainActivity.IsTablet)
                    sfPopUp.PopupView.HeightRequest = 200;
                else
                    sfPopUp.PopupView.HeightRequest = 150;
                sfPopUp.PopupView.WidthRequest = 350;
                sfPopUp.PopupView.ContentView = linear;
                popupLayoutpoint = this.sfGrid.RowColumnIndexToPoint(new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(3, 0));
                sfPopUp.PopupView.AnimationMode = AnimationMode.Fade;
                sfPopUp.Show((int)(popupLayoutpoint.X / density), (int)(popupLayoutpoint.Y / density));
                img = null;
                img2 = null;
                linear = null;
            }
        }

        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Orientation.Vertical;
            allowsorting = new CheckBox(context);
            allowResizing = new CheckBox(context);
            allowEditing = new CheckBox(context);
            allowRowDragAndDrop = new CheckBox(context);

            allowsorting.Text = "Allow Sorting";
            allowResizing.Text = "Allow Resizing";
            allowEditing.Text = "Allow Editing";
            allowRowDragAndDrop.Text = "Allow RowDragAndDrop";


            allowsorting.Checked = true;
            allowResizing.Checked = true;
            allowEditing.Checked = true;
            allowRowDragAndDrop.Checked = true;


            allowsorting.CheckedChange += OnAllowSortingChanged;
            allowResizing.CheckedChange += OnAllowResizingChanged;
            allowEditing.CheckedChange += OnAllowEditingChanged;
            allowRowDragAndDrop.CheckedChange += OnAllowRowDragAndDropChanged;

            linear.AddView(allowsorting);
            linear.AddView(allowResizing);
            linear.AddView(allowEditing);
            linear.AddView(allowRowDragAndDrop);
            return linear;
        }

        void OnAllowRowDragAndDropChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                sfGrid.AllowDraggingRow = true;
            else
                sfGrid.AllowDraggingRow = false;
        }

        void OnAllowSortingChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                sfGrid.AllowSorting = true;
            else
                sfGrid.AllowSorting = false;
        }

        void OnAllowResizingChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                sfGrid.AllowResizingColumn = true;
            else
                sfGrid.AllowResizingColumn = false;
        }

        void OnAllowEditingChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                sfGrid.AllowEditing = true;
            else
                sfGrid.AllowEditing = false;
        }



        void GridGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (MainActivity.IsTablet)
                e.Column.MaximumWidth = 300;
            else
                e.Column.MaximumWidth = 150;
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.ColumnSizer = ColumnSizer.None;
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.ColumnSizer = ColumnSizer.None;
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else
                e.Cancel = true;
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
            allowsorting.CheckedChange -= OnAllowSortingChanged;
            allowResizing.CheckedChange -= OnAllowResizingChanged;
            allowEditing.CheckedChange -= OnAllowEditingChanged;
            allowRowDragAndDrop.CheckedChange -= OnAllowRowDragAndDropChanged;
            imageView = null;
            anim = null;
            backgroundView = null;
            viewModel = null;
            allowEditing = null;
            allowResizing = null;
            allowRowDragAndDrop = null;
            allowsorting = null;
            sfGrid.Dispose();
            sfGrid = null;
        }

        private void SfGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            swipedRowindex = e.RowIndex;
        }

        void swipeViewImage_Click(object sender, EventArgs e)
        {
            viewModel.OrdersInfo.RemoveAt(swipedRowindex - 1);
        }
    }

    public class DrawArc : Animation
    {
        private float displacementY;
        private Point start;
        private Point end;
        private Point middle;
        private float fromXValue;
        private float toXValue;
        private float y;
        private int startXType;
        private int endXType;
        private int yType;

        public DrawArc(long duration, int fromXType, float fromXValue,
                int toXType, float toXValue, int yType, float yValue)
        {
            this.Duration = duration;

            this.fromXValue = fromXValue;
            this.toXValue = toXValue;
            y = yValue;

            startXType = fromXType;
            endXType = toXType;
            this.yType = yType;

        }

        private long CalculatePoints(float interpolatedTime, float p0, float p1, float p2)
        {
            return (long)Math.Round((Math.Pow((1 - interpolatedTime), 2) * p0)
                   + (2 * (1 - interpolatedTime) * interpolatedTime * p1)
                   + (Math.Pow(interpolatedTime, 2) * p2));
        }

        protected override void ApplyTransformation(float interpolatedTime, Transformation t)
        {
            float displacementX = CalculatePoints(interpolatedTime, start.X, middle.X, end.X);
            if (MainActivity.IsTablet)
                displacementY = CalculatePoints(interpolatedTime, start.Y, middle.Y, end.Y - 50);
            else
                displacementY = CalculatePoints(interpolatedTime, start.Y, middle.Y, end.Y + 50);
            t.Matrix.SetTranslate(displacementX - 50, displacementY);
        }

        public override void Initialize(int width, int height, int parentWidth, int parentHeight)
        {
            base.Initialize(width, height, parentWidth, parentHeight);
            float startX = ResolveSize(Dimension.Absolute, fromXValue, width, parentWidth);
            float endX = ResolveSize(Dimension.Absolute, toXValue, width, parentWidth);
            float middleY = ResolveSize(Dimension.Absolute, y, width, parentWidth);
            float middleX = startX + ((endX - startX) / 2);
            start = new Point((int)startX, 0);
            end = new Point((int)endX, 100);
            middle = new Point((int)middleX, (int)middleY);
        }
    }
}

