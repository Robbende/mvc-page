using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books_MVC.Models
{
    public class CommentSummary
    {
        public string UserName { get; set; }
        public int NumberOfComments { get; set; }
    }
}