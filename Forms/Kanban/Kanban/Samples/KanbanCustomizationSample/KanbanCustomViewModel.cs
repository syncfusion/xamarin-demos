#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

        public ObservableCollection<CustomKanbanModel> Cards { get; set; }

		public int LastOrderID
		{
			get;
			set;
		}

        public KanbanCustomViewModel()
        {
			LastOrderID = 16365;

            Cards = new ObservableCollection<CustomKanbanModel>();
           
			Cards.Add(
				new CustomKanbanModel()
				{
					ID = 1,
					Title = "Margherita",
					ImageURL = "margherita.png",
					Category = "Menu",
					Rating = 4,
                    Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only.",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese",
                    ImageURL = "doublecheesemargherita.png",
                    Category = "Menu",
					Rating = 5,
					Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = "bucolicpie.png",
                    Category = "Menu",
					Rating = 4.5f,
					Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
					Rating = 3.25f,
					ImageURL = "bumpercrop.png",
                    Category = "Menu",
                    Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = "SpiceOfLife.png",
                    Category = "Menu",
					Rating = 4.75f,
					Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = "VeryNicoise.png",
                    Category = "Menu",
					Rating = 3.75f,
					Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 7,
                    Title = "Salad Daze",
                    ImageURL = "SaladDaze.png",
                    Category = "Menu",
					Rating = 5,
					Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion.",
                    Tags = new string[] { "Onions", "Jalapeno" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 4,
                    Title = "Bumper Crop",
                    ImageURL = "bumpercrop.png",
                    Category = "Ready to Serve",
					OrderID = "Order ID - #16362",
					Description = "Can’t get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more",
                    Tags = new string[] { "Tomato", "Mushroom" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 5,
                    Title = "Spice of Life",
                    ImageURL = "SpiceOfLife.png",
                    Category = "Ready to Serve",
					OrderID = "Order ID - #16363",
					Description = "Thrill-seeking, heat-seeking pizza people only.  It’s hot. Trust us.",
                    Tags = new string[] { "Corn", "Gherkins" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 3,
                    Title = "Bucolic Pie",
                    ImageURL = "bucolicpie.png",
                    Category = "Door Delivery",
					OrderID = "Order ID - #16361",
					Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes.",
                    Tags = new string[] { "Onions", "Capsicum" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 6,
                    Title = "Very Nicoise",
                    ImageURL = "VeryNicoise.png",
                    Category = "Dining",
					OrderID = "Order ID - #16364",
					AnimationDuration = 60000,
					Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes.",
                    Tags = new string[] { "Red pepper", "Capsicum" }
                }
            );

            Cards.Add(
                new CustomKanbanModel()
                {
                    ID = 2,
                    Title = "Double Cheese",
                    ImageURL = "doublecheesemargherita.png",
                    Category = "Delivery",
					OrderID = "Order ID - #16365",
					AnimationDuration = 60000,
					Description = "The minimalist classic with a double helping of cheese",
                    Tags = new string[] { "Cheese" }
                }
            );
        }
    }

	public class CustomKanbanModel : KanbanModel
	{
		public float Rating
		{
			get;
			set;
		}

		public string OrderID
		{
			get;
			set;
		}

		public int AnimationDuration
		{
			get;
			set;
		}
	}
}
