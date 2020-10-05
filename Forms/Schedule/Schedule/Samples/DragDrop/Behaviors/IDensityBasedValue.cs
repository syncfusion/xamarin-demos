#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace SampleBrowser.SfSchedule
{
    /// <summary>
    /// Density Based value class
    /// </summary>
    public interface IDensityBasedValue
    {
        /// <summary>
        /// Gets the density based value.
        /// </summary>
        /// <returns>The density based value.</returns>
        /// <param name="oldValue">Old value.</param>
        double GetDensityBasedValue(double oldValue);
    }
}
