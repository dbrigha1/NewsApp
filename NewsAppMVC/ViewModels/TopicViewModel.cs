using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsAppMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsAppMVC.ViewModels
{
    [NotMapped]
    public class TopicViewModel : Topic
    {
        public IEnumerable<SelectListItem> AllArticles { get; set; }

        private IList<int> selectedArticleIds { get; set; }
        public IList<int> SelectedArticleIds
        {
            get
            {
                if (selectedArticleIds == null)
                {
                    selectedArticleIds = this.Articles.Select(c => c.ID).ToList();
                }
                return selectedArticleIds;
            }
            set
            {
                selectedArticleIds = value;
            }
        }
    }
}
