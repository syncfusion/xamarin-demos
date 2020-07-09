#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "BlogsInfoRepository.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPullToRefresh
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using Xamarin.Forms;

    /// <summary>
    /// A class used to assign collection values for a Model properties
    /// </summary>
    public class BlogsInfoRepository
    {
        #region BlogsInfo

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal string[] BlogsTitle =
        {
            "Syncfusion is Attending dotnet Cologne and Magdeburger Dev Days Conferences",
            "Syncfusion Celebrates World Book Day", "What do e-books mean for developers?",
            "Q&A from “File-Format Manipulation in Xamarin.Forms” Webinar",
            "Syncfusion Sponsoring Global Azure Bootcamp Chennai",
            "Intel Forms Dedicated AI Group", "Upcoming Webinar: File-Format Manipulation in Xamarin.Forms, April 18",
            "Processing More Data in Less Time", "Syncfusion Sponsoring Xamarin Dev Days in Irving, Texas",
            "Syncfusion Presents at C# Corner Annual Conference", "Syncfusion Attending NG-CONF",
            "Visual Studio 2017 + Xamarin + Syncfusion Webinar Q&A", "Guest Blog: Moving from Emacs to Visual Studio",
            "Webinar on How Syncfusion Extends VS-Xamarin Integration", "Microsoft Forges Ahead with AI Advancements",
            "Syncfusion Celebrates Sim-Shipping Essential Studio with Visual Studio 2017",
            "Visual Studio: A Future and a Past",
            "Syncfusion to host Xamarin Dev Days Raleigh - June 10th 2017", "Syncfusion Xamarin Charts Webinar Q&A",
            "Guest Blog: Forms with Elm and Essential Studio"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.internal field does not need documentation")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal string[] BlogsCategory =
        {
            "Syncfusion", "Syncfusion", "E-book, Succinctly Series",
            "webinar, Xamarin", "Azure, Code Camp", "Deep Learning", "C#, DocIO, Mobile", "BI, Big Data",
            "Code Camp, Xamarin", "C#", "JavaScript, Web", "Essential Studio, Mobile", "Succinctly Series",
            "Mobile, Xamarin", "E-book, Microsoft", "Syncfusion", "Succinctly Series", "Code Camp, Xamarin",
            "Xamarin", "Syncfusion"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.internal field does not need documentation")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal string[] BlogsAuthers =
        {
            "Jacqueline Bieringer", "loric@syncfusion.com", "Graham High",
            "Darren West", "Marissa Keller Outten", "Darren West", "Graham High", "Tres Watkins",
            "Marissa Keller Outten",
            "Jacqueline Bieringer", "Graham High", "Tres Watkins", "Syncfusion Guest Blogger", "Tres Watkins",
            "Darren West",
            "Jacqueline Bieringer", "Tres Watkins", "Marissa Keller Outten", "Jacqueline Bieringer",
            "Syncfusion Guest Blogger"
        };

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.internal field does not need documentation")]
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Some fields must be public")]
        internal string[] BlogsReadMoreInfo =
        {
            "Syncfusion is always pleased to have the opportunity to talk to you in person." +
            " This month, we’re looking forward to seeing those of you who are attending either the dotnet Cologne conference," +
            " May 4–5, or the Magdeburger Developer Days Conference, May 10–11, in Germany. \n\nWe’re proud to be a silver" +
            " sponsor of the dotnet Cologne conference and a gold sponsor of the Magdeburger Developer Days Conference." +
            " We will have a booth at both with three of our developers and our director of sales ready to answer any questions" +
            " and give away prizes. If you’re planning to attend either conference, be sure to stop by and say hello to George, " +
            "Jayakrishnan, Soundara, and Christian!",
            "Sunday, April 23, was World Book Day, a celebration of reading and publishing designated by UNESCO." +
            " Syncfusion is proud to be contributing to the knowledge of the world with our Succinctly series, helping developers " +
            "get a quick start on new technologies for free. We’ve published 113 e-books, and counting!\n\nNot all of us are developers," +
            " though, and often our tastes in books span many genres, so we asked our employees, " +
            "“What are your favorite books and authors?” And they responded!\n\nOur favorite genre was science fiction," +
            " closely followed by fantasy, sometimes loved by the same person.",
            "April 23 is World Book Day, an international celebration of books and authors established by " +
            "UNESCO to recognize the immeasurable contributions to civilization that books have made, and to encourage " +
            "readership around the world, especially in youngsters.\n\nBooks play a critical role in what we do at Syncfusion, " +
            "and not just when we consult our in-office library of mostly technical references. " +
            "The Succinctly series of e-books we produce is one way we contribute to the growth and enrichment of the development " +
            "community at large. In about 100 pages, experienced developers can glean the information they " +
            "need to get started with an unfamiliar technology quickly.",
            "On April 18, Syncfusion hosted a webinar on file-format manipulation in Xamarin.Forms. " +
            "Product solutions specialist Aaron Melamed gave a thorough overview of the subject. In this blog post, " +
            "we’d like to address the questions we received from the audience.\n\nWhy parse a string to set a date value?\nIt was " +
            "done this way in this sample, but XlsIO just requires a DateTime object, so you can initialize it as desired." +
            "\n\nDo developers use OData RESTful services to populate content in layouts created using the file, creation, " +
            "layout, and handling capabilities you showed today?\nYes, this will work.",
            "Syncfusion is happy to support the Global Azure Bootcamp in Chennai this Saturday, April 22, 2017." +
            "\n\nThis one-day event will feature learning opportunities including sessions about Microsoft Azure, " +
            "talks with experts, and hands-on labs. Global Azure Bootcamps started in April 2013 in more than 134 locations " +
            "around the world.These events expanded to 183 in 2015 and continue to grow, with more than 250 events planned for this Saturday!\n\nSyncfusion will provide some free licenses for the raffle. Winners will receive a complimentary one-year license of Essential Studio Enterprise Edition. This includes more than 800 components for web, desktop, and mobile development, as well as the Big Data, Dashboard, Reporting, and Data Integration Platforms.",
            "We post news about AI advancements on a regular basis on this blog, but how can we resist when so many " +
            "companies are exploring the power of this field? The latest company to fully invest in the trend towards " +
            "AI-powered technology is Intel. In late March, they announced the formation of the Intel Artificial Intelligence" +
            " Products Group (AIPG), an organization that intends to consolidate the company’s AI efforts across all its " +
            "divisions.\n\nThis move towards unifying AI projects isn’t simply a pivot towards the future; Intel has invested " +
            "heavily in AI development. Over the past two years, Intel has acquired an AI-processor startup, a computer-vision " +
            "developer, a driverless car developer, and an FPGA manufacturer. Each of these acquisitions either gives Intel an" +
            " entry point to specific AI development targets or provides a technology to support AI development.",
            "On Tuesday, April 18, join product solutions specialist Aaron Melamed as he explores the extensive capabilities of " +
            "Syncfusion’s file-format manipulation libraries for Xamarin.Forms.\n\nSyncfusion has long been a leader of building" +
            " powerful, dependency-free file-format libraries for working with Excel, Word, and PDF documents, and now, even " +
            "PowerPoint presentations. These libraries are used across a spectrum of business scenarios, but are most often " +
            "used to create richly formatted reports. Combining these libraries with cross-platform mobile development enabled " +
            "by Xamarin.Forms can greatly simplify your document needs within your mobile apps, whether it involves file " +
            "conversion, filling templates, importing data, or generating documents from scratch.",
            "Want to see how fast we can summarize a billion rows of data? Don’t blink. It takes just six seconds.\n\nRemember " +
            "the good ol’ days, before Apache Spark 2.0, when life was simpler and processing 173 GB of data took a whole 30" +
            " seconds? You actually had time to sip your coffee before the bar charts rendered.\n\nThose days are gone. In this" +
            " post-Spark 2.0 world, using the combined force of the Syncfusion Big Data Platform and the Dashboard Platform, " +
            "you can process and visualize that same amount of data within six seconds. Advances in Apache Spark have increased" +
            " Syncfusion’s data processing speed by a factor of five to ten times, generally speaking.",
            "Syncfusion is sponsoring the Xamarin Dev Days event in Irving, Texas on April 15th. We are delighted to be able to " +
            "support this regional community of Xamarin developers. Each attendee will get a free license to " +
            "Syncfusion Essential Studio for Xamarin, some swag, and some great learning!\n\nOther ways we support the " +
            "developer community at large is through free webinars like “What’s New in Xamarin Forms” and " +
            "“Fall Madly in Love with 10 Xamarin Charts!”\n\nIf you are in the Irving, Texas area and would like to sign up, " +
            "go to https://ti.to/xamarin/dev-days-irving-2017/en and click Register. ",
            "This weekend in Delhi, India, Syncfusion is proud to be one of the platinum sponsors of the C# Corner " +
            "Annual Conference 2017 at the Leela Ambience Convention Hotel. At the long sold-out conference, " +
            "attendees will benefit from over 30 speakers on over 35 technologies. Along with thousands of others," +
            " several of our developers will be attending to learn from other experts and share their own expertise." +
            "\n\nFor anyone in attendance interested in mobile development, Syncfusion’s own Harikrishna Natarajan will " +
            "be giving a presentation entitled Creating Real World User Interfaces with Xamarin.Forms that we hope you will " +
            "find very informative.",
            "In just one week, ng-conf, the world’s original Angular conference, will be held in Salt Lake City. The event " +
            "boasts a stacked lineup of sessions and workshops showcasing the great tooling that Angular provides. " +
            "Syncfusion is proud to be a silver sponsor for the event, and our very own Alicia Morris and Lori Crist" +
            " will be attending. If you’re going, drop by the Syncfusion booth and say hi!\n\nRemember, Syncfusion has more " +
            "than 80 UI components for Angular app development, and recently published a free new e-book on Angular, Angular 2 " +
            "Succinctly. Keep an eye on our Facebook and Twitter feeds next week to see what’s happening at ng-conf," +
            " and let us know if you’ll be there!",
            "On March 21, 2017, Aaron Melamed, product solutions specialist for Syncfusion, presented the webinar Visual Studio " +
            "+ Xamarin + Syncfusion­—a primer on how to use Xamarin and Visual Studio in conjunction with Syncfusion components" +
            ".\n\nDid you miss the webinar? Watch the recording here and download the sample Aaron used.\n\nThe following " +
            "section contains all the questions asked by attendees during the webinar with answers provided by Aaron " +
            "and additional Syncfusion staff. ",
            "In college, I did everything in UNIX. On UNIX, everything was centered around programming. Of course, " +
            "you probably had to be a programmer to get anything done or at least appreciate it.  The big debate of the day" +
            " was the merits of vi vs emacs. After much deliberation, I settled on emacs. Despite its power," +
            " vi was just a bit too cryptic for me. Emacs was very powerful, still quite cryptic, but had nearly " +
            "endless options for customization.\n\nYou could start up emacs and stay there all day. It didn’t matter" +
            " whether you wanted to run a command shell, query a database, read email, or even browse the web," +
            " there was no reason to leave emacs. Regardless of the type of file you were editing, " +
            "there was a custom mode available to help with editing that file. Whether it was the password file," +
            " Fortran, lisp, C, C++, HTML, SQL, Eiffel, or something else, " +
            "there was a language-specific editor mode ready to help with syntax highlighting, indention support, " +
            "matching parenthesis, and more",
            "Xamarin is to development what the Rosetta Stone was to Egyptologists—a bridge to unknown languages, " +
            "or at least to the languages of Objective-C and Swift, which may not be known to C# developers. " +
            "Now, with the integration of Xamarin and Visual Studio, " +
            ".NET developers can use C# to build native apps for Android and iOS." +
            "\n\nSyncfusion adds a lot of power to the Microsoft-Xamarin mix by offering Essential Studio for Xamarin. " +
            "Tomorrow’s webinar, Visual Studio 2017 + Xamarin + Syncfusion, presented by Aaron Melamed at 11:00 a.m. EDT, " +
            "will demonstrate how you can use Syncfusion’s suite of Xamarin controls to quickly build native apps " +
            "that run on Windows, Android, and iOS.",
            "In December of 2016, Microsoft unveiled its new chatbot, Zo." +
            " Intended as the next step in Microsoft’s ongoing efforts to develop more capable AI, " +
            "Zo has been rolled out on more platforms and been made available to more users." +
            "\n\nChatbots are social AIs designed to interact with human users via text chatting or direct, " +
            "spoken communication. There are a variety of uses for chatbots, from allowing for a more natural " +
            "user interface to simply being a form of entertainment. The chief concern is that software programmed " +
            "to communicate with a human must acquire language and deploy it correctly, a challenge of titanic proportions. ",
            "As you’ve probably noticed, Visual Studio 2017 was released on Tuesday. Excitement has been mounting " +
            "since the release candidate came out in November, and the final version is finally here. " +
            "We at Syncfusion have been jumping up and down—usually figuratively, " +
            "but sometimes literally—with anticipation because we’ve been wanting to share that " +
            "we’re SIM-SHIPPING Essential Studio 2017 Volume 1 with Visual Studio 2017!\n\nOh yes, " +
            "that’s 800+ Essential Studio components and frameworks fully compatible with VS2017, " +
            "all for your seamless developing convenience. You are very welcome.\n\nWe were so excited " +
            "about sim-shipping we had to throw an early party for Visual Studio 2017 and keep it secret until now. " +
            "After all, it’s not every year you turn 20 and become a brand new version of yourself. We strongly felt " +
            "this deserved cake.",
            "With the Visual Studio 2017 launch underway, " +
            "developers around the globe are focusing on how the new features in Microsoft’s updated IDE will improve their dev-ops." +
            " Because of Visual Studio’s impetus to constantly move development forward, " +
            "much of the conversation surrounding these launches has to do with what’s coming, not what has been." +
            "\n\nBut with this release, Visual Studio celebrates its twentieth birthday. To reflect on this notable milestone, " +
            "Syncfusion asked a variety of developers when they started working with Visual Studio and what features meaningfully " +
            "changed how they develop.\n\nThe majority of people we surveyed said they started working with Visual Studio 6.0," +
            " which was released in 1998. The previous year, Microsoft released Visual Studio 97, " +
            "described in this Microsoft Systems Journal article:",
            "We will be hosting Xamarin Dev Days here at Syncfusion on Saturday, June 10th, 2017!  " +
            "Join us for a day of focused, hands-on learning. " +
            "Sign up here.\n\nThe morning of each event is spent exploring mobile development in expert-led sessions," +
            " while the afternoon is dedicated to coding. With Xamarin.Forms, " +
            "developers can build cross-platform, native UIs with one shared C# codebase.\n\nOur presenters will be Ed Snider," +
            " a Xamarin MVP, and Dan Rigby, Xamarin technical solutions professional at Microsoft. " +
            "We are glad to have both leading sessions again. " +
            "Our new colleague Aaron Melamed, product solution specialist at Syncfusion, will also participate at the event." +
            " We’re sure that Aaron will provide insight for attendees since, as he said, " +
            "“I have dipped my toes into the Xamarin world after writing a cross-platform app " +
            "that searches thousands of curated recipes via an API.”",
            "Syncfusion would like to thank all attendees of last week’s webinar, " +
            "“Fall Madly in Love with These 10 Xamarin Charts!” " +
            "for participating as Syncfusion Product Manager Chad Church showed off some of our coolest charts. " +
            "Here’s the webinar if you missed it.\n\nAs promised, " +
            "here is a summary of the Q&A portion from the end of the webinar, " +
            "plus answers to questions we couldn’t get to then:\n\nDoes the chart work inside a ScrollView?\nYes." +
            "\n\nWhat about MVVM support? I use Prism and a kind of pure MVVM model." +
            " Is it easy to integrate the charts in that model?\nYes. There’s complete MVVM support. " +
            "Prism and other packages should all work well.",
            "(This guest blog was written by Wolfgang Loder, " +
            "February 2017.)\n\nWhenever web developers are asked about a language or framework they want to try, " +
            "most likely the language Elm will be mentioned.\n\nThis is not an Elm primer, " +
            "so I assume you have a little experience with the Elm basics. " +
            "If not, the following paragraphs will give you an idea what can be achieved with the Elm platform." +
            "\n\nAs much as Elm libraries try to cover everything needed for web applications development, " +
            "there are gaps and inadequate solutions. " +
            "This is why pure Elm applications may be good for demos and simple applications, " +
            "but are not always feasible for production code. We will often have to enhance Elm code with JavaScript libraries."
        };

        #endregion

        #region ItemsSource

        /// <summary>
        /// Used to add Record rows in View
        /// </summary>
        /// <returns>generate items</returns>
        internal ObservableCollection<ListViewBlogsInfo> GenerateSource()
        {
            ObservableCollection<ListViewBlogsInfo> blogsInfo = new ObservableCollection<ListViewBlogsInfo>();
            Assembly assembly = this.GetType().Assembly;
            int blogsTitleCount = this.BlogsTitle.Count() - 1;
            int blogsCategoryCount = this.BlogsCategory.Count() - 1;
            int blogsAuthorCount = this.BlogsAuthers.Count() - 1;
            int blogsReadMoreCount = this.BlogsReadMoreInfo.Count() - 1;

            for (int i = 0; i < 5; i++)
            {
                ListViewBlogsInfo blog = new ListViewBlogsInfo
                {
                    BlogTitle = this.BlogsTitle[blogsTitleCount - i],
                    BlogCategory = this.BlogsCategory[blogsCategoryCount - i],
                    BlogAuthor = this.BlogsAuthers[blogsAuthorCount - i],

                    BlogAuthorIcon = new FontImageSource
                        {
                            Glyph = "\ue72a",
                            FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                        Color = Color.FromRgb(51, 173, 225),
                    },
                    BlogCategoryIcon = new FontImageSource
                    {
                        Glyph = "\ue738",
                        FontFamily = Device.RuntimePlatform == Device.iOS ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                        Color = Color.FromRgb(51, 173, 225),
                    },
                    BlogFacebookIcon = "FacebookLine.png",
                    BlogTwitterIcon = "TwitterLine.png",
                    BlogGooglePlusIcon = "GooglePlusLine.png",
                    BlogLinkedInIcon = "LinkedInLine.png",
                    ReadMoreContent = this.BlogsReadMoreInfo[blogsReadMoreCount - i]
                };
                blogsInfo.Insert(0, blog);
            }

            return blogsInfo;
        }

        #endregion
    }
}