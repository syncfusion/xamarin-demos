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
