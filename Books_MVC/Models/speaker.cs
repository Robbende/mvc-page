using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books_MVC.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string Bio { get; set; }
    }
}