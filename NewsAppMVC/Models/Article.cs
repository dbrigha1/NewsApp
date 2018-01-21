using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAppMVC.Models
{
    public class Article
    {
        public Article()
        {
            this.Topics = new HashSet<Topic>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Last Updated")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateUpdated { get; set; }
        
        public virtual ICollection<Topic> Topics {get; set;}
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}