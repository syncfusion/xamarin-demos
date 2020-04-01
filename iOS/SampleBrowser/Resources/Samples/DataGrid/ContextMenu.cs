#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.iOS.PopupLayout;
using Syncfusion.SfDataGrid;
using System.Linq;
using System.Collections;
using UIKit;
using System.ComponentModel;

namespace SampleBrowser
{
    public class ContextMenu : SampleView
    {

        #region Private Field
        //Source Initializing
        private SfDataGrid sfGrid;
        private SfPopupLayout sfPopup;
        private ContextMenuViewModel contextMenuItem;


        private String currentColumn;

        //Button and Image Initializing
        private UIView buttonColumn;
        private UIView imageColumn;

        //Buttons and Image Arrray
        private string[] contextMenuButtonNames;
        private string[] contextMenuImageNames;
        #endregion

        #region Constructor
        public ContextMenu()
        {
            //Button and Images Name's Contained in array
            this.contextMenuButtonNames = new string[] { "Sort Ascending", "Sort Descending", "Clear Sorting", "seperator", "Group this Column", "Clear Grouping" };
            this.contextMenuImageNames = new string[] { "Images/Sort_Ascending_Icons.png", "Images/Sort_descending_Icons.png", "Images/Clear_sorting_Icon.png", "seperator", "Images/Grouping_Icon.png", "Images/Clear_grouping_icon.png" };

            this.sfGrid = new SfDataGrid();
            this.sfGrid.AutoGenerateColumns = true;
            this.contextMenuItem = new ContextMenuViewModel();
            this.sfGrid.ItemsSource = this.contextMenuItem.Products;

            this.sfPopup = new SfPopupLayout();
            this.sfPopup.Content = this.sfGrid;

            //Event Handling
            this.sfGrid.GridLongPressed += SfGrid_GridLongPressed;

            //Popup Initializing 
            InitializingPopContent();

            //ContextMenu Initializing
            InitializingContextMenuLayout();

            //Adding the poppup view as rootView 
            this.Add(this.sfPopup);
        }
        #endregion

        #region Methods
        public override void LayoutSubviews()
        {
            this.sfPopup.Frame = new CoreGraphics.CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews();
        }

        private void InitializingPopContent()
        {
            this.sfPopup.PopupView.AnimationMode = AnimationMode.Fade;
            this.sfPopup.PopupView.AnimationDuration = 300;
            this.sfPopup.PopupView.ShowHeader = false;
            this.sfPopup.PopupView.ShowFooter = false;
            this.sfPopup.PopupView.ShowCloseButton = false;
            this.sfPopup.PopupView.Frame = new CoreGraphics.CGRect(0, 0, 200, 200);
        }

        private void InitializingContextMenuLayout()
        {
            //contextMenu
            UIView contextMenu = new UIView();
            contextMenu.BackgroundColor = UIColor.White;
            contextMenu.Frame = new CGRect(0, 0, 200, 200);

            //contextMenuView with horizontal alignment to hold the imageColum & buttonColumn
            UIStackView contextMenuView = new UIStackView
            {
                Axis = UILayoutConstraintAxis.Horizontal
            };
            contextMenuView.Frame = new CGRect(0, 0, 200, 200);

            //initializing & Framing 
            this.imageColumn = new UIView();
            this.imageColumn.Frame = new CGRect(10, 0, 50, 200);
            this.buttonColumn = new UIView();
            this.buttonColumn.Frame = new CGRect(imageColumn.Frame.Width, 0, 150, 200);

            //Method to creating Image's and Button
            CreateImages(contextMenuImageNames);
            CreateButtons(contextMenuButtonNames);

            contextMenuView.AddSubview(this.imageColumn);
            contextMenuView.AddSubview(this.buttonColumn);

            contextMenu.AddSubview(contextMenuView);

            this.sfPopup.PopupView.ContentView = contextMenu;
        }

        void SfGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
        {
            this.currentColumn = this.sfGrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName;
            this.sfPopup.ShowAtTouchPoint();
        }

        private void CreateImages(string[] imageNames)
        {
            var initialEntry = false;
            for (int i = 0; i < imageNames.Length; i++)
            {
                if (imageNames[i].Equals("seperator"))
                {
                    UIView seperatorView = new UIView();
                    seperatorView.BackgroundColor = UIKit.UIColor.White;
                    seperatorView.Frame = new CGRect(0, imageColumn.Subviews[i - 1].Frame.Bottom + 5, 30, 2);
                    seperatorView.Alpha = .1f;
                    this.imageColumn.AddSubview(seperatorView);
                }
                else
                {
                    UIImageView imageView = new UIImageView();
                    imageView.Image = new UIImage(imageNames[i]);
                    imageView.Frame = !initialEntry ?
                        new CGRect(0, 10, 25, 25) :
                        new CGRect(0, imageColumn.Subviews[i - 1].Frame.Bottom + 10, 25, 25);
                    if (imageNames[i].Equals("Images/Clear_sorting_Icon.png") || imageNames[i].Equals("Images/Clear_grouping_icon.png"))
                    {
                        imageView.Alpha = .3f;
                    }

                    //Adding the every image into the contextMenuOptionImage
                    this.imageColumn.AddSubview(imageView);
                    initialEntry = true;
                }
            }
        }

        private void CreateButtons(string[] buttonNames)
        {
            var initialEntry = false;

            for (int i = 0; i < buttonNames.Length; i++)
            {
                if (buttonNames[i].Equals("seperator"))
                {
                    UIView seperatorView = new UIView();
                    seperatorView.BackgroundColor = UIColor.Gray;
                    seperatorView.Frame = new CGRect(-42, buttonColumn.Subviews[i - 1].Frame.Bottom + 1, 180, 1);
                    seperatorView.Alpha = .3f;
                    this.buttonColumn.AddSubview(seperatorView);
                }
                else
                {
                    UIButton buttonView = UIButton.FromType(UIButtonType.System);
                    buttonView.SetTitle(buttonNames[i], UIControlState.Normal);
                    buttonView.SetTitleColor(UIColor.Black, UIControlState.Normal);
                    buttonView.Frame = !initialEntry ?
                        new CGRect(0, 10, this.buttonColumn.Frame.Width, this.buttonColumn.Frame.Height / 6) :
                        new CGRect(0, buttonColumn.Subviews[i - 1].Frame.Bottom + 2, this.buttonColumn.Frame.Width, this.buttonColumn.Frame.Height / 6);

                    if (buttonNames[i].Equals("Clear Sorting") || buttonNames[i].Equals("Clear Grouping"))
                    {
                        buttonView.Alpha = .3f;
                    }

                    buttonView.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;

                    //Event Trigger
                    buttonView.TouchUpInside += ButtonTouch;

                    //Adding the every button into the contextMenuButton
                    this.buttonColumn.AddSubview(buttonView);
                    initialEntry = true;
                }
            }
        }

        private void ButtonTouch(object sender, EventArgs e)
        {
            var buttonName = (sender as UIButton).TitleLabel.Text;
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
            this.sfPopup.IsOpen = false;
        }

        private void ApplyAlphaToSorting(string buttonName)
        {
            this.imageColumn.Subviews[0].Alpha = buttonName == "Sort Ascending" ? .4f : 1f;
            this.buttonColumn.Subviews[0].Alpha = buttonName == "Sort Ascending" ? .4f : 1f;

            this.imageColumn.Subviews[1].Alpha = buttonName == "Sort Descending" ? .4f : 1f;
            this.buttonColumn.Subviews[1].Alpha = buttonName == "Sort Descending" ? .4f : 1f;

            this.imageColumn.Subviews[2].Alpha = this.sfGrid.SortColumnDescriptions.Count > 0 ? 1f : .4f;
            this.buttonColumn.Subviews[2].Alpha = this.sfGrid.SortColumnDescriptions.Count > 0 ? 1f : .4f;
        }

        private void ApplyAlphaToGrouping()
        {
            (this.buttonColumn.Subviews[4] as UIButton).Enabled = this.sfGrid.GroupColumnDescriptions.Count > 0 ? false : true;
            this.buttonColumn.Subviews[4].Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? .4f : 1;
            this.imageColumn.Subviews[4].Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? .4f : 1;
            this.imageColumn.Subviews[5].Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? 1f : .4f;
            this.buttonColumn.Subviews[5].Alpha = this.sfGrid.GroupColumnDescriptions.Count > 0 ? 1f : .4f;
        }
        #endregion
    }
}
