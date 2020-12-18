#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CellTemplateModelRepository.cs" company="Syncfusion.com">
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
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    ///  A class Use for store the Item values 
    /// </summary>
    public class CellTemplateModelRepository
    {
        /// <summary>
        /// Initializes a new instance of the CellTemplateModelRepository class.
        /// </summary>
        public CellTemplateModelRepository()
        {
        }

        /// <summary>
        /// Used to generates the Items source.
        /// </summary>
        /// <returns>returns generates items</returns>
        public List<CellTemplateModel> GetEmployeeDetails()
        {
            List<CellTemplateModel> employeeDetails = new List<CellTemplateModel>();
            var assembly = Assembly.GetAssembly(this.GetType());
            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Nancy",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1948, 8, 12),
                About = "Education includes a BA in psychology from Colorado State University in 1970. Nancy is a member of Toastmasters International.",
                Country = "USA",
                EmployeeID = 4563,
                Telephone = "(206) 555 -9857",
                Image = "People_Circle1.png",
            });

            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Andrea",
                Designation = "Vice President",
                DateOfBirth = new DateTime(1952, 2, 19),
                About = "Andrea received her Ph.D. in international marketing in 1981. She joined the company as a sales representative in March 1993.",
                Country = "USA",
                EmployeeID = 4362,
                Telephone = "(206) 555 -9482",
                Image = "People_Circle2.png",
            });

            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Janet",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1963, 8, 30),
                Country = "USA",
                EmployeeID = 4134,
                About = "Janet has a BS degree in chemistry from Boston College (1984). Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.",
                Telephone = "(206) 555 -9356",
                Image = "People_Circle3.png",
            });
            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Margaret",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1937, 9, 19),
                Country = "USA",
                EmployeeID = 4834,
                About = "Margaret holds a BA in English literature from Concordia College (1958).  She was assigned to the London office temporarily 1992.",
                Telephone = "(206) 555 -4766",
                Image = "People_Circle16.png"
            });
            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Steven",
                Designation = "Sales Manager",
                DateOfBirth = new DateTime(1955, 4, 3),
                Country = "USA",
                EmployeeID = 4267,
                About = "Steven Buchanan graduated with a BSC degree in 1976. He spent 6 months in an orientation program at the Seattle office and then returned to London.",
                Telephone = "(206) 555 -4567",
                Image = "People_Circle8.png"
            });
            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Michale",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1963, 7, 2),
                Country = "USA",
                EmployeeID = 4553,
                About = "Michale is a graduate of Sussex University (MA, economics, 1983).  She has also taken the course Multi-Cultural Selling for the Sales Professional.",
                Telephone = "(206) 555 -7777",
                Image = "People_Circle12.png"
            });
            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Robert",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1960, 5, 27),
                Country = "USA",
                EmployeeID = 4423,
                About = "Robert King completing his degree in English at the University of Michigan in 1992.  After completing a course, he was transferred to the London office in March 1993.",
                Telephone = "(206) 555 -7856",
                Image = "People_Circle14.png"
            });

            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Laura",
                Designation = "Inside Sales Coordinator",
                DateOfBirth = new DateTime(1958, 9, 1),
                Country = "Seattle",
                EmployeeID = 4265,
                About = "Laura received a BA in psychology from the University of Washington.  She has also completed a course in business French.",
                Telephone = "(206) 555 -1189",
                Image = "People_Circle9.png"
            });

            employeeDetails.Add(new CellTemplateModel()
            {
                Name = "Anne",
                Designation = "Sales Representative",
                DateOfBirth = new DateTime(1966, 1, 27),
                Country = "USA",
                EmployeeID = 3563,
                About = "Anne has a BA degree in English from St. Lawrence College. She has also completed a course in business French.",
                Telephone = "(206) 555 -7856",
                Image = "People_Circle10.png"
            });

            return employeeDetails;
        }
    }
}
