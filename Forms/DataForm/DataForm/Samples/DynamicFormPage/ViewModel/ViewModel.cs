#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser.SfDataForm
{
    /// <summary>
    /// Represents the view model of data form dynamic forms sample.
    /// </summary>
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ViewModel
    {
        /// <summary>
        /// Represents the selectionForm information.
        /// </summary>
        private List<string> selectedForm;

        /// <summary>
        /// Gets or sets the SelectionForm information.
        /// </summary>
        public List<string> SelectedForm
        {
            get { return this.selectedForm; }
            set { this.selectedForm = value; }
        }

        /// <summary>
        /// Initializes  a new list of the <see cref="SelectedForm"/>.
        /// </summary>
        public ViewModel()
        {
            List<string> list = new List<string>();
            list.Add("Organization Form");
            list.Add("Employee Form");
            list.Add("Ecommerce");
            this.selectedForm = list;
        }
    }

}
