#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class CountriesViewModel
    {
        public ObservableCollection<Countries> CountriesInfo { get; set; }

        public ObservableCollection<object> SelectedCountries { get; set; }

        public CountriesViewModel()
        {
            GenerateCountriesInfo();
        }

        private void GenerateCountriesInfo()
        {
            var australia = new Countries() { Name = "Australia" };
            var _NSW = new Countries() { Name = "New South Wales" };
            var sydney = new Countries() { Name = "Sydney" };
            var canbera = new Countries() { Name = "Canberra" };
            var maitland = new Countries() { Name = "Newcastle–Maitland" };
            var victoria = new Countries() { Name = "Victoria" };
            var melborne = new Countries() { Name = "Melbourne" };
            var queensland = new Countries() { Name = "Queensland" };
            var brisbane = new Countries() { Name = "Brisbane" };
            var westAussie = new Countries() { Name = "West Australia" };
            var perth = new Countries() { Name = "Perth" };
            var southAussie = new Countries() { Name = "South Australia" };
            var aldehide = new Countries() { Name = "Adelaide" };

            australia.States = new ObservableCollection<Countries>();
            australia.States.Add(_NSW);
            australia.States.Add(victoria);
            australia.States.Add(queensland);
            australia.States.Add(westAussie);
            australia.States.Add(southAussie);
            _NSW.States = new ObservableCollection<Countries>();
            _NSW.States.Add(sydney);
            _NSW.States.Add(canbera);
            _NSW.States.Add(maitland);
            victoria.States = new ObservableCollection<Countries>();
            victoria.States.Add(melborne);
            queensland.States = new ObservableCollection<Countries>();
            queensland.States.Add(brisbane);
            westAussie.States = new ObservableCollection<Countries>();
            westAussie.States.Add(perth);
            southAussie.States = new ObservableCollection<Countries>();
            southAussie.States.Add(aldehide);


            var brazil = new Countries() { Name = "Brazil" };
            var saoPaulostate = new Countries() { Name = "São Paulo" };
            var saoPaulo = new Countries() { Name = "São Paulo" };
            var campinas = new Countries() { Name = "Campinas" };
            var sorocaba = new Countries() { Name = "Sorocaba" };
            var deJaneiro = new Countries() { Name = "Rio de Janeiro" };
            var gerais = new Countries() { Name = "Minas Gerais" };
            var horizonte = new Countries() { Name = "Belo Horizonte" };
            var brassilia = new Countries() { Name = "Distrito Federal e Entorno (Brasilia)" };
            var ceara = new Countries() { Name = "Ceará" };
            var fortaleza = new Countries() { Name = "Fortaleza" };
            var caucaia = new Countries() { Name = "Caucaia" };
            var parana = new Countries() { Name = "Paraná" };
            var curitiba = new Countries() { Name = "Curitiba" };

            brazil.States = new ObservableCollection<Countries>();
            brazil.States.Add(saoPaulostate);
            brazil.States.Add(deJaneiro);
            brazil.States.Add(gerais);
            brazil.States.Add(ceara);
            brazil.States.Add(parana);
            saoPaulostate.States = new ObservableCollection<Countries>();
            saoPaulostate.States.Add(saoPaulo);
            saoPaulostate.States.Add(campinas);
            saoPaulostate.States.Add(sorocaba);
            gerais.States = new ObservableCollection<Countries>();
            gerais.States.Add(horizonte);
            gerais.States.Add(brassilia);
            ceara.States = new ObservableCollection<Countries>();
            ceara.States.Add(fortaleza);
            ceara.States.Add(caucaia);
            parana.States = new ObservableCollection<Countries>();
            parana.States.Add(curitiba);


            var china = new Countries() { Name = "China" };
            var guangdong = new Countries() { Name = "Guangdong" };
            var guanghou = new Countries() { Name = "Guanghou" };
            var jingjinji = new Countries() { Name = "Jingjinji" };
            var beijing = new Countries() { Name = "Beijing" };
            var tianjin = new Countries() { Name = "Tianjin" };
            var yangtze = new Countries() { Name = "Yangtze River Delta" };
            var shanghai = new Countries() { Name = "Shanghai" };
            var chengyu = new Countries() { Name = "Chengyu" };
            var chongqing = new Countries() { Name = "Chongqing" };
            var zhejiang = new Countries() { Name = "Zhejiang Province" };
            var hangzhou = new Countries() { Name = "Hangzhou" };

            china.States = new ObservableCollection<Countries>();
            china.States.Add(guangdong);
            china.States.Add(jingjinji);
            china.States.Add(yangtze);
            china.States.Add(chengyu);
            china.States.Add(zhejiang);
            guangdong.States = new ObservableCollection<Countries>();
            guangdong.States.Add(guanghou);
            jingjinji.States = new ObservableCollection<Countries>();
            jingjinji.States.Add(beijing);
            jingjinji.States.Add(tianjin);
            yangtze.States = new ObservableCollection<Countries>();
            yangtze.States.Add(shanghai);
            chengyu.States = new ObservableCollection<Countries>();
            chengyu.States.Add(chongqing);
            zhejiang.States = new ObservableCollection<Countries>();
            zhejiang.States.Add(hangzhou);

            var usa = new Countries() { Name = "United States of America" };
            var newYork = new Countries() { Name = "New York" };
            var california = new Countries() { Name = "California" };
            var losAngeles = new Countries() { Name = "Los Angeles" };
            var sanJose = new Countries() { Name = "San Jose" };
            var sanFrancisco = new Countries() { Name = "San Francisco" };
            var illinois = new Countries() { Name = "Illinois" };
            var chicago = new Countries() { Name = "Chicago" };
            var texas = new Countries() { Name = "Texas" };
            var houston = new Countries() { Name = "Houston" };
            var sanAntonio = new Countries() { Name = "San Antonio" };
            var dallas = new Countries() { Name = "Dallas" };
            var pennsylvania = new Countries() { Name = "Pennsylvania" };
            var philadelphia = new Countries() { Name = "Philadelphia" };
            usa.States = new ObservableCollection<Countries>();
            usa.States.Add(newYork);
            usa.States.Add(california);
            usa.States.Add(illinois);
            usa.States.Add(texas);
            usa.States.Add(pennsylvania);
            california.States = new ObservableCollection<Countries>();
            california.States.Add(losAngeles);
            california.States.Add(sanJose);
            california.States.Add(sanFrancisco);
            illinois.States = new ObservableCollection<Countries>();
            illinois.States.Add(chicago);
            texas.States = new ObservableCollection<Countries>();
            texas.States.Add(houston);
            texas.States.Add(sanAntonio);
            texas.States.Add(dallas);
            pennsylvania.States = new ObservableCollection<Countries>();
            pennsylvania.States.Add(philadelphia);


            var india = new Countries() { Name = "India" };
            var delhi = new Countries() { Name = "Delhi" };
            var newDelhi = new Countries() { Name = "New Delhi" };
            var maharastra = new Countries() { Name = "Maharashtra" };
            var mumbai = new Countries() { Name = "Mumbai" };
            var pune = new Countries() { Name = "Pune" };
            var westBengal = new Countries() { Name = "West Bengal" };
            var kolkatta = new Countries() { Name = "Kolkatta" };
            var karnataka = new Countries() { Name = "Karnataka" };
            var bangalore = new Countries() { Name = "Bangalore" };
            var tamilNadu = new Countries() { Name = "Tamil Nadu" };
            var chennai = new Countries() { Name = "Chennai" };

            india.States = new ObservableCollection<Countries>();
            india.States.Add(delhi);
            india.States.Add(maharastra);
            india.States.Add(westBengal);
            india.States.Add(karnataka);
            india.States.Add(tamilNadu);
            delhi.States = new ObservableCollection<Countries>();
            delhi.States.Add(newDelhi);
            maharastra.States = new ObservableCollection<Countries>();
            maharastra.States.Add(mumbai);
            maharastra.States.Add(pune);
            westBengal.States = new ObservableCollection<Countries>();
            westBengal.States.Add(kolkatta);
            karnataka.States = new ObservableCollection<Countries>();
            karnataka.States.Add(bangalore);
            tamilNadu.States = new ObservableCollection<Countries>();
            tamilNadu.States.Add(chennai);

            this.CountriesInfo = new ObservableCollection<Countries>();
            CountriesInfo.Add(australia);
            CountriesInfo.Add(brazil);
            CountriesInfo.Add(china);
            CountriesInfo.Add(usa);
            CountriesInfo.Add(india);

            SelectedCountries = new ObservableCollection<object>();
            SelectedCountries.Add(_NSW);
            SelectedCountries.Add(victoria);
        }
    }
}