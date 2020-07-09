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
using System.Text;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeMap
{
    [Preserve(AllMembers = true)]
    public class LabelPopulationViewModel
    {
        public LabelPopulationViewModel()
        {
            LabelPopulationDetails = new ObservableCollection<LabelPopulationDetail>();
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "China", Population = 1388232693 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "India", Population = 1342512706 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "United States of America", Population = 326474013 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Indonesia", Population = 263510146 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Brazil", Population = 211243220 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Pakistan", Population = 196744376 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Nigeria", Population = 191835936 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Bangladesh", Population = 164827718 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Russian Federation", Population = 143375006 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Mexico", Population = 130222815 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Japan", Population = 126045211 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Ethiopia", Population = 104344901 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Philippines", Population = 103796832 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Viet Nam", Population = 95414640 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Egypt", Population = 95215102 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "D.R. Congo", Population = 82242685 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Iran", Population = 80945718 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Germany", Population = 80636124 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Turkey", Population = 80417526 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Thailand", Population = 68297547 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "United Kingdom", Population = 65511098 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "France", Population = 64938716 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Italy", Population = 59797978 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Tanzania", Population = 56877529 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "South Africa", Population = 55436360 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Myanmar", Population = 54836483 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Republic of Korea", Population = 50704971 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Colombia", Population = 49067981 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Kenya", Population = 48466928 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Spain", Population = 46070146 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Ukraine", Population = 44405055 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Argentina", Population = 44272125 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Sudan", Population = 42166323 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Uganda", Population = 41652938 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Algeria", Population = 41063753 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Iraq", Population = 38654287 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Poland", Population = 38563573 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Canada", Population = 36626083 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Morocco", Population = 35241418 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Afghanistan", Population = 34169169 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Saudi Arabia", Population = 32742664 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Peru", Population = 32166473 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Venezuela", Population = 31925705 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Malaysia", Population = 31164177 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Uzbekistan", Population = 30690914 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Mozambique", Population = 29537914 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Nepal", Population = 29187037 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Ghana", Population = 28656723 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Yemen", Population = 28119546 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Angola", Population = 26655513 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Madagascar", Population = 25612972 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Dem Peoples Republic of Korea", Population = 25405296 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Australia", Population = 24641662 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Cameroon", Population = 24513689 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Côte dIvoire", Population = 23815886 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Taiwan", Population = 23405309 });
            LabelPopulationDetails.Add(new LabelPopulationDetail() { Country = "Niger", Population = 21563607 });
		}

        public ObservableCollection<LabelPopulationDetail> LabelPopulationDetails
        {
            get;
            set;
        }

    }
}
