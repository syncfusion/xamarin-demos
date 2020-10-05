#region Copyright Syncfusion Inc. 2001 - 2020.
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSunburstChart
{
    [Preserve(AllMembers = true)]

    public class SunburstViewModel
    {
        public SunburstViewModel()
        {
            this.DataSource = new ObservableCollection<SunburstModel>
            {
                new SunburstModel { Country = "USA", JobDescription = "Sales", JobGroup="Executive", EmployeesCount = 50 },
                new SunburstModel { Country = "USA", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Marketing", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 35 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 175 },
                new SunburstModel { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 70 },
                new SunburstModel { Country = "USA", JobDescription = "Management", EmployeesCount = 40 },
                new SunburstModel { Country = "USA", JobDescription = "Accounts", EmployeesCount = 60 },

                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 33 },
                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 125 },
                new SunburstModel { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 60 },
                new SunburstModel { Country = "India", JobDescription = "HR Executives", EmployeesCount = 70 },
                new SunburstModel { Country = "India", JobDescription = "Accounts", EmployeesCount = 45 },

                new SunburstModel { Country = "Germany", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 30 },
                new SunburstModel { Country = "Germany", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 },
                new SunburstModel { Country = "Germany", JobDescription = "Marketing", EmployeesCount = 50 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 40 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 65 },
                new SunburstModel { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 27 },
                new SunburstModel { Country = "Germany", JobDescription = "Management", EmployeesCount = 33 },
                new SunburstModel { Country = "Germany", JobDescription = "Accounts", EmployeesCount = 55 },

                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 25 },
                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 96 },
                new SunburstModel { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 55 },
                new SunburstModel { Country = "UK", JobDescription = "HR Executives", EmployeesCount = 60 },
                new SunburstModel { Country = "UK", JobDescription = "Accounts", EmployeesCount = 30 }
            };


            this.Population_Data = new ObservableCollection<SunburstModel>
            {
                    new SunburstModel { State = "Ontario", Continent = "North America", Country = "Canada", Population = 13210600 },
                    new SunburstModel { State = "New York", Continent = "North America", Country = "United States", Population = 19378102 },
                    new SunburstModel { State = "Pennsylvania", Continent = "North America", Country = "United States", Population = 12702379 },
                    new SunburstModel { State = "Ohio", Continent = "North America", Country = "United States", Population = 11536504 },
                    new SunburstModel { State = "Buenos Aires", Continent = "South America", Country = "Argentina", Population = 15594428 },
                    new SunburstModel { State = "Minas Gerais", Continent = "South America", Country = "Brazil", Population = 20593366 },
                    new SunburstModel { State = "Rio de Janeiro", Continent = "South America", Country = "Brazil", Population = 16369178 },
                    new SunburstModel { State = "Bahia", Continent = "South America", Country = "Brazil", Population = 15044127 },
                    new SunburstModel { State = "Rio Grande do Sul", Continent = "South America", Country = "Brazil", Population = 11164050 },
                    new SunburstModel { State = "Parana", Continent = "South America", Country = "Brazil", Population = 10997462 },
                    new SunburstModel { State = "Chittagong", Continent = "Asia", Country = "Bangladesh", Population = 28079000 },
                    new SunburstModel { State = "Rajshahi", Continent = "Asia", Country = "Bangladesh", Population = 18329000 },
                    new SunburstModel { State = "Khulna", Continent = "Asia", Country = "Bangladesh", Population = 15563000 },
                    new SunburstModel { State = "Liaoning", Continent = "Asia", Country = "China", Population = 43746323 },
                    new SunburstModel { State = "Shaanxi", Continent = "Asia", Country = "China", Population = 37327378 },
                    new SunburstModel { State = "Fujian", Continent = "Asia", Country = "China", Population = 36894216 },
                    new SunburstModel { State = "Shanxi", Continent = "Asia", Country = "China", Population = 35712111 },
                    new SunburstModel { State = "Kerala", Continent = "Asia", Country = "India", Population = 33387677 },
                    new SunburstModel { State = "Punjab", Continent = "Asia", Country = "India", Population = 27704236 },
                    new SunburstModel { State = "Haryana", Continent = "Asia", Country = "India", Population = 25353081 },
                    new SunburstModel { State = "Delhi", Continent = "Asia", Country = "India", Population = 16753235 },
                    new SunburstModel { State = "Jammu", Continent = "Asia", Country = "India", Population = 12548926 },
                    new SunburstModel { State = "West Java", Continent = "Asia", Country = "Indonesia", Population = 43021826 },
                    new SunburstModel { State = "East Java", Continent = "Asia", Country = "Indonesia", Population = 37476011 },
                    new SunburstModel { State = "Banten", Continent = "Asia", Country = "Indonesia", Population = 10644030 },
                    new SunburstModel { State = "Jakarta", Continent = "Asia", Country = "Indonesia", Population = 10187595 },
                    new SunburstModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 24000200 },
                    new SunburstModel { State = "Tianjin", Continent = "Africa", Country = "Ethiopia", Population = 15042531 },
                    new SunburstModel { State = "Rift Valley", Continent = "Africa", Country = "Kenya", Population = 10006805 },
                    new SunburstModel { State = "Lagos", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                    new SunburstModel { State = "Kano", Continent = "Africa", Country = "Nigeria", Population = 10006805 },
                    new SunburstModel { State = "Gauteng", Continent = "Africa", Country = "South Africa", Population = 12728400 },
                    new SunburstModel { State = "KwaZulu-Natal", Continent = "Africa", Country = "South Africa", Population = 10456900 },
                    new SunburstModel { State = "Ile-de- France", Continent = "Europe", Country = "France", Population = 11694000 },
                    new SunburstModel { State = "North Rhine-Westphalia", Continent = "Europe", Country = "Germany", Population = 17872863 },
                    new SunburstModel { State = "Bavaria", Continent = "Europe", Country = "Germany", Population = 12510331 },
                    new SunburstModel { State = "NBaden-Wurttemberg", Continent = "Europe", Country = "Germany", Population = 10747479 },
                    new SunburstModel { State = "England", Continent = "Europe", Country = "United Kingdom", Population = 51446600 }
            };


            Data = new ObservableCollection<SunburstModel>();

            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Jan", Sales = 11 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Feb", Sales = 8 });
            Data.Add(new SunburstModel() { Quarter = "Q1", Month = "Mar", Sales = 5 });

            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Apr", Sales = 13 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "May", Sales = 12 });
            Data.Add(new SunburstModel() { Quarter = "Q2", Month = "Jun", Sales = 17 });

            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Jul", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Aug", Sales = 4 });
            Data.Add(new SunburstModel() { Quarter = "Q3", Month = "Sep", Sales = 5 });

            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Oct", Sales = 7 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Nov", Sales = 18 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W1", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W2", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W3", Sales = 5 });
            Data.Add(new SunburstModel() { Quarter = "Q4", Month = "Dec", Week = "W4", Sales = 5 });
            
        }
        public ObservableCollection<SunburstModel> DataSource { get; set; }

        public ObservableCollection<SunburstModel> Data { get; set; }

        public ObservableCollection<SunburstModel> Population_Data { get; set; }  

    }
}
