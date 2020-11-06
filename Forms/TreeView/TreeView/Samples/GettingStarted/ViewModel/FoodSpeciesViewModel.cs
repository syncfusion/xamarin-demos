#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeView
{
    [Preserve(AllMembers = true)]
    public class FoodSpeciesViewModel
    {
        public ObservableCollection<SpeciesFamily> SpeciesFamilies { get; set; }
        public ObservableCollection<SpeciesType> SpeciesType { get; set; }
        public ObservableCollection<Species> Species { get; set; }

        public FoodSpeciesViewModel()
        {
           this.SpeciesFamilies= GenerateItems();
        }

        private ObservableCollection<SpeciesFamily> GenerateItems()
        {
            var fruit = new SpeciesFamily() { SpeciesName = "Fruits" };
            var vegetables = new SpeciesFamily() { SpeciesName = "Vegetables" };
            var grains = new SpeciesFamily() { SpeciesName = "Grains" };


            var oranges = new SpeciesType() { SpeciesName = "Oranges" };
            var pineapple = new SpeciesType() { SpeciesName = "Pineapple" };
            var apples = new SpeciesType() { SpeciesName = "Apples" };
            var bananas = new SpeciesType() { SpeciesName = "Bananas" };
            var pears = new SpeciesType() { SpeciesName = "Pears" };

            var apple = new Species() { SpeciesName = "Apple" };
            var macintosh = new Species() { SpeciesName = "Macintosh" };
            var grannysmith = new Species() { SpeciesName = "Granny Smith" };
            var fuji = new Species() { SpeciesName = "Fuji" };

            var anjou = new Species() { SpeciesName = "Anjou" };
            var barlett = new Species() { SpeciesName = "Bartlett" };
            var bosc = new Species() { SpeciesName = "Bosc" };
            var concorde = new Species() { SpeciesName = "Concorde" };
            var seckel = new Species() { SpeciesName = "Seckel" };
            var starkrimson = new Species() { SpeciesName = "Starkrimson" };

            var podded = new SpeciesType() { SpeciesName = "Podded Vegetables" };
            var bulb = new SpeciesType() { SpeciesName = "Bulb and Stem Vegetables" };
            var root = new SpeciesType() { SpeciesName = "Root and Tuberous Vegetables" };

            var lentil = new Species() { SpeciesName = "Lentil" };
            var pea = new Species() { SpeciesName = "Pea" };
            var peanut = new Species() { SpeciesName = "Peanut" };

            var asparagus = new Species() { SpeciesName = "Asparagus" };
            var celery = new Species() { SpeciesName = "Celery" };
            var leek = new Species() { SpeciesName = "Leek" };
            var onion = new Species() { SpeciesName = "Onion" };

            var carrot = new Species() { SpeciesName = "Carrot" };
            var ginger = new Species() { SpeciesName = "Ginger" };
            var parsnip = new Species() { SpeciesName = "Parsnip" };
            var potato = new Species() { SpeciesName = "Potato" };

            var cereals = new SpeciesType() { SpeciesName = "Cereals" };
            var pseidocereals = new SpeciesType() { SpeciesName = "Pseudocereals" };
            var oilseeds = new SpeciesType() { SpeciesName = "Oilseeds" };

            var barley = new Species() { SpeciesName = "Barley" };
            var oats = new Species() { SpeciesName = "Oats" };
            var rice = new Species() { SpeciesName = "Rice" };

            var amaranth = new Species() { SpeciesName = "Amaranth" };
            var bucketwheat = new Species() { SpeciesName = "Buckwheat" };
            var chia = new Species() { SpeciesName = "Chia" };
            var quinoa = new Species() { SpeciesName = "Quinoa" };

            var mustard = new Species() { SpeciesName = "India Mustard" };
            var safflower = new Species() { SpeciesName = "Safflower" };
            var flaxseed = new Species() { SpeciesName = "Flax Seed" };
            var poppyseed = new Species() { SpeciesName = "Poppy Seed" };

            fruit.SpeciesType = new ObservableCollection<SpeciesType>();
            fruit.SpeciesType.Add(oranges);
            fruit.SpeciesType.Add(pineapple);
            fruit.SpeciesType.Add(apples);
            fruit.SpeciesType.Add(bananas);
            fruit.SpeciesType.Add(pears);

            apples.Species = new ObservableCollection<Species>();
            apples.Species.Add(apple);
            apples.Species.Add(macintosh);
            apples.Species.Add(grannysmith);
            apples.Species.Add(fuji);
            pears.Species = new ObservableCollection<Species>();
            pears.Species.Add(anjou);
            pears.Species.Add(barlett);
            pears.Species.Add(bosc);
            pears.Species.Add(concorde);
            pears.Species.Add(seckel);
            pears.Species.Add(starkrimson);

            vegetables.SpeciesType = new ObservableCollection<SpeciesType>();
            vegetables.SpeciesType.Add(podded);
            vegetables.SpeciesType.Add(bulb);
            vegetables.SpeciesType.Add(root);

            podded.Species = new ObservableCollection<Species>();
            podded.Species.Add(lentil);
            podded.Species.Add(pea);
            podded.Species.Add(peanut);
            bulb.Species = new ObservableCollection<Species>();
            bulb.Species.Add(asparagus);
            bulb.Species.Add(celery);
            bulb.Species.Add(leek);
            bulb.Species.Add(onion);

            root.Species = new ObservableCollection<Species>();
            root.Species.Add(carrot);
            root.Species.Add(ginger);
            root.Species.Add(parsnip);
            root.Species.Add(potato);

            grains.SpeciesType = new ObservableCollection<SpeciesType>();
            grains.SpeciesType.Add(cereals);
            grains.SpeciesType.Add(pseidocereals);
            grains.SpeciesType.Add(oilseeds);

            cereals.Species = new ObservableCollection<Species>();
            cereals.Species.Add(barley);
            cereals.Species.Add(oats);
            cereals.Species.Add(rice);
            pseidocereals.Species = new ObservableCollection<Species>();
            pseidocereals.Species.Add(amaranth);
            pseidocereals.Species.Add(bucketwheat);
            pseidocereals.Species.Add(chia);
            pseidocereals.Species.Add(quinoa);

            oilseeds.Species = new ObservableCollection<Species>();
            oilseeds.Species.Add(mustard);
            oilseeds.Species.Add(safflower);
            oilseeds.Species.Add(flaxseed);
            oilseeds.Species.Add(poppyseed);

            var sepciesList = new ObservableCollection<SpeciesFamily>();
            sepciesList.Add(fruit);
            sepciesList.Add(vegetables);
            sepciesList.Add(grains);
            return sepciesList;

        }
    }
}

