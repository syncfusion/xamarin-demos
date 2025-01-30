#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "GettingStarted.xaml.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
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
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// A sampleView that contains the Dialogs sample.
    /// </summary>
    public partial class GettingStarted : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted" /> class
        /// </summary>
        public GettingStarted()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// You can override this method while View was disappear from window
        /// </summary>
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            if (this.alertDialog != null)
            {
                this.alertDialog.Dispose();
                this.alertDialog = null;
            }

            if (this.alertWithTitleDialogue != null)
            {
                this.alertWithTitleDialogue.Dispose();
                this.alertWithTitleDialogue = null;
            }

            if (this.simpleDialog != null)
            {
                this.simpleDialog.Dispose();
                this.simpleDialog = null;
            }

            if (this.confirmationDialog != null)
            {
                this.confirmationDialog.Dispose();
                this.confirmationDialog = null;
            }

            if (this.modelWindow != null)
            {
                this.modelWindow.Dispose();
                this.modelWindow = null;
            }

            if (this.relativeDialog != null)
            {
                this.relativeDialog.Dispose();
                this.relativeDialog = null;
            }

            if (this.fullScreenDialog != null)
            {
                this.fullScreenDialog.Dispose();
                this.fullScreenDialog = null;
            }
        }
    }
}