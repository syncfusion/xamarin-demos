#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SalesByDate.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class SalesByDate : Employee
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string name;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double qS1;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double qS2;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double qS3;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double qS4;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double total;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private DateTime year;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public new string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the Q s1.
        /// </summary>
        /// <value>The Q s1.</value>
        public double QS1
        {
            get
            {
                return this.qS1;
            }

            set
            {
                this.qS1 = value;
                this.RaisePropertyChanged("QS1");
            }
        }

        /// <summary>
        /// Gets or sets the Q s2.
        /// </summary>
        /// <value>The Q s2.</value>
        public double QS2
        {
            get
            {
                return this.qS2;
            }

            set
            {
                this.qS2 = value;
                this.RaisePropertyChanged("QS2");
            }
        }

        /// <summary>
        /// Gets or sets the Q s3.
        /// </summary>
        /// <value>The Q s3.</value>
        public double QS3
        {
            get
            {
                return this.qS3;
            }

            set
            {
                this.qS3 = value;
                this.RaisePropertyChanged("QS3");
            }
        }

        /// <summary>
        /// Gets or sets the Q s4.
        /// </summary>
        /// <value>The Q s4.</value>
        public double QS4
        {
            get
            {
                return this.qS4;
            }

            set
            {
                this.qS4 = value;
                this.RaisePropertyChanged("QS4");
            }
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total
        {
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
                this.RaisePropertyChanged("Total");
            }
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public DateTime Date
        {
            get
            {
                return this.year;
            }

            set
            {
                this.year = value;
                this.RaisePropertyChanged("Date");
            }
        }
    }
}
