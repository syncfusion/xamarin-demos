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
using System.Collections.Generic;
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
	public class CustomizationKanban : SampleView
	{
		SfKanban kanban;
		public CustomizationKanban()
		{
			kanban = new SfKanban();

			KanbanErrorBarSettings errorBar = new KanbanErrorBarSettings();
			errorBar.Height = 2;
			errorBar.Color = UIColor.FromRGB(179.0f / 255.0f, 71.0f / 255.0f, 36.0f / 255.0f);
			errorBar.MaxValidationColor = UIColor.FromRGB(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
			errorBar.MinValidationColor = UIColor.FromRGB(67.0f / 255.0f, 188.0f / 255.0f, 131.0f / 255.0f);

			KanbanPlaceholderStyle style = new KanbanPlaceholderStyle();
			style.SelectedBackgroundColor = UIColor.FromRGB(250.0f / 255.0f, 199.0f / 255.0f, 173.0f / 255.0f);
			kanban.PlaceholderStyle = style;

			KanbanColumn column1 = new KanbanColumn() { Categories = new List<object>() { "Menu" } };
			column1.Title = "Menu";
			column1.ErrorBarSettings = errorBar;
			kanban.Columns.Add(column1);

			KanbanColumn column2 = new KanbanColumn() { Categories = new List<object>() { "Dining", "Delivery" } };
			column2.Title = "Order";
			column2.ErrorBarSettings = errorBar;
			kanban.Columns.Add(column2);

			KanbanColumn column3 = new KanbanColumn() { Categories = new List<object>() { "Ready to Serve" } };
			column3.Title = "Ready to Serve";
			column3.AllowDrag = false;
			column3.ErrorBarSettings = errorBar;
			kanban.Columns.Add(column3);

			KanbanColumn column4 = new KanbanColumn() { Categories = new List<object>() { "Door Delivery" } };
			column4.Title = "Delivery";
			column4.AllowDrag = false;
			column4.ErrorBarSettings = errorBar;
			kanban.Columns.Add(column4);

			kanban.ItemsSource = this.ItemsSourceCards();

			List<KanbanWorkflow> flows = new List<KanbanWorkflow>();
			flows.Add(new KanbanWorkflow("Menu", new List<object>() { "Dining", "Delivery" }));
			flows.Add(new KanbanWorkflow("Dining", new List<object>() { "Ready to Serve" }));
			flows.Add(new KanbanWorkflow("Delivery", new List<object>() { "Door Delivery" }));
			flows.Add(new KanbanWorkflow("Ready to Serve", new List<object>() { }));
			flows.Add(new KanbanWorkflow("Door Delivery", new List<object>() { }));

			kanban.Workflows = flows;

			kanban.DragStart += (object sender, KanbanDragStartEventArgs e) =>
			{
				if ((e.Data as KanbanModel).Category.ToString() == "Menu")
					e.KeepItem = true;
			};

			kanban.DragEnd += (object sender, KanbanDragEndEventArgs e) =>
			{
				if (e.TargetColumn != null && e.SourceColumn.Categories.Contains("Menu"))
				{
					e.Cancel = true;
					e.TargetColumn.InsertItem(CloneModel((e.Data as KanbanModel),e.TargetCategory), e.TargetIndex);
				}

				else if (e.TargetColumn != null && e.TargetCategory != null)
				{
					(e.Data as KanbanModel).Category = e.TargetCategory;
				}

			};

			this.AddSubview(kanban);
		}

		KanbanModel CloneModel(KanbanModel model, object category)
		{
			KanbanModel newModel = new KanbanModel();

			newModel.ImageURL = model.ImageURL;
			newModel.Category = category;
			newModel.ColorKey = model.ColorKey;
			newModel.Description = model.Description;
			newModel.ID = model.ID;
			newModel.Tags = model.Tags;
			newModel.Title = model.Title;

			return newModel;
		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				if (view == kanban)
					view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			kanban.Dispose();
		}

		#region ItemsSource

		ObservableCollection<KanbanModel> ItemsSourceCards()
		{
			ObservableCollection<KanbanModel> cards = new ObservableCollection<KanbanModel>();

			cards.Add(
				new KanbanModel()
				{
					ID = 1,
					Title = "Margherita",
					ImageURL = "margherita.png",
					Category = "Menu",
					Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.",
					Tags = new string[] { "Cheese" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 2,
					Title = "Double Cheese Margherita",
					ImageURL = "doublecheesemargherita.png",
					Category = "Menu",
					Description = "The minimalist classic with a double helping of cheese",
					Tags = new string[] { "Cheese" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 3,
					Title = "Bucolic Pie",
					ImageURL = "bucolicpie.png",
					Category = "Menu",
					Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes. (Note: The “Onions” tag beneath the description in the screenshot is misspelled.)",
					Tags = new string[] { "Oninons", "Capsicum" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 4,
					Title = "Bumper Crop",
					ImageURL = "bumpercrop.png",
					Category = "Menu",
					Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
					Tags = new string[] { "Tomato", "Mushroom" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 5,
					Title = "Spice of Life",
					ImageURL = "spiceoflife.png",
					Category = "Menu",
					Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
					Tags = new string[] { "Corn", "Gherkins" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 6,
					Title = "Very Nicoise",
					ImageURL = "verynicoise.png",
					Category = "Menu",
					Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
					Tags = new string[] { "Red pepper", "Capsicum" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 7,
					Title = "Salad Daze",
					ImageURL = "saladdaze.png",
					Category = "Menu",
					Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
					Tags = new string[] { "Onions", "Jalapeno" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 4,
					Title = "Bumper Crop",
					ImageURL = "bumpercrop.png",
					Category = "Ready to Serve",
					Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
					Tags = new string[] { "Tomato", "Mushroom" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 5,
					Title = "Spice of Life",
					ImageURL = "spiceoflife.png",
					Category = "Ready to Serve",
					Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
					Tags = new string[] { "Corn", "Gherkins" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 3,
					Title = "Bucolic Pie",
					ImageURL = "bucolicpie.png",
					Category = "Door Delivery",
					Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes. (Note: The “Onions” tag beneath the description in the screenshot is misspelled.)",
					Tags = new string[] { "Oninons", "Capsicum" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 6,
					Title = "Very Nicoise",
					ImageURL = "verynicoise.png",
					Category = "Dining",
					Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
					Tags = new string[] { "Red pepper", "Capsicum" }
				}
			);

			cards.Add(
				new KanbanModel()
				{
					ID = 2,
					Title = "Double Cheese Margherita",
					ImageURL = "doublecheesemargherita.png",
					Category = "Delivery",
					Description = "The minimalist classic with a double helping of cheese",
					Tags = new string[] { "Cheese" }
				}
			);

			return cards;
		}

		#endregion
	}

}

