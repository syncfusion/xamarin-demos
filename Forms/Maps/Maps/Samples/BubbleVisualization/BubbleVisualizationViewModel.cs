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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfMaps
{
   [Preserve(AllMembers = true)]
    public class BubbleVisualizationViewModel
    {
        public BubbleVisualizationViewModel()
        {
            Countries = new ObservableCollection<BubbleVisualizationModel>();

            Countries.Add(new BubbleVisualizationModel("China", 1393730000, 18.2));
            Countries.Add(new BubbleVisualizationModel("India", 1336180000, 17.5));
            Countries.Add(new BubbleVisualizationModel("United States", 327726000, 4.29));
            Countries.Add(new BubbleVisualizationModel("Indonesia", 265015300, 3.47));
            Countries.Add(new BubbleVisualizationModel("Pakistan", 209503000, 2.78));
            Countries.Add(new BubbleVisualizationModel("Brazil", 201795000, 2.74));
            Countries.Add(new BubbleVisualizationModel("Nigeria", 197306006, 2.53));
            Countries.Add(new BubbleVisualizationModel("Bangladesh", 165086000, 2.16));
            Countries.Add(new BubbleVisualizationModel("Russia", 146877088, 1.92));
            Countries.Add(new BubbleVisualizationModel("Japan", 126490000, 1.66));
            Countries.Add(new BubbleVisualizationModel("Mexico", 124737789, 1.63));
            Countries.Add(new BubbleVisualizationModel("Ethiopia", 107534882, 1.41));
            Countries.Add(new BubbleVisualizationModel("Philippines", 106375000, 1.39));
            Countries.Add(new BubbleVisualizationModel("Egypt", 97459100, 1.27));
            Countries.Add(new BubbleVisualizationModel("Vietnam", 94660000, 1.24));
            Countries.Add(new BubbleVisualizationModel("Germany", 82740900, 1.08));
            Countries.Add(new BubbleVisualizationModel("Iran", 81737800, 1.07));
            Countries.Add(new BubbleVisualizationModel("Turkey", 80810525, 1.06));
            Countries.Add(new BubbleVisualizationModel("Thailand", 69183173, 0.91));
            Countries.Add(new BubbleVisualizationModel("France", 67297000, 0.88));
            Countries.Add(new BubbleVisualizationModel("United Kingdom", 66040229, 0.86));
            Countries.Add(new BubbleVisualizationModel("Italy", 60436469, 0.79));
            Countries.Add(new BubbleVisualizationModel("South Africa", 57725600, 0.76));
            Countries.Add(new BubbleVisualizationModel("Colombia", 49918600, 0.65));
            Countries.Add(new BubbleVisualizationModel("Spain", 46659302, 0.61));
            Countries.Add(new BubbleVisualizationModel("Argentina", 44494502, 0.58));
            Countries.Add(new BubbleVisualizationModel("Poland", 38433600, 0.5));
            Countries.Add(new BubbleVisualizationModel("Canada", 37206700, 0.48));
            Countries.Add(new BubbleVisualizationModel("Saudi Arabia", 33413660, 0.44));
            Countries.Add(new BubbleVisualizationModel("Malaysia", 32647000, 0.42));
            Countries.Add(new BubbleVisualizationModel("Nepal", 29218867, 0.38));
            Countries.Add(new BubbleVisualizationModel("Australia", 25015400, 0.32));
            Countries.Add(new BubbleVisualizationModel("Kazakhstan", 18253300, 0.24));
            Countries.Add(new BubbleVisualizationModel("Cambodia", 16069921, 0.21));
            Countries.Add(new BubbleVisualizationModel("Belgium", 11414214, 0.15));
            Countries.Add(new BubbleVisualizationModel("Greece", 10768193, 0.14));
            Countries.Add(new BubbleVisualizationModel("Sweden", 10171524, 0.13));
            Countries.Add(new BubbleVisualizationModel("Somalia", 15181925, 0.12));
            Countries.Add(new BubbleVisualizationModel("Austria", 8830487, 0.12));
            Countries.Add(new BubbleVisualizationModel("Bulgaria", 7050034, 0.092));
        }
        public ObservableCollection<BubbleVisualizationModel> Countries { get; set; }
    }
}
