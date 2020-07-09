#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OnBoardHelpsBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;
    using SfDataGrid = Syncfusion.SfDataGrid.XForms.SfDataGrid;

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  OnBoardHelps samples
    /// </summary>
    public class OnBoardHelpsBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// Holds the instance of the DataGrid.
        /// </summary>
        private SfDataGrid datagrid;

        /// <summary>
        /// Holds the instance of PopupLayout.
        /// </summary>
        private SfPopupLayout popupLayout;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            base.OnAttachedTo(bindAble);

            this.popupLayout = bindAble.Content.FindByName<SfPopupLayout>("popupLayout");
            this.datagrid = bindAble.Content.FindByName<SfDataGrid>("dataGrid");
            this.datagrid.GridLoaded += this.Datagrid_GridLoaded;
            this.datagrid.AutoGeneratingColumn += this.Datagrid_AutoGeneratingColumn;
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.datagrid.AutoGeneratingColumn -= this.Datagrid_AutoGeneratingColumn;
            this.datagrid.GridLoaded -= this.Datagrid_GridLoaded;
            this.popupLayout.Dispose();
            this.popupLayout = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when DataGrid comes in to the View
        /// </summary>
        /// <param name="sender">DataGrid_GridLoaded event sender</param>
        /// <param name="e">DataGrid_GridLoaded events args e</param>
        private void Datagrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            this.popupLayout.PopupView.HeightRequest = this.datagrid.Height;
            this.popupLayout.PopupView.WidthRequest = this.datagrid.Width;
            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.Android)
            {
                this.popupLayout.Show((double)0, 90);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                this.popupLayout.Show((double)0, 50);
            }
            else
            {
                this.popupLayout.Show((double)0, 40);
            }
        }

        /// <summary>
        /// Occurs when <see cref="AutoGenerateColumns"/>is set as true. Using this event, the user 
        /// can customize the columns being generated automatically.
        /// </summary>
        /// <param name="sender">DataGrid_AutoGeneratingColumn event sender</param>
        /// <param name="e">DataGrid_AutoGeneratingColumn event args e</param>
        private void Datagrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
        }
    }
}