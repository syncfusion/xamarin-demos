#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "Paging.xaml.cs" company="Syncfusion.com">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.SfDataGrid.XForms.DataPager;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A sampleView that contains the Paging sample.
    /// </summary>
    public partial class Paging : SampleView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Paging class.
        /// </summary>
        public Paging()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the Paging class.
        /// </summary>
        /// <param name="shape">The shape of the pager when it loads.</param>
        public Paging(string shape)
        {
            this.InitializeComponent();
            if (shape.Equals("Rectangle"))
            {
                this.dataPager.ButtonShape = ButtonShape.Rectangle;
            }
            else
            {
                this.dataPager.ButtonShape = ButtonShape.Circle;
            }
        }

        #endregion
    }  
}
