using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace SampleBrowser
{
    public class Mail
    {
        #region Properties

        public string Sender
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }

        public UIColor BackgroundColor
        {
            get;
            set;
        }

        #endregion
    }
}