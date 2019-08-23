#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Syncfusion.DataSource;
using ListView = Syncfusion.ListView.XForms.SfListView;
using Xamarin.Forms.Internals;
using Syncfusion.ListView.XForms.Control.Helpers;

namespace SampleBrowser.SfListView
{
	[Preserve(AllMembers = true)]
	public class ListViewItemReorderingBehavior : Behavior<ListView>
	{
		#region Overrides

		protected override void OnAttachedTo(ListView bindable)
		{
			var viewModel = new ListViewToDoViewModel();
            bindable.BindingContext = viewModel;
			bindable.ItemsSource = viewModel.ToDoList;
			bindable.DataSource.GroupDescriptors.Add(new GroupDescriptor() { PropertyName = "CategoryName" });
            bindable.ItemDragging += Bindable_ItemDragging;
			base.OnAttachedTo(bindable);
		}

        private void Bindable_ItemDragging(object sender, ItemDraggingEventArgs e)
        {
            var listview = sender as ListView;
            var totalExtent = listview.GetVisualContainer().Bounds.Bottom;
            if (e.Action == DragAction.Drop && (e.Bounds.Y < -30 || e.Bounds.Bottom > totalExtent + 40))
            {
                //e.Cancel = true;
            }
        }

        protected override void OnDetachingFrom(ListView bindable)
		{
            bindable.ItemDragging -= Bindable_ItemDragging;
            base.OnDetachingFrom(bindable);
		}

		#endregion
	}
}
