#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace SampleBrowser
{
	public class SampleViewController : UIViewController
	{
		bool codeVisible, codeVisited;
		bool optionVisible;
		bool showOptions;
		public NSIndexPath indexPath;

		SampleView sample;
		UIView fadeOutView;
		UIBarButtonItem codeViewButton;
		UIBarButtonItem optionButton;

		UICollectionView collectionView;
		UICollectionViewFlowLayout layout;

		UILabel overlayTags;

		bool isKeyboardVisible = true, isOptionVisible = false;
		bool isOptionsKeyboard = false;

		// iOS 10 issue fix for resetting last button color
		public UIButton deselectedButton; 
		public UIButton deselectedButtonX;

		public UIView optionView
		{
			get;
			set;
		}

		public string ControlName { get; set;}
		public string sampleNameToLoad { get; set; }
		public NSArray SamplesCollection;

		NSObject obs1;
		NSObject obs2;

		public SampleViewController(NSIndexPath indexPath)
		{
			//Fix to restrict setting automatic inset for scrollview and tableview 
			this.AutomaticallyAdjustsScrollViewInsets = false;

			this.indexPath = indexPath;

			SamplesCollection = new NSArray();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.View.BackgroundColor = UIColor.White;
			this.NavigationItem.SetRightBarButtonItem(codeViewButton, true);
			this.NavigationController.InteractivePopGestureRecognizer.Enabled = false;

			optionVisible = false;
			codeVisible = false;
			showOptions = false;

			overlayTags = new UILabel();
			overlayTags.Layer.CornerRadius = 20f;
			overlayTags.TextColor = UIColor.White;
			overlayTags.TextAlignment = UITextAlignment.Center;
			overlayTags.ClipsToBounds = true;
			overlayTags.Alpha = 0.0f;
			overlayTags.Font = UIFont.SystemFontOfSize(14);
			overlayTags.BackgroundColor = UIColor.FromRGB(101.0f / 255.0f, 101.0f / 255.0f, 101.0f / 255.0f);
			overlayTags.Layer.ZPosition = 1000;
			this.View.AddSubview(overlayTags);

			fadeOutView = new UIView(this.View.Bounds);
			fadeOutView.BackgroundColor = UIColor.FromRGBA(0.537f, 0.537f, 0.537f, 0.3f);

			UITapGestureRecognizer singleFingerTap = new UITapGestureRecognizer();
			singleFingerTap.AddTarget(() => HandleSingleTap(singleFingerTap));
			fadeOutView.AddGestureRecognizer(singleFingerTap);

			codeViewButton = new UIBarButtonItem();
			codeViewButton.Image = UIImage.FromBundle("Controls/Tags/Viewcode");
			codeViewButton.Style = UIBarButtonItemStyle.Plain;
			codeViewButton.Target = this;
			codeViewButton.Clicked += ViewCode;

			optionButton = new UIBarButtonItem();
			optionButton.Image = UIImage.FromBundle("Controls/Tags/Option");
			optionButton.Style = UIBarButtonItemStyle.Plain;
			optionButton.Target = this;
			optionButton.Clicked += OpenOptionView;

			this.LoadCollectionView();
			this.LoadSample();
		}

		private void LoadCollectionView()
		{
			layout = new UICollectionViewFlowLayout();
			layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;

			collectionView = new UICollectionView(CGRect.Empty, layout);
			collectionView.DataSource = new TextCollectionDataSource(this);
			collectionView.Delegate = new TextCollectionDelegate(this);
			collectionView.BackgroundColor = Utility.BackgroundColor;

			UINib nib = UINib.FromName("TextCell", null);
			collectionView.RegisterNibForCell(nib, "textReuseCell");

			this.View.AddSubview(collectionView);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (!Utility.IsIPad)
			{
				obs1 = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, delegate (NSNotification n)
				{
					if (isKeyboardVisible && isOptionVisible)
					{
						var kbdRect = UIKeyboard.FrameEndFromNotification(n);
						var duration = UIKeyboard.AnimationDurationFromNotification(n);
						var frame = optionView.Frame;
						frame.Y = 66;
						frame.Height = this.View.Frame.Height - kbdRect.Height;
						UIView.BeginAnimations("ResizeForKeyboard");
						UIView.SetAnimationDuration(duration);
							optionView.Frame = frame;
						UIView.CommitAnimations();

						isKeyboardVisible = false;
						isOptionsKeyboard = true;
					}
				});

				obs2 = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, delegate (NSNotification n)
				{
					if (isOptionsKeyboard && isOptionVisible)
					{
						var duration = UIKeyboard.AnimationDurationFromNotification(n);

						UIView.BeginAnimations("ResizeForKeyboard");
						UIView.SetAnimationDuration(duration);
						optionView.Frame = new CGRect(0, this.View.Bounds.Height - this.View.Bounds.Height / 1.5, this.View.Bounds.Width, this.View.Bounds.Height / 1.5);
						UIView.CommitAnimations();

						isKeyboardVisible = true;
						isOptionsKeyboard = false;
					}
				});
			}

			if (indexPath != null)
			{
				var cell = collectionView.CellForItem(indexPath);

				if (cell != null)
				{
					deselectedButton = (UIButton)cell.ViewWithTag(500);
					deselectedButtonX = (UIButton)cell.ViewWithTag(510);
				}
				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);
			}

			if(!codeVisited)
			UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveLinear, () =>
			{
				overlayTags.Alpha = 1.0f;
			},
				() =>
				{
					UIView.Animate(3.0, () =>
					{
						overlayTags.Alpha = 0.0f;
					});
				}
			);
			
		}

		public void LoadSample()
		{
			overlayTags.Alpha = 0.0f;
			overlayTags.Hidden = false;
			codeVisited = false;

			if (sample != null && sample.IsDescendantOfView(this.View))
			{
				if (sample.OptionView != null)
				{
					sample.OptionView.RemoveFromSuperview();
					sample.OptionView.Dispose();
					sample.OptionView = null;
				}

				foreach (UIView view in sample.Subviews)
				{
					view.RemoveFromSuperview();
					view.Dispose();
				}

				sample.RemoveFromSuperview();
				sample.Dispose();
			}

			Control control = SamplesCollection.GetItem<Control>((nuint)indexPath.Row);

			ControlName = control.ControlName;
			sampleNameToLoad = control.Name;

			if (control.Tag == "NEW")
			{
				overlayTags.Text = " New Sample";
			}
			else if (control.Tag == "UPDATED")
			{
				overlayTags.Text = " Updated Sample"; 
			}
			else
			{
				overlayTags.Hidden = true;
			}

			NSString dispName = control.DisplayName;

            this.Title = string.IsNullOrEmpty(dispName) ? dispName : sampleNameToLoad;

			sampleNameToLoad = sampleNameToLoad.Replace(" ", string.Empty);

			string classname = "SampleBrowser." + sampleNameToLoad;

			if (sampleNameToLoad == "100% Stacked Area")
			{
				classname = "SampleBrowser.StackingArea100";
			}
			else if (sampleNameToLoad == "100% Stacked Column")
			{
				classname = "SampleBrowser.StackingColumn100";
			}
			else if (sampleNameToLoad == "100% Stacked Bar")
			{
				classname = "SampleBrowser.StackingBar100";
			}

			if (classname == "SampleBrowser.CustomizationKanban")
				this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
			else
				this.NavigationController.NavigationBar.BarTintColor = Utility.ThemeColor;

			Type sampleClass = Type.GetType(classname);

			if (sampleClass != null)
			{
				sample = Activator.CreateInstance(sampleClass) as SampleView;

				sample.RemoveFromSuperview();
			
				this.View.AddSubview(sample);

				this.NavigationItem.RightBarButtonItems = null;

				this.View.AddSubview(sample);

				this.View.AddSubview(fadeOutView);
				fadeOutView.Hidden = true;

				if (sample.OptionView != null)
				{
					if (!Utility.IsIPad)
					{
						optionView = new UIView();
						optionView.Frame = new CGRect(0, this.View.Bounds.Height, this.View.Bounds.Width, this.View.Bounds.Height / 1.5);

						UIMarginLabel title = new UIMarginLabel();
						title.Text = "PROPERTIES";
						title.Insets = new UIEdgeInsets(0, 20, 0, 0);
						title.Frame = new CGRect(0, 0, this.View.Frame.Size.Width, 50);
						title.BackgroundColor = UIColor.Clear;
						optionView.AddSubview(title);

						UIButton close = new UIButton();
						close.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
						close.BackgroundColor = UIColor.FromRGBA(1, 1, 1, 0.95f);
						close.SetTitle("X", UIControlState.Normal);
						close.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
						close.VerticalAlignment = UIControlContentVerticalAlignment.Center;
						close.TouchUpInside += (object sender, EventArgs e) =>
						{
							this.View.EndEditing(true);
							HideOptionView();
						};
						close.Frame = new CGRect(this.View.Frame.Width - 45, 0, 45, 45);
						optionView.AddSubview(close);
						UITapGestureRecognizer singleFingerTap = new UITapGestureRecognizer();
						singleFingerTap.AddTarget(() => HandleSingleTap(singleFingerTap));
						close.AddGestureRecognizer(singleFingerTap);

						sample.OptionView.Frame = new CGRect(0, 40, optionView.Frame.Width, optionView.Frame.Height - 30);
						optionView.AddSubview(sample.OptionView);

						optionView.BackgroundColor = UIColor.FromRGBA(1, 1, 1, 0.95f);

						if (control.ControlName != "DataGrid" && control.ControlName != "DataSource")
						{
							UITapGestureRecognizer tap = new UITapGestureRecognizer();
							tap.AddTarget(() => HideKeyboard(tap));
							optionView.AddGestureRecognizer(tap);
						}

						this.View.AddSubview(optionView);
					}
					else
						optionView = sample.OptionView;
					

					this.NavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] { optionButton, codeViewButton }, true);
				}
				else 
				{
					this.NavigationItem.SetRightBarButtonItem(codeViewButton, true);
				}
			}

			UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveLinear, () =>
			{
				overlayTags.Alpha = 1.0f;
			},
				() =>
				{
					UIView.Animate(3.0, () =>
					{
						overlayTags.Alpha = 0.0f;
					});
				}
			);

		}

		void HideKeyboard(UITapGestureRecognizer gesture)
		{
				this.View.EndEditing(true);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			float collectionViewHeight = 50;

			if (SamplesCollection.Count == 0 || SamplesCollection.Count == 1)
				collectionViewHeight = 0;

			sample.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 66,
			                          this.View.Frame.Width, this.View.Frame.Height - 66 - collectionViewHeight);

			collectionView.Frame = new CGRect(0, this.View.Frame.Size.Height - collectionViewHeight, this.View.Frame.Width, collectionViewHeight);

			overlayTags.Frame = new CGRect(sample.Frame.Width/2 - 75, this.View.Frame.Height - 100 , 150, 35);

		}

		void ViewCode(object sender, EventArgs ea)
		{
			codeVisited = true;
			codeVisible = true;
			CodeViewController viewController = new CodeViewController();
			viewController.ControlName = ControlName;
			viewController.SampleName = sampleNameToLoad;
			this.NavigationItem.BackBarButtonItem = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);
			this.NavigationController.PushViewController(viewController, true);
		}

		void OpenOptionView(object sender, EventArgs ea)
		{
			optionVisible = true;

			if (!Utility.IsIPad)
			{
				if (!showOptions)
					this.ShowOptionView();
				else
					this.HideOptionView();
					
				showOptions = !showOptions;
			}
			else
			{
				//iPad view, present PopOver
				OptionViewController optionController = new OptionViewController();
				optionController.OptionView = optionView;

				UIPopoverController popover = new UIPopoverController(optionController);
				popover.SetPopoverContentSize(new CGSize(320.0, 400.0), true);

				UIBarButtonItem barbtn = sender as UIBarButtonItem;
				UIView view = barbtn.ValueForKey(new NSString("view")) as UIView;
				CGRect frame = new CGRect(this.View.Frame.Width - view.Frame.Width, view.Frame.Y + 23, view.Frame.Width, view.Frame.Height);

				popover.PresentFromRect(frame, this.View, UIPopoverArrowDirection.Up, true);
			}
		}

		void ShowOptionView()
		{
			this.View.EndEditing(true);
			isOptionVisible = true;
			isKeyboardVisible = true;
			fadeOutView.Hidden = false;

			UIView.Animate(0.3, () =>
			{
				optionView.Frame = new CGRect(0, this.View.Bounds.Height - this.View.Bounds.Height / 1.5, this.View.Bounds.Width, this.View.Bounds.Height / 1.5);
			});
		}

		void HideOptionView()
		{
			UIView.Animate(0.4, () =>
			{
				optionView.Frame = new CGRect(0, this.View.Bounds.Height, this.View.Bounds.Width, this.View.Bounds.Height / 1.5);
			},()=>sample.OnOptionsViewClosed());

			fadeOutView.Hidden = true;
			isOptionVisible = false;
			this.View.EndEditing(true);
		}

		void HandleSingleTap(UITapGestureRecognizer gesture)
		{
			showOptions = false;
			HideOptionView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.NavigationController.SetNavigationBarHidden(false, false);

			if (sampleNameToLoad == "CustomizationKanban")
				this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
			else
				this.NavigationController.NavigationBar.BarTintColor = Utility.ThemeColor;

			optionVisible = false;
			codeVisible = false;

			overlayTags.Alpha = 0f;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			if (!Utility.IsIPad)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(obs1);
				NSNotificationCenter.DefaultCenter.RemoveObserver(obs2);
			}

			if (this.IsMovingFromParentViewController)
			{
				//moving back
				if (!(optionVisible || codeVisible ))
				{
					if (sample != null)
					{
						if (sample.OptionView != null)
						{
							sample.OptionView.RemoveFromSuperview();
							sample.OptionView.Dispose();
							sample.OptionView = null;
						}
						Utility.DisposeEx(sample);
						sample.RemoveFromSuperview();
						sample.Dispose();
						sample = null;
					}
					if (optionView != null)
					{
						//optionView.RemoveFromSuperview();
						optionView.Dispose();
						optionView = null;
					}
					if (collectionView != null)
					{
						collectionView.Dispose();
						collectionView = null;
					}

					Utility.DisposeEx(this.View);

					this.Dispose();
				}
			}
		}
	}

	public class TextCollectionDataSource : UICollectionViewDataSource
	{
		SampleViewController controller;

		public TextCollectionDataSource(SampleViewController controller)
		{
			this.controller = controller;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			UICollectionViewCell cell = (UICollectionViewCell)collectionView.DequeueReusableCell("textReuseCell", indexPath);
			cell.BackgroundColor = UIColor.Clear;

			UIButton label = (UIButton)cell.ViewWithTag(500);
			UIButton labelX = (UIButton)cell.ViewWithTag(510);

			labelX.TouchUpInside += (sender, e) => 
			{
				if (controller.indexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.TouchUpInside += (sender, e) =>
			{
				if (controller.indexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.SetTitle(string.Empty, UIControlState.Normal);
			labelX.SetTitle(string.Empty, UIControlState.Normal);

			Control item = controller.SamplesCollection.GetItem<Control>((nuint)indexPath.Row);

			NSString sampleName = item.Name;
			NSString dispName = item.DisplayName;

            dispName = string.IsNullOrEmpty(dispName) ? sampleName : dispName;

			UIImageView tag = (UIImageView)cell.ViewWithTag(502);

			if (item.Tag == "NEW")
			{
				label.SetTitle(dispName, UIControlState.Normal);
				tag.Image = UIImage.FromBundle("Controls/Tags/x_new.png");
			}
			else if (item.Tag == "UPDATED")
			{
				label.SetTitle(dispName, UIControlState.Normal);
				tag.Image = UIImage.FromBundle("Controls/Tags/x_update.png");
			}
			else
			{
				labelX.SetTitle(dispName, UIControlState.Normal);
				tag.Image = null;
			}

			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f),UIControlState.Normal);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);

			if (indexPath.Row == (int)controller.indexPath.Row)
			{
				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)controller.SamplesCollection.Count;
		}


		public void HighlightCell(UIButton label, UIButton labelX, UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (controller.indexPath != indexPath)
			{

				foreach (UICollectionViewCell collectionViewCell in collectionView.VisibleCells)
				{
					UIButton label1 = (UIButton)collectionViewCell.ViewWithTag(510);
					UIButton label2 = (UIButton)collectionViewCell.ViewWithTag(510);
					label1.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					label2.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				if (controller.deselectedButton != null)
				{
					controller.deselectedButton.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					controller.deselectedButtonX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);

				controller.indexPath = indexPath;
				controller.deselectedButton = label;
				controller.deselectedButtonX = labelX;

				Control control = controller.SamplesCollection.GetItem<Control>((nuint)indexPath.Row);

                if (control.ControlName.Equals("DataGrid"))
                {
                    label.Alpha = 0.5f;
                    labelX.Alpha = 0.5f;

                    NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 0, 0, 2), (t) => {
                        label.Alpha = 1f;
                        labelX.Alpha = 1f;
                        controller.LoadSample();
                    });
                } 				else 					controller.LoadSample();

				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}
		}
	}

	public class TextCollectionDelegate : UICollectionViewDelegateFlowLayout
	{
		SampleViewController controller;

		public TextCollectionDelegate(SampleViewController controller)
		{
			this.controller = controller;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (controller.indexPath != indexPath)
			{
				var cell = collectionView.CellForItem(indexPath);
				cell.Alpha = 0.5f;

				if (cell != null)
				{
					UIButton labelX = (UIButton)cell.ViewWithTag(510);

					labelX.SendActionForControlEvents(UIControlEvent.TouchUpInside);
				}
			}
		}

		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);

			if (cell != null)
			{
				UIButton label = (UIButton)cell.ViewWithTag(500);
				UIButton labelX = (UIButton)cell.ViewWithTag(510);
				label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			}

		}

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            Control control = controller.SamplesCollection.GetItem<Control>((nuint)indexPath.Row);

            NSString sampleName = control.Name;
            NSString dispName = control.DisplayName;

            NSString name = string.IsNullOrEmpty(dispName) ? sampleName : dispName;
            UIStringAttributes attribs = new UIStringAttributes { Font = UIFont.SystemFontOfSize(15) };
            CGSize size = name.GetSizeUsingAttributes(attribs);

            if (string.IsNullOrEmpty(control.Tag))
                return new CGSize(size.Width + 20, 50);
            else
                return new CGSize(size.Width + 40, 50);
        }
	}
}