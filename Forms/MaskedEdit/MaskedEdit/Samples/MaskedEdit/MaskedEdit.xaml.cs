#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfMaskedEdit
{
    public partial class MaskedEdit : SampleView
    {
        public MaskedEdit()
        {
            InitializeComponent();

            if (Device.Idiom == TargetIdiom.Phone || Device.RuntimePlatform == Device.UWP)
            {
                MaskedEdit_Default maskedEdit = new MaskedEdit_Default();
                this.Content = maskedEdit.getContent();
                this.PropertyView = maskedEdit.getPropertyView();

            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                MaskedEdit_Tablet maskedEdit = new MaskedEdit_Tablet();
                this.Content = maskedEdit.getContent();
                this.PropertyView = maskedEdit.getPropertyView();
            }

        }
    }
}