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

