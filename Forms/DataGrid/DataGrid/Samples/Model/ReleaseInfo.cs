#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ReleaseInfo.cs" company="Syncfusion.com">
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
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class contains properties and notifies clients that a property value has changed.
    /// </summary>  
    public class ReleaseInfo
    {
        #region private variables
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int sNo;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string platform;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string releaseVersion;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string features;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string description;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string dateOfRelease;

        #endregion

        /// <summary>
        /// Initializes a new instance of the ReleaseInfo class.
        /// </summary>
        public ReleaseInfo()
        {
        }

        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of SNo and notifies user when value gets changed
        /// </summary>
        public int SNo
        {
            get
            {
                return this.sNo;
            }

            set
            {
                this.sNo = value;
                this.RaisePropertyChanged("SNo");
            }
        }

        /// <summary>
        /// Gets or sets the value of Platform and notifies user when value gets changed
        /// </summary>
        public string Platform
        {
            get
            {
                return this.platform;
            }

            set
            {
                this.platform = value;
                this.RaisePropertyChanged("Platform");
            }
        }

        /// <summary>
        /// Gets or sets the value of ReleaseVersion and notifies user when value gets changed
        /// </summary>
        public string ReleaseVersion
        {
            get
            {
                return this.releaseVersion;
            }

            set
            {
                this.releaseVersion = value;
                this.RaisePropertyChanged("ReleaseVersion");
            }
        }

        /// <summary>
        /// Gets or sets the value of Features and notifies user when value gets changed
        /// </summary>
        public string Features
        {
            get
            {
                return this.features;
            }

            set
            {
                this.features = value;
                this.RaisePropertyChanged("Features");
            }
        }

        /// <summary>
        /// Gets or sets the value of Description and notifies user when value gets changed
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the value of DateOfRelease and notifies user when value gets changed
        /// </summary>
        public string DateOfRelease
        {
            get
            {
                return this.dateOfRelease;
            }

            set
            {
                this.dateOfRelease = value;
                this.RaisePropertyChanged("DateOfRelease");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of parameter name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }              
        }

        #endregion
    }
}
