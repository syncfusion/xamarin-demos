#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SortingBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private Switch switch1;
        private Switch switch2;
        private Switch switch3;
        private Switch switch4;

        protected override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            switch1 = bindable.FindByName<Switch>("switch1");
            switch2 = bindable.FindByName<Switch>("switch2");
            switch3 = bindable.FindByName<Switch>("switch3");
            switch4 = bindable.FindByName<Switch>("switch4");

            switch1.Toggled += Switch1_Toggled;
            switch2.Toggled += Switch2_Toggled;
            switch3.Toggled += Switch3_Toggled;
            switch4.Toggled += Switch4_Toggled;
            base.OnAttachedTo(bindable);
        }

        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {
                dataGrid.AllowSorting = true;
            }
            else
            {
                dataGrid.AllowSorting = false;
            }
        }

        private void Switch2_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                dataGrid.AllowTriStateSorting = true;
            }
            else
            {
                dataGrid.AllowTriStateSorting = false;
            }
        }

        private void Switch3_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                dataGrid.AllowMultiSorting = true;
            }
            else
            {
                dataGrid.AllowMultiSorting = false;
            }
        }

        private void Switch4_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                dataGrid.Columns["ProductName"].AllowSorting = true;
            }
            else
            {
                dataGrid.Columns["ProductName"].AllowSorting = false;
            }
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            switch1.Toggled -= Switch1_Toggled;
            switch2.Toggled -= Switch2_Toggled;
            switch3.Toggled -= Switch3_Toggled;
            switch4.Toggled -= Switch4_Toggled;
            dataGrid = null;
            switch1 = null;
            switch2 = null;
            switch3 = null;
            switch4 = null;
            base.OnDetachingFrom(bindable);
        }

    }
}
