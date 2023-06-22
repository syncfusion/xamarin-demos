#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfBarcode.XForms;
using Xamarin.Forms.Internals;
using SampleBrowser.Core;
using System.IO;
using System.Reflection;

namespace SampleBrowser.SfBarcode.Samples.QRBarcodeLogo
{
    [Preserve(AllMembers = true)]
    public partial class QRBarcodeLogo : SampleView
    {
        public QRBarcodeLogo()
        {
            InitializeComponent();
            Stream imageStream = typeof(QRBarcodeLogo).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.SfBarcode.Assets.qrcodelogo.png");
            QRCodeLogo logo = new QRCodeLogo(imageStream);
            QRBarcodeSettings settings = new QRBarcodeSettings();
            settings.Logo = logo;
            settings.XDimension = 8;
            this.qrBarcode.SymbologySettings = settings;
        }
    }
}