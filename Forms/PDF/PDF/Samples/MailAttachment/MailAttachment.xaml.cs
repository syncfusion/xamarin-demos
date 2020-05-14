#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using SampleBrowser.Core;

namespace SampleBrowser.PDF
{
    public partial class MailAttachment : SampleView
    {
        public MailAttachment()
        {
            InitializeComponent();
            AddDetails();
            this.newsLetter.IsToggled = true;
            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {                
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnTemplate.HorizontalOptions = LayoutOptions.Start;               
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.BackgroundColor = Xamarin.Forms.Color.Gray;
                this.btnTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnTemplate.BackgroundColor = Xamarin.Forms.Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {               
                this.Description.FontSize = 13.5;                            
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }     
        public void OnButtonClicked(object sender, EventArgs e)
        {
#if COMMONSB
            Stream docStream = typeof(MailAttachment).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.FormFillingDocument.pdf");
#else
            Stream docStream = typeof(MailAttachment).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.FormFillingDocument.pdf");
#endif

            MemoryStream stream = new MemoryStream();

            //Load the existing PDF document
            using (PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream))
            {

                //Get the PDF form
                PdfLoadedForm lForm = ldoc.Form;

                if (name.Text != null)
                {
                    //Load the textbox field
                    PdfLoadedTextBoxField nameText = lForm.Fields["name"] as PdfLoadedTextBoxField;

                    //Fill the text box
                    nameText.Text = this.name.Text;
                }
               
                //Get the Radio button field
                PdfLoadedRadioButtonListField genderRadio = lForm.Fields["gender"] as PdfLoadedRadioButtonListField;
                
                switch(gender.Items[gender.SelectedIndex])
                {
                    case "Male":
                        genderRadio.SelectedIndex = 0;
                        break;
                    case "Female":
                        genderRadio.SelectedIndex = 2;
                        break;
                    case "Unspecified":
                        genderRadio.SelectedIndex = 1;
                        break;
                }            

                //Load the textbox field
                PdfLoadedTextBoxField dobText = lForm.Fields["dob"] as PdfLoadedTextBoxField;

                //Fill the text box
                dobText.Text = this.dob.Date.ToString("dd MMMM yyyy");

                if (this.emailID.Text != null)
                {
                    //Load the textbox field
                    PdfLoadedTextBoxField emailText = lForm.Fields["email"] as PdfLoadedTextBoxField;

                    //Fill the text box
                    emailText.Text = this.emailID.Text;
                }

                //Load the combobox field
                PdfLoadedComboBoxField countryCombo = lForm.Fields["state"] as PdfLoadedComboBoxField;

                //Set the selected value
                countryCombo.SelectedValue =this.country.Items[country.SelectedIndex];

                //Get the Checkbox field
                PdfLoadedCheckBoxField newsCheck = lForm.Fields["newsletter"] as PdfLoadedCheckBoxField;

                newsCheck.Checked = this.newsLetter.IsToggled;

                //Flatten the form fields
                ldoc.Form.Flatten = true;

                //Save the PDF document
                ldoc.Save(stream);
            }

            stream.Position = 0;

            //Open in default system viewer.
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<IMailService>().ComposeMail("MailAttachment.pdf", null, "Workshop Registration", "Syncfusion", stream);
            else
                Xamarin.Forms.DependencyService.Get<IMailService>().ComposeMail("MailAttachment.pdf", null, "Workshop Registration", "Syncfusion", stream);

        }
        public void OnTemplateButtonClicked(object sender, EventArgs e)
        {
			#if COMMONSB
            Stream docStream = typeof(MailAttachment).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Samples.Assets.FormFillingDocument.pdf");
			#else
			Stream docStream = typeof(MailAttachment).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.PDF.Samples.Assets.FormFillingDocument.pdf");	
			#endif

            MemoryStream stream = new MemoryStream();

            //Load the template document
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream))
            {
                //Save the document
                loadedDocument.Save(stream);
            }

            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("MailAttachmentTemplate.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("MailAttachmentTemplate.pdf", "application/pdf", stream);
        }
#region Helper method
        private void AddDetails()
        {
            this.gender.Items.Add("Male");
            this.gender.Items.Add("Female");
            this.gender.Items.Add("Unspecified");
            this.gender.SelectedIndex = 0;
            string[] countryList = new string[] { "Alabama","Alaska","Arizona","Arkansas","California","Colorado","Connecticut","Delaware","Florida","Georgia","Hawaii","Idaho","Illinois","Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts","Michigan","Minnesota","Mississippi","Missouri","Montana","Nebraska","Nevada","New Jersey","New Mexico","New York","North Carolina","North Dakota","Ohio","Oklahoma","Oregon","Pennsylvania","South Carolina","South Dakota","Tennessee","Texas","Utah","Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming" };
            for (int i = 0; i < countryList.Length; i++)
                country.Items.Add(countryList[i]);
            this.country.SelectedIndex = 0;
        }
#endregion
    }
}
