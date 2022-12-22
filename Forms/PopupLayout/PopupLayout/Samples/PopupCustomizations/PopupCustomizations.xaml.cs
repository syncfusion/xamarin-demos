#region Copyright Syncfusion Inc. 2001-2022.
// ------------------------------------------------------------------------------------
// <copyright file = "PopupCustomizations.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Diagnostics.CodeAnalysis;
    using Core;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// A sampleView that contains the PopupCustomizations sample.
    /// </summary>
    public partial class PopupCustomizations : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the PopupCustomizations class.
        /// </summary>
        public PopupCustomizations()
        {
            this.InitializeComponent();
        }        

        /// <summary>
        /// You can override this method while View was disappear from window
        /// </summary>
        public override void OnDisappearing()
        {          
            base.OnDisappearing();

            if (this.bookingNotification != null)
            {
                this.bookingNotification.Dispose();
                this.bookingNotification = null;
            }

            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }
        }
    }
}