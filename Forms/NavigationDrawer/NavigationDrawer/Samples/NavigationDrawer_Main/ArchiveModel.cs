#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleBrowser
{
	public class CollectionViewModel
	{
		public CollectionViewModel()
		{
		}
		private string name;
		private string date;
		private string subject;
		private string description;

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public string Date
		{
			get
			{
				return date;
			}

			set
			{
				date = value;
			}
		}

		public string Subject
		{
			get
			{
				return subject;
			}

			set
			{
				subject = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}

			set
			{
				description = value;
			}
		}
	}
	public class ArchiveViewModel
	{
		private string title = "Archive";

		ObservableCollection<CollectionViewModel> viewCollection;

		public ObservableCollection<CollectionViewModel> ViewCollection
		{
			get
			{
				return viewCollection;
			}

			set
			{
				viewCollection = value;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}

			set
			{
				title = value;
			}
		}

		public ArchiveViewModel()
		{
			viewCollection = new ObservableCollection<CollectionViewModel>();
			for (int i = 0; i < SubjectArray.Count(); i++)
			{
				viewCollection.Add(new CollectionViewModel { Name = NameArray[i], Date = MonthArray[i] + " " + (i + 7).ToString(), Subject = SubjectArray[i], Description = DescriptionsArray[i] });
			}
		}
		string[] NameArray = new string[]
		{
			"James Landon",
			"Daniel Caden",
			"Fiona Michael",
			"Ralph Jennifer",
			"Nicholas Ryan",
			"Liam Connor",
			"Benjamin Alexander",
			"Brenda Kyle",
			"Liz Torrey",
			"Riley Sean",
			"Xavier Bryce"
		};

		string[] MonthArray = new string[]
		{
			"Jan",
			"Jan",
			"Mar",
			"Apr",
			"May",
			"May",
			"May",
			"June",
			"July",
			"Sep",
			"Sep"
		};
		string[] SubjectArray = new string[] {
			"Happy birthday to an amazing employee!",
			"Like a vintage auto, your value increases...",

			"No one could do a better job than...",
			"GET WELL SOON!!",
			"A cheery Christmas hold lots of happiness for you!",
			"BOO!!! Happy Halloween! Happy Halloween!",
			"Happy Turkey Day!!",
			"Wishing you Happy St Pat's Day!",
			"Congratulations on the move!",
			"Never doubt yourself. You’re always...",
			"The warmest wishes to a great member of our team...",
		};

		string[] DescriptionsArray = new string[] {
			"Wishing you great achievements in this career, And I hope that you have a great day today!",
			"Happy birthday to one of the best and most loyal employees ever!",
			"No one could do a better job than the job you do. We thank you for sticking with us!",
			"Card messages aren't my thing. Get well soon!",
			"Wishing you a happy Christmas. May it be all that you hope it will be! All the best",
			"Wishing you a killer Halloween, Don't forget to give us treat or else..",
			"Happy Turkey Day!. Don't forget to give thanks for being so blessed.",
			"It's all green which means its all good! HAPPY ST PAT'S",
			"Congratulations! May you find great happiness at your new address.",
			"Never doubt yourself. You’re always the best! Just continue to be like that!",
			"Warmest wishes! May your special day be full of good emotions, fun and cheer!"
		};
	}
}
