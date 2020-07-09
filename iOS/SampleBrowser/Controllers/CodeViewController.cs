#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Foundation;
using CoreGraphics;

#endregion
using System;
using UIKit;

namespace SampleBrowser
{
    public class CodeViewController : UIViewController
    {
        #region fields

        private UILabel viewer;

        private bool menuVisible;

        private UIView fadeOutView;

        private UIScrollView scrollview;

        private UIBarButtonItem menuButton;

        #endregion

        #region ctor

        public CodeViewController()
        {
            SampleName = string.Empty;
            ControlName = string.Empty;
        }

        #endregion

        #region properties

        public NSArray SampleDictionaryArray { get; set; }

        public string SampleName { get; set; }

        public string ControlName { get; set; }

        public UIView MenuView { get; set; }

        public UITableView MenuTable { get; set; }

        #endregion

        #region methods

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBar.BarTintColor = Utility.ThemeColor;
            this.View.BackgroundColor = UIColor.White;

            menuButton = new UIBarButtonItem
            {
                Image = UIImage.FromBundle("Images/Changefile"),
                Style = UIBarButtonItemStyle.Plain,
                Target = this
            };
            menuButton.Clicked += OpenMenu;

            fadeOutView = new UIView(this.View.Bounds)
            {
                BackgroundColor = UIColor.FromRGBA(0.537f, 0.537f, 0.537f, 0.3f)
            };

            UITapGestureRecognizer singleFingerTap = new UITapGestureRecognizer();
            singleFingerTap.AddTarget(() => HandleSingleTap(singleFingerTap));
            fadeOutView.AddGestureRecognizer(singleFingerTap);

            string controlListPathString = NSBundle.MainBundle.BundlePath + "/plist/SourceList.plist";
            NSDictionary controlDict = new NSDictionary();
            controlDict = NSDictionary.FromFile(controlListPathString);
            NSString controlDictKey = new NSString(ControlName);
            string sample = GetFileName(SampleName);

            NSDictionary controlDictArray = controlDict.ValueForKey(controlDictKey) as NSDictionary;
            if (controlDictArray != null)
            {
                NSString sampleDictKey = new NSString(sample);
                SampleDictionaryArray = controlDictArray.ValueForKey(sampleDictKey) as NSArray;

                if (SampleDictionaryArray != null)
                {
                    sample = (string)SampleDictionaryArray.GetItem<NSString>(0);
                    this.NavigationItem.SetRightBarButtonItem(menuButton, true);

                    menuVisible = false;
                    nfloat height = this.View.Bounds.Height - 64;
                    nfloat left = this.View.Bounds.Width - 260;
                    MenuView = new UIView(new CGRect(left, 64, 260, height));
                    MenuTable = new UITableView(new CGRect(0, 0, 260, height));
                    MenuTable.Layer.BorderWidth = 0.5f;
                    MenuTable.Layer.BorderColor = UIColor.FromRGBA(0.537f, 0.537f, 0.537f, 0.5f).CGColor;
                    MenuTable.BackgroundColor = UIColor.White;
                    MenuTable.Source = new SampleDataSource(this);
                    NSIndexPath indexPath = NSIndexPath.FromRowSection(0, 0);

                    MenuTable.SelectRow(indexPath, false, UITableViewScrollPosition.Top);
                    MenuView.AddSubview(MenuTable);
                }
            }

            viewer = new UILabel
            {
                Font = UIFont.SystemFontOfSize(12.0f),
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };
            viewer.SizeToFit();

            scrollview = new UIScrollView();
            scrollview.AddSubview(viewer);
            this.View.AddSubview(scrollview);
            this.LoadSample((string)sample);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            if (viewer != null)
            {
                viewer.RemoveFromSuperview();
                viewer.Dispose();
                viewer = null;
            }

            if (scrollview != null)
            {
                scrollview.RemoveFromSuperview();
                scrollview.Dispose();
                scrollview = null;
            }

            Utility.DisposeEx(this.View);
            this.Dispose();
        }

        public void LoadSample(string sample)
        {
            this.Title = sample + ".cs";

            menuVisible = false;

            string sampleListPathString = NSBundle.MainBundle.BundlePath + "/Samples/" + this.ControlName + "/" + sample + ".cs";
            NSData data = NSData.FromFile(sampleListPathString);
            string text = NSString.FromData(data, NSStringEncoding.UTF8);

            viewer.Text = text;
            viewer.Lines = 10000;

            viewer.SizeToFit();

            viewer.Frame = new CGRect(5, 5, viewer.Frame.Width + 5, viewer.Frame.Height + 5);
            CGSize maxSize = new CGSize(viewer.Frame.Size.Width, float.MaxValue);
            CGSize labelSize = viewer.SizeThatFits(maxSize);
            scrollview.Frame = new CGRect(0, 0, this.View.Frame.Size.Width, this.View.Frame.Size.Height);
            scrollview.ContentSize = labelSize;
            scrollview.ContentOffset = new CGPoint(0, 0);
        }

        public void HideMenu()
        {
            MenuView.Frame = new CGRect(this.View.Bounds.Width - 260, 64, 260, this.View.Bounds.Height - 64 - 49);
            fadeOutView.RemoveFromSuperview();
            UIView.AnimateNotify(
                0.3,
                () => MenuView.Frame = new CGRect(
                    this.View.Bounds.Width,
                    64,
                    260,
                    this.View.Bounds.Height - 64 - 49),
                    (bool finished) =>
                    {
                        if (finished)
                        {
                            MenuView.RemoveFromSuperview();
                        }
                    });
        }

        private void ShowMenu()
        {
            MenuView.Frame = new CGRect(this.View.Bounds.Width, 64, 260, this.View.Bounds.Height - 64 - 49);
            UIView.Animate(0.3, () => MenuView.Frame = new CGRect(this.View.Bounds.Width - 260, 64, 260, this.View.Bounds.Height - 64 - 49));
        }

        private void OpenMenu(object sender, EventArgs ea)
        {
            if (menuVisible)
            {
                menuVisible = false;
                HideMenu();
            }
            else
            {
                menuVisible = true;
                this.View.AddSubview(fadeOutView);
                this.View.AddSubview(MenuView);
                ShowMenu();
            }
        }

        private static string GetFileName(string selectedSample)
        {
            string name = selectedSample;

            if (name == "Stacked Area")
            {
                name = "StackingArea";
            }
            else if (name == "AutoComplete")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "AutoComplete_Tablet" : "AutoComplete";
            }
            else if (name == "BusyIndicator")
            {
                name = "BusyIndicator_Mobile";
            }
            else if (name == "CalendarViews")
            {
                name = "CalendarViews_Mobile";
            }
            else if (name == "CalendarLocalization")
            {
                name = "CalendarLocalization_Mobile";
            }
            else if (name == "CalendarConfiguration")
            {
                name = "CalendarConfiguration_Mobile";
            }
            else if (name == "Carousel")
            {
                name = "Carousel_Mobile";
            }
            else if (name == "NumericTextBox")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "NumericTextBox_Tablet" : "NumericTextBox_Mobile";
            }
            else if (name == "NumericUpDown")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "NumericUpDown_Tablet" : "NumericUpDown_Tablet";
            }
            else if (name == "RangeSlider")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "RangeSlider_Tablet" : "RangeSlider_Mobile";
            }
            else if (name == "Rating")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "Rating_Tablet" : "Rating_Mobile";
            }
            else if (name == "SegmentedControl")
            {
                name = "SegementViewGettingStarted";
            }
            else if (name == "Rotator")
            {
                name = "Rotator_Mobile";
            }
            else if (name == "RangeSliderGettingStarted")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "RangeSliderGettingStarted_Tablet" : "RangeSliderGettingStarted_Mobile";
            }
            else if (name == "MaskedEdit")
            {
                name = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad
                    ? "MaskedEdit_Tablet" : "MaskedEdit_Mobile";
            }
            else if (name == "CheckBox")
            {
                name = "CheckBox_Mobile";
            }
            else if (name == "RadioButton")
            {
                name = "RadioButton_Mobile";
            }
            else if (name == "PdfViewerDemo")
            {
                name = "GettingStartedPDFViewer";
            }
            else if (name == "Stacked Column")
            {
                name = "StackingColumn";
            }
            else if (name == "Stacked Bar")
            {
                name = "StackingBar";
            }
            else if (name == "100% Stacked Area")
            {
                name = "StackingArea100";
            }
            else if (name == "100% Stacked Column")
            {
                name = "StackingColumn100";
            }
            else if (name == "100% Stacked Bar")
            {
                name = "StackingBar100";
            }
            else if (name == "Data Point Selection")
            {
                name = "ChartSelection";
            }
            else if (name == "Zooming and Panning")
            {
                name = "ChartZooming";
            }
            else if (name == "Live Update")
            {
                name = "LiveUpate";
            }
            else if (name == "Category Axis")
            {
                name = "Category";
            }
            else if (name == "Numerical Axis")
            {
                name = "Numerical";
            }
            else if (name == "Logarithmic Axis")
            {
                name = "Logarithmic";
            }
            else if (name == "Multiple Axes")
            {
                name = "MultipleAxis";
            }
            else if (name == "Strip Lines")
            {
                name = "StripLine";
            }
            else if (name == "DateTime Axis")
            {
                name = "Date";
            }

            if (name != "Vertical Chart")
            {
                name = name.Replace(" ", string.Empty);
            }

            return name;
        }

        private void HandleSingleTap(UITapGestureRecognizer gesture)
        {
            if (menuVisible)
            {
                menuVisible = false;
                HideMenu();
            }
        }

        #endregion
    }

    internal class SampleDataSource : UITableViewSource
    {
        #region fields

        private CodeViewController controller;

        #endregion

        #region ctor

        public SampleDataSource(CodeViewController sampleControl)
        {
            this.controller = sampleControl;
        }

        #endregion

        #region methods

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return (nint)this.controller.SampleDictionaryArray.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            nuint row = (nuint)indexPath.Row;

            string sample = this.controller.SampleDictionaryArray.GetItem<NSString>(row);

            this.controller.HideMenu();
            this.controller.LoadSample(sample);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(AllControlsViewCell.Key) as AllControlsViewCell;
            if (cell == null)
            {
                cell = new AllControlsViewCell();
            }

            nuint row = (nuint)indexPath.Row;

            string sample = this.controller.SampleDictionaryArray.GetItem<NSString>(row);

            string[] tokens = sample.Split('/');

            if (tokens.Length > 1)
            {
                sample = tokens[tokens.Length - 1];
            }

            cell.TextLabel.Text = sample + ".cs";

            cell.DetailTextLabel.Font = UIFont.FromName("Helvetica", 10f);
            cell.DetailTextLabel.TextColor = UIColor.White;
            cell.TextLabel.HighlightedTextColor = Utility.ThemeColor;

            UIView selectionColor = new UIView();
            selectionColor.Frame = cell.Frame;
            selectionColor.BackgroundColor = UIColor.FromRGB(249, 249, 249);
            cell.SelectedBackgroundView = selectionColor;

            return cell;
        }

        #endregion
    }
}