#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using SampleBrowser.Core;
using Syncfusion.DocIO.DLS;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace SampleBrowser.DocIO
{
    public partial class BookmarkNavigation : SampleView
    {
        public BookmarkNavigation()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
               
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                //if (!SampleBrowser.DocIO.App.isUWP)
                //{
                  //  this.Content_1.FontSize = 18.5;
                //}
                //else
                //{
                    this.Content_1.FontSize = 13.5;
                //}
                
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Assembly assembly = typeof(BookmarkNavigation).GetTypeInfo().Assembly;
            // Creating a new document.
            WordDocument document = new WordDocument();
            //Adds section with one empty paragraph to the Word document
            document.EnsureMinimal();
            //sets the page margins
            document.LastSection.PageSetup.Margins.All = 72f;
            //Appends bookmark to the paragraph
            document.LastParagraph.AppendBookmarkStart("NorthwindDatabase");
            document.LastParagraph.AppendText("Northwind database with relational data");
            document.LastParagraph.AppendBookmarkEnd("NorthwindDatabase");
            // Open an existing template document with single section.
            WordDocument nwdInformation = new WordDocument();
#if COMMONSB
            string rootPath = "SampleBrowser.Samples.DocIO.Samples.Templates.";
#else
            string rootPath = "SampleBrowser.DocIO.Samples.Templates.";
#endif
            Stream inputStream = assembly.GetManifestResourceStream(rootPath + "Bookmark_Template.doc");
            // Open an existing template document.
            nwdInformation.Open(inputStream, FormatType.Doc);
            inputStream.Dispose();
            // Open an existing template document with multiple section.
            WordDocument templateDocument = new WordDocument();
            inputStream = assembly.GetManifestResourceStream(rootPath + "BkmkDocumentPart_Template.doc");
            // Open an existing template document.
            templateDocument.Open(inputStream, FormatType.Doc);
            inputStream.Dispose();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the template document.
            BookmarksNavigator bk = new BookmarksNavigator(templateDocument);
            // Move to the NorthWind bookmark in template document
            bk.MoveToBookmark("NorthWind");
            //Gets the bookmark content as WordDocumentPart
            WordDocumentPart documentPart = bk.GetContent();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the Northwind information document.
            bk = new BookmarksNavigator(nwdInformation);
            // Move to the information bookmark 
            bk.MoveToBookmark("Information");
            // Get the content of information bookmark.
            TextBodyPart bodyPart = bk.GetBookmarkContent();
            // Creating a bookmark navigator. Which help us to navigate through the 
            // bookmarks in the destination document.
            bk = new BookmarksNavigator(document);
            // Move to the NorthWind database in the destination document
            bk.MoveToBookmark("NorthwindDatabase");
            //Replace the bookmark content using word document parts
            bk.ReplaceContent(documentPart);
            // Move to the Northwind_Information in the destination document
            bk.MoveToBookmark("Northwind_Information");
            // Replacing content of Northwind_Information bookmark.
            bk.ReplaceBookmarkContent(bodyPart);
            // Move to the text bookmark
            bk.MoveToBookmark("Text");
            //Deletes the bookmark content
            bk.DeleteBookmarkContent(true);
            // Inserting text inside the bookmark. This will preserve the source formatting
            bk.InsertText("Northwind Database contains the following table:");
#region tableinsertion
            WTable tbl = new WTable(document);
            tbl.TableFormat.Borders.BorderType = BorderStyle.None;
            tbl.TableFormat.IsAutoResized = true;
            tbl.ResetCells(8, 2);
            IWParagraph paragraph;
            tbl.Rows[0].IsHeader = true;
            paragraph = tbl[0, 0].AddParagraph();
            paragraph.AppendText("Suppliers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[0, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[1, 0].AddParagraph();
            paragraph.AppendText("Customers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[1, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[2, 0].AddParagraph();
            paragraph.AppendText("Employees");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[2, 1].AddParagraph();
            paragraph.AppendText("3");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[3, 0].AddParagraph();
            paragraph.AppendText("Products");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[3, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[4, 0].AddParagraph();
            paragraph.AppendText("Inventory");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[4, 1].AddParagraph();
            paragraph.AppendText("2");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[5, 0].AddParagraph();
            paragraph.AppendText("Shippers");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[5, 1].AddParagraph();
            paragraph.AppendText("1");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[6, 0].AddParagraph();
            paragraph.AppendText("PO Transactions");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[6, 1].AddParagraph();
            paragraph.AppendText("3");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[7, 0].AddParagraph();
            paragraph.AppendText("Sales Transactions");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;

            paragraph = tbl[7, 1].AddParagraph();
            paragraph.AppendText("7");
            paragraph.BreakCharacterFormat.FontName = "Calibri";
            paragraph.BreakCharacterFormat.FontSize = 10;


            bk.InsertTable(tbl);
#endregion
            bk.MoveToBookmark("Image");
            bk.DeleteBookmarkContent(true);
            // Inserting image to the bookmark.
            IWPicture pic = bk.InsertParagraphItem(ParagraphItemType.Picture) as WPicture;
            inputStream = assembly.GetManifestResourceStream(rootPath + "Northwind.png");
            pic.LoadImage(inputStream);
            inputStream.Dispose();
            pic.WidthScale = 50f;  // It reduce the image size because it don't fit 
            pic.HeightScale = 75f; // in document page.


#region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("BookMarkNavigation.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("BookMarkNavigation.docx", "application/msword", stream);
#endregion
        }
    }
}
