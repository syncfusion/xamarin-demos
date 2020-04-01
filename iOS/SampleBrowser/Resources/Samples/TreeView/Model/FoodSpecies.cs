#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleBrowser
{
    public class FoodSpecies : INotifyPropertyChanged
    {
        #region Fields

        private string speciesName;
        private ObservableCollection<FoodSpecies> species;

        #endregion

        #region Constructor

        public FoodSpecies()
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<FoodSpecies> Species
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
}