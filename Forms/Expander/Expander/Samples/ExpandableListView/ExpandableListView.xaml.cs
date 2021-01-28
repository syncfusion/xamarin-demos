#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Expander;

namespace SampleBrowser.SfExpander
{
    [Preserve(AllMembers = true)]
    public partial class ExpandableListView : SampleView
    {
		public ExpandableListView()
		{
			InitializeComponent();
       	}

        private void listView_ScrollStateChanged(object sender, Syncfusion.ListView.XForms.ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState == ScrollState.Idle)
            {
                foreach (var item in this.viewModel.ContactsInfo)
                {
                    item.Animation = AnimationEasing.Linear;
                }
            }
            else
            {
                foreach (var item in this.viewModel.ContactsInfo)
                {
                    item.Animation = AnimationEasing.None;
                }
            }
        }
    }
}
