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
        UITableView table = new UITableView();
        string[] tableItems = new string[100];
        UILabel eventLog;
        int i = 0;
		UIButton button_calendarView = new UIButton();
		UIButton doneButton = new UIButton();
		public UIView option = new UIView();

        void PickerControl_ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(e.NewValue.ToString())
            {
                case "Blue":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(0, 0, 255, 0.3f);
                    break;
                case "Red":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(255, 0, 0, 0.3f);
                    break;
                case "Pink":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(255, 0, 255, 0.3f);
                    break;
                case "Orange":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(255, 128, 0, 1);
                    break;
                case "Yellow":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(255, 255, 0, 0.3f);
                    break;
                case "Brown":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(102, 51, 0,1);
                    break;
                case "Magenta":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(102, 0, 102, 0.8f);
                    break;
                case "LightGray":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(192, 192, 192, 0.3f);
                    break;
                case "Green":
                    pickerControl.BackgroundColor = UIColor.FromRGBA(0, 102, 0, 1);
                    break;
            }
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
            collectionStrings.Add("Red");
            collectionStrings.Add("Pink");
            collectionStrings.Add("Orange");
            collectionStrings.Add("Magenta");
            collectionStrings.Add("Yellow");
            collectionStrings.Add("Green");
            collectionStrings.Add("LightGray");
            collectionStrings.Add("Brown");

            pickerControl = new SfPicker();
			pickerControl.SelectedIndex = 2;
			pickerControl.ShowColumnHeader = true;
			pickerControl.HeaderText = "Select a Color";
			pickerControl.ColumnHeaderText = "Colors";
            pickerControl.ShowFooter = false;
			pickerControl.ShowHeader = true;
            pickerControl.SelectionChanged += PickerControl_ValueChanged;
            pickerControl.ItemsSource = collectionStrings;
            pickerControl.BackgroundColor = UIColor.FromRGBA(255, 0, 255, 0.3f);
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
                pickerControl.Frame = new CGRect(20, 30, this.Frame.Size.Width-40, 300);
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    eventLog.Frame = new CGRect(20, 370, Frame.Width, 30);
                    table.Frame = new CGRect(20, 400, Frame.Width - 18, 200);
                }
                else
                {
                    eventLog.Frame = new CGRect(16, Frame.Height - 150, Frame.Width, 30);
                    table.Frame = new CGRect(0, Frame.Height - 120, Frame.Width - 18, 200);
                }
			}
            base.LayoutSubviews();
        }
    }
}
