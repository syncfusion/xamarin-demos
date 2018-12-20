#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class SalesByDate : NotificationObject
    {
        #region Fields

        private string name;
        private DateTime date;
        private double qS1;
        private double qS2;
        private double qS3;
        private double qS4;
        private double total;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return name; }
            set {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public DateTime Date
        {
            get { return date; }
            set {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        /// <summary>
        /// Gets or sets the Q s1.
        /// </summary>
        /// <value>The Q s1.</value>
        public double QS1
        {
            get { return qS1; }
            set {
                qS1 = value;
                RaisePropertyChanged("QS1");
            }
        }        

        /// <summary>
        /// Gets or sets the Q s2.
        /// </summary>
        /// <value>The Q s2.</value>
        public double QS2
        {
            get { return qS2; }
            set {
                qS2 = value;
                RaisePropertyChanged("QS2");
            }
        }

        /// <summary>
        /// Gets or sets the Q s3.
        /// </summary>
        /// <value>The Q s3.</value>
        public double QS3
        {
            get { return qS3; }
            set {
                qS3 = value;
                RaisePropertyChanged("QS3");
            }
        }

        /// <summary>
        /// Gets or sets the Q s4.
        /// </summary>
        /// <value>The Q s4.</value>
        public double QS4
        {
            get { return qS4; }
            set {
                qS4 = value;
                RaisePropertyChanged("QS4");
            }
        }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double Total
        {
            get { return total; }
            set
            {
                total = value;
                RaisePropertyChanged("Total");
            }
        }

        #endregion
    }   
}