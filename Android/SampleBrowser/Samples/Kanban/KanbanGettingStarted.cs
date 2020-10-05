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
    public class KanbanGettingStarted : SamplePage
    {
        KanbanColumn column1;
        KanbanColumn column2;
        KanbanColumn column3;
        KanbanColumn column4;

        public override View GetSampleContent(Context context)
        {
           
            var kanban = new SfKanban(context);

            column1 = new KanbanColumn(context) { Categories = new List<object>() { "Open", "Postponed", "Validated" } };
            column1.Title = "To Do";
            column1.MinimumLimit = 5;
            column1.MaximumLimit = 20;
            kanban.Columns.Add(column1);

            column2 = new KanbanColumn(context) { Categories = new List<object>() { "In Progress" } };
            column2.Title = "In Progress";
            column2.MinimumLimit = 5;
            column2.MaximumLimit = 10;
            kanban.Columns.Add(column2);

            column3 = new KanbanColumn(context) { Categories = new List<object>() { "Code Review" } };
            column3.Title = "Code Review";
            column3.MinimumLimit = 10;
            column3.MaximumLimit = 15;
            kanban.Columns.Add(column3);

            column4 = new KanbanColumn(context) { Categories = new List<object>() { "Closed", "Closed-No Code Changes", "Resolved" } };
            column4.Title = "Done";
            column4.MinimumLimit = 10;
            column4.MaximumLimit = 15;
            kanban.Columns.Add(column4);

            kanban.ItemsSource = new KanbanData().Data;

            List<KanbanColorMapping> colormodels = new List<KanbanColorMapping>();
            colormodels.Add(new KanbanColorMapping("Green", Color.Green));
            colormodels.Add(new KanbanColorMapping("Red", Color.Red));
            colormodels.Add(new KanbanColorMapping("Orange", Color.Orange));
            colormodels.Add(new KanbanColorMapping("Brown", Color.Brown));

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

            return kanban;
        }
    }
}