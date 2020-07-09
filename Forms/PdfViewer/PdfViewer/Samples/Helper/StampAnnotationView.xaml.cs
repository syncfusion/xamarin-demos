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
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfPdfViewer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StampAnnotationView : ContentView
    {
        TapGestureRecognizer recognizer;
        Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer;
        public StampAnnotationView(Syncfusion.SfPdfViewer.XForms.SfPdfViewer pdfViewer)
        {
            InitializeComponent();
            this.pdfViewer = pdfViewer;
            Grid.SetRow(this, 0);
            if (Device.Idiom != TargetIdiom.Desktop)
                Grid.SetRowSpan(this, 3);
            else
                Grid.SetRowSpan(this, 2);
            recognizer = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1
            };
            recognizer.Tapped += (s, e) =>
            {
                CreateAndAddCustomStamp(s as Image);
            };
            approved.GestureRecognizers.Add(recognizer);
            notapproved.GestureRecognizers.Add(recognizer);
            draft.GestureRecognizers.Add(recognizer);
            confidential.GestureRecognizers.Add(recognizer);
            expired.GestureRecognizers.Add(recognizer);
        }

        private void CreateAndAddCustomStamp(Image tappedImage)
        {
            Image customImage = new Image();
            customImage.HeightRequest = 90;
            customImage.WidthRequest = 300;
            if (tappedImage == approved)
                customImage.Source = "Approved.png";
            else if (tappedImage == notapproved)
                customImage.Source = "NotApproved.png";
            else if (tappedImage == draft)
                customImage.Source = "Draft.png";
            else if (tappedImage == expired)
                customImage.Source = "Expired.png";
            else if (tappedImage == confidential)
                customImage.Source = "Confidential.png";

            pdfViewer.AddStamp(customImage, pdfViewer.PageNumber, new Point(250, 400));
            (Parent as Grid).Children.Remove(this);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            (Parent as Grid).Children.Remove(this);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            (Parent as Grid).Children.Remove(this);
        }
    }
    public class CustomStampEffect : RoutingEffect
    {
        public CustomStampEffect() : base("SampleBrowser.SfPdfViewer.CustomStampEffect")
        {

        }
    }
}