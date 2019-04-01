#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.Cards
{
    public class CardViewModel : INotifyPropertyChanged
    {
        
        private double cornerRadius = 7;

        public double CornerRadius
        {
            get
            {
                return cornerRadius;
            }
            set
            {
                cornerRadius = Math.Round(value);
                OnPropertyChanged("CornerRadius");
            }
        }

        private double indicatorThickness;

        public double IndicatorThickness
        {
            get
            {
                return indicatorThickness;
            }
            set
            {
                indicatorThickness = value;
                OnPropertyChanged("IndicatorThickness");
            }
        }

        private bool isCardAlreadySwiped = false;

        public bool IsCardAlreadySwiped
        {
            get
            {
                return isCardAlreadySwiped;
            }
            set
            {
                isCardAlreadySwiped = value;
                OnPropertyChanged("IsCardAlreadySwiped");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private bool enableFadeOutOnSwiping=true;
        public bool EnableFadeOutOnSwiping
        {
            get
            {
                return enableFadeOutOnSwiping;
            }
            set
            {
                enableFadeOutOnSwiping = value;
                EnableSwipToDismiss = value;
                OnPropertyChanged("EnableFadeOutOnSwiping");
            }
        }

        private bool enableSwipToDismiss = true;
        public bool EnableSwipToDismiss
        {
            get
            {
                return enableSwipToDismiss;
            }
            set
            {
                enableSwipToDismiss = value;
                OnPropertyChanged("EnableSwipToDismiss");
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
