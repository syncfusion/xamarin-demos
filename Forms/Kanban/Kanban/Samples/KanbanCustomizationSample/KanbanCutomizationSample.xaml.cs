#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Syncfusion.SfKanban.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfKanban
{
    [Preserve(AllMembers = true)]
    public partial class KanbanCustomizationSample : SampleView
	{

		KanbanCustomViewModel model;

        public KanbanCustomizationSample()
        {
            model  = new KanbanCustomViewModel();
            InitializeComponent();
            kanban.BindingContext = model;
            column1.Categories = new List<object>() { "Menu" };
            column2.Categories = new List<object>() { "Dining", "Delivery" };
            column3.Categories = new List<object>() { "Ready to Serve" };
            column4.Categories = new List<object>() { "Door Delivery" };

            KanbanErrorBarSettings errorBar = new KanbanErrorBarSettings();
            errorBar.Height = 2;
            errorBar.Color = Color.FromRgb(179.0f / 255.0f, 71.0f / 255.0f, 36.0f / 255.0f);
            errorBar.MaxValidationColor = Color.FromRgb(211.0f / 255.0f, 51.0f / 255.0f, 54.0f / 255.0f);
            errorBar.MinValidationColor = Color.FromRgb(67.0f / 255.0f, 188.0f / 255.0f, 131.0f / 255.0f);

            column1.ErrorbarSettings = column2.ErrorbarSettings = column3.ErrorbarSettings
                = column4.ErrorbarSettings = errorBar;
			column1.AllowDrop = false;
			column3.AllowDrag = column4.AllowDrag = false;

            KanbanPlaceholderStyle style = new KanbanPlaceholderStyle();
            style.SelectedBackgroundColor = Color.FromRgb(250.0f / 255.0f, 199.0f / 255.0f, 173.0f / 255.0f);
            kanban.PlaceholderStyle = style;

            List<KanbanWorkflow> flows = new List<KanbanWorkflow>();
            flows.Add(new KanbanWorkflow("Menu", new List<object>() { "Dining", "Delivery" }));
            flows.Add(new KanbanWorkflow("Dining", new List<object>() { "Ready to Serve" }));
            flows.Add(new KanbanWorkflow("Delivery", new List<object>() { "Door Delivery" }));
            flows.Add(new KanbanWorkflow("Ready to Serve", new List<object>() { }));
            flows.Add(new KanbanWorkflow("Door Delivery", new List<object>() { }));

            kanban.Workflows = flows;

        }

		void Handle_DragEnd(object sender, KanbanDragEndEventArgs e)
		{
			if (e.TargetColumn != null && e.SourceColumn.Title.ToString() == "Menu" && e.TargetColumn.Title.ToString() == "Order")
			{
				e.Cancel = true;
				model.LastOrderID += 1;
				model.Cards.Add(CloneModel((e.Data as CustomKanbanModel), e.TargetCategory));
			}

			else if (e.TargetColumn != null && e.TargetCategory != null)
			{
				(e.Data as CustomKanbanModel).Category = e.TargetCategory;
			}
		}

		void Handle_DragStart(object sender, KanbanDragStartEventArgs e)
		{
			if ((e.Data as CustomKanbanModel).Category.ToString() == "Menu")
				e.KeepItem = true;
		}

		void Handle_DragOver(object sender, KanbanDragOverEventArgs e)
		{
			if (e.TargetColumn.Title.ToString() == "Menu")
				e.Cancel = true;
		}

		CustomKanbanModel CloneModel(CustomKanbanModel datamodel, object category)
		{
			CustomKanbanModel newModel = new CustomKanbanModel();

			newModel.ImageURL = datamodel.ImageURL;
			newModel.Category = category;
			newModel.ColorKey = datamodel.ColorKey;
			newModel.Description = datamodel.Description;
			newModel.ID = datamodel.ID;
			newModel.Tags = datamodel.Tags;
			newModel.Title = datamodel.Title;
			newModel.OrderID = "Order ID - #" + model.LastOrderID.ToString();
			return newModel;
		}
	}

	public class KanbanTemplateSelector : DataTemplateSelector
	{
		private readonly DataTemplate menuTemplate;

		private readonly DataTemplate orderTemplate;

		private readonly DataTemplate readyToServeTemplate;

		private readonly DataTemplate deliveryTemplate;


		public KanbanTemplateSelector()
		{
			menuTemplate = new DataTemplate(typeof(MenuTemplate));
			orderTemplate = new DataTemplate(typeof(OrderTemplate));
			readyToServeTemplate = new DataTemplate(typeof(ReadyToServeTemplate));
			deliveryTemplate = new DataTemplate(typeof(DeliveryTemplate));
		}

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var data = item as CustomKanbanModel;
			if (data == null)
				return null;

			string category = data.Category?.ToString();

			if (category == null)
				return null;

			return category.Equals("Menu") ? menuTemplate : 
				           category.Equals("Dining") || category.Equals("Delivery") ? orderTemplate :
				           category.Equals("Ready to Serve") ? readyToServeTemplate : deliveryTemplate;
		}
	}
}