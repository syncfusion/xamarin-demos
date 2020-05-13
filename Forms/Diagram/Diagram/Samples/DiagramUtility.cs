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

namespace SampleBrowser.SfDiagram
{
    public class DiagramUtility
    {
        public static float factor = 1;
        private static float m_currentDensity = 1;

        public static float currentDensity
        {
            get
            {
                return m_currentDensity;
            }
            set
            {
                m_currentDensity = value;
                float staticDensity = 1.5f;
                factor = m_currentDensity / staticDensity;
            }
        }
    }
}
