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
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.PopupLayout;
using Syncfusion.SfDataGrid;
using Android.Support.V7.Widget;
using System.Drawing;
using Android.Content;
using static Android.App.ActionBar;
using System.ComponentModel;

namespace SampleBrowser
{
    public class ContextMenu : SamplePage
    {
        #region Private Field
        //Source Initializing
        private SfDataGrid sfGrid;
        private SfPopupLayout sfPopupLayout;
        private ContextMenuModel itemViewModel;
        private string currentColumn;

        //Button field
        private Button sortAscendingButton;
        private Button sortDescendingButton;
        private Button clearSortingButton;
        private Button groupColumnButton;
        private Button clearGroupingButton;


        //Image field
        ImageView sortAscendingImage;
        ImageView sortDescendingImage;
        ImageView clearSortingImage;
        ImageView groupColumnImage;
        ImageView clearGroupingImage;

        //Initial values 
        private int initialValue = 20;
        private int initialPoppupHeight = 200;
        private int initialPoppupWidth = 200;
        private int gridHeight;
        private int imagesHeight;
        private double displayDensity;
        #endregion

        #region Methods
        public override Android.Views.View GetSampleContent(Android.Content.Context context)
        {
            // Initializing grid with required properties
            this.sfGrid = new SfDataGrid(context);
            this.sfGrid.AutoGenerateColumns = true;
            this.itemViewModel = new ContextMenuModel();
            this.sfGrid.ItemsSource = itemViewModel.OrderInfo;
            this.sfPopupLayout = new SfPopupLayout(context);

            //Calculation for the image and gridHeight
            this.displayDensity = (sfPopupLayout.Resources.DisplayMetrics.Density);
            this.imagesHeight = (int)(initialValue * displayDensity);
            this.gridHeight = (int)(198.5 * displayDensity) / 5;

            //Initializing SfPoplayout with required properties
            this.InitializePopLayout(context);

            //Initializing the layout to be displayed inside popup
            this.InitializingContextMenuLayout(context);

            this.sfGrid.GridLongPressed += SfGrid_GridLongPressed;

            //RootView is Poplayout so sfgrid view added as child to poppup
            this.sfPopupLayout.Content = this.sfGrid;
            return sfPopupLayout;
        }

        private void InitializePopLayout(Context context)
        {
            this.sfPopupLayout.PopupView.AnimationMode = AnimationMode.Fade;
            this.sfPopupLayout.PopupView.AnimationDuration = 300;
            this.sfPopupLayout.PopupView.ShowCloseButton = false;
            this.sfPopupLayout.PopupView.ShowFooter = false;
            this.sfPopupLayout.PopupView.ShowHeader = false;
            this.sfPopupLayout.PopupView.WidthRequest = initialPoppupWidth;
            this.sfPopupLayout.PopupView.HeightRequest = initialPoppupHeight;
        }

        private void InitializingContextMenuLayout(Context context)
        {
            LinearLayout contextMenu = new LinearLayout(context);
            contextMenu.Orientation = Android.Widget.Orientation.Vertical;

            #region Image declaring
            this.sortAscendingImage = new ImageView(context);
            this.sortAscendingImage.SetImageResource(Resource.Drawable.Sort_Ascending_Icons);
            this.sortDescendingImage = new ImageView(context);
            this.sortDescendingImage.SetImageResource(Resource.Drawable.Sort_descending_Icons);
            this.clearSortingImage = new ImageView(context);
            this.clearSortingImage.SetImageResource(Resource.Drawable.Clear_sorting_Icon);
            this.clearSortingImage.Alpha = .2f;
            this.groupColumnImage = new ImageView(context);
            this.groupColumnImage.SetImageResource(Resource.Drawable.Grouping_Icon);
            this.clearGroupingImage = new ImageView(context);
            this.clearGroupingImage.SetImageResource(Resource.Drawable.Clear_grouping_icon);
            this.clearGroupingImage.Alpha = .2f;
            #endregion

            #region Button
            this.sortAscendingButton = CreateButton("Sort Ascending", context);
            this.sortDescendingButton = CreateButton("Sort Descending", context);
            this.clearSortingButton = CreateButton("Clear Sorting", context);
            this.groupColumnButton = CreateButton("Group this Column", context);
            this.clearGroupingButton = CreateButton("Clear Grouping", context);
            #endregion

            #region Seperator View
            View seperatorView = new View(context);
            seperatorView.SetBackgroundColor(Android.Graphics.Color.Gray);
            seperatorView.Alpha = .3f;
            #endregion

            #region GridLayout With Button and Image
            GridLayout ascendingGrid = CreateGridWithViews(context, sortAscendingButton, sortAscendingImage);
            GridLayout descendigGrid = CreateGridWithViews(context, sortDescendingButton, sortDescendingImage);
            GridLayout clearSortingGrid = CreateGridWithViews(context, clearSortingButton, clearSortingImage);
            GridLayout groupingGrid = CreateGridWithViews(context, groupColumnButton, groupColumnImage);
            GridLayout ClearGroupingGrid = CreateGridWithViews(context, clearGroupingButton, clearGroupingImage);
            #endregion

            contextMenu.AddView(ascendingGrid, ViewGroup.LayoutParams.MatchParent, gridHeight);
            contextMenu.AddView(descendigGrid, ViewGroup.LayoutParams.MatchParent, gridHeight);
            contextMenu.AddView(clearSortingGrid, ViewGroup.LayoutParams.MatchParent, gridHeight);
            contextMenu.AddView(seperatorView, ViewGroup.LayoutParams.MatchParent, (int)(1.5 * displayDensity));
            contextMenu.AddView(groupingGrid, ViewGroup.LayoutParams.MatchParent, gridHeight);
            contextMenu.AddView(ClearGroupingGrid, ViewGroup.LayoutParams.MatchParent, gridHeight);

            this.sfPopupLayout.PopupView.ContentView = contextMenu;
        }

        private void SfGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
        {
            this.currentColumn = this.sfGrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName;
            this.sfPopupLayout.ShowAtTouchPoint();
        }

        private GridLayout CreateGridWithViews(Context context, Button bundleButton, ImageView bundleImage)
        {
            GridLayout gridView = new GridLayout(context);
            gridView.AlignmentMode = GridAlign.Bounds;
            gridView.ColumnCount = 2;
            gridView.Orientation = GridOrientation.Horizontal;
            gridView.UseDefaultMargins = true;
            gridView.AddView(bundleImage, this.imagesHeight, this.imagesHeight);
            gridView.AddView(bundleButton);
            return gridView;
        }

        private Button CreateButton(String content, Context context)
        {
            Button optionButton = new Button(context);
            optionButton.SetBackgroundColor(Android.Graphics.Color.Transparent);
            optionButton.SetPadding(0, 0, 20, 0);
            optionButton.Text = content;
            optionButton.TextSize = 16;
            optionButton.Gravity = GravityFlags.Left;
            optionButton.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            optionButton.Click += OptionButton_Click;
            if (content.Equals("Clear Sorting") || content.Equals("Clear Grouping"))
            {
                optionButton.Alpha = .2f;
            }
            return optionButton;
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            var buttonName = (sender as Button).Text;
            switch (buttonName)
            {
                case "Sort Ascending":
                case "Sort Descending":
                case "Clear Sorting":
                    this.sfGrid.SortColumnDescriptions.Clear();
                    if (!(buttonName == "Clear Sorting"))
                    {
                        // Sorting is applied
                        this.sfGrid.SortColumnDescriptions.Add(new SortColumnDescription()
                        {
                            ColumnName = this.currentColumn,
                            SortDirection = (buttonName == "Sort Ascending") ? ListSortDirection.Ascending : ListSortDirection.Descending
                        });
                    }
                    ApplyAlphaToSorting(buttonName);
                    break;

                case "Group this Column":
                case "Clear Grouping":
                    {
                        if (sfGrid.GroupColumnDescriptions.Count == 0)
                        {
                            // Grouping is applied
                            sfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = this.currentColumn });
                        }
                        else
                        {
                            // Clears the Grouping
                            this.sfGrid.GroupColumnDescriptions.Clear();
                            if (this.sfGrid.SortColumnDescriptions.Count > 0)
                            {
                                this.sfGrid.SortColumnDescriptions.Clear();
                                ApplyAlphaToSorting("Clear Sorting");
                            }
                        }
                        ApplyAlphaToGrouping();
                        break;
                    }
            }
            this.sfPopupLayout.IsOpen = false;
        }

        private void ApplyAlphaToSorting(string buttonName)
        {
            this.sortAscendingImage.Alpha = buttonName == "Sort Ascending" ? .2f : 1f;
            this.sortAscendingButton.Alpha = buttonName == "Sort Ascending" ? .2f : 1f;

            this.sortDescendingImage.Alpha = buttonName == "Sort Descending" ? .2f : 1f;
            this.sortDescendingButton.Alpha = buttonName == "Sort Descending" ? .2f : 1f;

            this.clearSortingImage.Alpha = this.sfGrid.SortColumnDescriptions.Count > 0 ? 1f : .4f;
            this.clearSortingButton.Alpha = this.sfGrid.SortColumnDescriptions.Count > 0 ? 1f : .4f;
        }

        private void ApplyAlphaToGrouping()
        {
            this.groupColumnButton.Enabled = this.sfGrid.GroupColumnDescriptions.Count > 0 ? false : true;
            this.groupColumnButton.Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? .2f : 1;
            this.groupColumnImage.Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? .2f : 1;
            this.clearGroupingImage.Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? 1f : .2f;
            this.clearGroupingButton.Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? 1f : .2f;
        }
        #endregion

        #region Dispose
        public override void Destroy()
        {
            this.sfPopupLayout.Dispose();
            sfGrid = null;
            itemViewModel = null;
        }
        #endregion
    }
}