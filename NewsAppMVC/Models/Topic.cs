using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsAppMVC.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        public virtual ICollection<Article> Article { get; set; }
        
    }
}