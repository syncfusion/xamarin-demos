using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.ZugFerd
{
    /// <summary>
    /// Invoice product
    /// </summary>
    public class Product
    {
        public string ProductID { get; set; }

        public string productName { get; set; }

        public float Price { get; set; }

        public float Quantity { get; set; }

        public float Total { get; set; }


    }
}
