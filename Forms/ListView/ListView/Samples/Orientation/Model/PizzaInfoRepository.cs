#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
        private static Assembly assembly = typeof(Orientation).GetTypeInfo().Assembly;

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
#if COMMONSB
                if (i == 9)
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.Icons.Pizza3.jpg", assembly);
                else
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.Icons.Pizza" + i + ".jpg", assembly);
#else
                if (i == 9)
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Pizza3.jpg", assembly);
                else
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Pizza" + i + ".jpg", assembly);
#endif
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
#if COMMONSB
                if (i == 9)
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.Icons.Pizza12.jpg", assembly);
                else
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.Icons.Pizza" + (i + 9) + ".jpg", assembly);
#else
                if (i == 9)
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Pizza12.jpg", assembly);
                else
                    info.PizzaImage = ImageSource.FromResource("SampleBrowser.SfListView.Icons.Pizza" + (i + 9) + ".jpg", assembly);
#endif
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
