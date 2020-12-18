#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfAutoComplete.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
    public class Diacritics_Sense : SampleView
    {
        NSMutableArray diacriticsList = new NSMutableArray();
        SFAutoComplete diacriticsAutoComplete;
        public Diacritics_Sense()
        {
            this.addingdiacriticsList();
            diacriticsAutoComplete = new SFAutoComplete();
            diacriticsAutoComplete.AutoCompleteSource = diacriticsList;
            diacriticsAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContains;
            diacriticsAutoComplete.Watermark = (NSString)"Search Text";
            diacriticsAutoComplete.MaxDropDownHeight = 200;
            diacriticsAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
            diacriticsAutoComplete.IgnoreDiacritic = false;
            this.AddSubview(diacriticsAutoComplete);
        }

        private void addingdiacriticsList()
        {
            diacriticsList.Add((NSString)"Whât is thé wéâthér tódây ? ");
            diacriticsList.Add((NSString)"Hów tó bóók my flight?");
            diacriticsList.Add((NSString)"Whéré is my lócâtión?");
            diacriticsList.Add((NSString)"Is bânk ópén tódây?");
            diacriticsList.Add((NSString)"Why sky is blué?");
            diacriticsList.Add((NSString)"Gét mé sóméthing");
            diacriticsList.Add((NSString)"List óf hólidâys");
            diacriticsList.Add((NSString)"Diréct mé tó hómé");
            diacriticsList.Add((NSString)"Hów tó gâin wéight?");
            diacriticsList.Add((NSString)"Hów tó drâw ân éléphânt?");
            diacriticsList.Add((NSString)"Whéré cân I buy â câmérâ?");
            diacriticsList.Add((NSString)"Guidé mé âll thé wây");
            diacriticsList.Add((NSString)"Hów tó mâké â câké?");
            diacriticsList.Add((NSString)"Sây, Hélló Wórld!");
            diacriticsList.Add((NSString)"Hów tó mâké â róbót?");
            diacriticsList.Add((NSString)"Cónnéct Móbilé tó TV?");
            diacriticsList.Add((NSString)"Whât timé nów in Indiâ?");
            diacriticsList.Add((NSString)"Whó is whó in thé wórld?");
            diacriticsList.Add((NSString)"Hów cân I léârn Tâmil?");
            diacriticsList.Add((NSString)"Hów cân I léârn Jâpânésé?");
            diacriticsList.Add((NSString)"Hów tó réâch néârést âirpórt?");
        }
        public override void LayoutSubviews()
        {

            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    diacriticsAutoComplete.Frame = new CGRect(40, 30, view.Frame.Width - 80, 40);
                }
                else
                {
                    diacriticsAutoComplete.Frame = new CGRect(20, 30, view.Frame.Width - 40, 40);
                }
            }
            base.LayoutSubviews();
        }
    }
}
