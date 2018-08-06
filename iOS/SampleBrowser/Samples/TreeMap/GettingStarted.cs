#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfTreeMap.iOS;
#if __UNIFIED__
using UIKit;
using CoreGraphics;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
	public class GettingStarted : SampleView
	{
		#region Fields

		SFTreeMap tree ;
		UILabel label;
		UIView view;

		#endregion

		public GettingStarted ()
		{
			// TreeMap Initialization
			view = new UIView();
			label = new UILabel();
			tree = new SFTreeMap ();
			tree.WeightValuePath = (NSString)"Population";
			tree.ColorValuePath = (NSString)"Growth";
			tree.Levels.Add (new SFTreeMapFlatLevel (){ GroupPath = (NSString)"Continent", HeaderStyle = new SFStyle(){Color = UIColor.DarkGray}, HeaderHeight = 22, ShowHeader =true });

			// Leaf Item Settings

			tree.LeafItemSettings = new SFLeafItemSetting ();
			tree.LeafItemSettings.LabelStyle = new SFStyle () { Font = UIFont.SystemFontOfSize (12), Color = UIColor.White };
			tree.LeafItemSettings.LabelPath = (NSString)"Region";
			tree.LeafItemSettings.ShowLabels = true;
			tree.LeafItemSettings.Gap = 2;
			tree.LeafItemSettings.BorderColor=UIColor.Gray;
			tree.LeafItemSettings.BorderWidth = 1;

			//Color Mappings

			NSMutableArray ranges = new NSMutableArray ();
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"1 % Growth",
				From = 0,
				To = 1,
				Color = UIColor.FromRGB (0x77, 0xD8, 0xD8)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"2 % Growth",
				From = 0,
				To = 2,
				Color = UIColor.FromRGB (0xAE, 0xD9, 0x60)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"3 % Growth",
				From = 0,
				To = 3,
				Color = UIColor.FromRGB (0xFF, 0xAF, 0x51)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"4 % Growth",
				From = 0,
				To = 4,
				Color = UIColor.FromRGB (0xF3, 0xD2, 0x40)
			});
			tree.LeafItemColorMapping = new SFRangeColorMapping () { Ranges = ranges };

			// Legend Settings

			CGSize legendSize = new CGSize (this.Frame.Size.Width, 60);
			CGSize iconSize = new CGSize (17, 17);
			UIColor legendColor = UIColor.Gray;
			tree.LegendSettings = new SFLegendSetting () {
				LabelStyle = new SFStyle () {
					Font = UIFont.SystemFontOfSize (12),
					Color = legendColor
				},
				IconSize = iconSize,
				ShowLegend = true,
				Size = legendSize
			};
			GetPopulationData ();
			tree.DataSource = PopulationDetails;
			AddSubview (view);

		}

		public override void LayoutSubviews()
		{
			// Popup Window

			label.Text = "Getting Started";
			label.Frame = new CGRect(0, 0, 300, 30);


			base.LayoutSubviews();
			view.Frame = new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height);
			tree.Frame = new CGRect(0, 0, Frame.Size.Width - 6, Frame.Size.Height);
			view.AddSubview(tree);
			label.Frame = new CGRect(0, 0, Frame.Size.Width, 40);
			tree.LegendSettings.Size = new CGSize(this.Frame.Size.Width, 60);
			SetNeedsDisplay();
		}


		void GetPopulationData()
		{
			NSMutableArray array = new NSMutableArray();
			array.Add(getDictionary("Asia", "Indonesia", 3, 237641326));
			array.Add(getDictionary("Asia", "Russia", 2, 152518015));
			array.Add(getDictionary("North America", "United States", 4, 315645000));
			array.Add(getDictionary("North America", "Mexico", 2, 112336538));
			array.Add(getDictionary("North America", "Canada", 1, 35056064));
			array.Add(getDictionary("South America", "Colombia", 1, 47000000));
			array.Add(getDictionary("South America", "Brazil", 3, 193946886));
			array.Add(getDictionary("Africa", "Nigeria", 2, 170901000));
			array.Add(getDictionary("Africa", "Egypt", 1, 83661000));
			array.Add(getDictionary("Europe", "Germany", 1, 81993000));
			array.Add(getDictionary("Europe", "France", 1, 65605000));
			array.Add(getDictionary("Europe", "UK", 1, 63181775));
			PopulationDetails = array;
		}

		NSDictionary getDictionary(string continent,string region,double growth,double population)
		{
			
			object[] objects= new object[4];
			object[] keys=new object[4];
			keys.SetValue ("Continent", 0);
			keys.SetValue ("Region", 1);
			keys.SetValue ("Growth", 2);
			keys.SetValue ("Population", 3);
			objects.SetValue ((NSString)continent, 0);
			objects.SetValue ((NSString)region, 1);
			objects.SetValue (growth, 2);
			objects.SetValue (population, 3);
			return NSDictionary.FromObjectsAndKeys (objects, keys);
		}


		public NSMutableArray PopulationDetails {
			get;
			set;
		}

	}
}

