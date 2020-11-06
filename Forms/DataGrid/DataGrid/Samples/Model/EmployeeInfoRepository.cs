#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EmployeeInfoRepository.cs" company="Syncfusion.com">
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
    using System.Linq;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class EmployeeInfoRepository
    {
        #region DataSource

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] title = new string[]
        {
            "Marketing Assistant",
            "Engineering Manager",
            "Senior Tool Designer",
            "Tool Designer",
            "Marketing Manager",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Design Engineer",
            "Production Technician - WC10",
            "Design Engineer",
            "Vice President of Engineering",
            "Production Technician - WC10",
            "Production Supervisor - WC50",
            "Production Technician - WC10",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Production Supervisor - WC60",
            "Production Technician - WC10",
            "Production Technician - WC30",
            "Production Control Manager",
            "Production Technician - WC45",
            "Production Technician - WC45",
            "Production Technician - WC30",
            "Production Supervisor - WC10",
            "Production Technician - WC20",
            "Production Technician - WC40",
            "Network Administrator",
            "Production Technician - WC50",
            "Human Resources Manager",
            "Production Technician - WC40",
            "Production Technician - WC30",
            "Production Technician - WC30",
            "Stocker",
            "Shipping and Receiving Clerk",
            "Production Technician - WC50",
            "Production Technician - WC60",
            "Production Supervisor - WC50",
            "Production Technician - WC20",
            "Production Technician - WC45",
            "Quality Assurance Supervisor",
            "Information Services Manager",
            "Production Technician - WC50",
            "Master Scheduler",
            "Production Technician - WC40",
            "Marketing Specialist",
            "Recruiter",
            "Production Technician - WC50",
            "Maintenance Supervisor",
            "Production Technician - WC30",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] employeeName = new string[] 
        {
            "Sean Jacobson",
            "Phyllis Allen",
            "Marvin Allen",
            "Michael Allen",
            "Cecil Allison",
            "Oscar Alpuerto",
            "Sandra Alvaro",
            "Selena Alvarad",
            "Emilio Alvaro",
            "Maxwell Amland",
            "Mae Anderson",
            "Ramona Antrim",
            "Sabria Arthur",
            "Hannah Arakawa",
            "Kyley Arbelaez",
            "Tom Johnston",
            "Thomas Armstrong",
            "John Arthur",
            "Chris Ashton",
            "Teresa Atkinson",
            "John Ault",
            "Robert Avalos",
            "Stephen Ayers",
            "Phillip Bacalzo",
            "Gustavo Achong",
            "Catherine Abel",
            "Kim Abercrombie",
            "Humberto Acevedo",
            "Pilar Ackerman",
            "Frances Adams",
            "Margar Smith",
            "Carla Adams",
            "Jay Adams",
            "Ronald Adina",
            "Samuel Agcaoili",
            "James Aguilar",
            "Robert Ahlering",
            "Francois Ault",
            "Kim Akers",
            "Lili Alameda",
            "Amy Alberts",
            "Anna Albright",
            "Milton Albury",
            "Paul Alcorn",
            "Gregory Alderson",
            "Phillip Alexander",
            "Michelle Adams",
            "Daniel Blanco",
            "Cory Booth",
            "James Bailey"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random r = new Random();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string> loginID = new Dictionary<string, string>();
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Dictionary<string, string> gender = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// Initializes a new instance of the EmployeeInfoRepository class.
        /// </summary>
        public EmployeeInfoRepository()
        {
            this.PopulateData();
        }

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>added employee details</returns>
        public ObservableCollection<Employee> GetEmployeesDetails(int count)
        {
            var employees = new ObservableCollection<Employee>();
            for (var i = 1; i < count; i++)
            {
                employees.Add(this.GetEmployee(i));
            }

            return employees;
        }

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="i">generates row count</param>
        /// <returns>employee details</returns>
        public Employee GetEmployee(int i)
        {
            var name = this.employeeName[this.r.Next(this.employeeName.Count() - 1)];
            return new Employee()
            {
                EmployeeID = 1000 + i,
                Name = name,
                ContactID = this.r.Next(1001, 2000),
                Gender = this.gender[name],
                Title = this.title[this.r.Next(this.title.Count() - 1)],
                BirthDate = new DateTime(this.r.Next(1975, 1985), this.r.Next(1, 12), this.r.Next(1, 28)),
                SickLeaveHours = this.r.Next(15, 70),
                Salary = new decimal(Math.Round(this.r.NextDouble() * 6000.5, 2))
            };
        }

        /// <summary>
        /// Used to add items in gender collection
        /// </summary>
        private void PopulateData()
        {
            this.gender.Add("Sean Jacobson", "Male");
            this.gender.Add("Phyllis Allen", "Male");
            this.gender.Add("Marvin Allen", "Male");
            this.gender.Add("Michael Allen", "Male");
            this.gender.Add("Cecil Allison", "Male");
            this.gender.Add("Oscar Alpuerto", "Male");
            this.gender.Add("Sandra Alvaro", "Female");
            this.gender.Add("Selena Alvarad", "Female");
            this.gender.Add("Emilio Alvaro", "Female");
            this.gender.Add("Maxwell Amland", "Male");
            this.gender.Add("Mae Anderson", "Male");
            this.gender.Add("Ramona Antrim", "Female");
            this.gender.Add("Sabria Arthur", "Male");
            this.gender.Add("Hannah Arakawa", "Male");
            this.gender.Add("Kyley Arbelaez", "Male");
            this.gender.Add("Tom Johnston", "Female");
            this.gender.Add("Thomas Armstrong", "Female");
            this.gender.Add("John Arthur", "Male");
            this.gender.Add("Chris Ashton", "Female");
            this.gender.Add("Teresa Atkinson", "Male");
            this.gender.Add("John Ault", "Male");
            this.gender.Add("Robert Avalos", "Male");
            this.gender.Add("Stephen Ayers", "Male");
            this.gender.Add("Phillip Bacalzo", "Male");
            this.gender.Add("Gustavo Achong", "Male");
            this.gender.Add("Catherine Abel", "Male");
            this.gender.Add("Kim Abercrombie", "Male");
            this.gender.Add("Humberto Acevedo", "Male");
            this.gender.Add("Pilar Ackerman", "Male");
            this.gender.Add("Frances Adams", "Female");
            this.gender.Add("Margar Smith", "Male");
            this.gender.Add("Carla Adams", "Male");
            this.gender.Add("Jay Adams", "Male");
            this.gender.Add("Ronald Adina", "Female");
            this.gender.Add("Samuel Agcaoili", "Male");
            this.gender.Add("James Aguilar", "Female");
            this.gender.Add("Robert Ahlering", "Male");
            this.gender.Add("Francois Ault", "Male");
            this.gender.Add("Kim Akers", "Male");
            this.gender.Add("Lili Alameda", "Female");
            this.gender.Add("Amy Alberts", "Male");
            this.gender.Add("Anna Albright", "Female");
            this.gender.Add("Milton Albury", "Male");
            this.gender.Add("Paul Alcorn", "Male");
            this.gender.Add("Gregory Alderson", "Male");
            this.gender.Add("Phillip Alexander", "Male");
            this.gender.Add("Michelle Adams", "Male");
            this.gender.Add("Daniel Blanco", "Male");
            this.gender.Add("Cory Booth", "Male");
            this.gender.Add("James Bailey", "Female");

            this.loginID.Add("Sean Jacobson", "sean2");
            this.loginID.Add("Phyllis Allen", "phyllis0");
            this.loginID.Add("Marvin Allen", "marvin0");
            this.loginID.Add("Michael Allen", "michael10");
            this.loginID.Add("Cecil Allison", "cecil0");
            this.loginID.Add("Oscar Alpuerto", "oscar0");
            this.loginID.Add("Sandra Alvaro", "sandra1");
            this.loginID.Add("Selena Alvarad", "selena0");
            this.loginID.Add("Emilio Alvaro", "emilio0");
            this.loginID.Add("Maxwell Amland", "maxwell0");
            this.loginID.Add("Mae Anderson", "mae0");
            this.loginID.Add("Ramona Antrim", "ramona0");
            this.loginID.Add("Sabria Arthur", "sabria0");
            this.loginID.Add("Hannah Arakawa", "hannah0");
            this.loginID.Add("Kyley Arbelaez", "kyley0");
            this.loginID.Add("Tom Johnston", "tom1");
            this.loginID.Add("Thomas Armstrong", "thomas1");
            this.loginID.Add("John Arthur", "john6");
            this.loginID.Add("Chris Ashton", "chris3");
            this.loginID.Add("Teresa Atkinson", "teresa0");
            this.loginID.Add("John Ault", "john7");
            this.loginID.Add("Robert Avalos", "robert2");
            this.loginID.Add("Stephen Ayers", "stephen1");
            this.loginID.Add("Phillip Bacalzo", "phillip0");
            this.loginID.Add("Gustavo Achong", "gustavo0");
            this.loginID.Add("Catherine Abel", "catherine0");
            this.loginID.Add("Kim Abercrombie", "kim2");
            this.loginID.Add("Humberto Acevedo", "humberto0");
            this.loginID.Add("Pilar Ackerman", "pilar1");
            this.loginID.Add("Frances Adams", "frances0");
            this.loginID.Add("Margar Smith", "margaret0");
            this.loginID.Add("Carla Adams", "carla0");
            this.loginID.Add("Jay Adams", "jay1");
            this.loginID.Add("Ronald Adina", "ronald0");
            this.loginID.Add("Samuel Agcaoili", "samuel0");
            this.loginID.Add("James Aguilar", "james2");
            this.loginID.Add("Robert Ahlering", "robert1");
            this.loginID.Add("Francois Ault", "françois1");
            this.loginID.Add("Kim Akers", "kim3");
            this.loginID.Add("Lili Alameda", "lili0");
            this.loginID.Add("Amy Alberts", "amy1");
            this.loginID.Add("Anna Albright", "anna0");
            this.loginID.Add("Milton Albury", "milton0");
            this.loginID.Add("Paul Alcorn", "paul2");
            this.loginID.Add("Gregory Alderson", "gregory0");
            this.loginID.Add("Phillip Alexander", "jphillip0");
            this.loginID.Add("Michelle Adams", "michelle0");
            this.loginID.Add("Daniel Blanco", "daniel0");
            this.loginID.Add("Cory Booth", "cory0");
            this.loginID.Add("James Bailey", "james3");
        }
    }
}
