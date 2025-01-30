using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

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

        public Color BackgroundColor
        {
            get;
            set;
        }

        #endregion
    }
}