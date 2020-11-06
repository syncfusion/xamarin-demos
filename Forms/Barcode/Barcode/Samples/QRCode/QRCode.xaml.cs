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
using Syncfusion.SfBarcode.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;
using Xamarin.Forms.Internals;
namespace SampleBrowser.SfBarcode
{
	[Preserve(AllMembers = true)]
    public partial class QRCode : SampleView
    {
        public QRCode()
        {
            InitializeComponent();
			QRBarcodeSettings settings = new QRBarcodeSettings();
            settings.XDimension = 8;
            this.barcode11.SymbologySettings = settings;
        }
    }
}
