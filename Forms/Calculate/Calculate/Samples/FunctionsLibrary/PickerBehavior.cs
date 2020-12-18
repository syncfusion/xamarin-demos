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
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.Calculate
{
    [Preserve(AllMembers = true)]
    public class PickerBehavior : Behavior<Picker>
    {
        private FunctionsLibraryViewModel viewModel;

        protected override void OnAttachedTo(Picker bindable)
        {
            base.OnAttachedTo(bindable);
            viewModel = bindable.BindingContext as FunctionsLibraryViewModel;
            bindable.SelectedIndexChanged += Bindable_SelectedIndexChanged;
        }

        protected override void OnDetachingFrom(Picker bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SelectedIndexChanged -= Bindable_SelectedIndexChanged;
        }

        private void Bindable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string item = picker.Items[picker.SelectedIndex];

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
                    viewModel.TxtGen = "=" + item + "(A1,B1,C1,C4)";
                    break;
                case "PI":
                    viewModel.TxtGen = "=" + item + "()*(A1+B1*C1)";
                    break;
                case "VLOOKUP":
                    viewModel.TxtGen = "=" + item + "(A1,A2:C5,2,true)";
                    break;
                case "HLOOKUP":
                    viewModel.TxtGen = "=" + item + "(A1,A2:C5,3,true)";
                    break;
                case "INDEX":
                    viewModel.TxtGen = "=" + item + "(A1:C5,3,2)";
                    break;
                case "CHAR":
                case "UNICHAR":
                    viewModel.TxtGen = "=" + item + "(C2)";
                    break;
                case "DB":
                case "DDB":
                    viewModel.TxtGen = "=" + item + "(A1,B1,C1,5)";
                    break;
                case "HYPGEOMDIST":
                    viewModel.TxtGen = "=" + item + "(C1,A2,A1,B1)";
                    break;
                case "IMSUM":
                case "IMSQRT":
                case "IMDIV":
                    viewModel.TxtGen = "=" + item + "(\"1+4i\",\"1+3i\")";
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
                    viewModel.TxtGen = "=" + item + "(A1)";
                    break;
                case "MORMSINV":
                    viewModel.TxtGen = "=" + item + "(A1/100)";
                    break;
                case "NORMINV":
                    viewModel.TxtGen = "=" + item + "(0.98,A2,A3)";
                    break;
                case "FINV":
                    viewModel.TxtGen = "=" + item + "(1,A1,B1)";
                    break;
                case "IFERROR":
                    viewModel.TxtGen = "=" + item + "(A1,\"Error in calculation\")";
                    break;
                case "ACOS":
                case "ASECH":
                    viewModel.TxtGen = "=" + item + "(0.5)";
                    break;
                case "ASIN":
                case "ATANH":
                case "FISHER":
                    viewModel.TxtGen = "=" + item + "(0.6)";
                    break;
                case "BIN2DEC":
                case "BIN2OCT":
                case "BIN2HEX":
                    viewModel.TxtGen = "=" + item + "(11000011)";
                    break;
                case "LARGE":
                case "QUARTILE":
                case "QUARTILE.EXC":
                case "QUARTILE.INC":
                case "SMALL":
                    viewModel.TxtGen = "=" + item + "({C1,A2,C4,B2},3)";
                    break;
                case "CORREL":
                case "COVARIANCE.P":
                case "COVARIANCE.S":
                case "INTERCEPT":
                case "PEARSON":
                case "RSQ":
                case "SLOPE":
                case "STEYX":
                    viewModel.TxtGen = "=" + item + "({C1,A2,C4},{B2,A1,C5})";
                    break;
                case "PERCENTILE.EXC":
                case "PERCENTILE.INC":
                    viewModel.TxtGen = "=" + item + "({C1,A2,C4},0.7)";
                    break;
                case "FORECAST":
                    viewModel.TxtGen = "=" + item + "(A4,{C1,A2,C4},{B2,A1,C5})";
                    break;
                case "RANDBETWEEN":
                    viewModel.TxtGen = "=" + item + "(C1,A1)";
                    break;
                case "PERCENTRANK":
                    viewModel.TxtGen = "=" + item + "(A1:A5,A3)";
                    break;
                case "TRANSPOSE":
                    viewModel.TxtGen = "=" + item + "({100,200,300})";
                    break;
                case "TRIMMEAN":
                    viewModel.TxtGen = "=" + item + "(A1:A5,10%)";
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
                    viewModel.TxtGen = "=" + item + "(A1,C1)";
                    break;
                case "IF":
                    viewModel.TxtGen = "=" + item + "(A1+B1>C1+A4,True)";
                    break;
                case "SUMIF":
                    viewModel.TxtGen = "=" + item + "(A1:A5,\">C5\")";
                    break;
                case "NOT":
                    viewModel.TxtGen = "=" + item + "(IF(A1+B1>C1,True))";
                    break;
                case "FALSE":
                case "TRUE":
                    viewModel.TxtGen = "=(IF(A1+B1>C1,True))" + item + "()";
                    break;
                case "LEFT":
                case "RIGHT":
                case "LEFTB":
                case "RIGHTB":
                    viewModel.TxtGen = "=" + item + "(A1,3)";
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
                    viewModel.TxtGen = "=" + item + "(Sum(A1,B1,C1))";
                    break;
                case "ABS":
                    viewModel.TxtGen = "=" + item + "(B3)";
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
                    viewModel.TxtGen = "=" + item + "(A1,B1,C1)";
                    break;
                case "RAND":
                    viewModel.TxtGen = "=" + item + "()*Sum(A1,B1,C1)";
                    break;
                case "CEILING":
                case "FLOOR":
                case "ROUNDDOWN":
                case "ROUND":
                    viewModel.TxtGen = "=" + item + "(Sum(A1,B1,C1),0.5)";
                    break;
                case "DAY":
                case "HOUR":
                case "MINUTE":
                case "SECOND":
                case "MONTH":
                case "WEEKDAY":
                case "YEAR":
                    viewModel.TxtGen = "=" + item + "(A1)";
                    break;
                case "DATEVALUE":
                    viewModel.TxtGen = "=" + item + "(\"1990/01/24\")";
                    break;
                case "OFFSET":
                    viewModel.TxtGen = "=" + item + "(A1,2,2)";
                    break;
                case "MID":
                    viewModel.TxtGen = "=" + item + "(\"MidPoint\",1,A1)";
                    break;
                case "MIDB":
                    viewModel.TxtGen = "=" + item + "(\"Simple Text\",1,6)";
                    break;
                case "EXACT":
                    viewModel.TxtGen = "=" + item + "(A1,A1)";
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
                    viewModel.TxtGen = "=" + item + "(A1,A2,A3)";
                    break;
                case "LOWER":
                    viewModel.TxtGen = "=" + item + "(\"LOWERTEXT\")";
                    break;
                case "UPPER":
                    viewModel.TxtGen = "=" + item + "(\"uppertext\")";
                    break;
                case "TRIM":
                    viewModel.TxtGen = "=" + item + "(\"Simple     Text\")";
                    break;
                case "TEXT":
                    viewModel.TxtGen = "=" + item + "(Sum(A1,B1,C1),$0.00)";
                    break;
                case "XIRR":
                    viewModel.TxtGen = "=" + item + "(A1:A5," + DateTime.Now + ",0.1)";
                    break;
                case "VALUE":
                    viewModel.TxtGen = "=" + item + "(Avg(A1,B1,C1))";
                    break;
                case "MODE":
                    viewModel.TxtGen = "=" + item + "(A1,B1,C1,A1)";
                    break;
                case "MODE.SNGL":
                    viewModel.TxtGen = "=" + item + "(A1,B1,B1,C4)";
                    break;
                case "MODE.MULT":
                    viewModel.TxtGen = "=" + item + "(A1,B1,C1,C1)";
                    break;
                case "TRUNC":
                    viewModel.TxtGen = "=" + item + "(A1/1.3,3)";
                    break;
                case "COUNTIF":
                case "NORM.S.DIST":
                    viewModel.TxtGen = "=" + item + "(A1,True)";
                    break;
                case "COUNTIFS":
                    viewModel.TxtGen = "=" + item + "(A2:A5, \">30\")";
                    break;
                case "AND":
                case "OR":
                case "XOR":
                    viewModel.TxtGen = "=" + item + "(A1<B1,C5<B4)";
                    break;
                case "IFNA":
                    viewModel.TxtGen = "=" + item + "(VLOOKUP(A1,A2:A5,2,true),\"Not Found\")";
                    break;
                case "LOOKUP":
                    viewModel.TxtGen = "=" + item + "(B2,A1:B4,C1:C5)";
                    break;
                case "SUMPRODUCT":
                case "GROWTH":
                    viewModel.TxtGen = "=" + item + "(A1:A5,B1:B5,C1:C5)";
                    break;
                case "MATCH":
                    viewModel.TxtGen = "=" + item + "(B3,A2:B4,0)";
                    break;
                case "FIND":
                case "FINDB":
                case "SEARCH":
                case "SEARCHB":
                    viewModel.TxtGen = "=" + item + "(\"n\",\"Syncfusion\",1)";
                    break;
                case "CHOOSE":
                    viewModel.TxtGen = "=" + item + "(4,A1,A2,A3,A4,A5)";
                    break;
                case "CLEAN":
                    viewModel.TxtGen = "=" + item + "(CHAR(9)&\"Monthly report\"&CHAR(10))";
                    break;
                case "DOLLAR":
                case "ROUNDUP":
                case "ROMAN":
                case "CEILING.MATH":
                    viewModel.TxtGen = "=" + item + "(A4, 4)";
                    break;
                case "DOLLARDE":
                case "DOLLARFR":
                    viewModel.TxtGen = "=" + item + "(C2,B5)";
                    break;
                case "DURATION":
                    viewModel.TxtGen = "=" + item + "(A1,A3,C1,B2,2,1)";
                    break;
                case "FVSCHEDULE":
                    viewModel.TxtGen = "=" + item + "(1,{0.09,0.11,0.1})";
                    break;
                case "DISC":
                    viewModel.TxtGen = "=" + item + "(A1,B4,C1,C4,1)";
                    break;
                case "INTRATE":
                    viewModel.TxtGen = "=" + item + "(\"01/24/1990\",\"01/24/1991\",A5,B5,2)";
                    break;
                case "CUMIPMT":
                    viewModel.TxtGen = "=" + item + "(A2/12,A3*12,A4,1,1,0)";
                    break;
                case "CUMPRINC":
                    viewModel.TxtGen = "=" + item + "(0.1,A3,A4,1,1,0)";
                    break;
                case "NA":
                case "SHEET":
                case "SHEETS":
                case "NOW":
                case "TODAY":
                    viewModel.TxtGen = "=" + item + "()";
                    break;
                case "ERROR.TYPE":
                    viewModel.TxtGen = "=" + item + "(#REF!)";
                    break;
                case "SUBTOTAL":
                    viewModel.TxtGen = "=" + item + "(9,A1:B4,C1:C5)";
                    break;
                case "PV":
                    viewModel.TxtGen = "=" + item + "(A3, A4, A2,B4, 0)";
                    break;
                case "ACCRINT":
                    viewModel.TxtGen = "=" + item + "(DATE(A1,A2,B2), DATE(C1,C2,B2), DATE(B1,B2,C1),0.1,C5,2,0)";
                    break;
                case "ACCRINTM":
                    viewModel.TxtGen = "=" + item + "(DATE(A1,A2,B2),DATE(C2,C4,C5),0.1,B5,2)";
                    break;
                case "VDB":
                    viewModel.TxtGen = "=" + item + "(A1,A2,A3,DATE(A1,A2,B2),DATE(C2,C4,C5))";
                    break;
                case "TIMEVALUE":
                    viewModel.TxtGen = "=" + item + "(\"2:24 AM\")";
                    break;
                case "MROUND":
                    viewModel.TxtGen = "=" + item + "(A1,3)";
                    break;
                case "NORMSINV":
                case "NORM.S.INV":
                    viewModel.TxtGen = "=" + item + "(0.8)";
                    break;
                case "LOGEST":
                case "LOGESTB":
                    viewModel.TxtGen = "=" + item + "(A1:A5,B1:B5,TRUE,TRUE)";
                    break;
                case "PERCENTRANK.EXC":
                case "PERCENTRANK.INC":
                case "Z.TEST":
                    viewModel.TxtGen = "=" + item + "(A1:A5,3)";
                    break;
                case "STANDARDIZE":
                    viewModel.TxtGen = "=" + item + "(A1,A5,1.5)";
                    break;
                case "ADDRESS":
                    viewModel.TxtGen = "=" + item + "(2,3)";
                    break;
                case "AVERAGEIF":
                    viewModel.TxtGen = "=" + item + "(B2:B5,\"<23000\")";
                    break;
                case "AVERAGEIFS":
                    viewModel.TxtGen = "=" + item + "(A2:A5, C2:C5, \">30\", A2:A5, \"<90\")";
                    break;
                case "SUMIFS":
                    viewModel.TxtGen = "=" + item + "(A2:A5, C1:C5,\">C4\")";
                    break;
                case "NETWORKDAYS":
                    viewModel.TxtGen = "=" + item + "(C4,B5)";
                    break;
                case "CONFIDENCE.T":
                case "CONFIDENCE":
                case "GAMMAINV":
                case "LOGINV":
                    viewModel.TxtGen = "=" + item + "(0.6,B2,A1)";
                    break;
                case "BINOMDIST":
                    viewModel.TxtGen = "=" + item + "(A1,B1,0.6,TRUE)";
                    break;
                case "CHISQ.TEST":
                    viewModel.TxtGen = "=" + item + "(A1:A3, C1:C3)";
                    break;
                case "MMULT":
                    viewModel.TxtGen = "=" + item + "(A2:A5, B2:B5)";
                    break;
                case "NORM.DIST":
                    viewModel.TxtGen = "=" + item + "(A2,A3,B1,TRUE)";
                    break;
                case "NORM.INV":
                    viewModel.TxtGen = "=" + item + "(0.908789,A5,B2)";
                    break;
                case "WEIBULL.DIST":
                case "GAMMA.DIST":
                case "LOGNORM.DIST":
                case "F.DIST":
                    viewModel.TxtGen = "=" + item + "(A2,A3,A4,TRUE)";
                    break;
                case "EXPON.DIST":
                case "CHISQ.DIST":
                    viewModel.TxtGen = "=" + item + "(0.3,A3,TRUE)";
                    break;
                case "GAMMA.INV":
                case "F.INV.RT":
                case "LOGNORM.INV":
                case "CONFIDENCE.NORM":
                    viewModel.TxtGen = "=" + item + "(0.068094,A3,A4)";
                    break;
                case "BINOM.INV":
                case "CRITBINOM":
                    viewModel.TxtGen = "=" + item + "(A1,0.5,0.6)";
                    break;
                case "HYPGEOM.DIST":
                    viewModel.TxtGen = "=" + item + "(A1,A2,A3,A4,TRUE)";
                    break;
                case "BETA.DIST":
                    viewModel.TxtGen = "=" + item + "(A2,A3,A4,TRUE,B1,B2)";
                    break;
                case "CHISQ.INV":
                case "CHISQ.INV.RT":
                case "T.INV":
                case "CHIINV":
                    viewModel.TxtGen = "=" + item + "(0.5,A3)";
                    break;
                case "BINOM.DIST":
                case "NEGBINOM.DIST":
                    viewModel.TxtGen = "=" + item + "(A1,A3,0.7,TRUE)";
                    break;
                case "RANK.AVG":
                    viewModel.TxtGen = "=" + item + "(A2,A1:A5,1)";
                    break;
                case "RANK.EQ":
                    viewModel.TxtGen = "=" + item + "(B3,B1:B5,1)";
                    break;
                case "RANK":
                    viewModel.TxtGen = "=" + item + "(C4,C1:C5,1)";
                    break;
                case "POISSON.DIST":
                case "T.DIST":
                    viewModel.TxtGen = "=" + item + "(A1,A2,TRUE)";
                    break;
                case "CONVERT":
                    viewModel.TxtGen = "=" + item + "(A1,\"F\",\"C\")";
                    break;
                case "REPLACE":
                case "REPLACEB":
                    viewModel.TxtGen = "=" + item + "(\"SimpleText\",6,5,\"*\")";
                    break;
                case "CODE":
                case "UNICODE":
                case "ASC":
                case "JIS":
                case "ENCODEURL":
                case "T":
                    viewModel.TxtGen = "=" + item + "(\"SimpleText\")";
                    break;
                case "PROPER":
                    viewModel.TxtGen = "=" + item + "(\"SimPleTeXt\")";
                    break;
                case "NUMBERVALUE":
                    viewModel.TxtGen = "=" + item + "(\"2.500,27\",\",\",\".\")";
                    break;
                case "REPT":
                    viewModel.TxtGen = "=" + item + "(\"SimpleText\",3)";
                    break;
                case "MDETERM":
                case "ROWS":
                case "COLUMNS":
                case "IRR":
                    viewModel.TxtGen = "=" + item + "(A1:A5)";
                    break;
                case "MINVERSE":
                    viewModel.TxtGen = "=" + item + "({1,2,4})";
                    break;
                case "DECIMAL":
                    viewModel.TxtGen = "=" + item + "(\"FF\",16)";
                    break;
                case "SERIESSUM":
                    viewModel.TxtGen = "=" + item + "(A3,0,2,A1:A5)";
                    break;
                case "ARABIC":
                    viewModel.TxtGen = "=" + item + "(\"LVII\")";
                    break;
                case "NETWORKDAYS.INTL":
                    viewModel.TxtGen = "=" + item + "(\"1990/01/24\",\"1992/01/24\")";
                    break;
                case "HYPERLINK":
                    viewModel.TxtGen = "=" + item + "(\"http:\\www.syncfusion.com\",\"Syncfusion\")";
                    break;
                case "INFO":
                    viewModel.TxtGen = "=" + item + "(\"NUMFILE\")";
                    break;
                case "CELL":
                    viewModel.TxtGen = "=" + item + "(\"col\",C3)";
                    break;
            }
        }
    }
}
