using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books_MVC.Models
{
    public class Pet
    {
        public int id { get; set; }
        public string name { get; set; }
        public int ownerId { get; set; }
    }
}