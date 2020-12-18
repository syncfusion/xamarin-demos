#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SortingBehaviors.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;

    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Sorting samples
    /// </summary>
    public class SortingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Switch switch1;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Switch switch2;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Switch switch3;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Switch switch4;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of para named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.switch1 = bindAble.FindByName<Switch>("switch1");
            this.switch2 = bindAble.FindByName<Switch>("switch2");
            this.switch3 = bindAble.FindByName<Switch>("switch3");
            this.switch4 = bindAble.FindByName<Switch>("switch4");
          
            this.switch1.Toggled += this.Switch1_Toggled;
            this.switch2.Toggled += this.Switch2_Toggled;
            this.switch3.Toggled += this.Switch3_Toggled;
            this.switch4.Toggled += this.Switch4_Toggled;
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.switch1.Toggled -= this.Switch1_Toggled;
            this.switch2.Toggled -= this.Switch2_Toggled;
            this.switch3.Toggled -= this.Switch3_Toggled;
            this.switch4.Toggled -= this.Switch4_Toggled;
            this.dataGrid = null;
            this.switch1 = null;
            this.switch2 = null;
            this.switch3 = null;
            this.switch4 = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Triggers while Switch was enabled 
        /// </summary>
        /// <param name="sender">Switch1_Toggled event sender</param>
        /// <param name="e">Switch1_Toggled event args e</param>
        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.dataGrid.AllowSorting = true;
            }
            else
            {
                this.dataGrid.AllowSorting = false;
            }
        }

        /// <summary>
        /// Triggers while Switch was enabled 
        /// </summary>
        /// <param name="sender">Switch2_Toggled event sender</param>
        /// <param name="e">Switch2_Toggled event args e</param>
        private void Switch2_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.dataGrid.AllowTriStateSorting = true;
            }
            else
            {
                this.dataGrid.AllowTriStateSorting = false;
            }
        }

        /// <summary>
        /// Triggers while Switch was enabled 
        /// </summary>
        /// <param name="sender">Switch3_Toggled event sender</param>
        /// <param name="e">Switch3_Toggled event args e</param>
        private void Switch3_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.dataGrid.AllowMultiSorting = true;
            }
            else
            {
                this.dataGrid.AllowMultiSorting = false;
            }
        }

        /// <summary>
        /// Triggers while Switch was enabled 
        /// </summary>
        /// <param name="sender">Switch4_Toggled event sender</param>
        /// <param name="e">Switch4_Toggled event args e</param>
        private void Switch4_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.dataGrid.Columns["ProductName"].AllowSorting = true;
            }
            else
            {
                this.dataGrid.Columns["ProductName"].AllowSorting = false;
            }
        }
    }
}
