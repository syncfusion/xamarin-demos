#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser
{
    public class FormattingViewModel
    {
        public FormattingViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        private List<BankInfo> bankInfo;

        public List<BankInfo> BankInfo
        {
            get { return bankInfo; }
            set { this.bankInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            BankRepository bank = new BankRepository();
            bankInfo = bank.GetBankDetails(200);
        }

        #endregion

    }

}

