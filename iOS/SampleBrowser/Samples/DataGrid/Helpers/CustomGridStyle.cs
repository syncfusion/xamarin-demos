using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SampleBrowser
{
    public class CustomGridStyle : DataGridStyle
    {
        public CustomGridStyle()
        {

        }

        public override GridLinesVisibility GetGridLinesVisibility()
        {
            return GridLinesVisibility.Both;
        }
    }
}