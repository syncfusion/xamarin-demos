#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfAvatarView
{
    public partial class GroupView : SampleView
    {
        private GroupModel selectedGroup;

        public GroupModel SelectedGroup
        {
            get
            {
                return selectedGroup;
            }
            set
            {
                selectedGroup = value;

                if (value != null)
                    this.PeopleListView.IsVisible = true;
                else
                    this.PeopleListView.IsVisible = false;
                this.OnPropertyChanged();
            }
        }

        private People selectedPerson;

        public People SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                if (value != null)
                    this.PersonView.IsVisible = true;
                else
                    this.PersonView.IsVisible = false;
                this.OnPropertyChanged();
            }
        }



        private ObservableCollection<GroupModel> groupCollection = new ObservableCollection<GroupModel>();

        public ObservableCollection<GroupModel> GroupCollection
        {
            get
            {
                return groupCollection;
            }
            set
            {
                groupCollection = value;
                this.OnPropertyChanged();
            }
        }

        public GroupView()
        {
            InitializeComponent();

            this.GroupCollection.Add(new GroupModel(5) { GroupName = "Marketing Managers" });
            this.GroupCollection.Add(new GroupModel(10) { GroupName = "Marketing Representative" });
            this.GroupCollection.Add(new GroupModel(3) { GroupName = "Marketing Heads" });
            this.GroupCollection.Add(new GroupModel(4) { GroupName = "Sales Managers" });
            this.GroupCollection.Add(new GroupModel(9) { GroupName = "Sales Representative" });
            this.GroupCollection.Add(new GroupModel(2) { GroupName = "Sales Heads" });
            this.GroupCollection.Add(new GroupModel(5) { GroupName = "Process Managers" });
            this.GroupCollection.Add(new GroupModel(10) { GroupName = "Process Representative" });
            this.GroupCollection.Add(new GroupModel(2) { GroupName = "Process Heads" });
            this.GroupCollection.Add(new GroupModel(3) { GroupName = "Coordinaters" });
            this.GroupCollection.Add(new GroupModel(3) { GroupName = "Desinger" });
            this.GroupCollection.Add(new GroupModel(2) { GroupName = "Field Managers" });
            this.GroupCollection.Add(new GroupModel(2) { GroupName = "Server Team" });


            this.BindingContext = this;

            this.ExtButton.Clicked += ExtButton_Clicked;
        }

        private void ExtButton_Clicked(object sender, EventArgs e)
        {
            if (this.PersonView.IsVisible)
            {
                this.SelectedPerson = null;
            }
            else
            {
                this.SelectedGroup = null;
            }
        }
    }

    public class GroupModel
    {
        public String GroupName { get; set; }

        public ObservableCollection<People> PeopleCollection { get; set; }

        private ObservableCollection<People> TotalPeople { get; set; }

        public String TotalParticipants { get; set; }

        public GroupModel(int peopleCount)
        {
            this.TotalParticipants = peopleCount.ToString() + " Participants";

            this.PopulateAllPeople();

            this.PopulatePeopleBasedOnCount(peopleCount);
        }

        private void PopulateAllPeople()
        {
            this.TotalPeople = new ObservableCollection<People>();

            this.TotalPeople.Add(new People() { Name = "Kyle", Image = "Avatar1.png" , Backgroundcolor= Color.FromHex("#90DDFE") });
            this.TotalPeople.Add(new People() { Name = "Gina" , Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Michael", Image = "People_Square18.png", Backgroundcolor= Color.White });
            this.TotalPeople.Add(new People() { Name = "Oscar", Image = "People_Square23.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "William", Image = "Avatar5.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Bill" , Backgroundcolor= Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Daniel", Image = "Avatar7.png", Backgroundcolor = Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Frank", Backgroundcolor= Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Howard", Image = "Avatar9.png", Backgroundcolor = Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Jack" , Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Holly" , Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Steve", Image = "Avatar2.png", Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Vince" ,Backgroundcolor = Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Zeke", Image = "Avatar4.png", Backgroundcolor = Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Aiden", Image = "People_Square10.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Jackson", Image = "People_Square15.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Mason" , Backgroundcolor = Color.BlanchedAlmond });
            this.TotalPeople.Add(new People() { Name = "Liam", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Jacob" , Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Jayden", Image = "People_Square14.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Ethan", Image = "Avatar1.png", Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Alexander", Image = "People_Square8.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Sebastian", Image = "Avatar3.png", Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Clara", Image = "People_Square3.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Victoriya", Image = "People_Square25.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Ellie", Image = "People_Square6.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Gabriella", Image = "People_Square9.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Arianna", Image = "People_Square2.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Sarah", Image = "People_Square17.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Kaylee", Image = "People_Square10.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Adriana", Image = "People_Square1.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Finley", Image = "People_Square7.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Daleyza", Image = "People_Square4.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Leila", Image = "People_Square11.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Mckenna", Image = "People_Square15.png", Backgroundcolor = Color.White });
            this.TotalPeople.Add(new People() { Name = "Jacqueline", Backgroundcolor = Color.FromHex("#9AA8F5") });
            this.TotalPeople.Add(new People() { Name = "Brynn" , Backgroundcolor = Color.FromHex("#FCCE65") });
            this.TotalPeople.Add(new People() { Name = "Sawyer", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Rosalie", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Maci", Image = "Avatar10.png", Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Miranda", Backgroundcolor = Color.FromHex("#90DDFE") });
            this.TotalPeople.Add(new People() { Name = "Talia", Image = "Avatar4.png", Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Shelby", Backgroundcolor = Color.FromHex("#9FEFC5") });
            this.TotalPeople.Add(new People() { Name = "Haven", Image = "Avatar6.png", Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Brynn" ,Backgroundcolor = Color.FromHex("#E79AF5") });
            this.TotalPeople.Add(new People() { Name = "Yaretzi", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Zariah", Image = "Avatar6.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Karla", Backgroundcolor = Color.FromHex("#D7E99C") });
            this.TotalPeople.Add(new People() { Name = "Cassandra", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Pearl", Backgroundcolor = Color.FromHex("#FBBC93") });
            this.TotalPeople.Add(new People() { Name = "Irene", Image = "Avatar10.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Zelda", Backgroundcolor = Color.FromHex("#F5EF9A") });
            this.TotalPeople.Add(new People() { Name = "Wren", Image = "Avatar4.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Yamileth", Backgroundcolor = Color.FromHex("#9AA8F5") });
            this.TotalPeople.Add(new People() { Name = "Belen", Image = "Avatar6.png", Backgroundcolor = Color.FromHex("#9AA8F5") });
            this.TotalPeople.Add(new People() { Name = "Briley", Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "Jada", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#9FCC69") });
            this.TotalPeople.Add(new People() { Name = "Jaden", Backgroundcolor = Color.FromHex("#FE9B90") });
            this.TotalPeople.Add(new People() { Name = "George", Backgroundcolor= Color.FromHex("#FCCE65") });
            this.TotalPeople.Add(new People() { Name = "Ellanaa", Image = "Avatar8.png", Backgroundcolor = Color.FromHex("#9AA8F5") });
            this.TotalPeople.Add(new People() { Name = "James", Backgroundcolor = Color.FromHex("#9FCC69") });

        }

        //Random random = new Random();
        static int count = 0;
        private void PopulatePeopleBasedOnCount(int peopleCount)
        {
           
            this.PeopleCollection = new ObservableCollection<People>();
            for (int i = 0; i < peopleCount; i++)
            {
                while (true)
                {
                    if (this.TotalPeople.Count <= count)
                        count = 0;

                    var person = (this.TotalPeople[count++]);
                    if (!this.PeopleCollection.Contains(person))
                    {                       
                        this.PeopleCollection.Add(person);
                        break;
                    }
                }
            }
        }
    }

    public class People
    {
        public String Name { get; set; }

        public String Image { get; set; }

        public Color Backgroundcolor { get; set; }
    }
}