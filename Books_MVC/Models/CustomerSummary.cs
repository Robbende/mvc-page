using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books_MVC.Models
{
    /* [view model] */
    public class CustomerSummary
    { 
        public string Name { get; set; }
        public string ServiceLevel { get; set; }
        public string OrderCount { get; set; }
        public string MostRecentOrderDate { get; set; }

        public CustomerSumaryInput Input { get; set; }

        /* [input model] */
        public class CustomerSumaryInput 
        {
            public int Number { get; set; }
            public bool Active { get; set; }
        }
    }

    /* [domain model] */
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceLevel { get; set; }

        public List<Order> Orders { get; set; }
    }

    /* [domain model] */
    public class Order 
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
    }
}