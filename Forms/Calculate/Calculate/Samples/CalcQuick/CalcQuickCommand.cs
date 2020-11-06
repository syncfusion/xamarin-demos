#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Calculate
{
    [Preserve(AllMembers = true)]
    public class CalcQuickCommand : ICommand
    {
        private CalcQuickViewModel viewModel;
        public CalcQuickCommand(CalcQuickViewModel _ViewModel)
        {
            viewModel = _ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.calcQuickBase["A"] = viewModel.TextA;
            viewModel.calcQuickBase["B"] = viewModel.TextB;
            viewModel.calcQuickBase["C"] = viewModel.TextC;

            viewModel.calcQuickBase.SetDirty();

            viewModel.Result1 = viewModel.calcQuickBase["Exp1"];
            viewModel.Result2 = viewModel.calcQuickBase["Exp2"];
            viewModel.Result3 = viewModel.calcQuickBase["Exp3"];
        }

        private void RaiseCanExcuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
