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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SampleBrowser.Cards
{
    public class CardViewModel : INotifyPropertyChanged
    {
        internal ObservableCollection<CardViewData> Data = new ObservableCollection<CardViewData>(); 

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

        public CardViewModel()
        {
            Data.Add(new CardViewData
            {
                Name = "White Sofa",
                Price = "$99",
                Offer = "35% Offer",
                ImagePath = "AngleSofa.jpg",
            });

            Data.Add(new CardViewData
            {
                Name = "Dining Chair",
                Price = "$80",
                Offer = "15% Offer",
                ImagePath = "DiningTable.jpg",
            });

            Data.Add(new CardViewData
            {
                Name = "Semi-Cotton Fabric Sofa",
                Price = "$99",
                Offer = "25% Offer",
                ImagePath = "GraySofa.jpg",
            });
        }
    }
}
