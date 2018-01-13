using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAppMVC.Models
{
    public class Author
    {
        public Author()
        {
            this.Articles = new HashSet<Article>();
        }
        public int ID { get; set; }
        [Display(Name="First Name")]
        public string FirstName {get; set;}
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Articles")]
        public virtual ICollection<Article> Articles { get; set; }
        
    }
}