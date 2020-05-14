#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class SpeciesFamily : INotifyPropertyChanged
    {
        #region Fields

        private string speciesName;
        private ObservableCollection<SpeciesType> speciesType;

        #endregion

        #region Constructor

        public SpeciesFamily()
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<SpeciesType> SpeciesType
        {
            get { return speciesType; }
            set
            {
                speciesType = value;
                RaisedOnPropertyChanged("SpeciesType");
            }
        }

        public string SpeciesName
        {
            get { return speciesName; }
            set
            {
                speciesName = value;
                RaisedOnPropertyChanged("SpeciesName");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }

    [Preserve(AllMembers = true)]
    public class SpeciesType : INotifyPropertyChanged
    {
        #region Fields

        private string speciesName;
        private ObservableCollection<Species> species;

        #endregion

        #region Constructor

        public SpeciesType()
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<Species> Species
        {
            get { return species; }
            set
            {
                species = value;
                RaisedOnPropertyChanged("Species");
            }
        }

        public string SpeciesName
        {
            get { return speciesName; }
            set
            {
                speciesName = value;
                RaisedOnPropertyChanged("SpeciesName");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }

    [Preserve(AllMembers = true)]
    public class Species : INotifyPropertyChanged
    {
        #region Fields

        private string speciesName;

        #endregion

        #region Constructor

        public Species()
        {
        }

        #endregion

        #region Properties

        public string SpeciesName
        {
            get { return speciesName; }
            set
            {
                speciesName = value;
                RaisedOnPropertyChanged("SpeciesName");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }


}