using NewsAppMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsAppMVC.ViewModels
{
    [NotMapped]
    public class ArticleViewModel : Article
    {
        public ICollection<SelectListItem> AllTopics { get; set; }
        public IEnumerable<int> SelectedTopics { get; set; }
    }
}