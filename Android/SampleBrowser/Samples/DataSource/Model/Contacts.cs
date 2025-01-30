using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleBrowser
{
    public class Contacts
    {
        private string contactName;
        private string contactNumber;
        private Color color;

        public Contacts(string name, string number)
        {
            contactName = name;
            contactNumber = number;
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public Color ContactColor
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }
    }
}