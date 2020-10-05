#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser
{
	public class AutoRowHeightViewModel : INotifyPropertyChanged
	{

        public AutoRowHeightViewModel()
        {
            ReleaseInfoRepository details = new ReleaseInfoRepository();
            releaseInformation = details.GetReleaseDetails(28);
        }

        #region ItemsSource

        private ObservableCollection<ReleaseInfo> releaseInformation;

        public ObservableCollection<ReleaseInfo> ReleaseInformation
        {
            get { return this.releaseInformation; }
            set { this.releaseInformation = value; }
        }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion
    }
}
