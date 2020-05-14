#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ContextMenu.xaml.cs" company="Syncfusion.com">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.XForms.PopupLayout;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A sampleView that contains the ContextMenu sample.
    /// </summary>
    public partial class ContextMenu : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the ContextMenu class.
        /// </summary>
        public ContextMenu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// You can override this method while view has disappears
        /// </summary>
        public override void OnDisappearing()
        {
            popUpLayout.Dispose();
            base.OnDisappearing();
        }
    }
}