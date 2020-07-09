#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "EmployeeDetails.cs" company="Syncfusion.com">
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
    using System.Diagnostics.CodeAnalysis;
    using Xamarin.Forms.Internals;

    [Preserve(AllMembers = true)]

    /// <summary>
    /// A class used to store the item values 
    /// </summary>
    public class EmployeeDetails
    {
        #region DataSource

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] employeeID = new int[] 
        {
            1803,
            1345,
            4523,
            4932,
            9475,
            5243,
            4263,
            2435,
            3527,
            3634,
            2523,
            3652,
            3524,
            6532,
            2123
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] salary = new int[] 
        {
            256787,
            34455,
            445545,
            234567,
            78434555,
            93455,
            3456674,
            34567457,
            23424,
            655676,
            2252459,
            34368,
            125436,
            90558,
            648489,
            5537383
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] company = new string[] 
        {
            "ABC",
            "XYZ",
            "XXX",
            "YYY",
            "ZZZ",
            "ZXY",
            "KKK",
            "BCD",
            "XZY",
            "FDG",
            "BCA",
            "UTS",
            "KFI",
            "XXX",
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] title = new string[] 
        {
            "Manager ",
            "Recruiter",
            "Security",
            "Supervisor",
            "Admin",
            "Admin",
            "Assistant",
            "President",
            "Designer",
            "Manager",
            "Marketing",
            "Stocker",
            "Clerk"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string[] customers = new string[] 
        {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int[] age = new int[] 
        {
            21,
            34,
            45,
            21,
            23,
            25,
            43,
            32,
            22,
            44,
            25,
            47,
            35,
            37,
            41
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private double[] bonus = new double[] 
        {
            0.2,
            0.3,
            0.4,
            0.1,
            0.12,
            0.13,
            0.15,
            0.18,
            0.14,
            0.6,
            0.7
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private List<string> employeeDates;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Random random = new Random();

        #endregion

        /// <summary>
        /// Initializes a new instance of the EmployeeDetails class.
        /// </summary>
        public EmployeeDetails()
        {
        }

        #region GetEmployeeDetails

        /// <summary>
        /// Generates record rows with given count
        /// </summary>
        /// <param name="count">generates row count</param>
        /// <returns>added employee details</returns>
        public List<EmployeeInfo> GetEmployeeDetails(int count)
        {
            this.employeeDates = this.GetDateBetween(2000, 2014, count);
            List<EmployeeInfo> employeeDetails = new List<EmployeeInfo>();

            for (int i = 1; i <= count; i++)
            {
                var ord = new EmployeeInfo()
                {
                    EmployeeID = this.employeeID[this.random.Next(15)],
                    Name = this.customers[this.random.Next(15)],
                    Age = this.age[this.random.Next(10)],
                    Company = this.company[this.random.Next(10)],
                    Title = this.title[this.random.Next(10)],
                    Salary = this.salary[this.random.Next(13)],
                    Bonus = this.bonus[this.random.Next(7)],
                    IsAvailable = (i % this.random.Next(1, 10) > 5) ? true : false,
                    DOJ = this.employeeDates[i - 1],
                    ImageName = this.GetImageName(this.random.Next(0, 2)),
                };
                employeeDetails.Add(ord);
            }

            return employeeDetails;
        }

        #endregion

        /// <summary>
        /// Used to get Image name whether girl or boy depends on the Index 
        /// </summary>
        /// <param name="index">integer type parameter index</param>
        /// <returns>returns the image</returns>
        private string GetImageName(int index)
        {
            if (index == 0)
            {
                return "GIRL" + this.random.Next(1, 24) + ".png";
            }
            else
            {
                return "GUY" + this.random.Next(1, 24) + ".png";
            }
        }

        /// <summary>
        /// Used to generate DateTime and returns the value
        /// </summary>
        /// <param name="startYear">integer type of parameter startYear</param>
        /// <param name="endYear">integer type of parameter endYear</param>
        /// <param name="count">integer type of parameter count</param>
        /// <returns>returns the generated DateTime</returns>
        private List<string> GetDateBetween(int startYear, int endYear, int count)
        {
            List<string> date = new List<string>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add((new DateTime(year, month, day)).ToString());
            }

            return date;
        }     
    }
}