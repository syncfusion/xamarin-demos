#region Copyright
// <copyright file="GettingStarted.xaml.cs" company="Syncfusion"> 
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
    using SampleBrowser.Core;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Represents a simple DataForm sample to Transfer money from one account to another account.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStarted : SampleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStarted"/> class.
        /// </summary>
        public GettingStarted()
        {
            this.InitializeComponent();
        }
    }
}