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
    public class CalcQuick : SamplePage, IDisposable
    {
        #region Fields

        private CalcQuickBase calcQuickBase;
        private ScrollView scrollView;
        private EditText editTextA;
        private EditText editTextB;
        private EditText editTextC;
        private TextViewExt result1;
        private TextViewExt result2;
        private TextViewExt result3;
        private TextView textA;
        private TextView textB;
        private TextView textC;
        private Context context;

        #endregion

        #region Methods

        public override View GetSampleContent(Context context)
        {
            this.context = context;

            CreateCalcQuickDesign(context);

            return scrollView;
        }

        private void CreateCalcQuickDesign(Context context)
        {
            int width = context.Resources.DisplayMetrics.WidthPixels;
            var density = context.Resources.DisplayMetrics.Density;

            InitializeCalcQuick();

            scrollView = new ScrollView(context);
            scrollView.SetPadding(10, 10, 10, 20);

            LinearLayout linearLayout = new LinearLayout(context);

            linearLayout.Orientation = Orientation.Vertical;
            linearLayout.Focusable = true;
            linearLayout.FocusableInTouchMode = true;

            LinearLayout linearLayout1 = new LinearLayout(context);

            linearLayout1.Orientation = Orientation.Vertical;

            TextView titleText = new TextView(context)
            {
                Text = "CalcQuick Calculation",
                TextAlignment = TextAlignment.Center,
                Gravity = GravityFlags.Center,
                TextSize = 30
            };
            titleText.SetTypeface(null, TypefaceStyle.Bold);
            titleText.SetWidth(width);
            titleText.SetHeight((int)(50 * density));

            TextView descText = new TextView(context)
            {
                Text = "This sample demonstrates the calculation via keys and expressions using CalcQuick.",
                TextAlignment = TextAlignment.TextStart,
                Gravity = GravityFlags.FillHorizontal,
                TextSize = 12
            };

            descText.SetPadding(0, 10, 0, 0);
            descText.SetWidth(width);
            descText.SetHeight((int)(40 * density));

            linearLayout1.AddView(titleText);
            linearLayout1.AddView(descText);

            LinearLayout linearLayout2 = new LinearLayout(context);
            LinearLayout linearLayout3 = new LinearLayout(context);
            LinearLayout linearLayout4 = new LinearLayout(context);

            linearLayout2.Orientation = Orientation.Horizontal;
            linearLayout3.Orientation = Orientation.Horizontal;
            linearLayout4.Orientation = Orientation.Horizontal;
            linearLayout2.SetPadding(0, 30, 0, 0);
            linearLayout3.SetPadding(0, 25, 0, 0);
            linearLayout4.SetPadding(0, 25, 0, 0);

            textA = CreateTextView(context, "Key A", 15);
            textA.SetWidth((int)(width * 0.5));
            textA.SetHeight((int)(20 * density));

            textB = CreateTextView(context, "Key B", 15);
            textB.SetWidth((int)(width * 0.5));
            textB.SetHeight((int)(20 * density));

            textC = CreateTextView(context, "Key C", 15);
            textC.SetWidth((int)(width * 0.5));
            textC.SetHeight((int)(20 * density));

            editTextA = CreateEditText(context, calcQuickBase["A"]);
            editTextA.SetWidth(width - (int)(width * 0.5));
            editTextA.SetHeight((int)(20 * density));
            editTextA.SetSingleLine(true);

            editTextB = CreateEditText(context, calcQuickBase["B"]);
            editTextB.SetWidth(width - (int)(width * 0.5));
            editTextB.SetHeight((int)(20 * density));
            editTextB.SetSingleLine(true);

            editTextC = CreateEditText(context, calcQuickBase["C"]);
            editTextC.SetWidth(width - (int)(width * 0.5));
            editTextC.SetHeight((int)(20 * density));
            editTextC.SetSingleLine(true);

            linearLayout2.AddView(textA);
            linearLayout3.AddView(textB);
            linearLayout4.AddView(textC);
            linearLayout2.AddView(editTextA);
            linearLayout3.AddView(editTextB);
            linearLayout4.AddView(editTextC);

            LinearLayout linearLayout5 = new LinearLayout(context);
            linearLayout5.SetPadding(0, 15, 0, 0);

            Button compute = new Button(context);
            compute.Text = "Compute";
            compute.Click += Compute_Click;
            compute.SetWidth(width);
            compute.SetHeight((int)(20 * density));

            linearLayout5.AddView(compute);

            LinearLayout linearLayout6 = new LinearLayout(context);
            LinearLayout linearLayout7 = new LinearLayout(context);
            LinearLayout linearLayout8 = new LinearLayout(context);
            LinearLayout linearLayout9 = new LinearLayout(context);

            linearLayout6.Orientation = Orientation.Horizontal;
            linearLayout7.Orientation = Orientation.Horizontal;
            linearLayout8.Orientation = Orientation.Horizontal;
            linearLayout9.Orientation = Orientation.Horizontal;
            linearLayout6.SetPadding(0, 40, 0, 0);
            linearLayout7.SetPadding(0, 60, 0, 0);
            linearLayout8.SetPadding(0, 60, 0, 0);
            linearLayout9.SetPadding(0, 60, 0, 0);

            TextView expTitle = CreateTextView(context, "Expressions", 22);
            expTitle.SetTypeface(null, TypefaceStyle.Bold);
            expTitle.SetWidth(width);
            expTitle.SetHeight((int)(30 * density));

            TextView expression1 = CreateTextView(context, "Sum([A],[B],[C])", 15);
            expression1.SetWidth((int)(width * 0.5));
            expression1.SetHeight((int)(20 * density));

            TextView expression2 = CreateTextView(context, "PI()*([A]^2)", 15);
            expression2.SetWidth((int)(width * 0.5));
            expression2.SetHeight((int)(20 * density));

            TextView expression3 = CreateTextView(context, "Concatenate([A],[B],[C])", 15);
            expression3.SetWidth((int)(width * 0.5));
            expression2.SetHeight((int)(20 * density));

            result1 = CreateTextViewExt(context, calcQuickBase["Exp1"]);
            result1.SetWidth(width - (int)(width * 0.5));
            result1.SetHeight((int)(20 * density));
            result1.SetSingleLine(true);

            result2 = CreateTextViewExt(context, calcQuickBase["Exp2"]);
            result2.SetWidth(width - (int)(width * 0.5));
            result2.SetHeight((int)(20 * density));
            result2.SetSingleLine(true);

            result3 = CreateTextViewExt(context, calcQuickBase["Exp3"]);
            result3.SetWidth(width - (int)(width * 0.5));
            result3.SetHeight((int)(20 * density));
            result3.SetSingleLine(true);

            linearLayout6.AddView(expTitle);
            linearLayout7.AddView(expression1);
            linearLayout8.AddView(expression2);
            linearLayout9.AddView(expression3);
            linearLayout7.AddView(result1);
            linearLayout8.AddView(result2);
            linearLayout9.AddView(result3);

            linearLayout.AddView(linearLayout1);
            linearLayout.AddView(linearLayout2);
            linearLayout.AddView(linearLayout3);
            linearLayout.AddView(linearLayout4);
            linearLayout.AddView(linearLayout5);
            linearLayout.AddView(linearLayout6);
            linearLayout.AddView(linearLayout7);
            linearLayout.AddView(linearLayout8);
            linearLayout.AddView(linearLayout9);

            linearLayout.Touch += (object sender, View.TouchEventArgs e) => 
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    ClearFocus();
                }
            };

            scrollView.AddView(linearLayout);
        }

        private void Compute_Click(object sender, EventArgs e)
        {
            calcQuickBase["A"] = editTextA.Text;
            calcQuickBase["B"] = editTextB.Text;
            calcQuickBase["C"] = editTextC.Text;

            calcQuickBase.SetDirty();

            result1.Text = calcQuickBase["Exp1"];
            result2.Text = calcQuickBase["Exp2"];
            result3.Text = calcQuickBase["Exp3"];

            ClearFocus();
        }

        private void InitializeCalcQuick()
        {
            calcQuickBase = new CalcQuickBase();

            calcQuickBase["A"] = "25";
            calcQuickBase["B"] = "50";
            calcQuickBase["C"] = "10";

            calcQuickBase["Exp1"] = "=Sum([A],[B],[C])";
            calcQuickBase["Exp2"] = "=PI()*([A]^2)";
            calcQuickBase["Exp3"] = "=Concatenate([A],[B],[C])";
        }

        private TextView CreateTextView(Context context, string text, int size)
        {
           return new TextView(context)
            {
                Text = text,
                Gravity = GravityFlags.Start,
                TextSize = size
            };
        }

        private EditText CreateEditText(Context context, string text)
        {
            return new EditText(context)
            {
                Text = text,
                TextSize = 15
            };
        }

        private TextViewExt CreateTextViewExt(Context context, string text)
        {
            return new TextViewExt(context)
            {
                Text = text,
                TextSize = 15
            };
        }

        private void ClearFocus()
        {
            if (editTextA.IsFocused || editTextB.IsFocused || editTextC.IsFocused)
            {
                editTextA.ClearFocus();
                editTextB.ClearFocus();
                editTextC.ClearFocus();
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
            calcQuickBase.Dispose();
            calcQuickBase = null;
            editTextA = null;
            editTextB = null;
            editTextC = null;
            result1 = null;
            result2 = null;
            result3 = null;
            textA = null;
            textB = null;
            textC = null;
            context = null;
            base.Destroy();
        }

        public void Dispose()
        {
            if (scrollView != null)
            {
                scrollView.Dispose();
                scrollView = null;
            }

            if (calcQuickBase != null)
            {
                calcQuickBase.Dispose();
                calcQuickBase = null;
            }

            if (editTextA != null)
            {
                editTextA.Dispose();
                editTextA = null;
            }

            if (editTextB != null)
            {
                editTextB.Dispose();
                editTextB = null;
            }

            if (editTextC != null)
            {
                editTextC.Dispose();
                editTextC = null;
            }

            if (result1 != null)
            {
                result1.Dispose();
                result1 = null;
            }

            if (result2 != null)
            {
                result2.Dispose();
                result2 = null;
            }

            if (result3 != null)
            {
                result3.Dispose();
                result3 = null;
            }

            if (textA != null)
            {
                textA.Dispose();
                textA = null;
            }

            if (textB != null)
            {
                textB.Dispose();
                textB = null;
            }

            if (textC != null)
            {
                textC.Dispose();
                textC = null;
            }
        }
        #endregion
    }

    public class TextViewExt : TextView
    {
        private Paint paintBorder;

        public TextViewExt(Context context)
            : base(context)
        {
            paintBorder = new Paint(PaintFlags.AntiAlias);
            paintBorder.Color = Color.Black;
            paintBorder.TextAlign = Android.Graphics.Paint.Align.Center;
            paintBorder.SetStyle(Android.Graphics.Paint.Style.FillAndStroke);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawLine(0, this.Height, this.Width, this.Height, paintBorder);
        }
    }
}