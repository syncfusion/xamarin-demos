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
    public class DrilldownViewModel
    {
        public ObservableCollection<DrilldownModel> PopulationDetails
        {
            get;
            set;
        }

        public DrilldownViewModel()
        {
            this.PopulationDetails = new ObservableCollection<DrilldownModel>();

            #region Africa

            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Ethiopia", Population = 107534882 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Tanzania", Population = 59091392 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Kenya", Population = 50950879 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Uganda", Population = 44270563 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Mozambique", Population = 30528673 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Madagascar", Population = 26262810 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Malawi", Population = 19164728 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Zambia", Population = 17609178 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Zimbabwe", Population = 16913261 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Somalia", Population = 15181925 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "South Sudan", Population = 12919053 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Rwanda", Population = 12501156 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Burundi", Population = 107534882 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Eritrea", Population = 5187948 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Mauritius", Population = 1268315 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Djibouti", Population = 971408 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Réunion", Population = 883247 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Comoros", Population = 832347 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Mayotte", Population = 259682 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Eastern Africa", Region = "Seychelles", Population = 95235 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Democratic Republic of the Congo", Population = 84004989 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Angola", Population = 30774205 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Cameroon", Population = 24678234 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Chad", Population = 15353184 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Congo", Population = 5399895 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Central African Republic", Population = 4737423 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Gabon", Population = 2067561 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Equatorial Guinea", Population = 1313894 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Middle Africa", Region = "Sao Tome and Principe", Population = 208818 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Egypt", Population = 99375741 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Algeria", Population = 42008054 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Sudan", Population = 41511526 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Morocco", Population = 36191805 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Tunisia", Population = 11659174 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Libya", Population = 6470956 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Northern Africa", Region = "Western Sahara", Population = 567421 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Southern Africa", Region = "South Africa", Population = 57398421 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Southern Africa", Region = "Namibia", Population = 2587801 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Southern Africa", Region = "Botswana", Population = 2333201 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Southern Africa", Region = "Lesotho", Population = 2263010 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Southern Africa", Region = "Swaziland", Population = 1391385 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Nigeria", Population = 195875237 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Ghana", Population = 29463643 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Côte d'Ivoire", Population = 24905843 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Niger", Population = 22311375 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Burkina Faso", Population = 19751651 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Mali", Population = 19107706 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Senegal", Population = 16294270 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Guinea", Population = 13052608 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Benin", Population = 11485674 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Togo", Population = 7990926 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Sierra Leone", Population = 7719729 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Liberia", Population = 4853516 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Mauritania", Population = 4540068 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Gambia", Population = 2163765 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Guinea-Bissau", Population = 1907268 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Cabo Verde", Population = 553335 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Africa", States = "Western Africa", Region = "Saint Helena", Population = 4074 });

            #endregion

            #region Asia

            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Central Asia", Region = "Uzbekistan", Population = 32364996 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Central Asia", Region = "Kazakhstan", Population = 18403860 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Central Asia", Region = "Tajikistan", Population = 9107211 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Central Asia", Region = "Kyrgyzstan", Population = 6132932 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Central Asia", Region = "Turkmenistan", Population = 5851466 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "China", Population = 1415045928 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "Japan", Population = 127185332 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "South Korea", Population = 51164435 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "North Korea", Population = 25610672 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "Taiwan", Population = 23694089 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "Hong Kong", Population = 7428887 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "Mongolia", Population = 3121772 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Eastern Asia", Region = "Macao", Population = 632418 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Indonesia", Population = 266794980 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Philippines", Population = 106512074 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Viet Nam", Population = 96491146 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Thailand", Population = 69183173 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Myanmar", Population = 53855735 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Malaysia", Population = 32042458 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Cambodia", Population = 16245729 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Laos", Population = 6961210 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Singapore", Population = 5791901 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Timor-Leste", Population = 1324094 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southeastern Asia", Region = "Brunei Darussalam", Population = 434076 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "India", Population = 1354051854 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Pakistan", Population = 200813818 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Bangladesh", Population = 166368149 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Iran", Population = 82011735 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Afghanistan", Population = 36373176 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Nepal", Population = 29624035 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Sri Lanka", Population = 20950041 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Bhutan", Population = 817054 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Southern Asia", Region = "Maldives", Population = 444259 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Turkey", Population = 81916871 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Iraq", Population = 39339753 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Saudi Arabia", Population = 33554343 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Yemen", Population = 28915284 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Syria", Population = 18284407 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Azerbaijan", Population = 9923914 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Jordan", Population = 9903802 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "United Arab Emirates", Population = 9541615 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Israel", Population = 8452841 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Lebanon", Population = 6093509 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "State of Palestine", Population = 5052776 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Oman", Population = 4829946 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Kuwait", Population = 4197128 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Georgia", Population = 3907131 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Armenia", Population = 2934152 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Qatar", Population = 2694849 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Bahrain", Population = 1566993 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Asia", States = "Western Asia", Region = "Cyprus", Population = 1189085 });

            #endregion

            #region NorthAmerica

            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Mexico", Population = 130759074 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Guatemala", Population = 17245346 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Honduras", Population = 9417167 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "El, Salvador", Population = 6411558 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Nicaragua", Population = 6284757 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Costa, Rica", Population = 4953199 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Panama", Population = 4162618 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Central America", Region = "Belize", Population = 382444 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Northern America", Region = "U.S", Population = 322179605 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Northern America", Region = "Canada", Population = 36953765 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Northern America", Region = "Bermuda", Population = 61070 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Northern America", Region = "Greenland", Population = 56565 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "North America", States = "Northern America", Region = "Saint Pierre & Miquelon", Population = 6342 });

            #endregion

            #region SouthAmerica

            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Brazil", Population = 204519000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Colombia", Population = 48549000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Argentina", Population = 43132000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Peru", Population = 31153000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Venezuela", Population = 30620000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Chile", Population = 18006000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Ecuador", Population = 16279000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Bolivia", Population = 10520000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Paraguay", Population = 7003000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Uruguay", Population = 3310000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Guyana", Population = 747000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Suri Name", Population = 560000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "French Guiana", Population = 262000 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "South America", States = "South America", Region = "Falkland Islands", Population = 3000 });


            #endregion

            #region Europe

            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Russia", Population = 143964709 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Ukraine", Population = 44009214 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Poland", Population = 38104832 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Romania", Population = 19580634 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Crech, Republic", Population = 10625250 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Hungary", Population = 9688847 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Belarus", Population = 9452113 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Bulgaria", Population = 7036848 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Slovakia", Population = 5449816 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Eastern Europe", Region = "Moldova", Population = 4041065 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "United Kingdom", Population = 66573504 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Sweden", Population = 9982709 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Denmark", Population = 5754356 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Finland", Population = 5542517 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Norway", Population = 5353363 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Ireland", Population = 4803748 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Lithuania", Population = 2876475 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Latvia", Population = 1929938 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Estonia", Population = 1306788 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Iceland", Population = 337780 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Channel Islands", Population = 166083 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Isle of Man", Population = 84831 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Northern Europe", Region = "Faeroe Islands", Population = 49489 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Italy", Population = 59290969 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Spain", Population = 46397452 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Greece", Population = 11142161 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Portugal", Population = 10291196 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Serbia", Population = 8762027 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Croatia", Population = 4164783 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Bosnia and Herzegovina", Population = 3503554 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Albania", Population = 2934363 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Macedonia", Population = 2085051 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Slovenia", Population = 2081260 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Montenegro", Population = 629219 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Malta", Population = 432089 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Andorra", Population = 76953 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Gibraltar", Population = 34733 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "San Marino", Population = 33557 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Southern Europe", Region = "Holy, See", Population = 801 });

            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Germany", Population = 82293457 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "France", Population = 65233271 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Netherlands", Population = 17084459 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Belgium", Population = 11498519 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Austria", Population = 8751820 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Switzerland", Population = 8544034 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Luxembourg", Population = 590321 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Monaco", Population = 38897 });
            PopulationDetails.Add(new DrilldownModel() { Continent = "Europe", States = "Western Europe", Region = "Liechtenstein", Population = 38155 });

            #endregion
        }
    }
}
