#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "AutoRowHeightViewModel.cs" company="Syncfusion.com">
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
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.Data;
    using Syncfusion.Data.Extensions;
    using Syncfusion.SfDataGrid.XForms;
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    /// A ViewModel for AutoRowHeight sample.
    /// </summary>
    public class AutoRowHeightViewModel : INotifyPropertyChanged
    {
        #region Field

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<ReleaseInfo> releaseInformation;

        #endregion

        /// <summary>
        /// Initializes a new instance of the AutoRowHeightViewModel class.
        /// </summary>
        public AutoRowHeightViewModel()
        {
            ReleaseInfoRepository details = new ReleaseInfoRepository();
            this.releaseInformation = details.GetReleaseDetails(28);
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ItemsSource

        /// <summary>
        /// Gets or sets the value of ReleaseInformation
        /// </summary>
        public ObservableCollection<ReleaseInfo> ReleaseInformation
        {
            get { return this.releaseInformation; }
            set { this.releaseInformation = value; }
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="propertyName">string type of parameter propertyName</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}
