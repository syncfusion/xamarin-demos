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
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Calculate
{
    [Preserve(AllMembers = true)]
    public class FunctionsLibraryViewModel : INotifyPropertyChanged
    {
        #region Fields

        public string txtA1;
        public string txtA2;
        public string txtA3;
        public string txtA4;
        public string txtA5;
        public string txtB1;
        public string txtB2;
        public string txtB3;
        public string txtB4;
        public string txtB5;
        public string txtC1;
        public string txtC2;
        public string txtC3;
        public string txtC4;
        public string txtC5;
        public string txtGen;
        public string txtResult;
        private ICommand compute;
		internal List<string> LibraryFunctions;
		internal CalcEngine Engine;
		internal CalcData _CalcData;

        #endregion

        #region Constructor
        public FunctionsLibraryViewModel()
        {
            txtA1 = "32";
            txtA2 = "12";
            txtA3 = "88";
            txtA4 = "73";
            txtA5 = "63";
            txtB1 = "50";
            txtB2 = "24";
            txtB3 = "-22";
            txtB4 = "91";
            txtB5 = "29";
            txtC1 = "10";
            txtC2 = "90";
            txtC3 = "37";
            txtC4 = "21";
            txtC5 = "44";
            txtGen = string.Empty;
            txtResult = string.Empty;
			LibraryFunctions = new List<string>();
            InitializeEngine();
        }

        #endregion

        #region Properties

        public string TxtA1
        {
            get { return txtA1; }
            set
            {
                txtA1 = value;
                OnPropertyChanged("TxtA1");
            }
        }

        public string TxtA2
        {
            get { return txtA2; }
            set
            {
                txtA2 = value;
                OnPropertyChanged("TxtA2");
            }
        }

        public string TxtA3
        {
            get { return txtA3; }
            set
            {
                txtA3 = value;
                OnPropertyChanged("TxtA3");
            }
        }

        public string TxtA4
        {
            get { return txtA4; }
            set
            {
                txtA4 = value;
                OnPropertyChanged("TxtA4");
            }
        }

        public string TxtA5
        {
            get { return txtA5; }
            set
            {
                txtA5 = value;
                OnPropertyChanged("TxtA5");
            }
        }

        public string TxtB1
        {
            get { return txtB1; }
            set
            {
                txtB1 = value;
                OnPropertyChanged("TxtB1");
            }
        }

        public string TxtB2
        {
            get { return txtB2; }
            set
            {
                txtB2 = value;
                OnPropertyChanged("TxtB2");
            }
        }

        public string TxtB3
        {
            get { return txtB3; }
            set
            {
                txtB3 = value;
                OnPropertyChanged("TxtB3");
            }
        }

        public string TxtB4
        {
            get { return txtB4; }
            set
            {
                txtB4 = value;
                OnPropertyChanged("TxtB4");
            }
        }

        public string TxtB5
        {
            get { return txtB5; }
            set
            {
                txtB5 = value;
                OnPropertyChanged("TxtB5");
            }
        }

        public string TxtC1
        {
            get { return txtC1; }
            set
            {
                txtC1 = value;
                OnPropertyChanged("TxtC1");
            }
        }

        public string TxtC2
        {
            get { return txtC2; }
            set
            {
                txtC2 = value;
                OnPropertyChanged("TxtC2");
            }
        }

        public string TxtC3
        {
            get { return txtC3; }
            set
            {
                txtC3 = value;
                OnPropertyChanged("TxtC3");
            }
        }

        public string TxtC4
        {
            get { return txtC4; }
            set
            {
                txtC4 = value;
                OnPropertyChanged("TxtC4");
            }
        }

        public string TxtC5
        {
            get { return txtC5; }
            set
            {
                txtC5 = value;
                OnPropertyChanged("TxtC5");
            }
        }

        public string TxtGen
        {
            get { return txtGen; }
            set
            {
                txtGen = value;
                OnPropertyChanged("TxtGen");
            }
        }

        public string TxtResult
        {
            get { return txtResult; }
            set
            {
                txtResult = value;
                OnPropertyChanged("TxtResult");
            }
        }
        public ICommand ComputeCommand
        {
            get
            {
                if (compute == null)
                    compute = new ComputeCommand(this);
                return compute;
            }
            set
            {
                compute = value;
            }
        }

        #endregion

        #region Methods
        internal void InitializePicker(Picker picker)
        {
            foreach (string item in Engine.LibraryFunctions.Keys)
                LibraryFunctions.Add(item);

            LibraryFunctions.Sort();
            LibraryFunctions.RemoveAt(0);
            LibraryFunctions.RemoveAt(0);
            LibraryFunctions.RemoveAt(0);
            LibraryFunctions.Remove("ACCRINTM");
            LibraryFunctions.Remove("AVERAGEIFS");
            LibraryFunctions.Remove("BETA.DIST");
            LibraryFunctions.Remove("BIGMUL");
            LibraryFunctions.Remove("IMAGINARYDIFFERENCE");
            LibraryFunctions.Remove("IMPRODUCT");
            LibraryFunctions.Remove("IMSUB");
            LibraryFunctions.Remove("F.INV.RT");
            LibraryFunctions.Remove("HYPGEOM.DIST");
            LibraryFunctions.Remove("IMCONJUGATE");
            LibraryFunctions.Remove("MIRR");
            LibraryFunctions.Remove("FORMULATEXT");
            LibraryFunctions.Remove("GROWTH");
            LibraryFunctions.Remove("IRR");
            LibraryFunctions.Remove("MDETERN");
            LibraryFunctions.Remove("MMULT");
            LibraryFunctions.Remove("NORM.INV");
            LibraryFunctions.Remove("PROPER");
            LibraryFunctions.Remove("REPLACEB");
            LibraryFunctions.Remove("UNICODE");
            LibraryFunctions.Remove("XIRR");

            foreach (string item in LibraryFunctions)
                picker.Items.Add(item);

            picker.SelectedIndex = 0;
        }

        private void InitializeEngine()
        {
            _CalcData = new CalcData();
            Engine = new CalcEngine(_CalcData);
            Engine.UseNoAmpersandQuotes = true;
			int i = CalcEngine.CreateSheetFamilyID();
			Engine.RegisterGridAsSheet("CalcData" + i.ToString(), _CalcData, i);
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Dispose

        internal void Dispose()
        {
            _CalcData = null;
            Engine.Dispose();
            Engine = null;
        }

        #endregion
    }
}
