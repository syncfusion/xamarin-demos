#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PagingBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfDataGrid.XForms.DataPager;
    using Xamarin.Forms;
   
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the Paging samples
    /// </summary>
    public class PagingBehavior : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SfDataPager datapager;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DataPagerViewModel viewModel;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new DataPagerViewModel();
            bindAble.BindingContext = this.viewModel;
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.datapager = bindAble.FindByName<SfDataPager>("dataPager");
            this.datapager.PageSize = 20;
            this.datapager.Source = this.viewModel.OrdersInfo;
            this.datagrid.ItemsSource = this.datapager.PagedSource;
            this.datapager.AppearanceManager = new PagerAppearance();
            if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet || Device.RuntimePlatform == Device.macOS)
            {
                this.datapager.NumericButtonCount = 14;
            }              
            else if (Device.Idiom == TargetIdiom.Phone)
            {
                this.datapager.NumericButtonCount = 6;
            }
                
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.datapager.HeightRequest = 50;
            }

            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.datagrid = null;
            this.datapager = null;
            this.viewModel = null;
            base.OnDetachingFrom(bindAble);
        }
    }
}
