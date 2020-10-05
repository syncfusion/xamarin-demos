#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Syncfusion.SfKanban.Android;
using System.Collections.Generic;
using Android.Graphics;
using Android.Graphics.Drawables;


namespace SampleBrowser
{
    internal class CustomizationAdapter: KanbanAdapter
    {
        internal CustomizationAdapter(SfKanban kanban) : base(kanban) { }

        protected override void BindItemView(KanbanColumn column, KanbanItemViewHolder viewHolder, object data, int position)
        {
            TextView description = viewHolder.ItemDescription;
            description.SetMaxLines(4);

            base.BindItemView(column, viewHolder, data, position);
        }
    }

    public class KanbanCustomization : SamplePage
    {
        KanbanColumn menu;
        KanbanColumn order;
        KanbanColumn ready;
        KanbanColumn delivery;

        public override View GetSampleContent(Context context)
        {
          
            var kanban = new SfKanban(context);
            kanban.SetBackgroundColor(Color.ParseColor("#F2F2F2"));
            kanban.PlaceholderStyle.SelectedBackgroundColor = Color.ParseColor("#FBC7AB");

            menu = new KanbanColumn(context) { Categories = new List<object>() { "Menu" } };
            menu.Title = "Menu";
            menu.AllowDrop = false;
            menu.ErrorBarSettings.Color = Color.ParseColor("#D53130");
            kanban.Columns.Add(menu);

            order = new KanbanColumn(context) { Categories = new List<object>() { "Dining", "Delivery" } };
            order.Title = "Order";
            order.ErrorBarSettings.Color = Color.ParseColor("#D53130");
            kanban.Columns.Add(order);

            ready = new KanbanColumn(context) { Categories = new List<object>() { "Ready" } };
            ready.Title = "Ready to Serve";
            ready.AllowDrag = false;
            ready.ErrorBarSettings.Color = Color.ParseColor("#D53130");
            kanban.Columns.Add(ready);

            delivery = new KanbanColumn(context) { Categories = new List<object>() { "Door Delivery" } };
            delivery.Title = "Delivery";
            delivery.AllowDrag = false;
            delivery.ErrorBarSettings.Color = Color.ParseColor("#D53130");
            kanban.Columns.Add(delivery);

            kanban.ItemsSource = new KanbanData().Data;

            kanban.Workflows.Add(new KanbanWorkflow("Menu", new List<object> { "Dining", "Delivery" }));

            kanban.Workflows.Add(new KanbanWorkflow("Dining", new List<object> { "Ready" }));

            kanban.Workflows.Add(new KanbanWorkflow("Delivery", new List<object> { "Door Delivery" }));

            kanban.DragStart += Kanban_DragStart;

            kanban.DragEnd += Kanban_DragEnd;

            kanban.DragOver += Kanban_DragOver;

            kanban.Adapter = new CustomizationAdapter(kanban); 

            return kanban;
        }

        private void Kanban_DragOver(object sender, KanbanDragOverEventArgs e)
        {
            if (e.SourceColumn == menu)
                e.Cancel = true;
        }

        private void Kanban_DragEnd(object sender, KanbanDragEndEventArgs e)
        {
            if (e.TargetColumn == order)
            {
                e.Cancel = true;
                if (e.TargetColumn.IsExpanded)
                {
                    e.TargetColumn.InsertItem(CloneModel(e.Data as CustomKanbanModel, e.TargetCategory), 0);
                }
            }
        }

        CustomKanbanModel CloneModel(CustomKanbanModel model, object category)
        {
            CustomKanbanModel newModel = new CustomKanbanModel();

            newModel.Category = category;
            newModel.ColorKey = model.ColorKey;
            newModel.Description = model.Description;
            newModel.ID = model.ID;
            newModel.Tags = model.Tags;
            newModel.Title = model.Title;
            newModel.Name = model.Name;
            newModel.ImageURL = model.ImageURL;

            return newModel;
        }

        private void Kanban_DragStart(object sender, KanbanDragStartEventArgs e)
        {
            if (e.SourceColumn == menu)
            {
                e.KeepItem = true;
            }
        }
    }
}