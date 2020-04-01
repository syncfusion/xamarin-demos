#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Collections.Generic;


#endregion
using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using Syncfusion.Office;
using Syncfusion.DocIORenderer;
using System.IO;
using COLOR = Syncfusion.Drawing;
using System.Reflection;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
#endif

namespace SampleBrowser
{
    public partial class CreateEquation : SampleView
    {
        CGRect frameRect = new CGRect();
        float frameMargin = 8.0f;
        UILabel label;
        UIButton button;

        public CreateEquation()
        {
            label = new UILabel();
            button = new UIButton(UIButtonType.System);
            button.TouchUpInside += OnButtonClicked;
        }

        void LoadAllowedTextsLabel()
        {
            label.Frame = frameRect;
            label.TextColor = UIColor.FromRGB(38 / 255.0f, 38 / 255.0f, 38 / 255.0f);
            label.Text = "This sample demonstrates how to create a Word document with mathematical equations using Essential DocIO.";
            label.Lines = 0;
            label.Font = UIFont.SystemFontOfSize(15);
            label.LineBreakMode = UILineBreakMode.WordWrap;
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                label.Font = UIFont.SystemFontOfSize(18);
                label.Frame = new CGRect(5, 5, frameRect.Location.X + frameRect.Size.Width, 70);
            }
            else
            {
                label.Frame = new CGRect(frameRect.Location.X, 5, frameRect.Size.Width, 70);
            }
            this.AddSubview(label);

            button.SetTitle("Generate Word", UIControlState.Normal);
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                button.Frame = new CGRect(5, 90, frameRect.Location.X + frameRect.Size.Width, 10);
            }
            else
            {
                button.Frame = new CGRect(frameRect.Location.X, 90, frameRect.Size.Width, 10);
            }
            button.TouchUpInside += OnButtonClicked;
            this.AddSubview(button);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            //Creates a new word document instance
            WordDocument document = new WordDocument();
            //Adds new section to the document
            IWSection section = document.AddSection();
            //Sets page margins
            document.LastSection.PageSetup.Margins.All = 72;
            //Adds new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();

            //Appends text to paragraph
            IWTextRange textRange = paragraph.AppendText("Mathematical equations");
            textRange.CharacterFormat.FontSize = 28;
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            paragraph.ParagraphFormat.AfterSpacing = 12;

            #region Sum to the power of n
            //Adds new paragraph to the section
            paragraph = AddParagraph(section, "This is an expansion of the sum (1+X) to the power of n.");
            //Creates an equation with sum to the power of N
            CreateSumToThePowerOfN(paragraph);
            #endregion

            #region Fourier series
            //Adds new paragraph to the section
            paragraph = AddParagraph(section, "This is a Fourier series for the function of period 2L");
            //Creates a Fourier series equation
            CreateFourierseries(paragraph);
            #endregion

            #region Triple scalar product
            //Adds new paragraph to the section
            paragraph = AddParagraph(section, "This is an expansion of triple scalar product");
            //Creates a triple scalar product equation
            CreateTripleScalarProduct(paragraph);
            #endregion

            #region Gamma function
            //Adds new paragraph to the section
            paragraph = AddParagraph(section, "This is an expansion of gamma function");
            //Creates a gamma function equation
            CreateGammaFunction(paragraph);
            #endregion

            #region Vector relation
            //Adds new paragraph to the section
            paragraph = AddParagraph(section, "This is an expansion of vector relation ");
            //Creates a vector relation equation
            CreateVectorRelation(paragraph);
            #endregion

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (stream != null)
            {
                SaveiOS iOSSave = new SaveiOS();
                iOSSave.Save("CreateEquation.docx", "application/msword", stream);
            }
        }
        public override void LayoutSubviews()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                frameMargin = 0.0f;
            }
            frameRect = Frame;
            frameRect.Location = new CGPoint(frameRect.Location.X + frameMargin, frameRect.Location.Y + 1.5f * frameMargin);
            frameRect.Size = new CGSize(frameRect.Size.Width - (frameRect.Location.X + frameMargin), frameRect.Size.Height - (frameRect.Location.Y + 1.5f * frameMargin));
            LoadAllowedTextsLabel();
            base.LayoutSubviews();
        }
        #region Helper Methods
        /// <summary>
        /// Adds new paragraph into the section
        /// </summary>
        /// <param name="section">Represents a section in Word document</param>
        /// <param name="text">Represents a text to append in paragraph</param>
        /// <returns>Returns a paragraph to add equation</returns>
        private IWParagraph AddParagraph(IWSection section, string text)
        {
            //Adds new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();
            //Adds new paragraph to add text
            paragraph = section.AddParagraph();
            //Appends text to paragraph
            paragraph.AppendText(text);
            paragraph.ParagraphFormat.AfterSpacing = 12;
            paragraph.ParagraphFormat.BeforeSpacing = 12;
            //Adds new paragraph to add equation
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.AfterSpacing = 12;
            return paragraph;
        }
        /// <summary>
        /// Creates an expansion of triple scalar product
        /// </summary>
        /// <param name="paragraph">Represents a paragraph to add MathML element</param>
        private void CreateTripleScalarProduct(IWParagraph paragraph)
        {
            WordDocument document = paragraph.Document;
            //Creates a MathML element
            WMath math = new WMath(document);
            //Adds an office math
            IOfficeMath officeMath = math.MathPara.Maths.Add(0);

            #region Math text
            //Unicode value of middle dot
            string middleDot = "\u00B7";
            string text = "A" + middleDot + "B×C";
            //Adds a math item
            IOfficeMathParaItem officeMathParaItem = AddMathText(document, officeMath, 0, text);
            //Sets style for math text
            officeMathParaItem.MathFormat.Style = MathStyleType.Bold;

            //Adds math text
            officeMathParaItem = AddMathText(document, officeMath, 1, "=");
            //Sets style for math text
            officeMathParaItem.MathFormat.Style = MathStyleType.Bold;

            //Adds math text
            text = "A×B" + middleDot + "C";
            officeMathParaItem = AddMathText(document, officeMath, 2, text);
            //Sets style for math text
            officeMathParaItem.MathFormat.Style = MathStyleType.Bold;

            //Adds math text
            officeMathParaItem = AddMathText(document, officeMath, 3, "=");
            #endregion

            #region Delimiter
            //Adds a delimiter 
            IOfficeMathDelimiter mathDelimiter = officeMath.Functions.Add(4, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Sets begin character for delimiter
            mathDelimiter.BeginCharacter = "|";
            //Sets end character for delimiter
            mathDelimiter.EndCharacter = "|";
            //Apply formats for delimiter
            mathDelimiter.ControlProperties = new WCharacterFormat(document);
            (mathDelimiter.ControlProperties as WCharacterFormat).Italic = true;

            //Adds arguments for delimiter
            officeMath = mathDelimiter.Equation.Add(0) as IOfficeMath;

            #region Matrix
            //Add matrix into delimiter
            IOfficeMathMatrix mathMatrix = officeMath.Functions.Add(0, MathFunctionType.Matrix) as IOfficeMathMatrix;

            #region First row
            //Adds a  new row
            IOfficeMathMatrixRow mathMatrixRow = mathMatrix.Rows.Add(0);
            ///Add values to row
            AddMatrixRowValues(document, mathMatrixRow, "A");
            #endregion

            #region Second row
            //Adds a  new row
            mathMatrixRow = mathMatrix.Rows.Add(1);
            ///Add values to row
            AddMatrixRowValues(document, mathMatrixRow, "B");
            #endregion

            #region Third row
            //Adds a  new row
            mathMatrixRow = mathMatrix.Rows.Add(2);
            ///Add values to row
            AddMatrixRowValues(document, mathMatrixRow, "C");
            #endregion
            #endregion

            #endregion
            //Adds MathML element into paragraph
            paragraph.Items.Add(math);
        }
        /// <summary>
        /// Creates an expansion of vector relation
        /// </summary>
        /// <param name="paragraph">Represents a paragraph to add MathML element</param>
        private void CreateVectorRelation(IWParagraph paragraph)
        {
            WordDocument document = paragraph.Document;
            //Creates a MathML element
            WMath math = new WMath(document);

            IOfficeMath officeMath = math.MathPara.Maths.Add(0);
            //Adds an accent equation
            AddMathAccent(document, officeMath, 8407, "A");

            //Adds a math text
            string middleDot = "\u00B7";
            officeMath = math.MathPara.Maths.Add(1);
            IOfficeMathParaItem officeMathParaItem = AddMathText(document, officeMath, 0, middleDot);

            //Adds an accent equation
            officeMath = math.MathPara.Maths.Add(2);
            AddMathAccent(document, officeMath, 8407, "B");

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(3);
            officeMathParaItem = AddMathText(document, officeMath, 0, "×");

            //Adds an accent equation
            officeMath = math.MathPara.Maths.Add(4);
            AddMathAccent(document, officeMath, 8407, "C");

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(5);
            officeMathParaItem = AddMathText(document, officeMath, 0, "=");

            //Adds an accent equation
            officeMath = math.MathPara.Maths.Add(6);
            AddMathAccent(document, officeMath, 8407, "A");

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(7);
            officeMathParaItem = AddMathText(document, officeMath, 0, "×");

            //Adds an accent equation
            officeMath = math.MathPara.Maths.Add(8);
            AddMathAccent(document, officeMath, 8407, "B");

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(9);
            officeMathParaItem = AddMathText(document, officeMath, 0, middleDot);

            //Adds an accent equation
            officeMath = math.MathPara.Maths.Add(10);
            AddMathAccent(document, officeMath, 8407, "C");
            //Adds the math to the paragraph
            paragraph.Items.Add(math);
        }
        /// <summary>
        /// Converts short value to string
        /// </summary>
        /// <param name="value">Represents a short value</param>
        private static string ConvertShortToString(short value)
        {
            char chrValue = Convert.ToChar(value);
            string strValue = Convert.ToString(chrValue);
            return strValue;
        }
        /// <summary>
        /// Creates an equation with sum to the power of N
        /// </summary>
        /// <param name="paragraph">Represents a paragraph to add MathML element</param>
        private void CreateSumToThePowerOfN(IWParagraph paragraph)
        {
            WordDocument document = paragraph.Document;
            //Creates a new MathML element
            WMath math = new WMath(document);

            IOfficeMath officeMath = math.MathPara.Maths.Add(0);
            //Adds a math script element
            IOfficeMathScript mathScript = AddMathScript(officeMath, 0, MathScriptType.Superscript);

            #region Delimiter equation
            //Adds a delimiter
            IOfficeMathDelimiter mathDelimiter = mathScript.Equation.Functions.Add(0, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds an office math in the delimiter
            officeMath = mathDelimiter.Equation.Add(0) as IOfficeMath;
            //Adds a math text
            IOfficeMathParaItem mathParaItem = AddMathText(document, officeMath, 0, "1+x");
            //Adds a math text
            mathParaItem = AddMathText(document, mathScript.Script, 0, "n");
            #endregion

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(1);
            mathParaItem = AddMathText(document, officeMath, 0, "=1+");

            #region Fraction equation
            //Adds a math fraction
            IOfficeMathFraction mathFraction = math.MathPara.Maths.Add(2).Functions.Add(0, MathFunctionType.Fraction) as IOfficeMathFraction;
            //Adds a numerator text
            AddMathText(document, mathFraction.Numerator, 0, "nx");
            //Adds a denominator text
            AddMathText(document, mathFraction.Denominator, 0, "1!");
            #endregion

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(3);
            mathParaItem = AddMathText(document, officeMath, 0, "+");

            #region Fraction equation
            //Adds a math fraction
            mathFraction = math.MathPara.Maths.Add(4).Functions.Add(0, MathFunctionType.Fraction) as IOfficeMathFraction;

            #region Numerator
            //Adds a numerator text
            AddMathText(document, mathFraction.Numerator, 0, "n");

            //Adds a delimiter
            mathDelimiter = mathFraction.Numerator.Functions.Add(1, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds a math text for delimiter
            officeMath = mathDelimiter.Equation.Add(0) as IOfficeMath;
            AddMathText(document, officeMath, 0, "n-1");

            //Adds a math script
            mathScript = mathFraction.Numerator.Functions.Add(2, MathFunctionType.SubSuperScript) as IOfficeMathScript;
            //Adds a math text for Superscript
            AddMathText(document, mathScript.Equation, 0, "x");
            AddMathText(document, mathScript.Script, 0, "2");
            #endregion

            #region Denominator
            //Adds a math text for denominator
            AddMathText(document, mathFraction.Denominator, 0, "2!");
            #endregion
            #endregion

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(5);
            AddMathText(document, officeMath, 0, "+...");
            //Adds MathML element into paragraph
            paragraph.Items.Add(math);
        }
        /// <summary>
        /// Creates an expansion of Gamma function
        /// </summary>
        /// <param name="paragraph">Represents a paragraph to add MathML element</param>
        private void CreateGammaFunction(IWParagraph paragraph)
        {
            WordDocument document = paragraph.Document;
            //Creates a new MathML element
            WMath math = new WMath(document);

            //Adds a math text
            IOfficeMath officeMath = math.MathPara.Maths.Add(0);
            //Unicode value of capital gamma
            string capitalGamma = "\u0393";
            IOfficeMathParaItem officeMathParaItem = AddMathText(document, officeMath, 0, capitalGamma);
            //Sets MathML style format for the text
            officeMathParaItem.MathFormat.Style = MathStyleType.Regular;

            //Adds a delimiter equation
            IOfficeMathDelimiter mathDelimiter = math.MathPara.Maths.Add(1).Functions.Add(0, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds a equation to the delimiter
            officeMath = mathDelimiter.Equation.Add(0);
            //Adds a math text
            officeMathParaItem = AddMathText(document, officeMath, 0, "z");

            //Adds a math text
            officeMath = math.MathPara.Maths.Add(2);
            officeMathParaItem = AddMathText(document, officeMath, 0, "=");

            //Adds an n array element
            IOfficeMathNArray mathNAry = math.MathPara.Maths.Add(3).Functions.Add(0, MathFunctionType.NArray) as IOfficeMathNArray;
            //Adds a math text
            AddMathText(document, mathNAry.Subscript, 0, "0");

            //Adds a math text
            string infinitySymbol = "\u221E";
            AddMathText(document, mathNAry.Superscript, 0, infinitySymbol);

            //Adds a math superscript
            IOfficeMathScript mathScript = AddMathScript(mathNAry.Equation, 0, MathScriptType.Superscript);
            //Adds a math text for Superscript
            AddMathText(document, mathScript.Equation, 0, "t");
            AddMathText(document, mathScript.Script, 0, "z-1");
            //Adds a Superscript
            mathScript = AddMathScript(mathNAry.Equation, 1, MathScriptType.Superscript);

            AddMathText(document, mathScript.Equation, 0, "e");
            AddMathText(document, mathScript.Script, 0, "-t");

            //Adds a math text in n Array equation
            AddMathText(document, mathNAry.Equation, 2, "dt");

            //Adds a math text
            AddMathText(document, math.MathPara.Maths.Add(4), 0, "=");

            //Adds a fraction equation
            IOfficeMathFraction mathFraction = math.MathPara.Maths.Add(5).Functions.Add(0, MathFunctionType.Fraction) as IOfficeMathFraction;
            //Adds a math script
            mathScript = AddMathScript(mathFraction.Numerator, 0, MathScriptType.Superscript);

            //Adds a math text for Superscript
            AddMathText(document, mathScript.Equation, 0, "e");
            AddMathText(document, mathScript.Script, 0, "-");
            //Unicode of small gamma
            string smallGamma = "\u03B3";
            AddMathText(document, mathScript.Script, 1, smallGamma);
            AddMathText(document, mathScript.Script, 2, "z");


            //Adds a math text for denominator
            AddMathText(document, mathFraction.Denominator, 0, "z");

            //Adds an n-array element
            mathNAry = math.MathPara.Maths.Add(6).Functions.Add(0, MathFunctionType.NArray) as IOfficeMathNArray;
            //Unicode value of n-array product
            string symbol = "\u220F";
            //Adds a n-array character
            mathNAry.NArrayCharacter = symbol;
            //Adds a math text
            AddMathText(document, mathNAry.Subscript, 0, "k=1");
            //Adds a math text
            AddMathText(document, mathNAry.Superscript, 0, infinitySymbol);

            //Adds a math script
            mathScript = AddMathScript(mathNAry.Equation, 0, MathScriptType.Superscript);
            //Adds a math delimiter element
            mathDelimiter = mathScript.Equation.Functions.Add(0, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds a equation to the delimiter equation collection
            officeMath = mathDelimiter.Equation.Add(0);
            //Adds a math text
            AddMathText(document, officeMath, 0, "1+");

            //Adds a fraction element
            mathFraction = officeMath.Functions.Add(1, MathFunctionType.Fraction) as IOfficeMathFraction;
            //Adds a math text for numerator
            AddMathText(document, mathFraction.Numerator, 0, "z");
            //Adds a math text for denominator
            AddMathText(document, mathFraction.Denominator, 0, "k");

            //Adds a math text
            AddMathText(document, mathScript.Script, 0, "-1");
            //Adds a Superscript equation
            mathScript = AddMathScript(mathNAry.Equation, 1, MathScriptType.Superscript);
            //Adds a math text for Superscript
            AddMathText(document, mathScript.Equation, 0, "e");
            AddMathText(document, mathScript.Script, 0, "z");
            officeMathParaItem = AddMathText(document, mathScript.Script, 1, "/");
            officeMathParaItem.MathFormat.HasLiteral = true;
            AddMathText(document, mathScript.Script, 2, "k");

            //Adds a math text
            AddMathText(document, math.MathPara.Maths.Add(7), 0, ",");

            //Adds a math text
            officeMathParaItem = AddMathText(document, math.MathPara.Maths.Add(8), 0, "  ");
            //Sets style for math text
            officeMathParaItem.MathFormat.Style = MathStyleType.Regular;

            //Adds a math text
            AddMathText(document, math.MathPara.Maths.Add(9), 0, smallGamma);
            string text = "\u2248" + "0.577216";
            AddMathText(document, math.MathPara.Maths.Add(10), 0, text);
            //Adds MathML element into paragraph
            paragraph.Items.Add(math);
        }
        /// <summary>
        /// Creates a Fourier series equation
        /// </summary>
        /// <param name="paragraph">Represents a paragraph to add MathML element</param>
        private void CreateFourierseries(IWParagraph paragraph)
        {
            WordDocument document = paragraph.Document;
            //Creates a new MathML element
            WMath math = new WMath(document);

            //Adds a math
            IOfficeMath officeMath = math.MathPara.Maths.Add(0);
            //Adds a math text
            AddMathText(document, officeMath, 0, "f");

            //Adds a math delimiter
            IOfficeMathDelimiter mathDelimiter = math.MathPara.Maths.Add(1).Functions.Add(0, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds a math in the delimiter
            officeMath = mathDelimiter.Equation.Add(0) as IOfficeMath;
            //Adds a math text
            AddMathText(document, officeMath, 0, "x");
            AddMathText(document, math.MathPara.Maths.Add(2), 0, "=");
            //Adds a Subscript equation
            IOfficeMathScript mathScript = AddMathScript(math.MathPara.Maths.Add(3), 0, MathScriptType.Subscript);
            //Adds a math text
            AddMathText(document, mathScript.Equation, 0, "a");
            AddMathText(document, mathScript.Script, 0, "0");

            //Adds a math text
            AddMathText(document, math.MathPara.Maths.Add(4), 0, "+");

            //Adds a math n-array
            IOfficeMathNArray mathNAry = math.MathPara.Maths.Add(5).Functions.Add(0, MathFunctionType.NArray) as IOfficeMathNArray;
            //Unicode value of n-array summation
            string sigma = "\u2211";
            //Sets the value as the n-array character
            mathNAry.NArrayCharacter = sigma;
            mathNAry.HasGrow = true;
            //Adds a math text
            AddMathText(document, mathNAry.Subscript, 0, "n=1");

            //Adds a math text
            string infinitySymbol = "\u221E";
            AddMathText(document, mathNAry.Superscript, 0, infinitySymbol);
            //Adds a math delimiter
            mathDelimiter = mathNAry.Equation.Functions.Add(0, MathFunctionType.Delimiter) as IOfficeMathDelimiter;
            //Adds an math in the delimiter equation collection
            officeMath = mathDelimiter.Equation.Add(0) as IOfficeMath;
            //Adds a math script
            mathScript = AddMathScript(officeMath, 0, MathScriptType.Subscript);

            //Adds a math text
            AddMathText(document, mathScript.Equation, 0, "a");

            //Adds a math text
            AddMathText(document, mathScript.Script, 0, "n");

            //Adds a math function
            IOfficeMathFunction mathFunction = officeMath.Functions.Add(1, MathFunctionType.Function) as IOfficeMathFunction;
            //Adds a math text
            IOfficeMathParaItem mathParaItem = AddMathText(document, mathFunction.FunctionName, 0, "cos");
            mathParaItem.MathFormat.Style = MathStyleType.Regular;

            //Adds a math fraction
            IOfficeMathFraction mathFraction = mathFunction.Equation.Functions.Add(0, MathFunctionType.Fraction) as IOfficeMathFraction;
            //Adds a math text
            //Unicode value of PI
            string pi = "\uD835\uDF0B";
            string text = "n" + pi + "x";
            AddMathText(document, mathFraction.Numerator, 0, text);
            AddMathText(document, mathFraction.Denominator, 0, "L");

            //Adds a math text
            AddMathText(document, officeMath, 2, "+");
            //Adds a math script
            mathScript = AddMathScript(officeMath, 3, MathScriptType.Subscript);
            //Adds a math text
            AddMathText(document, mathScript.Equation, 0, "b");
            AddMathText(document, mathScript.Script, 0, "n");

            //Adds a function
            mathFunction = officeMath.Functions.Add(4, MathFunctionType.Function) as IOfficeMathFunction;
            //Adds a math text
            mathParaItem = AddMathText(document, mathFunction.FunctionName, 0, "sin");
            mathParaItem.MathFormat.Style = MathStyleType.Regular;

            //Adds a math fraction element
            mathFraction = mathFunction.Equation.Functions.Add(0, MathFunctionType.Fraction) as IOfficeMathFraction;
            //Adds a math text for numerator
            AddMathText(document, mathFraction.Numerator, 0, text);
            //Adds a math text for denominator
            AddMathText(document, mathFraction.Denominator, 0, "L");
            //Adds MathML element into paragraph
            paragraph.Items.Add(math);
        }
        /// <summary>
        /// Adds a math text
        /// </summary>
        /// <param name="document">Represents a Word document to add math text</param>
        /// <param name="officeMath">Represents an office math to add math text</param>
        /// <param name="index">Represents an index, where to add math text</param>
        /// <param name="text">Represents the text to set for math item</param>
        private IOfficeMathParaItem AddMathText(WordDocument document, IOfficeMath officeMath, int index, string text)
        {
            //Adds math text
            IOfficeMathParaItem officeMathParaItem = officeMath.Functions.Add(index, MathFunctionType.RunElement) as IOfficeMathParaItem;
            officeMathParaItem.Item = new WTextRange(document);
            //Set math text value
            (officeMathParaItem.Item as WTextRange).Text = text;
            return officeMathParaItem;
        }
        /// <summary>
        /// Adds a math Subscript or Superscript equation
        /// </summary>
        private IOfficeMathScript AddMathScript(IOfficeMath officeMath, int index, MathScriptType mathScriptType)
        {
            IOfficeMathScript mathScript = officeMath.Functions.Add(index, MathFunctionType.SubSuperScript) as IOfficeMathScript;
            //Sets the script type as Subscript or Superscript
            mathScript.ScriptType = mathScriptType;
            return mathScript;
        }
        /// <summary>
        /// Adds a accent equation
        /// </summary>
        /// <param name="document">Represents a Word document</param>
        /// <param name="officeMath">Represents a office math to add accent equation</param>
        /// <param name="accentCharValue">Represents a accent character</param>
        /// <param name="text">Represents a text for accent equation</param>
        private void AddMathAccent(WordDocument document, IOfficeMath officeMath, short accentCharValue, string text)
        {
            IOfficeMathAccent mathAccent = officeMath.Functions.Add(0, MathFunctionType.Accent) as IOfficeMathAccent;
            //Sets the accent character from short value
            mathAccent.AccentCharacter = ConvertShortToString(accentCharValue);
            //Adds a math text
            IOfficeMathParaItem officeMathParaItem = AddMathText(document, mathAccent.Equation, 0, text);
        }
        /// <summary>
        /// Add values in matrix row
        /// </summary>
        /// <param name="document">Represents a Word document to add matrix</param>
        /// <param name="mathMatrixRow">Represents a matrix row to add values</param>
        /// <param name="text">Represents a base text value for Subscript and Superscript equation</param>
        private void AddMatrixRowValues(WordDocument document, IOfficeMathMatrixRow mathMatrixRow, string text)
        {
            //Adds arguments for matrix row
            IOfficeMath officeMath = mathMatrixRow.Args.Add(0);
            //Adds a Subscript
            IOfficeMathScript mathScript = AddMathScript(officeMath, 0, MathScriptType.Subscript);
            //Adds a math text
            IOfficeMathParaItem officeMathParaItem = AddMathText(document, mathScript.Equation, 0, text);
            //Adds math text
            officeMathParaItem = AddMathText(document, mathScript.Script, 0, "x");

            //Adds arguments for matrix row
            officeMath = mathMatrixRow.Args.Add(1);
            //Adds a script
            mathScript = AddMathScript(officeMath, 0, MathScriptType.Subscript);
            //Adds math text
            officeMathParaItem = AddMathText(document, mathScript.Equation, 0, text);
            //Adds math text
            officeMathParaItem = AddMathText(document, mathScript.Script, 0, "y");

            //Adds arguments for matrix row
            officeMath = mathMatrixRow.Args.Add(2);
            //Adds a script
            mathScript = AddMathScript(officeMath, 0, MathScriptType.Subscript);
            //Adds math text
            officeMathParaItem = AddMathText(document, mathScript.Equation, 0, text);
            //Adds math text
            officeMathParaItem = AddMathText(document, mathScript.Script, 0, "z");
        }
        #endregion
    }
}