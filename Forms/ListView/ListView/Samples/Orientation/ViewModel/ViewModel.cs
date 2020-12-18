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
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewOrientationViewModel
    {
        #region Fields

        private ObservableCollection<PizzaInfo> pizzaInfo;
        private ObservableCollection<PizzaInfo> pizzaInfo1;

        #endregion

        #region Constructor

        public ListViewOrientationViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<PizzaInfo> PizzaInfo
        {
            get { return pizzaInfo; }
            set { this.pizzaInfo = value; }
        }

        public ObservableCollection<PizzaInfo> PizzaInfo1
        {
            get { return pizzaInfo1; }
            set { this.pizzaInfo1 = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            PizzaInfoRepository pizzainfo = new PizzaInfoRepository();
            pizzaInfo = pizzainfo.GetPizzaInfo();
            pizzaInfo1 = pizzainfo.GetPizzaInfo1();
        }

        #endregion
    }
}
