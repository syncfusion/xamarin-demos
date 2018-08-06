#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfMaps
{
   [Preserve(AllMembers = true)]
    public class BubbleVisualizationViewModel
    {
        public List<BubbleVisualizationModel> GetDataSource()
        {
            List<BubbleVisualizationModel> list = new List<BubbleVisualizationModel>();
            list.Add(new BubbleVisualizationModel("Brazil", "BRA", 204436000, 22));
            list.Add(new BubbleVisualizationModel("United States", "USA", 321174000, 167));
            list.Add(new BubbleVisualizationModel("India", "IND", 1272470000, 73));
            list.Add(new BubbleVisualizationModel("China", "CHI", 1370320000, 30));
            list.Add(new BubbleVisualizationModel("Indonesia", "INO", 255461700, 72));

            return list;
        }
    }
}
