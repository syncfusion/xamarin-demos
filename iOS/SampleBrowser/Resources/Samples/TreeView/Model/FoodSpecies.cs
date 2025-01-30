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