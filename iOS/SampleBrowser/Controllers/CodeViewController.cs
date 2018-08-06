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
		UILabel viewer;
		bool 	menuVisible;
		UIView 	fadeOutView;
		UIScrollView 	scrollview;
		UIBarButtonItem menuButton;

		public NSArray sampleDictArray {
			get;
			set;
		}

		public CodeViewController ()
		{
			sampleName	= "";
			controlName	= "";
		}

		public string sampleName {
			get;
			set;
		}

		public string controlName {
			get;
			set;
		}

		public UIView menuView {
			get;
			set;
		}

		public UITableView menuTable {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			this.NavigationController.NavigationBar.BarTintColor = Utility.themeColor;
			this.View.BackgroundColor 	= UIColor.White;

			menuButton 					= new UIBarButtonItem();
			menuButton.Image 			= UIImage.FromBundle ("Images/Changefile");
			menuButton.Style 			= UIBarButtonItemStyle.Plain;
			menuButton.Target 			= this;
			menuButton.Clicked 	  	   += OpenMenu;

			fadeOutView               	= new UIView(this.View.Bounds);
			fadeOutView.BackgroundColor	= UIColor.FromRGBA( 0.537f ,0.537f,0.537f,0.3f);

			UITapGestureRecognizer singleFingerTap 	= new UITapGestureRecognizer ();
			singleFingerTap.AddTarget(() 			=> HandleSingleTap(singleFingerTap));
			fadeOutView.AddGestureRecognizer (singleFingerTap);

			string controlListPathString 	= NSBundle.MainBundle.BundlePath + "/plist/SourceList.plist";
			NSDictionary controlDict 		= new NSDictionary();
			controlDict 					= NSDictionary.FromFile(controlListPathString);
			NSString controlDictKey 		= new NSString (controlName);
			NSDictionary controlDictArray   = controlDict.ValueForKey (controlDictKey) as NSDictionary;
			string sample					= updateFileName( sampleName);

			if (controlDictArray != null) 
			{
				NSString sampleDictKey 	= new NSString (sample);
				sampleDictArray 		= controlDictArray.ValueForKey (sampleDictKey) as NSArray;

				if (sampleDictArray != null) 
				{
					sample 				= (string)sampleDictArray.GetItem<NSString> (0);
					this.NavigationItem.SetRightBarButtonItem (menuButton, true);

					menuVisible 				= false;
					nfloat height              	= this.View.Bounds.Height - 64;
					nfloat left                	= this.View.Bounds.Width - 260;
					menuView                  	= new UIView(new CGRect( left, 64, 260, height));
					menuTable 					= new UITableView (new CGRect (0, 0, 260, height));
					menuTable.Layer.BorderWidth = 0.5f;
					menuTable.Layer.BorderColor = (UIColor.FromRGBA (0.537f, 0.537f, 0.537f, 0.5f)).CGColor;
					menuTable.BackgroundColor 	= UIColor.White;
					menuTable.Source 			= new sampleDataSource (this) ;
					NSIndexPath indexPath 		= NSIndexPath.FromRowSection (0, 0);

					menuTable.SelectRow (indexPath, false, UITableViewScrollPosition.Top);
					menuView.AddSubview (menuTable);
				}
			}

			viewer 		 = new UILabel ();
			viewer.Font  = UIFont.SystemFontOfSize (12.0f);
			viewer.Lines = 0;
			viewer.LineBreakMode = UILineBreakMode.WordWrap;
			viewer.SizeToFit ();

			scrollview = new UIScrollView ();

			scrollview.AddSubview (viewer);
			this.View.AddSubview (scrollview);
			this.loadSample ((string)sample);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			if (viewer != null) {
				viewer.RemoveFromSuperview ();
				viewer.Dispose ();
				viewer = null;
			}

			if (scrollview != null) {
				scrollview.RemoveFromSuperview ();
				scrollview.Dispose ();
				scrollview = null;
			}

			Utility.DisposeEx(this.View);
			this.Dispose();
		}


		public void loadSample(string sample)
		{
			this.Title 					= sample + ".cs";

			menuVisible = false;

			string sampleListPathString = NSBundle.MainBundle.BundlePath + "/Samples/"+ this.controlName + "/" + sample + ".cs";
			NSData data 	 = NSData.FromFile (sampleListPathString);
			string text		 = NSString.FromData (data, NSStringEncoding.UTF8);

			viewer.Text 	 = text;
            viewer.Lines = 10000;

			viewer.SizeToFit ();

			viewer.Frame		= new CGRect (5, 5, viewer.Frame.Width + 5 , viewer.Frame.Height + 5);
			CGSize maxSize 		= new CGSize (viewer.Frame.Size.Width, float.MaxValue);
			CGSize labelSize 	= viewer.SizeThatFits (maxSize);
			scrollview.Frame 	= new CoreGraphics.CGRect(0, 0, this.View.Frame.Size.Width , this.View.Frame.Size.Height);

			scrollview.ContentSize = labelSize;

			//Move scrollview to top of the view
			scrollview.ContentOffset = new CGPoint (0,0);
		}

		void OpenMenu (object sender, EventArgs ea) 
		{
			if (menuVisible) 
			{
				menuVisible = false;
				HideMenu ();
			}
			else 
			{
				menuVisible = true;
				this.View.AddSubview (fadeOutView);
				this.View.AddSubview (menuView);
				ShowMenu ();
			}
		}

		string updateFileName(string selectedSample)
		{
			string name = selectedSample;

			if (name == "Stacked Area") {
				name = "StackingArea";
			}else if(name=="AutoComplete") 
			{
		   		if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			    {
					name="AutoComplete_Tablet";
				}
				else
					name="AutoComplete";
			}
			else if(name=="BusyIndicator") 
			{
					name="BusyIndicator_Mobile";
			}
			else if(name=="CalendarViews") 
			{
					name="CalendarViews_Mobile";
			}
			else if(name=="CalendarLocalization") 
			{
					name="CalendarLocalization_Mobile";
			}
			else if(name=="CalendarConfiguration") 
			{
					name="CalendarConfiguration_Mobile";
			}
			else if(name=="Carousel") 
			{
					name="Carousel_Mobile";
			}
			else if(name=="NumericTextBox") 
			{
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					name="NumericTextBox_Tablet";
				}
				else
					name="NumericTextBox_Mobile";
			}
			else if(name=="NumericUpDown") 
			{
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					name="NumericUpDown_Tablet";
				}
				else
					name="NumericUpDown_Mobile";
			}
			else if(name=="RangeSlider") 
			{
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					name="RangeSlider_Tablet";
				}
				else
					name="RangeSlider_Mobile";
			}
			else if(name=="Rating") 
			{
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					name="Rating_Tablet";
				}
				else
					name="Rating_Mobile";
			}
            else if (name == "SegmentedControl")
            {
                name = "SegementViewGettingStarted";
            }
			else if(name=="Rotator") 
			{
					name="Rotator_Mobile";
			}
			else if(name=="RangeSliderGettingStarted") 
			{
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					name="RangeSliderGettingStarted_Tablet";
				}
				else
					name="RangeSliderGettingStarted_Mobile";
			}
            else if (name == "MaskedEdit")
            {
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    name = "MaskedEdit_Tablet";
                }
                else
                    name = "MaskedEdit_Mobile";
            }
			else if (name == "CheckBox")
            {
                    name = "CheckBox_Mobile";
            }
            else if (name == "RadioButton")
            {
                    name = "RadioButton_Mobile";
            }
            else if(name=="PdfViewerDemo")
			{
				name="GettingStartedPDFViewer";
			}
			else if (name == "Stacked Column") {
				name = "StackingColumn";
			} else if (name == "Stacked Bar") {
				name = "StackingBar";
			} else if (name == "100% Stacked Area") {
				name = "StackingArea100";
			} else if (name == "100% Stacked Column") {
				name = "StackingColumn100";
			} else if (name == "100% Stacked Bar") {
				name = "StackingBar100";
			} else if (name == "Data Point Selection") {
				name = "ChartSelection";
			} else if (name == "Zooming and Panning") {
				name = "ChartZooming";
			} else if (name == "Live Update") {
				name = "LiveUpate";
			} else if (name == "Category Axis") {
				name = "Category";
			} else if (name == "Numerical Axis") {
				name = "Numerical";
			} else if (name == "Logarithmic Axis") {
				name = "Logarithmic";
			} else if (name == "Multiple Axes") {
				name = "MultipleAxis";
			} else if (name == "Strip Lines") {
				name = "StripLine";
			} else if (name == "DateTime Axis") {
				name = "Date";
			}

			if(name != "Vertical Chart")
				name = name.Replace (" ", "");

			return name;
		}

		void ShowMenu()
		{
			menuView.Frame = new CGRect( this.View.Bounds.Width , 64, 260, this.View.Bounds.Height - 64 - 49);
			UIView.Animate (0.3, () => {
				menuView.Frame = new CGRect( this.View.Bounds.Width - 260, 64, 260, this.View.Bounds.Height - 64 - 49);
			});
		}

		public void HideMenu()
		{
			menuView.Frame = new CGRect( this.View.Bounds.Width - 260, 64, 260, this.View.Bounds.Height - 64 - 49);
			fadeOutView.RemoveFromSuperview ();
			UIView.AnimateNotify (0.3, () => {
				menuView.Frame = new CGRect( this.View.Bounds.Width , 64, 260, this.View.Bounds.Height - 64 - 49);

			},(bool finished)=>{
				if(finished)
					menuView.RemoveFromSuperview();
			}
			);
		}

		void HandleSingleTap (UITapGestureRecognizer gesture){
			if(menuVisible){
				menuVisible = false;
				HideMenu ();
			}
		}
	}

	//Multiple files for a sample

	class sampleDataSource:UITableViewSource
	{
		CodeViewController controller;

		public sampleDataSource (CodeViewController sampleControl)
		{
			this.controller = sampleControl;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return (nint)this.controller.sampleDictArray.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			nuint row 				= (nuint)indexPath.Row;

			string sample = this.controller.sampleDictArray.GetItem<NSString>(row);

			this.controller.HideMenu ();
			this.controller.loadSample (sample);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (AllControlsViewCell.Key) as AllControlsViewCell;
			if (cell == null)
				cell = new AllControlsViewCell ();

			// Configure the cell...

			nuint row = (nuint)indexPath.Row;

			string sample = this.controller.sampleDictArray.GetItem<NSString>(row);

			string[] tokens = sample.Split('/');

			if (tokens.Length > 1)
				sample = tokens [tokens.Length-1];

			cell.TextLabel.Text = sample + ".cs";

			cell.DetailTextLabel.Font 			= UIFont.FromName ("Helvetica", 10f);
			cell.DetailTextLabel.TextColor 		= UIColor.White;
			cell.TextLabel.HighlightedTextColor = Utility.themeColor;

			UIView selectionColor 				= new UIView ();
			selectionColor.Frame 				= cell.Frame;
			selectionColor.BackgroundColor 		= UIColor.FromRGB (249, 249, 249);
			cell.SelectedBackgroundView 		= selectionColor;

			return cell;
		}
	}
}