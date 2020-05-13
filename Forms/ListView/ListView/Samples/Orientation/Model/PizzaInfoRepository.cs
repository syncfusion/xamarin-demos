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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class PizzaInfoRepository
    {
        #region Constructor

        public PizzaInfoRepository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<PizzaInfo> GetPizzaInfo()
        {
            var categoryInfo = new ObservableCollection<PizzaInfo>();
            for (int i = 0; i < PizzaNames.Count(); i++)
            {
                var info = new PizzaInfo() { PizzaName = PizzaNames[i] };

                if (i == 9)
                    info.PizzaImage = "Pizza3.jpg";
                else
                    info.PizzaImage = "Pizza" + i + ".jpg";

                categoryInfo.Add(info);
            }
            return categoryInfo;
        }

        internal ObservableCollection<PizzaInfo> GetPizzaInfo1()
        {
            var categoryInfo = new ObservableCollection<PizzaInfo>();

            for (int i = 0; i < PizzaNames1.Count(); i++)
            {
                var info = new PizzaInfo() { PizzaName = PizzaNames1[i] };

                if (i == 9)
                    info.PizzaImage = "Pizza12.jpg";
                else
                    info.PizzaImage = "Pizza" + (i + 9) + ".jpg";

                categoryInfo.Add(info);
            }
            return categoryInfo;
        }

        #endregion

        #region CategoryInfo

        string[] PizzaNames = new string[]
        {
            "Supreme",
            "GodFather",
            "Ciao-ciao",
            "Frutti di mare",
            "Kebabpizza",
            "Napolitana",
            "Apricot Chicken",
            "Lamb Tzatziki",
            "Mr Wedge",
            "Vegorama",
        };

        string[] PizzaNames1 = new string[]
        {
            "Margherita",
            "Funghi",
            "Capriciosa",
            "Stagioni",
            "Vegetariana",
            "Formaggi",
            "Marinara",
            "Peperoni",
            "apolitana",
            "Hawaii"
        };

        #endregion
    }
}
