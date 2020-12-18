#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser.SfAutoComplete
{
	public class ToleratingTyposHelper
	{
		 public ToleratingTyposHelper()
        {
            soundexTerms.Add("aeiouhyw");
            soundexTerms.Add("bfpv");
            soundexTerms.Add("cgikqsxz");
            soundexTerms.Add("dt");
            soundexTerms.Add("l");
            soundexTerms.Add("mn");
            soundexTerms.Add("r");
        }

        List<string> soundexTerms = new List<string>();

        /// <summary>
        /// Based on Soundex Algorithmn and DL Distance Algorithmn
        /// </summary>
        /// <returns>The matching.</returns>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        public int IsMatching(string value1, string value2)
        {
            var val1 = ProcessOnSoundexAlgorithmn(value1);
            var val2 = ProcessOnSoundexAlgorithmn(value2);
            return CalcualteDistance(val1, val2);
        }

        public int GetMinValue(int[] value)
        {
            int minValue = 0;
            foreach (var item in value)
            {
                if (item < minValue)
                    minValue = item;
            }
            return minValue;
        }

        public  int GetDamerauLevenshteinDistance(string source, string target)
        {
            var bounds = new { Height = source.Length + 1, Width = target.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++)
            {
                for (int width = 1; width < bounds.Width; width++)
                {
                    int cost = (source[height - 1] == target[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    if (height > 1 && width > 1 && source[height - 1] == target[width - 2] && source[height - 2] == target[width - 1])
                    {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }

        /// <summary>
        /// DL Algorithmn Implementation
        /// </summary>
        /// <returns>The distance.</returns>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        public int CalcualteDistance(string value1, string value2)
        {
            int lengthValue1 = value1.Length;
            int lengthValue2 = value2.Length;
            var matrix = new int[lengthValue1 + 1, lengthValue2 + 1];
            for (int i = 0; i <= lengthValue1; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= lengthValue2; j++)
                matrix[0, j] = j;
            for (int i = 1; i <= lengthValue1; i++)
            {
                for (int j = 1; j <= lengthValue2; j++)
                {
                    int cost = value2[j - 1] == value1[i - 1] ? 0 : 1;
                    var vals = new int[] {
                matrix[i - 1, j] + 1,
                matrix[i, j - 1] + 1,
                matrix[i - 1, j - 1] + cost
            };
                    matrix[i, j] = GetMinValue(vals);
                    if (i > 1 && j > 1 && value1[i - 1] == value2[j - 2] && value1[i - 2] == value2[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[lengthValue1, lengthValue2];
        }

        /// <summary>
        /// Soundex Algorithmn Implementation
        /// </summary>
        /// <returns>The on soundex algorithmn.</returns>
        /// <param name="value1">Value1.</param>
        /// <param name="moreAccuracy">If set to <c>true</c> more accuracy.</param>
        public string ProcessOnSoundexAlgorithmn(string value1, bool moreAccuracy = true)
        {
            string stringValue = string.Empty;
            foreach (var item in value1.ToLower())
            {
                for (int i = 0; i < soundexTerms.Count; i++)
                {
                    if (soundexTerms[i].Contains(item.ToString()))
                    {
                        stringValue += i.ToString();
                        continue;
                    }
                }
            }
            if (stringValue.Length > 0)
            {
                if (moreAccuracy)
                {
                    stringValue = stringValue.Insert(0, value1[0].ToString());
                    stringValue = stringValue.Replace("0", "");
                }
            }
            return stringValue;
        }
    }
}
