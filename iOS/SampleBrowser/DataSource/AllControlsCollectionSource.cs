#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public class AllControlsCollectionSource : UICollectionViewDataSource
	{
        #region ctor

        public AllControlsCollectionSource(NSArray controls)
		{
			this.Controls = controls;
		}

        #endregion

        #region properties

        public NSArray Controls { get; set; }

        #endregion

        #region methods

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (UICollectionViewCell)collectionView.DequeueReusableCell("controlCell", indexPath);
			cell.BackgroundColor = UIColor.White;
			cell.Layer.BorderWidth = 0.5f;
			cell.Layer.BorderColor = UIColor.FromRGB(221.0f / 255.0f, 221.0f / 255.0f, 221.0f / 255.0f).CGColor;

			Control item = Controls.GetItem<Control>((nuint)indexPath.Row);
			UIImageView imageView = (UIImageView)cell.ViewWithTag(200);
			imageView.Image = item.Image;
			imageView.Layer.BorderColor = UIColor.FromRGB(232.0f / 255.0f, 232.0f / 255.0f, 232.0f / 255.0f).CGColor;
            imageView.Layer.BorderWidth = 0.5f;

			UILabel lblTitle = (UILabel)cell.ViewWithTag(201);
            lblTitle.Text = string.IsNullOrEmpty(item.DisplayName) ? item.Name : item.DisplayName;
			UIImageView tag = (UIImageView)cell.ViewWithTag(205);

			if (item.Tag == "NEW")
			{
				tag.Image = new UIImage("Controls/Tags/new.png");
			}
			else if (item.Tag == "UPDATED")
			{
				tag.Image = new UIImage("Controls/Tags/updated.png");
			}
			else if (item.Tag == "PREVIEW")
			{
				tag.Image = new UIImage("Controls/Tags/preview.png");
			}
			else
			{
				tag.Image = null;
			}

			UILabel desc = (UILabel)cell.ViewWithTag(202);
			desc.Text = item.Description;

			return cell;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return (nint)Controls.Count;
		}

        #endregion
    }

    public class AllControlsCollectionDelegate : UICollectionViewDelegate
	{
        #region ctor

        public AllControlsCollectionDelegate(HomeViewController controller)
		{
			this.Controller = controller;
		}

        #endregion

        #region properties

        public HomeViewController Controller { get; set; }

        #endregion

        #region methods

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			nuint row = (nuint)indexPath.Row;

			Control ctrl = Controller.Controls.GetItem<Control>(row);
			string sampleListPathString = NSBundle.MainBundle.BundlePath + "/plist/SampleList.plist";
			NSDictionary sampleDict = new NSDictionary();
			sampleDict = NSDictionary.FromFile(sampleListPathString);

			NSMutableArray dictArray = sampleDict.ValueForKey(new NSString(ctrl.Name)) as NSMutableArray;
			NSMutableArray collections = new NSMutableArray();
			Control contrl = Controller.Controls.GetItem<Control>((nuint)indexPath.Row);

			for (nuint i = 0; i < dictArray.Count; i++)
			{
				NSDictionary dict = dictArray.GetItem<NSDictionary>(i);
                Control control = new Control
                {
                    ControlName = ctrl.Name,
                    Name = (NSString)dict.ValueForKey(new NSString("SampleName")),
                    Description = (NSString)dict.ValueForKey(new NSString("Description"))
                };

                NSString imageToLoad = (NSString)dict.ValueForKey(new NSString("Image"));
                if (imageToLoad != null)
                {
                    control.Image = UIImage.FromBundle(imageToLoad);
                }

				if (dict.ValueForKey(new NSString("IsNew")) != null && dict.ValueForKey(new NSString("IsNew")).ToString() == "YES")
				{
					control.Tag = new NSString("NEW");
				}
				else if (dict.ValueForKey(new NSString("IsUpdated")) != null && dict.ValueForKey(new NSString("IsUpdated")).ToString() == "YES")
				{
					control.Tag = new NSString("UPDATED");
				}
				else if (dict.ValueForKey(new NSString("IsPreview")) != null && dict.ValueForKey(new NSString("IsPreview")).ToString() == "YES")
				{
					control.Tag = new NSString("PREVIEW");
				}
				else
                {
					control.Tag = new NSString(string.Empty);
				}

                if (dict.ValueForKey(new NSString("DisplayName")) != null)
                {
                    control.DisplayName = dict.ValueForKey(new NSString("DisplayName")) as NSString;
                }
                else
                {
                    control.DisplayName = new NSString(string.Empty);
                }

				collections.Add(control);
			}

            this.Controller.NavigationItem.BackBarButtonItem = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);
            
			if (ctrl.Name == "Chart")
			{
                ChartSamplesViewController sampleController = new ChartSamplesViewController
                {
                    FeaturesCollections = collections,
                    ControlName = contrl.Name,
                    Types = contrl.Type1,
                    Features = contrl.Type2
                };

                Controller.NavigationController.PushViewController(sampleController, true);
			}
            else
            {
                indexPath = NSIndexPath.FromRowSection(0, 0);
                SampleViewController controller = new SampleViewController(indexPath)
                {
                    SamplesCollection = collections,
                    ControlName = contrl.Name
                };

                Controller.NavigationController.PushViewController(controller, true);
            }
        }

        #endregion
    }
}