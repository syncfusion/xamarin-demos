#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms.DataPager;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PagingBehavior:Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private SfDataPager datapager;
        private DataPagerViewModel viewModel;

        protected override void OnAttachedTo(SampleView bindable)
        {
            viewModel = new DataPagerViewModel();
            bindable.BindingContext = viewModel;
            datagrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            datapager = bindable.FindByName<SfDataPager>("dataPager");
            datapager.PageSize = 20;
            datapager.Source = viewModel.OrdersInfo;
            datagrid.ItemsSource = datapager.PagedSource;
             datapager.AppearanceManager = new PagerAppearance();
            if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet || Device.RuntimePlatform == Device.macOS)
                datapager.NumericButtonCount = 14;
            else if (Device.Idiom == TargetIdiom.Phone)
                datapager.NumericButtonCount = 6;
            if (Device.RuntimePlatform == Device.UWP)
            {
                datapager.HeightRequest = 50;
            }
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SampleView bindable)
        {
            datagrid = null;
            datapager = null;
            viewModel = null;
            base.OnDetachingFrom(bindable);
        }
    }
[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class PagerAppearance : AppearanceManager
    {
        public override Color GetPagerButtonBorderColor()
        {
            return Color.Black;
        }
    }

}
