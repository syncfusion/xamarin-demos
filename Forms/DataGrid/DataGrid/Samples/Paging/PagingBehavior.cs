#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "PagingBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2021. All rights reserved.
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
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfDataGrid.XForms.DataPager;
    using Syncfusion.XForms.Themes;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

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
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private PickerExt selectionPicker;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SampleView samplePage;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.viewModel = new DataPagerViewModel();
            this.samplePage = bindAble;
            bindAble.BindingContext = this.viewModel;
            this.InitPager(bindAble);
            base.OnAttachedTo(bindAble);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">A sampleView type of bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            if (this.selectionPicker != null)
            {
                this.selectionPicker.SelectedIndexChanged -= this.SelectionPicker_SelectedIndexChanged;
            }

            (this.datapager.Children[1] as ScrollView).Scrolled -= this.PagingBehavior_Scrolled;
            this.datagrid = null;
            this.datapager = null;
            this.viewModel = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Initializes the required properties of the data pager.
        /// </summary>
        /// <param name="bindAble">The sample view that hosts the data grid and the data pager.</param>
        private void InitPager(SampleView bindAble)
        {
            this.datagrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.datapager = bindAble.FindByName<SfDataPager>("dataPager");
            this.selectionPicker = bindAble.FindByName<PickerExt>("SelectionPicker");
            if (this.selectionPicker != null)
            {
                this.selectionPicker.Items.Add("Rectangle");
                this.selectionPicker.Items.Add("Circle");
                this.selectionPicker.SelectedIndexChanged += this.SelectionPicker_SelectedIndexChanged;
                this.datapager.AppearanceManager = new PagerAppearance();
            }
            else
            {
                this.datapager.PropertyChanged += this.DatapagerPropertyChanged;
            }

            this.datapager.PageSize = 20;
            this.datapager.Source = this.viewModel.OrdersInfo;
            this.datagrid.ItemsSource = this.datapager.PagedSource;
            (this.datapager.Children[1] as ScrollView).Scrolled += this.PagingBehavior_Scrolled;
            if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet || Device.RuntimePlatform == Device.macOS)
            {
                this.datapager.NumericButtonCount = 12;
            }
            else if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == Device.WPF)
            {
                this.datapager.NumericButtonCount = 6;
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                this.datapager.HeightRequest = 50;
            }
        }

        /// <summary>
        /// Triggers while selected Index was changed, used to set a button shape.
        /// </summary>
        /// <param name="sender">OnSelectionChanged event sender</param>
        /// <param name="e">EventArgs e</param>
        private void SelectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.datagrid != null && this.datagrid.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("IsGridLoaded")) != null && (bool)this.datagrid.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("IsGridLoaded")).GetValue(this.datagrid) == true)
            {
                if (this.selectionPicker.SelectedIndex == 0)
                {
                    (this.datapager.Children[1] as ScrollView).Scrolled -= this.PagingBehavior_Scrolled;
                    this.samplePage.Content = null;
                    this.samplePage.Content = new Paging("Rectangle").Content;
                }
                else if (this.selectionPicker.SelectedIndex == 1)
                {
                    (this.datapager.Children[1] as ScrollView).Scrolled -= this.PagingBehavior_Scrolled;
                    this.samplePage.Content = null;
                    this.samplePage.Content = new Paging("Circle").Content;
                }
            }
        }

        /// <summary>
        /// Raises when the <see cref="SfDataPager"/> property gets changed.
        /// </summary>
        /// <param name="sender"><see cref="SfDataPager"/> instance.</param>
        /// <param name="e">Event args.</param>
        private void DatapagerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AppearanceManager")
            {
                var pager = sender as SfDataPager;
                ICollection<ResourceDictionary> mergedDictionaries = null;
#if COMMONSB
            var parent = ((pager.Parent as Grid).Parent as Grid).Parent;
            while (parent != null)
            {
                if (parent is ThemesPage)
                {
                    mergedDictionaries = (parent as Page).Resources.MergedDictionaries;
                    break;
                }
                parent = parent.Parent;
            }
            parent = null;
#else
                mergedDictionaries = ((sender as SfDataPager).Parent.Parent.Parent as SampleView).Resources.MergedDictionaries;
#endif
                var boxView = ((sender as SfDataPager).Parent.Parent as Grid).Children[1] as BoxView;
                var darkTheme = (mergedDictionaries != null) ? mergedDictionaries.OfType<DarkTheme>().FirstOrDefault() : null;
                var lightTheme = (mergedDictionaries != null) ? mergedDictionaries.OfType<LightTheme>().FirstOrDefault() : null;
                var darkThemeIndex = mergedDictionaries.IndexOf(darkTheme);
                var lightThemeIndex = mergedDictionaries.IndexOf(lightTheme);
                if (darkTheme != null && darkThemeIndex > lightThemeIndex)
                {
                    boxView.Color = Color.FromHex("#414141");
                }
                else
                {
                    boxView.Color = Color.FromHex("#E0E0E0");
                }

                mergedDictionaries = null;
                pager = null;
                boxView = null;
            }
        }

        /// <summary>
        /// Event handler that is fired when scrolling happens in pager.
        /// </summary>
        /// <param name="sender">The scroll view inside the pager.</param>
        /// <param name="e">Scrolling event arguments</param>
        private async void PagingBehavior_Scrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;
            if (e.ScrollX > scrollView.ContentSize.Width - scrollView.Width - 3)
            {
                await(sender as ScrollView).ScrollToAsync(scrollView.ContentSize.Width - scrollView.Width - 3, 0, false);
            }

            scrollView = null;
        }
    }
}
