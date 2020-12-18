#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Android.Views;
using Android.Graphics;
using Com.Syncfusion.Treemap;
using System.Collections.Generic;
using Android.Widget;
using Com.Syncfusion.Treemap.Enums;
using Android.Content;
using System.Collections.ObjectModel;
using Org.Json;

namespace SampleBrowser
{
	public class Hierarchical : SamplePage
	{
		SfTreeMap tree;
		Toast currentToast;

		public Hierarchical ()
		{
			
		}


		public override View GetSampleContent (Context context)
		{
			
			var margin = context.Resources.DisplayMetrics.Density * 20;

			tree = new SfTreeMap (context);
			tree.WeightValuePath = "Sales";
			currentToast = new Toast(context);

			DesaturationColorMapping desat = new DesaturationColorMapping ();
			desat.Color = Color.ParseColor ("#41B8C4");
			desat.From = 1;
			desat.To = 0.2;
			tree.ColorValuePath = "Expense";
			tree.LeafItemColorMapping = desat;
			tree.HighlightOnSelection = true;
			tree.SelectionMode = SelectionMode.Single;
			TreeMapHierarchicalLevel level = new TreeMapHierarchicalLevel() { ChildPadding=4,  ShowHeader = true, HeaderHeight = 20, HeaderPath = "Name", ChildStrokeColor=Color.Gray ,ChildStrokeWidth=1, ChildPath = "RegionalSales" };
			level.HeaderStyle = new Style() { TextColor = Color.Gray, TextSize = 16 };
			level.ChildBackgroundColor =Color.White;
			tree.Levels.Add (level);
			tree.LeafItemSettings = new LeafItemSetting (){ ShowLabels = true, Gap = 5, StrokeColor = Color.White, StrokeWidth = 2 };
			tree.LeafItemSettings.LabelStyle = new Style () {Margin= new Margin(margin/2,margin,0,0), TextSize = 18, TextColor = Color.White };
			tree.LeafItemSettings.LabelPath ="Name";
			tree.DataSource = GetDataSource ();
			//tree.TreeMapSelected += (object sender, SfTreeMap.TreeMapSelectedEventArgs e) =>
			//{
			//	JSONObject data = (JSONObject)e.P0;
			//	if (data != null)
			//	{
			//		if (currentToast != null)
			//		{
			//			currentToast.Cancel();
			//		}
			//		currentToast = Toast.MakeText(context,"Country -"+ data.Get("Name") + "\n" + "Sales -$"+ data.Get("Sales"), ToastLength.Short);					currentToast.Show();
			//	}

			//};

			return tree;
		}

		JSONArray GetDataSource()
		{

			JSONArray regional1 = new JSONArray ();
			regional1.Put (getJsonObject1 ("United States", "New York", 2353, 2000));
			regional1.Put(getJsonObject1("United States", "Los Angeles", 3453, 3000));
			regional1.Put(getJsonObject1("United States", "San Francisco", 8456, 8000));
			regional1.Put(getJsonObject1("United States", "Chicago", 6785, 7000));
			regional1.Put(getJsonObject1("United States", "Miami", 7045, 6000));

			JSONArray regional2 = new JSONArray ();
			regional2.Put (getJsonObject1 ("Canada", "Toronto", 7045, 7000));
			regional2.Put(getJsonObject1("Canada", "Vancouver", 4352, 4000));
			regional2.Put(getJsonObject1("Canada", "Winnipeg", 7843, 7500));


			JSONArray regional3 = new JSONArray ();
			regional3.Put (getJsonObject1 ("Mexico", "Mexico City", 7843, 6500));
			regional3.Put(getJsonObject1("Mexico", "Cancun", 6683, 6000));
			regional3.Put(getJsonObject1("Mexico", "Acapulco", 2454, 2000));


			JSONArray array = new JSONArray ();
			array.Put(getJsonObject("United States",98456, 87000,regional1));
			array.Put(getJsonObject("Canada",43523, 40000,regional2));
			array.Put(getJsonObject("Mexico",45634, 46000,regional3));

			return array;

		}

		JSONObject getJsonObject(String name,double expense,double sales, JSONArray regionalSale)
		{
			JSONObject obj = new JSONObject ();


			obj.Put ("Name", name);
			obj.Put ("Expense", expense);
			obj.Put ("Sales", sales);
			obj.Put("RegionalSales",regionalSale);
			return obj;
		}

		JSONObject getJsonObject1(String country,String name,double expense,double sales)
		{
			JSONObject obj = new JSONObject ();


			obj.Put ("Country", country);
			obj.Put ("Name", name);
			obj.Put ("Expense", expense);
			obj.Put("Sales",sales);
			return obj;

		}

	}}



