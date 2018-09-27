#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfKanban.XForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;

namespace SampleBrowser.SfKanban
{
	[Preserve(AllMembers = true)]
    public class KanbanCustomViewModel
    {

        public ObservableCollection<KanbanModel> Cards { get; set; }

        public KanbanCustomViewModel()
        {
            string path = "";

            Cards = new ObservableCollection<KanbanModel>();
            if (Device.RuntimePlatform == Device.UWP)
            {
                path = "SampleBrowser.SfKanban.Images/";
            }
            else
            {
                path = "SampleBrowser.SfKanban.";
            }

            Cards.Add(
                new KanbanModel()
                {
                    ID = 1,
                    Title = "Margherita",
                    ImageURL = ImagePathConverter.GetImageSource(path + "margherita.png"),
                    Category = "Menu",
                    Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese Margherita",
                    ImageURL = ImagePathConverter.GetImageSource(path + "doublecheesemargherita.png"),
                    Category = "Menu",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = ImagePathConverter.GetImageSource(path + "bucolicpie.png"),
                    Category = "Menu",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = ImagePathConverter.GetImageSource(path + "bumpercrop.png"),
                    Category = "Menu",
                    Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = ImagePathConverter.GetImageSource(path + "spiceoflife.png"),
                    Category = "Menu",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = ImagePathConverter.GetImageSource(path + "verynicoise.png"),
                    Category = "Menu",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 7,
                    Title = "Salad Daze",
                    ImageURL = ImagePathConverter.GetImageSource(path + "saladdaze.png"),
                    Category = "Menu",
                    Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
                    Tags = new string[] { "Onions", "Jalapeno" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = ImagePathConverter.GetImageSource(path + "bumpercrop.png"),
                    Category = "Ready to Serve",
                    Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = ImagePathConverter.GetImageSource(path + "spiceoflife.png"),
                    Category = "Ready to Serve",
                    Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = ImagePathConverter.GetImageSource(path + "bucolicpie.png"),
                    Category = "Door Delivery",
                    Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = ImagePathConverter.GetImageSource(path + "verynicoise.png"),
                    Category = "Dining",
                    Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese Margherita",
                    ImageURL = ImagePathConverter.GetImageSource(path + "doublecheesemargherita.png"),
                    Category = "Delivery",
                    Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );


        }

        public void Init()
        {
            
        }
    }
}
