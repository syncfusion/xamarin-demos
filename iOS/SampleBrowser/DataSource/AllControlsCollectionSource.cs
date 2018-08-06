#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
namespace SampleBrowser
{
	public class AllControlsCollectionSource : UICollectionViewDataSource
	{
		public NSArray controls { get; set; }

		public AllControlsCollectionSource(NSArray controls)
		{
			this.controls = controls;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (UICollectionViewCell)collectionView.DequeueReusableCell("controlCell", indexPath);

			cell.BackgroundColor = UIColor.White;
			cell.Layer.BorderWidth = 0.5f;
			cell.Layer.BorderColor = UIColor.FromRGB(221.0f / 255.0f, 221.0f / 255.0f, 221.0f / 255.0f).CGColor;

			Control item = controls.GetItem<Control>((nuint)indexPath.Row);

			UIImageView imageView = (UIImageView)cell.ViewWithTag(200);
			imageView.Image = item.image;
			imageView.Layer.BorderColor = UIColor.FromRGB(232.0f / 255.0f, 232.0f / 255.0f, 232.0f / 255.0f).CGColor;				imageView.Layer.BorderWidth = 0.5f;

			UILabel lblTitle = (UILabel)cell.ViewWithTag(201);
			lblTitle.Text = (item.dispName != "" && item.dispName != null)? item.dispName: item.name;

			UIImageView tag = (UIImageView)cell.ViewWithTag(205);


			if (item.tag == "NEW")
			{
				tag.Image = new UIImage("Controls/Tags/new.png");
			}
			else if (item.tag == "UPDATED")
			{
				tag.Image = new UIImage("Controls/Tags/updated.png");
			}
			else if (item.tag == "PREVIEW")
			{
				tag.Image = new UIImage("Controls/Tags/preview.png");
			}
			else
			{
				tag.Image = null;
			}

			UILabel desc = (UILabel)cell.ViewWithTag(202);
			desc.Text = item.description;

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)controls.Count;
		}

	}


	public class AllControlsCollectionDelegate : UICollectionViewDelegate
	{
		public HomeViewController controller;

		public AllControlsCollectionDelegate(HomeViewController controller)
		{
			this.controller = controller;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			nuint row = (nuint)indexPath.Row;

			Control ctrl = controller.controls.GetItem<Control>(row);
			string sampleListPathString = NSBundle.MainBundle.BundlePath + "/plist/SampleList.plist";
			NSDictionary sampleDict = new NSDictionary();
			sampleDict = NSDictionary.FromFile(sampleListPathString);

			//NSMutableArray samplesArray = new NSMutableArray();
			NSMutableArray dictArray = sampleDict.ValueForKey(new NSString(ctrl.name)) as NSMutableArray;

			NSMutableArray collections = new NSMutableArray();
			Control contrl = controller.controls.GetItem<Control>((nuint)indexPath.Row);

			for (nuint i = 0; i < dictArray.Count; i++)
			{
				NSDictionary dict = dictArray.GetItem<NSDictionary>(i);

				//samplesArray.Add(dict.ValueForKey(new NSString("SampleName")));

				Control control = new Control();
				control.ControlName = ctrl.name;
				control.name = (NSString)dict.ValueForKey(new NSString("SampleName"));
				control.description = (NSString)dict.ValueForKey(new NSString("Description"));
				NSString imageToLoad = (NSString)dict.ValueForKey(new NSString("Image"));
				if(imageToLoad != null)
				control.image = UIImage.FromBundle(imageToLoad);

				if (dict.ValueForKey(new NSString("IsNew")) != null && dict.ValueForKey(new NSString("IsNew")).ToString() == "YES")
				{
					control.tag = new NSString("NEW");
				}
				else if (dict.ValueForKey(new NSString("IsUpdated")) != null && dict.ValueForKey(new NSString("IsUpdated")).ToString() == "YES")
				{
					control.tag = new NSString("UPDATED");
				}
				else if (dict.ValueForKey(new NSString("IsPreview")) != null && dict.ValueForKey(new NSString("IsPreview")).ToString() == "YES")
				{
					control.tag = new NSString("PREVIEW");
				}
				else {
					control.tag = new NSString("");
				}

				if (dict.ValueForKey(new NSString("DisplayName")) != null)
					control.dispName = dict.ValueForKey(new NSString("DisplayName")) as NSString;
				else
					control.dispName = new NSString("");

				collections.Add(control);
			}

			if (ctrl.name == "Chart")
			{
				ChartSamplesViewController sampleController = new ChartSamplesViewController();
				sampleController.FeaturesCollections = collections;
				sampleController.ControlName = contrl.name;
				sampleController.Types = contrl.Type1;
				sampleController.Features = contrl.Type2;

				controller.NavigationController.PushViewController(sampleController, true);
			}
            //Go directly to sample page for controls having sample less than or equat to 4
            else
            {
                indexPath = NSIndexPath.FromRowSection(0, 0);
                SampleViewController _controller = new SampleViewController(indexPath);
                _controller.SamplesCollection = collections;
                _controller.ControlName = contrl.name;
                //_controller.DisplayNameCollection = dispNames;

                controller.NavigationController.PushViewController(_controller, true);
            }
        }
	}
}

