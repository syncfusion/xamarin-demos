#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Linq;

namespace SampleBrowser
{
	public class ChartSamplesViewController : UIViewController
	{
		public NSString Features;
		UILabel featuresTextLabel;
		string[] featureSamples;
		SampleView featureSampleView;
		bool firstTimeLoad = true;
		UICollectionView featuresCollectionView;
		UICollectionViewFlowLayout featuresLayout;
		public string featuresSampleNameToLoad;
		public NSMutableArray FeaturesCollections { get; set; }
		public NSIndexPath FeaturesIndexPath { get; set; }

		public NSString Types;
		UILabel typesTextLabel;
		string[] typeSamples;
		SampleView typeSampleView;
		UICollectionView typesCollectionView;
		UICollectionViewFlowLayout typesLayout;
		public string typesSampleNameToLoad;
		public NSMutableArray TypesCollections { get; set; }
		public NSIndexPath TypesIndexPath { get; set; }

		bool codeVisible;
		UIView customTab;
		float customTabHeight = 50;
		CGRect typesRect, featuresRect;
		UIView selectedTabHighlightView;
		UIBarButtonItem codeViewButton;
		public bool IsTypesSampleView { get; set; } = true;
		public UIButton deselectedButton;
		public UIButton deselectedButtonX;
		public NSString ControlName { get; set; }

		public ChartSamplesViewController()
		{

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			codeVisible = false;
			this.NavigationItem.Title = ControlName;
			this.NavigationController.SetNavigationBarHidden(false, false);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.View.BackgroundColor = UIColor.White;

			codeViewButton = new UIBarButtonItem();
			codeViewButton.Image = UIImage.FromBundle("Controls/Tags/Viewcode");
			codeViewButton.Style = UIBarButtonItemStyle.Plain;
			codeViewButton.Target = this;
			codeViewButton.Clicked += ViewCode;

			this.NavigationItem.SetRightBarButtonItem(codeViewButton, true);
			TypesIndexPath = FeaturesIndexPath = NSIndexPath.FromRowSection(0, 0);

			this.LoadTabView();
			this.PrepareSamplesList();
			this.LoadSample();
			this.LoadCollectionView();

			if (IsTypesSampleView)
			{
				featureSampleView = new SampleView();
				featuresCollectionView.Hidden = true;
				featureSampleView.Hidden = true;
			}
		}

		void LoadCollectionView()
		{
			featuresLayout = new UICollectionViewFlowLayout();
			featuresLayout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
			featuresCollectionView = new UICollectionView(CGRect.Empty, featuresLayout);
			featuresCollectionView.DataSource = new FeatureSamplesDataSource(FeaturesCollections, this);
			featuresCollectionView.Delegate = new ChartSamplesDelegate(FeaturesCollections);
			featuresCollectionView.BackgroundColor = Utility.backgroundColor;
			featuresCollectionView.Hidden = true;
			UINib featureNib = UINib.FromName("TextCell", null);
			featuresCollectionView.RegisterNibForCell(featureNib, "textReuseCell");
			this.View.AddSubview(featuresCollectionView);

			typesLayout = new UICollectionViewFlowLayout();
			typesLayout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;
			typesCollectionView = new UICollectionView(CGRect.Empty, typesLayout);
			typesCollectionView.DataSource = new TypeSamplesDataSource(TypesCollections, this);
			typesCollectionView.Delegate = new ChartSamplesDelegate(TypesCollections);
			typesCollectionView.BackgroundColor = Utility.backgroundColor;
			featuresCollectionView.Hidden = true;
			UINib typeNib = UINib.FromName("TextCell", null);
			typesCollectionView.RegisterNibForCell(typeNib, "textReuseCell");
			this.View.AddSubview(typesCollectionView);
		}

		void LoadTabView()
		{
			typeSamples = ((string)Types).Split(',');
			featureSamples = ((string)Features).Split(',');

			customTab = new UIView();
			customTab.BackgroundColor = UIColor.FromRGB(0, 123.0f / 255.0f, 229.0f / 255.0f);

			selectedTabHighlightView = new UIView();
			selectedTabHighlightView.BackgroundColor = UIColor.FromRGB(1.0f, 198.0f / 255.0f, 66.0f / 255.0f);

			typesTextLabel = new UILabel();

			typesTextLabel.TextColor = UIColor.White;
			typesTextLabel.Text = typeSamples[0];
			typesTextLabel.TextAlignment = UITextAlignment.Center;
			typesTextLabel.Font = Utility.titleFont;

			featuresTextLabel = new UILabel();
			featuresTextLabel.TextColor = UIColor.White;
			featuresTextLabel.Text = featureSamples[0];
			featuresTextLabel.TextAlignment = UITextAlignment.Center;
			featuresTextLabel.Font = Utility.titleFont;

			customTab.AddSubview(selectedTabHighlightView);
			customTab.AddSubview(typesTextLabel);
			customTab.AddSubview(featuresTextLabel);

			UITapGestureRecognizer singleFingerTap = new UITapGestureRecognizer();
			singleFingerTap.AddTarget(() => HandleSingleTap(singleFingerTap));
			customTab.AddGestureRecognizer(singleFingerTap);

			this.View.AddSubview(customTab);
		}

		void PrepareSamplesList()
		{
			NSMutableArray typesCollections = new NSMutableArray();
			NSMutableArray featuresCollections = new NSMutableArray();

			for (nuint i = 0; i < FeaturesCollections.Count; i++)
			{
				Control control = FeaturesCollections.GetItem<Control>(i);

				if (typeSamples.Contains(control.name))
					typesCollections.Add(control);

				else if (featureSamples.Contains(control.name))
				{
					featuresCollections.Add(control);
				}
			}

			TypesCollections = typesCollections;
			FeaturesCollections = featuresCollections;
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			nfloat width = this.View.Frame.Size.Width, height = this.View.Frame.Size.Height;

			customTab.Frame = new CGRect(0, 64, width, customTabHeight);

			if(IsTypesSampleView)
				selectedTabHighlightView.Frame = new CGRect(0, customTabHeight - 5, width / 2, 5);
			else
				selectedTabHighlightView.Frame = new CGRect(this.View.Frame.Size.Width / 2, customTabHeight - 5, this.View.Frame.Size.Width / 2, 5);

			typesRect = new CGRect(0, 0, width / 2, customTabHeight);
			featuresRect = new CGRect(width / 2, 0, width / 2, customTabHeight);

			typesTextLabel.Frame = typesRect;
			featuresTextLabel.Frame = featuresRect;

			typeSampleView.Frame = new CGRect(0, 66 + customTabHeight, this.View.Frame.Width, this.View.Frame.Height - 66 - 50 - customTabHeight);
			typesCollectionView.Frame = new CGRect(0, height - 50, width, 50);

			featuresCollectionView.Frame = new CGRect(0, height - 50, width, 50);
			featureSampleView.Frame = new CGRect(0, 66 + customTabHeight, this.View.Frame.Width, this.View.Frame.Height - 66 - 50 - customTabHeight);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (TypesIndexPath != null && IsTypesSampleView)
			{
				var cell = typesCollectionView.CellForItem(TypesIndexPath);

				if (cell != null)
				{
					deselectedButton = (UIButton)cell.ViewWithTag(500);
					deselectedButtonX = (UIButton)cell.ViewWithTag(510);
				}

				typesCollectionView.SelectItem(TypesIndexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);
			}
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			if (this.IsMovingFromParentViewController)
			{
				//moving back
				if (! codeVisible)
				{
					if (typeSampleView != null)
					{
						if (typeSampleView.OptionView != null)
						{
							typeSampleView.OptionView.RemoveFromSuperview();
							typeSampleView.OptionView.Dispose();
							typeSampleView.OptionView = null;
						}
						typeSampleView.RemoveFromSuperview();
						typeSampleView.Dispose();
						typeSampleView = null;
					}

					if (featureSampleView != null)
					{
						if (featureSampleView.OptionView != null)
						{
							featureSampleView.OptionView.RemoveFromSuperview();
							featureSampleView.OptionView.Dispose();
							featureSampleView.OptionView = null;
						}
						featureSampleView.RemoveFromSuperview();
						featureSampleView.Dispose();
						featureSampleView = null;
					}

					if (featuresCollectionView != null)
					{
						featuresCollectionView.Dispose();
						featuresCollectionView = null;
					}
					if (typesCollectionView != null)
					{
						typesCollectionView.Dispose();
						typesCollectionView = null;
					}

					Utility.DisposeEx(this.View);

					this.Dispose();
				}
			}
		}

		//Multiple view for samples
		void HandleSingleTap(UITapGestureRecognizer gesture)
		{
			CGPoint point = gesture.LocationInView(customTab);

			if (typesRect.Contains(point))
			{
				featuresCollectionView.Hidden = true;
				typesCollectionView.Hidden = false;
				typeSampleView.Hidden = false;
				featureSampleView.Hidden = true;
				IsTypesSampleView = true;
				selectedTabHighlightView.Frame = new CGRect(0, customTabHeight - 5, this.View.Frame.Size.Width / 2, 5);
				typeSampleView.ViewWillAppear();
				featureSampleView.ViewWillDisappear();
			}
			else if (featuresRect.Contains(point))
			{
				typesCollectionView.Hidden = true;
				featuresCollectionView.Hidden = false;
				typeSampleView.Hidden = true;
				featureSampleView.Hidden = false;
				IsTypesSampleView = false;
				selectedTabHighlightView.Frame = new CGRect(this.View.Frame.Size.Width/2, customTabHeight - 5, this.View.Frame.Size.Width / 2, 5);
				if (firstTimeLoad)
				{
					LoadSample();
					firstTimeLoad = false;
				}
				else
				{
					featureSampleView.ViewWillAppear();
					typeSampleView.ViewWillDisappear();
				}
			}
		}

		public void LoadSample()
		{
			string[] samples = IsTypesSampleView ? typeSamples : featureSamples;
			NSIndexPath indexPath = IsTypesSampleView ? TypesIndexPath : FeaturesIndexPath;
				
			string sampleNameToLoad = samples[(nuint)indexPath.Row + 1]; //Note: 0th index is tab title 

			SampleView sampleView = IsTypesSampleView ? typeSampleView : featureSampleView;

			if (sampleView != null && sampleView.IsDescendantOfView(this.View))
			{
				sampleView.ViewWillDisappear();

				foreach (UIView view in sampleView.Subviews)
				{
					view.RemoveFromSuperview();
					view.Dispose();
				}

				sampleView.RemoveFromSuperview();
				sampleView.Dispose();
 			}

			ControlName = new NSString("Chart");

			this.Title = "Chart";

			if (sampleNameToLoad == "100% Stacked Area")
			{
				sampleNameToLoad = "StackingArea100";
			}
			else if (sampleNameToLoad == "100% Stacked Column")
			{
				sampleNameToLoad = "StackingColumn100";
			}
			else if (sampleNameToLoad == "100% Stacked Bar")
			{
				sampleNameToLoad = "StackingBar100";
			}

			sampleNameToLoad = sampleNameToLoad.Replace(" ", "");
			string classname = "SampleBrowser." + sampleNameToLoad;

			Type sampleClass = Type.GetType(classname);

			if (sampleClass != null)
			{
				if (IsTypesSampleView)
				{
					typeSampleView = Activator.CreateInstance(sampleClass) as SampleView;
					typeSampleView.RemoveFromSuperview();
					this.View.AddSubview(typeSampleView);
					typeSampleView.ViewWillAppear();
					typesSampleNameToLoad = sampleNameToLoad;
				}
				else
				{
					featureSampleView = Activator.CreateInstance(sampleClass) as SampleView;
					featureSampleView.RemoveFromSuperview();
					this.View.AddSubview(featureSampleView);
					featureSampleView.ViewWillAppear();
					featuresSampleNameToLoad = sampleNameToLoad;
				}
			}
		}

		void ViewCode(object sender, EventArgs ea)
		{
			CodeViewController viewController = new CodeViewController();
			viewController.controlName = ControlName;
			viewController.sampleName = IsTypesSampleView ? typesSampleNameToLoad : featuresSampleNameToLoad;
			codeVisible = true;
			this.NavigationController.PushViewController(viewController, true);
		}
	}
}