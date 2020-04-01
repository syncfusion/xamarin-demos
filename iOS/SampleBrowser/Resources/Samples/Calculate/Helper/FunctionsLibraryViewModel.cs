#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using UIKit;

namespace SampleBrowser
{
	public class FunctionsLibraryViewModel : UIPickerViewModel
	{

		List<string> functions;
		UITextField formulaEdit;
		UITextField pickerTextView;
		FunctionsLibraryView libraryView;

		public FunctionsLibraryViewModel(UITextField textFeild, UITextField pickerView, FunctionsLibraryView _libraryView)
		{
			functions = new List<string>();
			formulaEdit = textFeild;
			pickerTextView = pickerView;
			libraryView = _libraryView;
			functions = GetFunctions();
		}

		private List<string> GetFunctions()
		{
			List<string> functions = new List<string>();
			foreach (string item in libraryView.Engine.LibraryFunctions.Keys)
				functions.Add(item);

			functions.Sort();
			functions.RemoveAt(0);
			functions.RemoveAt(0);
			functions.RemoveAt(0);
			functions.Remove("ACCRINTM");
			functions.Remove("AVERAGEIFS");
			functions.Remove("BETA.DIST");
			functions.Remove("BIGMUL");
			functions.Remove("IMAGINARYDIFFERENCE");
			functions.Remove("IMPRODUCT");
			functions.Remove("IMSUB");
			functions.Remove("F.INV.RT");
			functions.Remove("HYPGEOM.DIST");
			functions.Remove("IMCONJUGATE");
			functions.Remove("MIRR");
			functions.Remove("FORMULATEXT");
			functions.Remove("GROWTH");
			functions.Remove("IRR");
			functions.Remove("MDETERN");
			functions.Remove("MMULT");
			functions.Remove("NORM.INV");
			functions.Remove("PROPER");
			functions.Remove("REPLACEB");
			functions.Remove("UNICODE");
			functions.Remove("XIRR");
			return functions;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return functions.Count;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return functions[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			string item = functions[(int)row];
			pickerTextView.Text = item;
			libraryView.EndEditing(true);
			FunctionsHelper.GetFunction(item, formulaEdit);
		}

		public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
		{
			return new UILabel() { Text = functions[(int)row], Font = UIFont.FromName("Helvetica", 14f) };
		}
	}
}