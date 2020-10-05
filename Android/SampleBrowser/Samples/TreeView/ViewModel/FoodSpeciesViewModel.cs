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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    public class FoodSpeciesViewModel
    {
        public ObservableCollection<FoodSpecies> SpeciesType { get; set; }

        public FoodSpeciesViewModel()
        {
            GenerateItems();
        }

        private void GenerateItems()
        {
            var fruit = new FoodSpecies() { SpeciesName = "Fruits" };
            var vegetables = new FoodSpecies() { SpeciesName = "Vegetables" };
            var grains = new FoodSpecies() { SpeciesName = "Grains" };

            var oranges = new FoodSpecies() { SpeciesName = "Oranges" };
            var pineapple = new FoodSpecies() { SpeciesName = "Pineapple" };
            var apples = new FoodSpecies() { SpeciesName = "Apples" };
            var bananas = new FoodSpecies() { SpeciesName = "Bananas" };
            var pears = new FoodSpecies() { SpeciesName = "Pears" };

            var apple = new FoodSpecies() { SpeciesName = "Apple" };
            var macintosh = new FoodSpecies() { SpeciesName = "Macintosh" };
            var grannysmith = new FoodSpecies() { SpeciesName = "Granny Smith" };
            var fuji = new FoodSpecies() { SpeciesName = "Fuji" };

            var anjou = new FoodSpecies() { SpeciesName = "Anjou" };
            var barlett = new FoodSpecies() { SpeciesName = "Bartlett" };
            var bosc = new FoodSpecies() { SpeciesName = "Bosc" };
            var concorde = new FoodSpecies() { SpeciesName = "Concorde" };
            var seckel = new FoodSpecies() { SpeciesName = "Seckel" };
            var starkrimson = new FoodSpecies() { SpeciesName = "Starkrimson" };

            var podded = new FoodSpecies() { SpeciesName = "Podded Vegetables" };
            var bulb = new FoodSpecies() { SpeciesName = "Bulb and Stem Vegetables" };
            var root = new FoodSpecies() { SpeciesName = "Root and Tuberous Vegetables" };

            var lentil = new FoodSpecies() { SpeciesName = "Lentil" };
            var pea = new FoodSpecies() { SpeciesName = "Pea" };
            var peanut = new FoodSpecies() { SpeciesName = "Peanut" };

            var asparagus = new FoodSpecies() { SpeciesName = "Asparagus" };
            var celery = new FoodSpecies() { SpeciesName = "Celery" };
            var leek = new FoodSpecies() { SpeciesName = "Leek" };
            var onion = new FoodSpecies() { SpeciesName = "Onion" };

            var carrot = new FoodSpecies() { SpeciesName = "Carrot" };
            var ginger = new FoodSpecies() { SpeciesName = "Ginger" };
            var parsnip = new FoodSpecies() { SpeciesName = "Parsnip" };
            var potato = new FoodSpecies() { SpeciesName = "Potato" };

            var cereals = new FoodSpecies() { SpeciesName = "Cereals" };
            var pseidocereals = new FoodSpecies() { SpeciesName = "Pseudocereals" };
            var oilseeds = new FoodSpecies() { SpeciesName = "Oilseeds" };

            var barley = new FoodSpecies() { SpeciesName = "Barley" };
            var oats = new FoodSpecies() { SpeciesName = "Oats" };
            var rice = new FoodSpecies() { SpeciesName = "Rice" };

            var amaranth = new FoodSpecies() { SpeciesName = "Amaranth" };
            var bucketwheat = new FoodSpecies() { SpeciesName = "Bucketwheat" };
            var chia = new FoodSpecies() { SpeciesName = "Chia" };
            var quinoa = new FoodSpecies() { SpeciesName = "Quinoa" };

            var mustard = new FoodSpecies() { SpeciesName = "India Mustard" };
            var safflower = new FoodSpecies() { SpeciesName = "Safflower" };
            var flaxseed = new FoodSpecies() { SpeciesName = "Flax Seed" };
            var poppyseed = new FoodSpecies() { SpeciesName = "Poppy Seed" };

            fruit.Species = new ObservableCollection<FoodSpecies>();
            fruit.Species.Add(oranges);
            fruit.Species.Add(pineapple);
            fruit.Species.Add(apples);
            fruit.Species.Add(bananas);
            fruit.Species.Add(pears);

            apples.Species = new ObservableCollection<FoodSpecies>();
            apples.Species.Add(apple);
            apples.Species.Add(macintosh);
            apples.Species.Add(grannysmith);
            apples.Species.Add(fuji);
            pears.Species = new ObservableCollection<FoodSpecies>();
            pears.Species.Add(anjou);
            pears.Species.Add(barlett);
            pears.Species.Add(bosc);
            pears.Species.Add(concorde);
            pears.Species.Add(seckel);
            pears.Species.Add(starkrimson);

            vegetables.Species = new ObservableCollection<FoodSpecies>();
            vegetables.Species.Add(podded);
            vegetables.Species.Add(bulb);
            vegetables.Species.Add(root);

            podded.Species = new ObservableCollection<FoodSpecies>();
            podded.Species.Add(lentil);
            podded.Species.Add(pea);
            podded.Species.Add(peanut);
            bulb.Species = new ObservableCollection<FoodSpecies>();
            bulb.Species.Add(asparagus);
            bulb.Species.Add(celery);
            bulb.Species.Add(leek);
            bulb.Species.Add(onion);

            root.Species = new ObservableCollection<FoodSpecies>();
            root.Species.Add(carrot);
            root.Species.Add(ginger);
            root.Species.Add(parsnip);
            root.Species.Add(potato);

            grains.Species = new ObservableCollection<FoodSpecies>();
            grains.Species.Add(cereals);
            grains.Species.Add(pseidocereals);
            grains.Species.Add(oilseeds);

            cereals.Species = new ObservableCollection<FoodSpecies>();
            cereals.Species.Add(barley);
            cereals.Species.Add(oats);
            cereals.Species.Add(rice);
            pseidocereals.Species = new ObservableCollection<FoodSpecies>();
            pseidocereals.Species.Add(amaranth);
            pseidocereals.Species.Add(bucketwheat);
            pseidocereals.Species.Add(chia);
            pseidocereals.Species.Add(quinoa);

            oilseeds.Species = new ObservableCollection<FoodSpecies>();
            oilseeds.Species.Add(mustard);
            oilseeds.Species.Add(safflower);
            oilseeds.Species.Add(flaxseed);
            oilseeds.Species.Add(poppyseed);

            this.SpeciesType = new ObservableCollection<FoodSpecies>();
            SpeciesType.Add(fruit);
            SpeciesType.Add(vegetables);
            SpeciesType.Add(grains);
        }
    }
}