#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
    [Foundation.Preserve(AllMembers = true)]
    public class ReleaseInfo :INotifyPropertyChanged
    {
        public ReleaseInfo()
        {
        }

        #region private variables
        private int sNo;
        private string platform;
        private string features;
        private string description;
        private string releaseVersion;
        
        #endregion

        #region Public Properties

        public int SNo
        {
            get { return this.sNo; }
            set
            {
                this.sNo = value;
                RaisePropertyChanged("SNo");
            }
        }

        public string Platform
        {
            get { return this.platform; }
            set
            {
                this.platform = value;
                RaisePropertyChanged("Platform");
            }
        }
        public string Features
        {
            get { return features; }
            set
            {
                features = value;
                RaisePropertyChanged("Features");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        public string ReleaseVersion
        {
            get { return releaseVersion; }
            set
            {
                this.releaseVersion = value;
                RaisePropertyChanged("ReleaseVersion");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
