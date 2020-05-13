#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Syncfusion.SfPicker.iOS;
using UIKit;

namespace SampleBrowser
{
    public class PickerGettingStarted : SampleView
    {
        SfPicker pickerControl;
        List<string> collectionStrings;
		UITableView table;
		string[] tableItems;
        UILabel eventLog;
        int i = 0;

        void PickerControl_ValueChanged(object sender, SelectionChangedEventArgs e)
        {
			if (i > 99)
			{
				i = 0;
				tableItems = new string[100];
			}
            tableItems[i] = e.NewValue.ToString() + "color has been selected";
			table.ReloadData();
			i++;
        }

        public PickerGettingStarted()
        {
            collectionStrings = new List<string>();
            collectionStrings.Add("Blue");
            collectionStrings.Add("Black");
            collectionStrings.Add("Red");
            collectionStrings.Add("Pink");
            collectionStrings.Add("Orange");
            collectionStrings.Add("Magenta");
            collectionStrings.Add("Yellow");
            collectionStrings.Add("Purple");
            collectionStrings.Add("Green");
            collectionStrings.Add("Gray");
            collectionStrings.Add("LightGray");
            collectionStrings.Add("Brown");

            pickerControl = new SfPicker();
            pickerControl.SelectionChanged += PickerControl_ValueChanged;
            pickerControl.ItemsSource = collectionStrings;
            this.Add(pickerControl);

			eventLog = new UILabel();
			eventLog.Lines = 0;
			eventLog.Text = "Event Log :";
			eventLog.BackgroundColor = UIColor.White;
			eventLog.LineBreakMode = UILineBreakMode.WordWrap;

			table = new UITableView(this.Bounds); // defaults to Plain style
			tableItems = new string[100];
			Add(eventLog);
			table.Source = new TableSourceCollection(tableItems);
			Add(table);
        }

        public override void LayoutSubviews()
        {
			foreach (var view in this.Subviews)
			{
                pickerControl.Frame = new CGRect(20, 30, this.Frame.Size.Width-40, 200);
				eventLog.Frame = new CGRect(16, Frame.Height - 250, Frame.Width, 30);
				table.Frame = new CGRect(0, Frame.Height - 220, Frame.Width - 18, 200);
			}
            base.LayoutSubviews();
        }
    }
}
