using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Books_MVC.Models
{
    public class books
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string author { get; set; }
        public string year { get; set; }
        public DateTime date { get; set; }
    }

    public class booksDbContext : DbContext
    {
        public booksDbContext(string connString)
            : base(connString)
        {
        }
        public DbSet<books> Books { get; set; }
        public DbSet<UserComments> Usercomments { get; set; }
    }
}