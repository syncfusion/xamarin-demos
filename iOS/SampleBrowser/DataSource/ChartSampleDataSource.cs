#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class TypeSamplesDataSource : UICollectionViewDataSource
	{
        #region fields

        private NSMutableArray samplesCollections;

        private ChartSamplesViewController controller;

        #endregion

        #region ctor

        public TypeSamplesDataSource(NSMutableArray collections, ChartSamplesViewController controller)
		{
			samplesCollections = collections;
			this.controller = controller;
		}

        #endregion

        #region methods

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			UICollectionViewCell cell = (UICollectionViewCell)collectionView.DequeueReusableCell("textReuseCell", indexPath);
			cell.BackgroundColor = UIColor.Clear;

			UIButton label = (UIButton)cell.ViewWithTag(500);
			UIButton labelX = (UIButton)cell.ViewWithTag(510);

			labelX.TouchUpInside += (sender, e) =>
			{
				if (controller.TypesIndexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.TouchUpInside += (sender, e) =>
			{
				if (controller.TypesIndexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.SetTitle(string.Empty, UIControlState.Normal);
			labelX.SetTitle(string.Empty, UIControlState.Normal);

			Control item = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

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

			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);

			if (indexPath.Row == (int)controller.TypesIndexPath.Row)
			{
				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)samplesCollections.Count;
		}

		public void HighlightCell(UIButton label, UIButton labelX, UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (controller.TypesIndexPath != indexPath)
			{
				foreach (UICollectionViewCell collectionViewCell in collectionView.VisibleCells)
				{
					UIButton label1 = (UIButton)collectionViewCell.ViewWithTag(500);
					UIButton label2 = (UIButton)collectionViewCell.ViewWithTag(510);
					label1.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					label2.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				if (controller.DeselectedButton != null)
				{
					controller.DeselectedButton.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					controller.DeselectedButtonX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);

				controller.TypesIndexPath = indexPath;
				controller.DeselectedButton = label;
				controller.DeselectedButtonX = labelX;

				controller.LoadSample();

				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}
		}

        #endregion
    }

    public class FeatureSamplesDataSource : UICollectionViewDataSource
    {
        #region fields

        private NSMutableArray samplesCollections;

        private ChartSamplesViewController controller;

        #endregion

        #region ctor

        public FeatureSamplesDataSource(NSMutableArray collections, ChartSamplesViewController controller)
		{
			samplesCollections = collections;
			this.controller = controller;
		}

        #endregion

        #region methods

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			UICollectionViewCell cell = (UICollectionViewCell)collectionView.DequeueReusableCell("textReuseCell", indexPath);
			cell.BackgroundColor = UIColor.Clear;

			UIButton label = (UIButton)cell.ViewWithTag(500);
			UIButton labelX = (UIButton)cell.ViewWithTag(510);

			labelX.TouchUpInside += (sender, e) =>
			{
				if (controller.FeaturesIndexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.TouchUpInside += (sender, e) =>
			{
				if (controller.FeaturesIndexPath != indexPath)
				{
					HighlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.SetTitle(string.Empty, UIControlState.Normal);
			labelX.SetTitle(string.Empty, UIControlState.Normal);

			Control item = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

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

			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
			label.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);
			labelX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Highlighted);

			if (indexPath.Row == (int)controller.TypesIndexPath.Row)
			{
				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)samplesCollections.Count;
		}

		public void HighlightCell(UIButton label, UIButton labelX, UICollectionView collectionView, NSIndexPath indexPath)
		{
			if (controller.FeaturesIndexPath != indexPath)
			{
				foreach (UICollectionViewCell collectionViewCell in collectionView.VisibleCells)
				{
					UIButton label1 = (UIButton)collectionViewCell.ViewWithTag(500);
					UIButton label2 = (UIButton)collectionViewCell.ViewWithTag(510);
					label1.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					label2.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);

				controller.FeaturesIndexPath = indexPath;
				controller.LoadSample();

				label.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.ThemeColor, UIControlState.Normal);
			}
		}

        #endregion
    }

    public class ChartSamplesDelegate : UICollectionViewDelegateFlowLayout
    {
        #region fields

        private NSMutableArray samplesCollections;

        #endregion

        #region ctor

        public ChartSamplesDelegate(NSMutableArray collections)
		{
			samplesCollections = collections;
		}

        #endregion

        #region methods

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

			NSString sampleName = control.Name;
			NSString dispName = control.DisplayName;

            NSString name = string.IsNullOrEmpty(dispName) ? sampleName : dispName;
			UIStringAttributes attribs = new UIStringAttributes { Font = UIFont.SystemFontOfSize(15) };
			CGSize size = name.GetSizeUsingAttributes(attribs);

            if (string.IsNullOrEmpty(control.Tag))
            {
                return new CGSize(size.Width + 20, 50);
            }
            else
            {
                return new CGSize(size.Width + 40, 50);
            }
        }

        #endregion
    }
}