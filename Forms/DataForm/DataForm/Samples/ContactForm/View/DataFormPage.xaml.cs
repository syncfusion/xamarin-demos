#region Copyright
// <copyright file="DataFormPage.xaml.cs" company="Syncfusion"> 
//  Copyright (c) Syncfusion Inc. 2001 - 2020. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace SampleBrowser.SfDataForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Represents a simple data form sample view.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Preserve(AllMembers = true)]
    public partial class DataFormPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormPage"/> class.
        /// </summary>
        public DataFormPage()
        {
            this.InitializeComponent();
        }
    }
}