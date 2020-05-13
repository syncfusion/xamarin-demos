#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 

#endregion

using System;
using System.Collections.ObjectModel;
using Syncfusion.SfKanban.iOS;
using System.Collections.Generic
            ;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class GettingStartedKanban : SampleView
	{
		SfKanban kanban;

		public GettingStartedKanban ()
		{
			KanbanColumn column1;
			KanbanColumn column2;
			KanbanColumn column3;
			KanbanColumn column4;

			kanban = new SfKanban ();

			column1 = new KanbanColumn() { Categories = new List<object>() { "Open", "Postponed", "Validated" } };
			column1.Title = "To Do";
			column1.MinimumLimit = 5;
			column1.MaximumLimit = 15;
			kanban.Columns.Add(column1);

			column2 = new KanbanColumn() { Categories = new List<object>() { "In Progress" } };
			column2.Title = "In Progress";
			column2.MinimumLimit = 3;
			column2.MaximumLimit = 8;
			kanban.Columns.Add(column2);

			column3 = new KanbanColumn() { Categories = new List<object>() { "Code Review" } };
			column3.Title = "Code Review";
			column3.MinimumLimit = 5;
			column3.MaximumLimit = 10;
			kanban.Columns.Add(column3);

			column4 = new KanbanColumn() { Categories = new List<object>() { "Closed", "Closed-No Code Changes", "Resolved" } };
			column4.Title = "Done";
			column4.MinimumLimit = 8;
			column4.MaximumLimit = 12;
			kanban.Columns.Add(column4);

			kanban.ItemsSource = new KanbanDataSource().Data;

			List<KanbanColorMapping> colormodels = new List<KanbanColorMapping>();
			colormodels.Add(new KanbanColorMapping("Purple", UIColor.Purple));
			colormodels.Add(new KanbanColorMapping("Red", UIColor.Red));
			colormodels.Add(new KanbanColorMapping("Orange", UIColor.Orange));
			colormodels.Add(new KanbanColorMapping("Brown", UIColor.Brown));
			kanban.IndicatorColorPalette = colormodels;

			List<KanbanWorkflow> keyfield = new List<KanbanWorkflow>();
			keyfield.Add(new KanbanWorkflow("Open", new List<object> { "In Progress" }));
			keyfield.Add(new KanbanWorkflow("In Progress", new List<object> { "Postponed", "Validated", "Code Review", "Closed-No Code Changes" }));
			keyfield.Add(new KanbanWorkflow("Code Review", new List<object> { "Closed", "Resolved" }));
			keyfield.Add(new KanbanWorkflow("Closed", new List<object> { "Open" }));
			keyfield.Add(new KanbanWorkflow("Postponed", new List<object> { "In Progress" }));
			keyfield.Add(new KanbanWorkflow("Validated", new List<object> { "In Progress" }));
			keyfield.Add(new KanbanWorkflow("Closed-No Code Changes", new List<object> { }));
			keyfield.Add(new KanbanWorkflow("Resolved", new List<object> { }));
			kanban.Workflows = keyfield;

			this.AddSubview (kanban);

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				
				if(view == kanban)
					view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			kanban.Dispose();
		}
	}

	public class KanbanDataSource
	{
		public ObservableCollection<KanbanModel> Data
		{
			get;
			set;
		}

		public KanbanDataSource()
		{
			Data = ItemsSourceCards();
		}

		ObservableCollection<KanbanModel> ItemsSourceCards()
		{
			ObservableCollection<KanbanModel> cards = new ObservableCollection<KanbanModel>();

			cards.Add(
				new KanbanModel()
				{
					ID = 1,
					Title = "iOS - 1",
					ImageURL = "Image8.png",
					Category = "Open",
					Description = "Analyze customer requirements",
					ColorKey = "Red",
					Tags = new string[] { "Bug", "Customer", "Release Bug" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 6,
					Title = "Xamarin - 6",
					ImageURL = "Image9.png",
					Category = "Open",
					Description = "Show the retrived data from the server in grid control",
					ColorKey = "Red",
					Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 3,
					Title = "iOS - 3",
					ImageURL = "Image10.png",
					Category = "Open",
					Description = "Fix the filtering issues reported in safari",
					ColorKey = "Red",
					Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 11,
					Title = "iOS - 11",
					ImageURL = "Image11.png",
					Category = "Open",
					Description = "Add input validation for editing",
					ColorKey = "Red",
					Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 15,
					Title = "Android - 15",
					Category = "Open",
					ImageURL = "Image12.png",
					Description = "Arrange web meeting for cutomer requirement",
					ColorKey = "Red",
					Tags = new string[] { "Story", "Kanban" }
				});

			cards.Add(
				new KanbanModel()
				{
					ID = 3,
					Title = "Android - 3",
					Category = "Code Review",
					ImageURL = "Image13.png",
					Description = "API Improvements",
					ColorKey = "Purple",
					Tags = new string[] { "Bug", "Customer" }
				});

			cards.Add(
				new KanbanModel()
				{
					ID = 4,
					Title = "UWP - 4",
					ImageURL = "Image14.png",
					Category = "Code Review",
					Description = "Enhance editing functionality",
					ColorKey = "Brown",
					Tags = new string[] { "Story", "Kanban" }
				});

			cards.Add(
				new KanbanModel()
				{
					ID = 9,
					Title = "Xamarin - 9",
					ImageURL = "Image15.png",
					Category = "Code Review",
					Description = "Improve application performance",
					ColorKey = "Orange",
					Tags = new string[] { "Story", "Kanban" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 13,
					Title = "UWP - 13",
					ImageURL = "Image16.png",
					Category = "In Progress",
					Description = "Add responsive support to applicaton",
					ColorKey = "Brown",
					Tags = new string[] { "Story", "Kanban" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 17,
					Title = "Xamarin - 17",
					Category = "In Progress",
					ImageURL = "Image17.png",
					Description = "Fix the issues reported in IE browser",
					ColorKey = "Brown",
					Tags = new string[] { "Bug", "Customer" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 21,
					Title = "Xamarin - 21",
					Category = "In Progress",
					ImageURL = "Image18.png",
					Description = "Improve performance of editing functionality",
					ColorKey = "Purple",
					Tags = new string[] { "Bug", "Customer" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 19,
					Title = "iOS - 19",
					Category = "In Progress",
					ImageURL = "Image19.png",
					Description = "Fix the issues reported by the customer",
					ColorKey = "Purple",
					Tags = new string[] { "Bug" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 8,
					Title = "Android",
					Category = "Code Review",
					ImageURL = "Image20.png",
					Description = "Check login page validation",
					ColorKey = "Brown",
					Tags = new string[] { "Feature" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 24,
					Title = "UWP - 24",
					ImageURL = "Image21.png",
					Category = "In Progress",
					Description = "Editing functionality",
					ColorKey = "Orange",
					Tags = new string[] { "Feature", "Customer", "Release" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 20,
					Title = "iOS - 20",
					Category = "In Progress",
					ImageURL = "Image22.png",
					Description = "Fix the issues reported in data binding",
					ColorKey = "Red",
					Tags = new string[] { "Feature", "Release", }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 12,
					Title = "Xamarin - 12",
					Category = "In Progress",
					ImageURL = "Image23.png",
					Description = "Editing functionality",
					ColorKey = "Red",
					Tags = new string[] { "Feature", "Release", }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 11,
					Title = "iOS - 11",
					Category = "In Progress",
					ImageURL = "Image24.png",
					Description = "Check filtering validation",
					ColorKey = "Red",
					Tags = new string[] { "Feature", "Release", }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 13,
					Title = "UWP - 13",
					ImageURL = "Image25.png",
					Category = "Closed",
					Description = "Fix cannot open user's default database sql error",
					ColorKey = "Purple",
					Tags = new string[] { "Bug", "Internal", "Release" }
				});

			cards.Add(
				new KanbanModel()
				{
					ID = 14,
					Title = "Android - 14",
					Category = "Closed",
					ImageURL = "Image26.png",
					Description = "Arrange web meeting with customer to get login page requirement",
					ColorKey = "Red",
					Tags = new string[] { "Feature" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 15,
					Title = "Xamarin - 15",
					Category = "Closed",
					ImageURL = "Image27.png",
					Description = "Login page validation",
					ColorKey = "Red",
					Tags = new string[] { "Bug" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 16,
					Title = "Xamarin - 16",
					ImageURL = "Image28.png",
					Category = "Closed",
					Description = "Improve application performance",
					ColorKey = "Purple",
					Tags = new string[] { "Bug" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 20,
					Title = "UWP - 20",
					ImageURL = "Image29.png",
					Category = "Closed",
					Description = "Analyze stored procedure",
					ColorKey = "Brown",
					Tags = new string[] { "CustomSample", "Customer", "Incident" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 21,
					Title = "Android - 21",
					Category = "Closed",
					ImageURL = "Image30.png",
					Description = "Arrange web meeting with customer to get editing requirements",
					ColorKey = "Orange",
					Tags = new string[] { "Story", "Improvement" }
				}
			);

			return cards;
		}
	}
}

