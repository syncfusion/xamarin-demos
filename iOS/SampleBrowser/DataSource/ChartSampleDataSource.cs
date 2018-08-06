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
		NSMutableArray samplesCollections;
		ChartSamplesViewController controller;

		public TypeSamplesDataSource(NSMutableArray collections, ChartSamplesViewController controller)
		{
			samplesCollections = collections;
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
				if (controller.TypesIndexPath != indexPath)
				{
					HightlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.TouchUpInside += (sender, e) =>
			{
				if (controller.TypesIndexPath != indexPath)
				{
					HightlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.SetTitle("", UIControlState.Normal);
			labelX.SetTitle("", UIControlState.Normal);

			Control item = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

			NSString sampleName = item.name;
			NSString dispName = item.dispName;

			dispName = (dispName != null && dispName != "") ? dispName : sampleName;

			UIImageView tag = (UIImageView)cell.ViewWithTag(502);

			if (item.tag == "NEW")
			{
				label.SetTitle(dispName, UIControlState.Normal);
				tag.Image = UIImage.FromBundle("Controls/Tags/x_new.png");
			}
			else if (item.tag == "UPDATED")
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
				label.SetTitleColor(Utility.themeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.themeColor, UIControlState.Normal);
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)samplesCollections.Count;
		}

		public void HightlightCell(UIButton label, UIButton labelX, UICollectionView collectionView, NSIndexPath indexPath)
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

				if (controller.deselectedButton != null)
				{
					controller.deselectedButton.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
					controller.deselectedButtonX.SetTitleColor(UIColor.FromRGB(45.0f / 255.0f, 45.0f / 255.0f, 45.0f / 255.0f), UIControlState.Normal);
				}

				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredHorizontally);

				controller.TypesIndexPath = indexPath;
				controller.deselectedButton = label;
				controller.deselectedButtonX = labelX;

				Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

				controller.LoadSample();

				label.SetTitleColor(Utility.themeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.themeColor, UIControlState.Normal);
			}
		}
	}

	public class FeatureSamplesDataSource : UICollectionViewDataSource
	{
		NSMutableArray samplesCollections;
		ChartSamplesViewController controller;

		public FeatureSamplesDataSource(NSMutableArray collections, ChartSamplesViewController controller)
		{
			samplesCollections = collections;
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
				if (controller.FeaturesIndexPath != indexPath)
				{
					HightlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.TouchUpInside += (sender, e) =>
			{
				if (controller.FeaturesIndexPath != indexPath)
				{
					HightlightCell(label, labelX, collectionView, indexPath);
				}
			};

			label.SetTitle("", UIControlState.Normal);
			labelX.SetTitle("", UIControlState.Normal);

			Control item = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

			NSString sampleName = item.name;
			NSString dispName = item.dispName;

			dispName = (dispName != null && dispName != "") ? dispName : sampleName;

			UIImageView tag = (UIImageView)cell.ViewWithTag(502);

			if (item.tag == "NEW")
			{
				label.SetTitle(dispName, UIControlState.Normal);
				tag.Image = UIImage.FromBundle("Controls/Tags/x_new.png");
			}
			else if (item.tag == "UPDATED")
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
				label.SetTitleColor(Utility.themeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.themeColor, UIControlState.Normal);
			}

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)samplesCollections.Count;
		}

		public void HightlightCell(UIButton label, UIButton labelX, UICollectionView collectionView, NSIndexPath indexPath)
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

				Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

				controller.LoadSample();

				label.SetTitleColor(Utility.themeColor, UIControlState.Normal);
				labelX.SetTitleColor(Utility.themeColor, UIControlState.Normal);
			}
		}
	}

	public class ChartSamplesDelegate : UICollectionViewDelegateFlowLayout
	{
		NSMutableArray samplesCollections;

		public ChartSamplesDelegate(NSMutableArray collections)
		{
			samplesCollections = collections;
		}

		public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			Control control = samplesCollections.GetItem<Control>((nuint)indexPath.Row);

			NSString sampleName = control.name;
			NSString dispName = control.dispName;

			NSString name = (dispName != null && dispName != "") ? dispName : sampleName;
			UIStringAttributes attribs = new UIStringAttributes { Font = UIFont.SystemFontOfSize(15) };
			CGSize size = name.GetSizeUsingAttributes(attribs);

			if (control.tag != "")
				return new CGSize(size.Width + 40, 50);
			else
				return new CGSize(size.Width + 20, 50);
		}
	}
}

