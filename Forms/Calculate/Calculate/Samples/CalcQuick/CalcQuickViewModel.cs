#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Calculate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Calculate
{
    [Preserve(AllMembers = true)]
    public class CalcQuickViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string textA;
        private string textB;
        private string textC;
        private string result1;
        private string result2;
        private string result3;
        private ICommand compute;

        #endregion

        #region Properties

        public string TextA
        {
            get
            {
                return textA;
            }
            set
            {
                textA = value;
                OnPropertyChanged("TextA");
            }
        }

        public string TextB
        {
            get
            {
                return textB;
            }
            set
            {
                textB = value;
                OnPropertyChanged("TextB");
            }
        }

        public string TextC
        {
            get
            {
                return textC;
            }
            set
            {
                textC = value;
                OnPropertyChanged("TextC");
            }
        }

        public string Result1
        {
            get
            {
                return result1;
            }

            set
            {
                result1 = value;
                OnPropertyChanged("Result1");
            }
        }

        public string Result2
        {
            get
            {
                return result2;
            }

            set
            {
                result2 = value;
                OnPropertyChanged("Result2");
            }
        }

        public string Result3
        {
            get
            {
                return result3;
            }

            set
            {
                result3 = value;
                OnPropertyChanged("Result3");
            }
        }

        public ICommand ComputeCommand
        {
            get
            {
                if (compute == null)
                    compute = new CalcQuickCommand(this);
                return compute;
            }
            set
            {
                compute = value;
            }
        }

        internal CalcQuickBase calcQuickBase
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public CalcQuickViewModel()
        {
            InitializeCalcQuick();

            TextA = calcQuickBase["A"];
            TextB = calcQuickBase["B"];
            TextC = calcQuickBase["C"];

            Result1 = calcQuickBase["Exp1"];
            Result2 = calcQuickBase["Exp2"];
            Result3 = calcQuickBase["Exp3"];
        }

        #endregion

        private void InitializeCalcQuick()
        {
            calcQuickBase = new CalcQuickBase();
            calcQuickBase.Engine.UseNoAmpersandQuotes = true;

            calcQuickBase["A"] = "25";
            calcQuickBase["B"] = "50";
            calcQuickBase["C"] = "10";

            calcQuickBase["Exp1"] = "=Sum([A],[B],[C])";
            calcQuickBase["Exp2"] = "=PI()*([A]^2)";
            calcQuickBase["Exp3"] = "=Concatenate([A],[B],[C])";
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Dispose

        internal void Dispose()
        {
            calcQuickBase.Dispose();
            calcQuickBase = null;
        }

        #endregion
    }
}
