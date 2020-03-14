using Blog.Application.Common.Mappings;
using Blog.Domain.Entities;
using System;

namespace Blog.Application.Articles.Queries.Details
{
    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string Author { get; set; }

        public string CreatedBy { get; set; }
    }
}
