#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using SampleBrowser.Core;
using Syncfusion.SfKanban.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfKanban
{
    [Preserve(AllMembers = true)]
    public partial class Themes : SampleView
    {
		public Themes ()
		{
			InitializeComponent ();

            column1.Categories = new List<object> { "Open", "Postponed", "Validated" };
            column2.Categories = new List<object> { "In Progress" };
            column3.Categories = new List<object> { "Code Review" };
            column4.Categories = new List<object> { "Closed", "Closed-No Code Changes", "Resolved" };

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
        }
	}
}