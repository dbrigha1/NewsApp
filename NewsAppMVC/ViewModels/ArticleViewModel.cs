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
        public IEnumerable<SelectListItem> AllTopics { get; set; }
        public IEnumerable<SelectListItem> AllAuthors { get; set; }
        public int SelectedAuthorId { get; set; }
        private IList<int> selectedTopicIds;
        public IList<int> SelectedTopicIds
        {
            get
            {
                if (selectedTopicIds == null)
                {
                    selectedTopicIds = this.Topics.Select(c => c.ID).ToList();
                }
                return selectedTopicIds;
            }
            set { selectedTopicIds = value; }
        }
    }
}