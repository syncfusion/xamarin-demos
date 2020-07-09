#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UIKit;

namespace SampleBrowser
{
    public class InboxRepositiory
    {
        private Random random;

        public ObservableCollection<Mail> InboxItems
        {
            get;
            set;
        }

        public InboxRepositiory()
        {
            random = new Random();
            InboxItems = new ObservableCollection<Mail>();
            GenerateItems(50);
        }

        private void GenerateItems(int count)
        {
            for(int i =0; i< count;i++)
            {
                int randomNumber = random.Next(0, 9);
                Mail mail = new Mail();
                mail.Sender = sender[random.Next(0,24)];
                mail.Subject = subject[randomNumber];
                mail.Details = details[randomNumber];
                mail.BackgroundColor = colors[randomNumber];
                InboxItems.Add(mail);
            }
        }

        public void RefreshItemSource()
        {
            int count = random.Next(1, 6);

            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(0, 9);
                Mail mail = new Mail();
                mail.Sender = sender[random.Next(0, 24)];
                mail.Subject = subject[randomNumber];
                mail.Details = details[randomNumber];
                mail.BackgroundColor = colors[randomNumber];
                InboxItems.Insert(i, mail);
            }
        }

        string[] sender = new string[] {
            "Adams",
            "Crowley",
            "Ellis",
            "Gable",
            "Irvine",
            "Keefe",
            "Mendoza",
            "Owens",
            "Rooney",
            "Fitzgerald",
            "Holmes",
            "Jefferson",
            "Landry",
            "Perez",
            "Spencer",
            "Vargas",
            "Grimes",
            "Edwards",
            "Stark",
            "Cruise",
            "Fitz",
            "Chief",
            "Blanc",
            "Perry",
            "Stone",
            "Williams"
        };

        string[] subject = new string[]{
            "Transaction alert on your card",
            "Job openings",
            "New Release",
            "Festive Offers",
            "Distance Education",
            "Internship offer",
            "Delivery Status Notification",
            "Online Exam Intimation",
            "Account Statement",
            "Successfully Registered"
        };
        string[] details = new string[]{
            "Dear Customer, Thank you for using your card at Shopping Bazaar on 8th November 2017. Your card balance is $9999.",
            "Excellent jobs for freshers. Candidates who can join immediately needed. The qualification required, interview timings and the venue details are provided in the attachment.",
            "We are happy to inform you that Syncfusion has successfully rolled out the 2017 Volume 4 release. Customers can update to the new version and make use of the new features.",
            "Hurry up..! Mega offers for festival. Special offers are available for you. Discount of 10% to 35% is available based on the products. Many new arrivals. ",
            "You are receiving this mail as you have registered in our website. This is to notify you the opportunities that are available for you to study your preferable course in your favorite institutions. Please find the details of the courses and the institutions in the attachment.",
            "Internship for students available. Interested students, click the below link and register in it. Please find the qualification and other details of the internship in the attachment.",
            "Dear Customer, This is to inform you that, the product you ordered is shipped and it will be delivered to you in the given address on 12th December 2017. Expecting your patience until then.",
            "Dear Student, Your exam dates are finalized. The time table of the exams are published in our site. Get more details of it from the attachment. The venue details will be confirmed and informed in the next intimation.",
            "Dear Customer, your account statement summary for the month January - February is updated. Please find the details of your account statement in the attachment.",
            "You have successfully registered in our website. You will get notifications emails for all our updates. To keep your account active, login to your account regularly."
        };

        private UIColor[] colors = new UIColor[]
        {
            UIColor.FromRGB(0,191,255),
            UIColor.FromRGB(255, 0, 191),
            UIColor.FromRGB(255, 26, 26),
            UIColor.FromRGB(255, 165, 0),
            UIColor.FromRGB(135, 206, 250),
            UIColor.FromRGB(241, 137, 48),
            UIColor.FromRGB(132, 92, 214),
            UIColor.FromRGB(247, 61, 40),
            UIColor.FromRGB(0, 154, 0),
            UIColor.FromRGB(255, 165, 0),
        };

    }
}