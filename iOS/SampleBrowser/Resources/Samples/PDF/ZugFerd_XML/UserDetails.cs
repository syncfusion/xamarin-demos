using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syncfusion.ZugFerd
{
    /// <summary>
    /// User Details
    /// </summary>
    public class UserDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public CountryCodes Country { get; set; }
        public string Street { get; set; }
    }
}
