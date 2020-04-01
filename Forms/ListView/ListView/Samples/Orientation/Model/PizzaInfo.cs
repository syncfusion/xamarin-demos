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
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class PizzaInfo : INotifyPropertyChanged
    {
        #region Fields

        private string pizzaName;
        private string pizzaImage;

        #endregion

        #region Constructor

        public PizzaInfo()
        {

        }

        #endregion

        #region Properties

        public string PizzaName
        {
            get { return pizzaName; }
            set
            {
                pizzaName = value;
                OnPropertyChanged("PizzaName");
            }
        }

        public string PizzaImage
        {
            get
            {
                return pizzaImage;
            }

            set
            {
                pizzaImage = value;
                OnPropertyChanged("PizzaImage");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
