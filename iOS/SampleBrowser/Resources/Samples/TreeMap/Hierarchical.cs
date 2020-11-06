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
	public class Hierarchical : SampleView
	{
		#region Fields

		SFTreeMap tree ;
		UILabel label;
		UIView view;

		#endregion

		public Hierarchical ()
		{
			
			// TreeMap Initialization
			view = new UIView();
			label = new UILabel();
			tree = new SFTreeMap ();
			tree.WeightValuePath = (NSString)"Sales";

			SFDesaturationColorMapping desat = new SFDesaturationColorMapping ();
			desat.Color = UIColor.FromRGB (0x41, 0xB8, 0xC4);
			desat.From = 1;
			desat.To = 0.2f;
			tree.ColorValuePath = (NSString)"Expense";
			tree.LeafItemColorMapping = desat;
			SFTreeMapHierarchicalLevel level = new SFTreeMapHierarchicalLevel() { ChildPadding=4, HeaderStyle = new SFStyle(){Color = UIColor.DarkGray}, ShowHeader = true, HeaderHeight = 20, HeaderPath = (NSString)"Name", ChildPath = (NSString)"RegionalSales" };

			tree.Levels.Add (level);
			tree.LeafItemSettings = new SFLeafItemSetting (){ ShowLabels = true, Gap = 5, BorderColor  = UIColor.White, BorderWidth = 2 };
			tree.LeafItemSettings.LabelStyle = new SFStyle () { Color = UIColor.White };
			tree.LeafItemSettings.LabelPath =(NSString)"Name";
			GetPopulationData ();
			tree.DataSource = PopulationDetails;

			AddSubview (view);

		}

		public override void LayoutSubviews()
		{
			label.Text = "Hierarchical";
			label.Frame = new CGRect(0, 0, 300, 30);

			base.LayoutSubviews();
			view.Frame = new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height);
			tree.Frame = new CGRect(0, 0, Frame.Size.Width - 6, Frame.Size.Height);
			view.AddSubview(tree);
			label.Frame = new CGRect(0, 0, Frame.Size.Width, 40);
			tree.LegendSettings.Size = new CGSize(this.Frame.Size.Width, 60);
			SetNeedsDisplay();
		}

		void  GetPopulationData ()
		{
			NSMutableArray array = new NSMutableArray ();

			NSMutableArray regional1 = new NSMutableArray ();
			regional1.Add(getDictionary ("United States", "New York", 2353, 2000));
			regional1.Add(getDictionary("United States", "Los Angeles", 3453, 3000));
			regional1.Add(getDictionary("United States", "San Francisco", 8456, 8000));
			regional1.Add(getDictionary("United States", "Chicago", 6785, 7000));
			regional1.Add(getDictionary("United States", "Miami", 7045, 6000));

			NSMutableArray regional2 = new NSMutableArray ();
			regional2.Add(getDictionary ("Canada", "Toronto", 7045, 7000));
			regional2.Add(getDictionary("Canada", "Vancouver", 4352, 4000));
			regional2.Add(getDictionary("Canada", "Winnipeg", 7843, 7500));


			NSMutableArray regional3 = new NSMutableArray ();
			regional3.Add(getDictionary ("Mexico", "Mexico City", 7843, 6500));
			regional3.Add(getDictionary("Mexico", "Cancun", 6683, 6000));
			regional3.Add(getDictionary("Mexico", "Acapulco", 2454, 2000));


			array.Add(getDictionary1("United States",98456, 87000,regional1));
			array.Add(getDictionary1("Canada",43523, 40000,regional2));
			array.Add(getDictionary1("Mexico",45634, 46000,regional3));
			PopulationDetails = array;

		}

		NSDictionary getDictionary1(string continent,double region,double growth,NSMutableArray population)
		{

			object[] objects= new object[4];
			object[] keys=new object[4];
			keys.SetValue ("Name", 0);
			keys.SetValue ("Expense", 1);
			keys.SetValue ("Sales", 2);
			keys.SetValue ("RegionalSales", 3);
			objects.SetValue ((NSString)continent, 0);
			objects.SetValue (region, 1);
			objects.SetValue (growth, 2);
			objects.SetValue (population, 3);
			return NSDictionary.FromObjectsAndKeys (objects, keys);
		}


		NSDictionary getDictionary(string continent,string region,double growth,double population)
		{

			object[] objects= new object[4];
			object[] keys=new object[4];
			keys.SetValue ("Country", 0);
			keys.SetValue ("Name", 1);
			keys.SetValue ("Expense", 2);
			keys.SetValue ("Sales", 3);
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


