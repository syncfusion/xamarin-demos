#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "AutoResizingPopupLayout.xaml.cs" company="Syncfusion.com">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SampleBrowser.Core;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// A sampleView that contains the AutoResizingPopupLayout sample.
    /// </summary>
    public partial class AutoResizingPopupLayout : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the AutoResizingPopupLayout class.
        /// </summary>
        public AutoResizingPopupLayout()
        {
           this.InitializeComponent();
        }
    }
}