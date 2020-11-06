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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Views.InputMethods;
using Syncfusion.Calculate;

namespace SampleBrowser
{
    public class FunctionsLibrary : SamplePage, IDisposable
    {
        #region Fields

        private ScrollView scrollView;
        private EditText formulaEdit;
        private TextViewExt computedValueEdit;
        private EditText txtA1;
        private EditText txtA2;
        private EditText txtA3;
        private EditText txtA4;
        private EditText txtA5;
        private EditText txtB1;
        private EditText txtB2;
        private EditText txtB3;
        private EditText txtB4;
        private EditText txtB5;
        private EditText txtC1;
        private EditText txtC2;
        private EditText txtC3;
        private EditText txtC4;
        private EditText txtC5;
        private Context context;
        private CalcData calcData;
        private CalcEngine engine;

        #endregion

        public override View GetSampleContent(Context context)
        {
            this.context = context;

            InitializeEngine();
            CreateFunctionLibraryDesign(context);

            return scrollView;
        }

        #region Private Methods

        private void CreateFunctionLibraryDesign(Context context)
        {
            int width = (int)(context.Resources.DisplayMetrics.WidthPixels - context.Resources.DisplayMetrics.Density);

            scrollView = new ScrollView(context);
            scrollView.SetPadding(10, 10, 10, 20);

            LinearLayout linearLayout = new LinearLayout(context);

            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.Focusable = true;
            linearLayout.FocusableInTouchMode = true;
            linearLayout.SetPadding(10, 10, 10, 10);

            LinearLayout linearLayout1 = new LinearLayout(context);

            linearLayout1.Orientation = Orientation.Vertical;

            TextView titleText = new TextView(context)
            {
                Text = "Functions Library",
                TextAlignment = TextAlignment.Center,
                Gravity = GravityFlags.Center,
                TextSize = 30
            };
            titleText.SetTypeface(null, TypefaceStyle.Bold);
            titleText.SetWidth(width);

            TextView descText = new TextView(context)
            {
                Text = "This sample demonstrates the calculation using various Excel-like functions.",
                TextAlignment = TextAlignment.TextStart,
                Gravity = GravityFlags.FillHorizontal,
                TextSize = 12
            };

            descText.SetPadding(0, 10, 0, 0);
            descText.SetWidth(width);

            linearLayout1.AddView(titleText);
            linearLayout1.AddView(descText);

            LinearLayout linearLayout2 = new LinearLayout(context);

            linearLayout2.Orientation = Orientation.Horizontal;
            linearLayout2.SetPadding(0, 10, 0, 0);

            TextView functionsText = new TextView(context)
            {
                Text = "Select a function",
                Gravity = GravityFlags.Start,
                TextSize = 15
            };

            functionsText.SetWidth((int)(width * 0.4));

            Spinner spinner = new Spinner(context, SpinnerMode.Dialog);

            var functions = GetLibraryFunctions();
            var adapter = new ArrayAdapter<string>(context, Resource.Drawable.SpinnerExt, functions);

            spinner.Adapter = adapter;
            spinner.SetGravity(GravityFlags.Start);
            spinner.SetMinimumWidth(width - (int)(width * 0.4));
            spinner.ItemSelected += Spinner_ItemSelected;

            linearLayout2.AddView(functionsText);
            linearLayout2.AddView(spinner);

            LinearLayout gridLinearLayout = new LinearLayout(context) { Orientation = Orientation.Vertical };

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);

            layoutParams.TopMargin = 25;
            gridLinearLayout.LayoutParameters = layoutParams;
            gridLinearLayout.SetBackgroundResource(Resource.Drawable.LinearLayout_Border);

            int padding = gridLinearLayout.PaddingLeft + gridLinearLayout.PaddingRight;
            int firstColWidth = (int)(width * 0.1) - padding;
            int cellWidth = ((width - firstColWidth) / 3) - padding;

            // First Row
            LinearLayout linearLayout3 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout3.SetPadding(0, 10, 0, 0);

            TextView text00 = new TextView(context);
            text00.SetWidth((int)(width * 0.1));

            TextView text01 = new TextView(context) { Text = "A", Gravity = GravityFlags.Center, TextSize = 15 };
            text01.SetWidth(cellWidth);

            TextView text02 = new TextView(context) { Text = "B", Gravity = GravityFlags.Center, TextSize = 15 };
            text02.SetWidth(cellWidth);

            TextView text03 = new TextView(context) { Text = "C", Gravity = GravityFlags.Center, TextSize = 15 };
            text03.SetWidth(cellWidth);

            linearLayout3.AddView(text00);
            linearLayout3.AddView(text01);
            linearLayout3.AddView(text02);
            linearLayout3.AddView(text03);

            // Second Row
            LinearLayout linearLayout4 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout4.SetPadding(0, 10, 0, 0);

            TextView text10 = new TextView(context) { Text = "1", Gravity = GravityFlags.Center, TextSize = 15 };
            text10.SetWidth((int)(width * 0.1));

            txtA1 = CreateEditText(context, "32");
            txtA1.SetWidth(cellWidth);

            txtB1 = CreateEditText(context, "50");
            txtB1.SetWidth(cellWidth);

            txtC1 = CreateEditText(context, "10");
            txtC1.SetWidth(cellWidth);

            linearLayout4.AddView(text10);
            linearLayout4.AddView(txtA1);
            linearLayout4.AddView(txtB1);
            linearLayout4.AddView(txtC1);

            // Third Row
            LinearLayout linearLayout5 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout5.SetPadding(0, 10, 0, 0);

            TextView text20 = new TextView(context) { Text = "2", Gravity = GravityFlags.Center, TextSize = 15 };
            text20.SetWidth((int)(width * 0.1));

            txtA2 = CreateEditText(context, "12");
            txtA2.SetWidth(cellWidth);

            txtB2 = CreateEditText(context, "24");
            txtB2.SetWidth(cellWidth);

            txtC2 = CreateEditText(context, "90");
            txtC2.SetWidth(cellWidth);

            linearLayout5.AddView(text20);
            linearLayout5.AddView(txtA2);
            linearLayout5.AddView(txtB2);
            linearLayout5.AddView(txtC2);

            // Fourth Row
            LinearLayout linearLayout6 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout6.SetPadding(0, 10, 0, 0);

            TextView text30 = new TextView(context) { Text = "3", Gravity = GravityFlags.Center, TextSize = 15 };
            text30.SetWidth((int)(width * 0.1));

            txtA3 = CreateEditText(context, "88");
            txtA3.SetWidth(cellWidth);

            txtB3 = CreateEditText(context, "-22");
            txtB3.SetWidth(cellWidth);

            txtC3 = CreateEditText(context, "37");
            txtC3.SetWidth(cellWidth);

            linearLayout6.AddView(text30);
            linearLayout6.AddView(txtA3);
            linearLayout6.AddView(txtB3);
            linearLayout6.AddView(txtC3);

            // Fifth Row
            LinearLayout linearLayout7 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout7.SetPadding(0, 10, 0, 0);

            TextView text40 = new TextView(context) { Text = "4", Gravity = GravityFlags.Center, TextSize = 15 };
            text40.SetWidth((int)(width * 0.1));

            txtA4 = CreateEditText(context, "73");
            txtA4.SetWidth(cellWidth);

            txtB4 = CreateEditText(context, "91");
            txtB4.SetWidth(cellWidth);

            txtC4 = CreateEditText(context, "21");
            txtC4.SetWidth(cellWidth);

            linearLayout7.AddView(text40);
            linearLayout7.AddView(txtA4);
            linearLayout7.AddView(txtB4);
            linearLayout7.AddView(txtC4);

            // Sixth Row
            LinearLayout linearLayout11 = new LinearLayout(context) { Orientation = Orientation.Horizontal };
            linearLayout11.SetPadding(0, 10, 0, 0);

            TextView text50 = new TextView(context) { Text = "5", Gravity = GravityFlags.Center, TextSize = 15 };
            text50.SetWidth((int)(width * 0.1));

            txtA5 = CreateEditText(context, "63");
            txtA5.SetWidth(cellWidth);

            txtB5 = CreateEditText(context, "29");
            txtB5.SetWidth(cellWidth);

            txtC5 = CreateEditText(context, "44");
            txtC5.SetWidth(cellWidth);

            linearLayout11.AddView(text50);
            linearLayout11.AddView(txtA5);
            linearLayout11.AddView(txtB5);
            linearLayout11.AddView(txtC5);

            LinearLayout linearLayout8 = new LinearLayout(context);

            linearLayout8.Orientation = Orientation.Horizontal;
            linearLayout8.SetPadding(0, 25, 0, 0);

            TextView formulaText = new TextView(context)
            {
                Text = "Formula",
                Gravity = GravityFlags.Start,
                TextSize = 15
            };

            formulaText.SetWidth((int)(width * 0.4));

            formulaEdit = new EditText(context) { TextSize = 15 };
            formulaEdit.SetWidth(width - (int)(width * 0.4));
            formulaEdit.SetSingleLine(true);

            linearLayout8.AddView(formulaText);
            linearLayout8.AddView(formulaEdit);

            LinearLayout linearLayout9 = new LinearLayout(context);
            linearLayout9.SetPadding(0, 5, 0, 0);

            Button compute = new Button(context);
            compute.Text = "Compute";
            compute.Click += Compute_Click;
            compute.SetWidth(width);

            linearLayout9.AddView(compute);

            LinearLayout linearLayout10 = new LinearLayout(context);

            linearLayout10.Orientation = Orientation.Horizontal;
            linearLayout10.SetPadding(0, 20, 0, 0);

            TextView computedText = new TextView(context)
            {
                Text = "Computed Value",
                Gravity = GravityFlags.Start,
                TextSize = 15
            };

            computedText.SetWidth((int)(width * 0.4));

            computedValueEdit = new TextViewExt(context) { TextSize = 15 };
            computedValueEdit.SetWidth(width - (int)(width * 0.4));
            computedValueEdit.SetSingleLine(true);

            linearLayout10.AddView(computedText);
            linearLayout10.AddView(computedValueEdit);

            gridLinearLayout.AddView(linearLayout3);
            gridLinearLayout.AddView(linearLayout4);
            gridLinearLayout.AddView(linearLayout5);
            gridLinearLayout.AddView(linearLayout6);
            gridLinearLayout.AddView(linearLayout7);
            gridLinearLayout.AddView(linearLayout11);

            linearLayout.AddView(linearLayout1);
            linearLayout.AddView(linearLayout2);
            linearLayout.AddView(gridLinearLayout);
            linearLayout.AddView(linearLayout8);
            linearLayout.AddView(linearLayout9);
            linearLayout.AddView(linearLayout10);

            linearLayout.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    ClearFocus();
                }
            };

            scrollView.AddView(linearLayout);
        }

        private void InitializeEngine()
        {
            calcData = new CalcData();
            engine = new CalcEngine(calcData);
            engine.UseNoAmpersandQuotes = true;
            int i = CalcEngine.CreateSheetFamilyID();
            engine.RegisterGridAsSheet("CalcData", calcData, i);
        }

        private EditText CreateEditText(Context context, string text)
        {
            return new EditText(context)
            {
                Text = text,
                TextSize = 15,
                Gravity = GravityFlags.Center,
                InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.ClassNumber
            };
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var item = (sender as Spinner).SelectedItem.ToString();

            switch (item)
            {
                case "SUM":
                case "AVG":
                case "MAX":
                case "MIN":
                case "AVERAGE":
                case "SUMSQ":
                case "AVEDEV":
                case "PRODUCT":
                case "AVERAGEA":
                case "GAMMADIST":
                case "GEOMEAN":
                case "HARMEAN":
                case "NORMDIST":
                case "COUNT":
                case "COUNTA":
                case "DEVSQ":
                case "KURT":
                case "MAXA":
                case "MEDIAN":
                case "MINA":
                case "GCD":
                case "LCM":
                case "STDEV.P":
                case "STDEV.S":
                case "IMAGINARYDIFFERENCE":
                case "IMPRODUCT":
                case "PPMT":
                case "IPMT":
                case "ISPMT":
                case "SYD":
                    formulaEdit.Text = "=" + item + "(A1,B1,C1,C4)";
                    break;
                case "PI":
                    formulaEdit.Text = "=" + item + "()*(A1+B1*C1)";
                    break;
                case "VLOOKUP":
                    formulaEdit.Text = "=" + item + "(A1,A2:C5,2,true)";
                    break;
                case "HLOOKUP":
                    formulaEdit.Text = "=" + item + "(A1,A2:C5,3,true)";
                    break;
                case "INDEX":
                    formulaEdit.Text = "=" + item + "(A1:C5,3,2)";
                    break;
                case "CHAR":
                case "UNICHAR":
                    formulaEdit.Text = "=" + item + "(C2)";
                    break;
                case "DB":
                case "DDB":
                    formulaEdit.Text = "=" + item + "(A1,B1,C1,5)";
                    break;
                case "HYPGEOMDIST":
                    formulaEdit.Text = "=" + item + "(C1,A2,A1,B1)";
                    break;
                case "IMSUM":
                case "IMSQRT":
                case "IMDIV":
                    formulaEdit.Text = "=" + item + "(\"1+4i\",\"1+3i\")";
                    break;
                case "SIGN":
                case "GAMMAIN":
                case "COUNTBLANK":
                case "FISHERINV":
                case "EVEN":
                case "INDIRECT":
                case "ISEVEN":
                case "ISODD":
                case "ISREF":
                case "N":
                case "TAN":
                case "ODD":
                case "RADIANS":
                case "SQRTPI":
                case "FACTDOUBLE":
                case "GAMMALN":
                case "NORMSDIST":
                case "SEC":
                case "SECH":
                case "COT":
                case "COTH":
                case "CSC":
                case "CSCH":
                case "ACOT":
                case "ACOTH":
                case "ACSCH":
                case "TRUNCATE":
                case "GAMMALN.PRECISE":
                case "DEC2BIN":
                case "DEC2OCT":
                case "DEC2HEX":
                case "HEX2BIN":
                case "HEX2OCT":
                case "HEX2DEC":
                case "OCT2BIN":
                case "OCT2HEX":
                case "OCT2DEC":
                case "IMABS":
                case "IMAGINARY":
                case "IMREAL":
                case "IMCONJUGATE":
                case "IMARGUMENT":
                case "IMSIN":
                case "IMCSC":
                case "IMCOS":
                case "IMSEC":
                case "IMTAN":
                case "IMCOT":
                case "IMSINH":
                case "IMCSCH":
                case "IMCOSH":
                case "IMSECH":
                case "IMTANH":
                case "IMCOTH":
                case "IMLOG10":
                case "IMLOG2":
                case "IMLN":
                case "IMEXP":
                case "ERF":
                case "ERF.PRECISE":
                case "ERFC.PRECISE":
                case "ERFC":
                case "FORMULATEXT":
                case "ISFORMULA":
                case "TYPE":
                case "WEEKNUM":
                case "ISOWEEKNUM":
                case "ROW":
                case "AREAS":
                case "MUNIT":
                case "DEGREES":
                    formulaEdit.Text = "=" + item + "(A1)";
                    break;
                case "MORMSINV":
                    formulaEdit.Text = "=" + item + "(A1/100)";
                    break;
                case "NORMINV":
                    formulaEdit.Text = "=" + item + "(0.98,A2,A3)";
                    break;
                case "FINV":
                    formulaEdit.Text = "=" + item + "(1,A1,B1)";
                    break;
                case "IFERROR":
                    formulaEdit.Text = "=" + item + "(A1,\"Error in calculation\")";
                    break;
                case "ACOS":
                case "ASECH":
                    formulaEdit.Text = "=" + item + "(0.5)";
                    break;
                case "ASIN":
                case "ATANH":
                case "FISHER":
                    formulaEdit.Text = "=" + item + "(0.6)";
                    break;
                case "BIN2DEC":
                case "BIN2OCT":
                case "BIN2HEX":
                    formulaEdit.Text = "=" + item + "(11000011)";
                    break;
                case "LARGE":
                case "QUARTILE":
                case "QUARTILE.EXC":
                case "QUARTILE.INC":
                case "SMALL":
                    formulaEdit.Text = "=" + item + "({C1,A2,C4,B2},3)";
                    break;
                case "CORREL":
                case "COVARIANCE.P":
                case "COVARIANCE.S":
                case "INTERCEPT":
                case "PEARSON":
                case "RSQ":
                case "SLOPE":
                case "STEYX":
                    formulaEdit.Text = "=" + item + "({C1,A2,C4},{B2,A1,C5})";
                    break;
                case "PERCENTILE.EXC":
                case "PERCENTILE.INC":
                    formulaEdit.Text = "=" + item + "({C1,A2,C4},0.7)";
                    break;
                case "FORECAST":
                    formulaEdit.Text = "=" + item + "(A4,{C1,A2,C4},{B2,A1,C5})";
                    break;
                case "RANDBETWEEN":
                    formulaEdit.Text = "=" + item + "(C1,A1)";
                    break;
                case "PERCENTRANK":
                    formulaEdit.Text = "=" + item + "(A1:A5,A3)";
                    break;
                case "TRANSPOSE":
                    formulaEdit.Text = "=" + item + "({100,200,300})";
                    break;
                case "TRIMMEAN":
                    formulaEdit.Text = "=" + item + "(A1:A5,10%)";
                    break;
                case "POW":
                case "POWER":
                case "SUMX2MY2":
                case "SUMX2PY2":
                case "SUMXMY2":
                case "CHIDIST":
                case "CHITEST":
                case "CONCATENATE":
                case "COMBIN":
                case "COVAR":
                case "PERCENTILE":
                case "PERMUT":
                case "ATAN2":
                case "EFFECT":
                case "QUOTIENT":
                case "BIGMUL":
                case "DIVREM":
                case "IEEEREMAINDER":
                case "COMBINA":
                case "PERMUTATIONA":
                case "CHISQ.DIST.RT":
                case "IHDIST":
                case "COMPLEX":
                case "IMSUB":
                case "IMPOWER":
                case "GESTEP":
                case "DELTA":
                case "BITAND":
                case "BITOR":
                case "BITXOR":
                case "BITLSHIFT":
                case "BITRSHIFT":
                case "BESSELI":
                case "BESSELJ":
                case "BESSELY":
                case "BESSELK":
                case "BASE":
                case "DAYS":
                case "EDATE":
                case "EOMONTH":
                case "WORKDAY.INTL":
                case "WORKDAY":
                case "YEARFRAC":
                case "DAYS360":
                case "MOD":
                    formulaEdit.Text = "=" + item + "(A1,C1)";
                    break;
                case "IF":
                    formulaEdit.Text = "=" + item + "(A1+B1>C1+A4,True)";
                    break;
                case "SUMIF":
                    formulaEdit.Text = "=" + item + "(A1:A5,\">C5\")";
                    break;
                case "NOT":
                    formulaEdit.Text = "=" + item + "(IF(A1+B1>C1,True))";
                    break;
                case "FALSE":
                case "TRUE":
                    formulaEdit.Text = "=(IF(A1+B1>C1,True))" + item + "()";
                    break;
                case "LEFT":
                case "RIGHT":
                case "LEFTB":
                case "RIGHTB":
                    formulaEdit.Text = "=" + item + "(A1,3)";
                    break;
                case "LEN":
                case "LENB":
                case "INT":
                case "COLUMN":
                case "ISERROR":
                case "ISNUMBER":
                case "ISLOGICAL":
                case "ISNA":
                case "ISERR":
                case "ISBLANK":
                case "ISTEXT":
                case "ISNONTEXT":
                case "EXP":
                case "SINH":
                case "SQRT":
                case "LOG10":
                case "LN":
                case "ACOSH":
                case "ASINH":
                case "ATAN":
                case "COS":
                case "SIN":
                case "COSH":
                case "TANH":
                case "LOG":
                case "FACT":
                    formulaEdit.Text = "=" + item + "(Sum(A1,B1,C1))";
                    break;
                case "ABS":
                    formulaEdit.Text = "=" + item + "(B3)";
                    break;
                case "FV":
                case "PMT":
                case "MIRR":
                case "NPER":
                case "NPV":
                case "RATE":
                case "DATE":
                case "TIME":
                case "EXPONDIST":
                case "FDIST":
                case "LOGNORMDIST":
                case "NEGBINOMDIST":
                case "POISSON":
                case "STANDARDSIZE":
                case "WEIBULL":
                case "SUBSTITUTE":
                case "MULTINOMIAL":
                case "SLN":
                case "SKEW.P":
                case "F.DIST.RT":
                    formulaEdit.Text = "=" + item + "(A1,B1,C1)";
                    break;
                case "RAND":
                    formulaEdit.Text = "=" + item + "()*Sum(A1,B1,C1)";
                    break;
                case "CEILING":
                case "FLOOR":
                case "ROUNDDOWN":
                case "ROUND":
                    formulaEdit.Text = "=" + item + "(Sum(A1,B1,C1),0.5)";
                    break;
                case "DAY":
                case "HOUR":
                case "MINUTE":
                case "SECOND":
                case "MONTH":
                case "WEEKDAY":
                case "YEAR":
                    formulaEdit.Text = "=" + item + "(A1)";
                    break;
                case "DATEVALUE":
                    formulaEdit.Text = "=" + item + "(\"1990/01/24\")";
                    break;
                case "OFFSET":
                    formulaEdit.Text = "=" + item + "(A1,2,2)";
                    break;
                case "MID":
                    formulaEdit.Text = "=" + item + "(\"MidPoint\",1,A1)";
                    break;
                case "MIDB":
                    formulaEdit.Text = "=" + item + "(\"Simple Text\",1,6)";
                    break;
                case "EXACT":
                    formulaEdit.Text = "=" + item + "(A1,A1)";
                    break;
                case "FIXED":
                case "PROB":
                case "SKEW":
                case "STDEV":
                case "STDEVA":
                case "STDEVP":
                case "STDEVPA":
                case "VAR":
                case "VARA":
                case "VARP":
                case "VARPA":
                case "ZTEST":
                case "UNIDIST":
                    formulaEdit.Text = "=" + item + "(A1,A2,A3)";
                    break;
                case "LOWER":
                    formulaEdit.Text = "=" + item + "(\"LOWERTEXT\")";
                    break;
                case "UPPER":
                    formulaEdit.Text = "=" + item + "(\"uppertext\")";
                    break;
                case "TRIM":
                    formulaEdit.Text = "=" + item + "(\"Simple     Text\")";
                    break;
                case "TEXT":
                    formulaEdit.Text = "=" + item + "(Sum(A1,B1,C1),$0.00)";
                    break;
                case "XIRR":
                    formulaEdit.Text = "=" + item + "(A1:A5," + DateTime.Now + ",0.1)";
                    break;
                case "VALUE":
                    formulaEdit.Text = "=" + item + "(Avg(A1,B1,C1))";
                    break;
                case "MODE":
                    formulaEdit.Text = "=" + item + "(A1,B1,C1,A1)";
                    break;
                case "MODE.SNGL":
                    formulaEdit.Text = "=" + item + "(A1,B1,B1,C4)";
                    break;
                case "MODE.MULT":
                    formulaEdit.Text = "=" + item + "(A1,B1,C1,C1)";
                    break;
                case "TRUNC":
                    formulaEdit.Text = "=" + item + "(A1/1.3,3)";
                    break;
                case "COUNTIF":
                case "NORM.S.DIST":
                    formulaEdit.Text = "=" + item + "(A1,True)";
                    break;
                case "AND":
                case "OR":
                case "XOR":
                    formulaEdit.Text = "=" + item + "(A1<B1,C5<B4)";
                    break;
                case "IFNA":
                    formulaEdit.Text = "=" + item + "(VLOOKUP(A1,A2:A5,2,true),\"Not Found\")";
                    break;
                case "LOOKUP":
                    formulaEdit.Text = "=" + item + "(B2,A1:B4,C1:C5)";
                    break;
                case "SUMPRODUCT":
                case "GROWTH":
                    formulaEdit.Text = "=" + item + "(A1:A5,B1:B5,C1:C5)";
                    break;
                case "MATCH":
                    formulaEdit.Text = "=" + item + "(B3,A2:B4,0)";
                    break;
                case "FIND":
                case "FINDB":
                case "SEARCH":
                case "SEARCHB":
                    formulaEdit.Text = "=" + item + "(\"n\",\"Syncfusion\",1)";
                    break;
                case "CHOOSE":
                    formulaEdit.Text = "=" + item + "(4,A1,A2,A3,A4,A5)";
                    break;
                case "CLEAN":
                    formulaEdit.Text = "=" + item + "(CHAR(9)&\"Monthly report\"&CHAR(10))";
                    break;
                case "DOLLAR":
                case "ROUNDUP":
                case "ROMAN":
                case "CEILING.MATH":
                    formulaEdit.Text = "=" + item + "(A4, 4)";
                    break;
                case "DOLLARDE":
                case "DOLLARFR":
                    formulaEdit.Text = "=" + item + "(C2,B5)";
                    break;
                case "DURATION":
                    formulaEdit.Text = "=" + item + "(A1,A3,C1,B2,2,1)";
                    break;
                case "FVSCHEDULE":
                    formulaEdit.Text = "=" + item + "(1,{0.09,0.11,0.1})";
                    break;
                case "DISC":
                    formulaEdit.Text = "=" + item + "(A1,B4,C1,C4,1)";
                    break;
                case "INTRATE":
                    formulaEdit.Text = "=" + item + "(\"01/24/1990\",\"01/24/1991\",A5,B5,2)";
                    break;
                case "CUMIPMT":
                    formulaEdit.Text = "=" + item + "(A2/12,A3*12,A4,1,1,0)";
                    break;
                case "CUMPRINC":
                    formulaEdit.Text = "=" + item + "(0.1,A3,A4,1,1,0)";
                    break;
                case "NA":
                case "SHEET":
                case "SHEETS":
                case "NOW":
                case "TODAY":
                    formulaEdit.Text = "=" + item + "()";
                    break;
                case "ERROR.TYPE":
                    formulaEdit.Text = "=" + item + "(#REF!)";
                    break;
                case "SUBTOTAL":
                    formulaEdit.Text = "=" + item + "(9,A1:B4,C1:C5)";
                    break;
                case "PV":
                    formulaEdit.Text = "=" + item + "(A3, A4, A2,B4, 0)";
                    break;
                case "ACCRINT":
                    formulaEdit.Text = "=" + item + "(DATE(A1,A2,B2), DATE(C1,C2,B2), DATE(B1,B2,C1),0.1,C5,2,0)";
                    break;
                case "ACCRINTM":
                    formulaEdit.Text = "=" + item + "(DATE(A1,A2,B2),DATE(C2,C4,C5),0.1,B5,2)";
                    break;
                case "VDB":
                    formulaEdit.Text = "=" + item + "(A1,A2,A3,DATE(A1,A2,B2),DATE(C2,C4,C5))";
                    break;
                case "TIMEVALUE":
                    formulaEdit.Text = "=" + item + "(\"2:24 AM\")";
                    break;
                case "MROUND":
                    formulaEdit.Text = "=" + item + "(A1,3)";
                    break;
                case "NORMSINV":
                case "NORM.S.INV":
                    formulaEdit.Text = "=" + item + "(0.8)";
                    break;
                case "LOGEST":
                case "LOGESTB":
                    formulaEdit.Text = "=" + item + "(A1:A5,B1:B5,TRUE,TRUE)";
                    break;
                case "PERCENTRANK.EXC":
                case "PERCENTRANK.INC":
                case "Z.TEST":
                    formulaEdit.Text = "=" + item + "(A1:A5,3)";
                    break;
                case "STANDARDIZE":
                    formulaEdit.Text = "=" + item + "(A1,A5,1.5)";
                    break;
                case "ADDRESS":
                    formulaEdit.Text = "=" + item + "(2,3)";
                    break;
                case "AVERAGEIF":
                    formulaEdit.Text = "=" + item + "(B2:B5,\"<23000\")";
                    break;
                case "AVERAGEIFS":
                    formulaEdit.Text = "=" + item + "(A2:A5, C2:C5, \">30\", A2:A5, \"<90\")";
                    break;
                case "SUMIFS":
                    formulaEdit.Text = "=" + item + "(A2:A5, C1:C5,\">C4\")";
                    break;
                case "NETWORKDAYS":
                    formulaEdit.Text = "=" + item + "(C4,B5)";
                    break;
                case "CONFIDENCE.T":
                case "CONFIDENCE":
                case "GAMMAINV":
                case "LOGINV":
                    formulaEdit.Text = "=" + item + "(0.6,B2,A1)";
                    break;
                case "BINOMDIST":
                    formulaEdit.Text = "=" + item + "(A1,B1,0.6,TRUE)";
                    break;
                case "CHISQ.TEST":
                    formulaEdit.Text = "=" + item + "(A1:A3, C1:C3)";
                    break;
                case "MMULT":
                    formulaEdit.Text = "=" + item + "(A2:A5, B2:B5)";
                    break;
                case "NORM.DIST":
                    formulaEdit.Text = "=" + item + "(A2,A3,B1,TRUE)";
                    break;
                case "NORM.INV":
                    formulaEdit.Text = "=" + item + "(0.908789,A5,B2)";
                    break;
                case "WEIBULL.DIST":
                case "GAMMA.DIST":
                case "LOGNORM.DIST":
                case "F.DIST":
                    formulaEdit.Text = "=" + item + "(A2,A3,A4,TRUE)";
                    break;
                case "EXPON.DIST":
                case "CHISQ.DIST":
                    formulaEdit.Text = "=" + item + "(0.3,A3,TRUE)";
                    break;
                case "GAMMA.INV":
                case "F.INV.RT":
                case "LOGNORM.INV":
                case "CONFIDENCE.NORM":
                    formulaEdit.Text = "=" + item + "(0.068094,A3,A4)";
                    break;
                case "BINOM.INV":
                case "CRITBINOM":
                    formulaEdit.Text = "=" + item + "(A1,0.5,0.6)";
                    break;
                case "HYPGEOM.DIST":
                    formulaEdit.Text = "=" + item + "(A1,A2,A3,A4,TRUE)";
                    break;
                case "BETA.DIST":
                    formulaEdit.Text = "=" + item + "(A2,A3,A4,TRUE,B1,B2)";
                    break;
                case "CHISQ.INV":
                case "CHISQ.INV.RT":
                case "T.INV":
                case "CHIINV":
                    formulaEdit.Text = "=" + item + "(0.5,A3)";
                    break;
                case "BINOM.DIST":
                case "NEGBINOM.DIST":
                    formulaEdit.Text = "=" + item + "(A1,A3,0.7,TRUE)";
                    break;
                case "RANK.AVG":
                    formulaEdit.Text = "=" + item + "(A2,A1:A5,1)";
                    break;
                case "RANK.EQ":
                    formulaEdit.Text = "=" + item + "(B3,B1:B5,1)";
                    break;
                case "RANK":
                    formulaEdit.Text = "=" + item + "(C4,C1:C5,1)";
                    break;
                case "POISSON.DIST":
                case "T.DIST":
                    formulaEdit.Text = "=" + item + "(A1,A2,TRUE)";
                    break;
                case "CONVERT":
                    formulaEdit.Text = "=" + item + "(A1,\"F\",\"C\")";
                    break;
                case "REPLACE":
                case "REPLACEB":
                    formulaEdit.Text = "=" + item + "(\"SimpleText\",6,5,\"*\")";
                    break;
                case "CODE":
                case "UNICODE":
                case "ASC":
                case "JIS":
                case "ENCODEURL":
                case "T":
                    formulaEdit.Text = "=" + item + "(\"SimpleText\")";
                    break;
                case "PROPER":
                    formulaEdit.Text = "=" + item + "(\"SimPleTeXt\")";
                    break;
                case "NUMBERVALUE":
                    formulaEdit.Text = "=" + item + "(\"2.500,27\",\",\",\".\")";
                    break;
                case "REPT":
                    formulaEdit.Text = "=" + item + "(\"SimpleText\",3)";
                    break;
                case "MDETERM":
                case "ROWS":
                case "COLUMNS":
                case "IRR":
                    formulaEdit.Text = "=" + item + "(A1:A5)";
                    break;
                case "MINVERSE":
                    formulaEdit.Text = "=" + item + "({1,2,4})";
                    break;
                case "DECIMAL":
                    formulaEdit.Text = "=" + item + "(\"FF\",16)";
                    break;
                case "SERIESSUM":
                    formulaEdit.Text = "=" + item + "(A3,0,2,A1:A5)";
                    break;
                case "ARABIC":
                    formulaEdit.Text = "=" + item + "(\"LVII\")";
                    break;
                case "NETWORKDAYS.INTL":
                    formulaEdit.Text = "=" + item + "(\"1990/01/24\",\"1992/01/24\")";
                    break;
                case "HYPERLINK":
                    formulaEdit.Text = "=" + item + "(\"http:\\www.syncfusion.com\",\"Syncfusion\")";
                    break;
                case "INFO":
                    formulaEdit.Text = "=" + item + "(\"NUMFILE\")";
                    break;
                case "CELL":
                    formulaEdit.Text = "=" + item + "(\"col\",C3)";
                    break;
            }
        }

        private void Compute_Click(object sender, EventArgs e)
        {
            ClearFocus();

            calcData.SetValueRowCol(txtA1.Text, 1, 1);
            calcData.SetValueRowCol(txtA2.Text, 2, 1);
            calcData.SetValueRowCol(txtA3.Text, 3, 1);
            calcData.SetValueRowCol(txtA4.Text, 4, 1);
            calcData.SetValueRowCol(txtA5.Text, 5, 1);
            calcData.SetValueRowCol(txtB1.Text, 1, 2);
            calcData.SetValueRowCol(txtB2.Text, 2, 2);
            calcData.SetValueRowCol(txtB3.Text, 3, 2);
            calcData.SetValueRowCol(txtB4.Text, 4, 2);
            calcData.SetValueRowCol(txtB5.Text, 5, 2);
            calcData.SetValueRowCol(txtC1.Text, 1, 3);
            calcData.SetValueRowCol(txtC2.Text, 2, 3);
            calcData.SetValueRowCol(txtC3.Text, 3, 3);
            calcData.SetValueRowCol(txtC4.Text, 4, 3);
            calcData.SetValueRowCol(txtC5.Text, 5, 3);

            computedValueEdit.Text = engine.ParseAndComputeFormula(formulaEdit.Text);
        }

        private List<string> GetLibraryFunctions()
        {
            List<string> libraryFunctions = new List<string>();

            foreach (string item in engine.LibraryFunctions.Keys)
            {
                libraryFunctions.Add(item);
            }

            libraryFunctions.Sort();
            libraryFunctions.RemoveAt(0);
            libraryFunctions.RemoveAt(0);
            libraryFunctions.RemoveAt(0);
            libraryFunctions.Remove("ACCRINTM");
            libraryFunctions.Remove("AVERAGEIFS");
            libraryFunctions.Remove("BETA.DIST");
            libraryFunctions.Remove("BIGMUL");
            libraryFunctions.Remove("IMAGINARYDIFFERENCE");
            libraryFunctions.Remove("IMPRODUCT");
            libraryFunctions.Remove("IMSUB");
            libraryFunctions.Remove("F.INV.RT");
            libraryFunctions.Remove("HYPGEOM.DIST");
            libraryFunctions.Remove("IMCONJUGATE");
            libraryFunctions.Remove("MIRR");
            libraryFunctions.Remove("FORMULATEXT");
            libraryFunctions.Remove("GROWTH");
            libraryFunctions.Remove("IRR");
            libraryFunctions.Remove("MDETERN");
            libraryFunctions.Remove("MMULT");
            libraryFunctions.Remove("NORM.INV");
            libraryFunctions.Remove("PROPER");
            libraryFunctions.Remove("REPLACEB");
            libraryFunctions.Remove("UNICODE");
            libraryFunctions.Remove("XIRR");

            return libraryFunctions;
        }

        private void ClearFocus()
        {
            if (txtA1.IsFocused || txtA2.IsFocused || txtA3.IsFocused || txtA4.IsFocused || txtA5.IsFocused ||
                txtB1.IsFocused || txtB2.IsFocused || txtB3.IsFocused || txtB4.IsFocused || txtB5.IsFocused ||
                txtC1.IsFocused || txtC2.IsFocused || txtC3.IsFocused || txtC4.IsFocused || txtC5.IsFocused || 
                formulaEdit.IsFocused)
            {
                txtA1.ClearFocus();
                txtA2.ClearFocus();
                txtA3.ClearFocus();
                txtA4.ClearFocus();
                txtA5.ClearFocus();
                txtB1.ClearFocus();
                txtB2.ClearFocus();
                txtB3.ClearFocus();
                txtB4.ClearFocus();
                txtB5.ClearFocus();
                txtC1.ClearFocus();
                txtC2.ClearFocus();
                txtC3.ClearFocus();
                txtC4.ClearFocus();
                txtC5.ClearFocus();
                formulaEdit.ClearFocus();
            }

            Activity activity = (Activity)context;
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);

            if (activity.CurrentFocus != null)
            {
                inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
            }
        }

        public override void Destroy()
        {
            scrollView = null;
            formulaEdit = null;
            computedValueEdit = null;
            txtA1 = null;
            txtA2 = null;
            txtA3 = null;
            txtA4 = null;
            txtA5 = null;
            txtB1 = null;
            txtB2 = null;
            txtB3 = null;
            txtB4 = null;
            txtB5 = null;
            txtC1 = null;
            txtC2 = null;
            txtC3 = null;
            txtC4 = null;
            txtC5 = null;
            context = null;
            calcData = null;

            if (engine != null)
            {
                engine.Dispose();
            }

            base.Destroy();
        }

        public void Dispose()
        {
            if (scrollView != null)
            {
                scrollView.Dispose();
                scrollView = null;
            }

            if (formulaEdit != null)
            {
                formulaEdit.Dispose();
                formulaEdit = null;
            }

            if (computedValueEdit != null)
            {
                computedValueEdit.Dispose();
                computedValueEdit = null;
            }

            if (txtA1 != null)
            {
                txtA1.Dispose();
                txtA1 = null;
            }

            if (txtA2 != null)
            {
                txtA2.Dispose();
                txtA2 = null;
            }

            if (txtA3 != null)
            {
                txtA3.Dispose();
                txtA3 = null;
            }

            if (txtA4 != null)
            {
                txtA4.Dispose();
                txtA4 = null;
            }

            if (txtA5 != null)
            {
                txtA5.Dispose();
                txtA5 = null;
            }

            if (txtB1 != null)
            {
                txtB1.Dispose();
                txtB1 = null;
            }

            if (txtB2 != null)
            {
                txtB2.Dispose();
                txtB2 = null;
            }

            if (txtB3 != null)
            {
                txtB3.Dispose();
                txtB3 = null;
            }

            if (txtB4 != null)
            {
                txtB4.Dispose();
                txtB4 = null;
            }

            if (txtB5 != null)
            {
                txtB5.Dispose();
                txtB5 = null;
            }

            if (txtC1 != null)
            {
                txtC1.Dispose();
                txtC1 = null;
            }

            if (txtC2 != null)
            {
                txtC2.Dispose();
                txtC2 = null;
            }

            if (txtC3 != null)
            {
                txtC3.Dispose();
                txtC3 = null;
            }

            if (txtC4 != null)
            {
                txtC4.Dispose();
                txtC4 = null;
            }

            if (txtC5 != null)
            {
                txtC5.Dispose();
                txtC5 = null;
            }

            if (engine != null)
            {
                engine.Dispose();
                engine = null;
            }
        }
        #endregion
    }

    public class CalcData : ICalcData
    {
        public event ValueChangedEventHandler ValueChanged;

        public CalcData()
        {
        }

        private Dictionary<string, object> values = new Dictionary<string, object>();

        public object GetValueRowCol(int row, int col)
        {
            object value = null;

            var key = RangeInfo.GetAlphaLabel(col) + row;

            this.values.TryGetValue(key, out value);

            return value;
        }

        public void SetValueRowCol(object value, int row, int col)
        {
            var key = RangeInfo.GetAlphaLabel(col) + row;

            if (!values.ContainsKey(key))
            {
                values.Add(key, value);
            }
            else
            {
                if (values.ContainsKey(key) && values[key] != value)
                {
                    values[key] = value;
                }
            }
        }

        public void WireParentObject()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Verified")]
        private void OnValueChanged(int row, int col, string value)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new ValueChangedEventArgs(row, col, value));
            }
        }
    }
}