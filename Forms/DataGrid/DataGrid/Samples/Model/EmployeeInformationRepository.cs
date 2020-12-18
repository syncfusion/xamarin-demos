#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EmployeeInformationRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion

namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class EmployeeInformationRepository
    {
        #region private variables

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<DateTime> birthDates;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private ObservableCollection<DateTime> hireDates;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random random = new Random();

        #endregion

        #region MainGrid DataSource

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] titles = new string[] 
        {
            "Sales Representative",
            "Vice President, Sales",
            "Sales Representative",
            "Sales Manager",
            "Inside Sales Coordinator",
            "Business Manager",
            "Mail Clerk",
            "Receptionist",
            "Marketing Director",
            "Marketing Associate",
            "Advertising Specialist"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] firstNames = new string[]
        {
            "Nancy",
            "Andrew",
            "Janet",
            "Margaret",
            "Steven",
            "Michael",
            "Robert",
            "Laura",
            "Anne",
            "Albert",
            "Caroline",
            "Xavier",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] lastNames = new string[]
        {
            "Davolio",
            "Fuller",
            "Leverling",
            "Peacock",
            "Buchanan",
            "Suyama",
            "King",
            "Callahan",
            "Dodsworth",
            "Hellstern",
            "Patterson",
            "Martin",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] homePhones = new string[]
        {
            "(206) 555-9857",
            "(206) 555-9482",
            "(206) 555-3412",
            "(206) 555-8122",
            "(71) 555-4848",
            "(71) 555-7773",
            "(71) 555-5598",
            "(206) 555-1189",
            "(71) 555-4444",
            "(206) 555-4869",
            "(206) 555-3857",
            "(206) 555-3487",
            "88 83 83 16",
            "88 62 43 53",
            "88 01 01 68",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] addresses = new string[] 
        {
            "507 - 20th Ave. E. Apt. 2A",
            "908 W. Capital Way",
            "722 Moss Bay Blvd.",
            "4110 Old Redmond Rd.",
            "14 Garrett Hill",
            "Coventry House Miner Rd.",
            "Edgeham Hollow Winchester Way",
            "4726 - 11th Ave. N.E.",
            "7 Houndstooth Rd.",
            "13920 S.E. 40th Street",
            "30301 - 166th Ave. N.E.",
            "16 Maple Lane",
            "2 impasse du Soleil",
            "9 place de la Liberté",
            "7 rue Nationale"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] notes = new string[] 
        {
            "Education includes a BA in Psychology from The Colorado State University in the year 1970.",
            "Andrew received his BTS commercial in 1964 and an MBA in International Marketing from the University of Dallas in 1971.",
            "Janet has a BS degree in Chemistry from The Boston College (1984). She has also completed a certification in Food Retailing Management.",
            "Margaret holds a BA in English literature from Concordia College and an MA from the American Institute of Culinary Arts.",
            "Steven Buchanan graduated from the St. Andrews University in Scotland, with a BSC degree in the year 1976.",
            "Michael is a graduate of Sussex University (MA, economics, 1983) and University of California at Los Angeles (MBA, marketing, 1986).",
            "Robert King served in the Peace Corps and traveled extensively before completing his English degree at the University of Michigan in 1992.",
            "Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.",
            "Anne has a BA degree in English from St. Lawrence College. She is fluent in French and German languages.",
            "Albert Hellstern is a graduate of Harvard University, where he earned a Bachelor of Science degree in 1981.",
            "Caroline Patterson is a graduate from The Tahoma High School and she also has an AA degree from the Bellevue Community College in Bellevue.",
            "Xavier Martin is a graduate of the University of Chicago. Mr. Martin is completely fluent in German, French and English and understands Polish."
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] countries = new string[] 
        {
            "USA",
            "UK",
            "France",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string[]> cities = new Dictionary<string, string[]>();

        #endregion

        /// <summary>
        /// Initializes a new instance of the EmployeeInformationRepository class.
        /// </summary>
        public EmployeeInformationRepository()
        {
        }

        #region GetOrderDetails

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>added record row details</returns>
        public ObservableCollection<EmployeeInformation> GetEmployeeDetails(int count)
        {
            this.SetCity();
            this.birthDates = this.GetDateBetween(1980, 1992, count);
            this.hireDates = this.GetDateBetween(2005, 2014, count);
            ObservableCollection<EmployeeInformation> employeeDetails = new ObservableCollection<EmployeeInformation>();

            for (int i = 0; i < count; i++)
            {
                var country = this.countries[this.random.Next(1)];
                var city = this.cities[country];

                var emp = new EmployeeInformation()
                {
                    EmployeeID = i + 1,
                    FirstName = this.firstNames[i % this.firstNames.Length],
                    LastName = this.lastNames[i % this.lastNames.Length],
                    Designation = this.titles[this.random.Next(5)],
                    DateOfBirth = this.birthDates[i],
                    DateOfJoining = this.hireDates[i],
                    Address = this.addresses[this.random.Next(6)],
                    Country = this.countries[this.random.Next(2)],
                    City = city[this.random.Next(city.Length - 1)],
                    Telephone = this.homePhones[this.random.Next(8)],
                    Qualification = this.notes[i % this.notes.Length],
                    HireDate = this.hireDates[i].ToString("d")
                };
                employeeDetails.Add(emp);
            }

            return employeeDetails;
        }

        #endregion

        /// <summary>
        /// Used to generate DateTime and returns the value
        /// </summary>
        /// <param name="startYear">integer type of parameter startYear</param>
        /// <param name="endYear">integer type of parameter endYear</param>
        /// <param name="count">integer type of parameter count</param>
        /// <returns>returns the generated DateTime</returns>
        private ObservableCollection<DateTime> GetDateBetween(int startYear, int endYear, int count)
        {
            ObservableCollection<DateTime> date = new ObservableCollection<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }

            return date;
        }

        /// <summary>
        /// Used to store a string type collection items
        /// </summary>
        private void SetCity()
        {
            string[] france = new string[]
            {
                "Haguenau",
                "Schiltigheim",
                "Strasbourg"
            };

            string[] uk = new string[]
            {
                "Colchester",
                "Hedge End",
                "London"
            };

            string[] usa = new string[]
            {
                "Seattle",
                "Tacoma",
                "Kirkland",
                "Redmond",
                "Bellevue",
                "Kent",
                "Auburn",
            };

            this.cities.Add("France", france);
            this.cities.Add("UK", uk);
            this.cities.Add("USA", usa);
        }
    }
}