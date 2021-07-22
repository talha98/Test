using System;
using System.Collections.Generic;

#nullable disable

namespace HandsOnAPIUsingEF.Entities
{
    public partial class Customer
    {
        public int Customerid { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
