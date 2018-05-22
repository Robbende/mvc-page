using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books_MVC.Models
{
    public class UserComments
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}