using Blog.Domain.Common;
using Blog.Domain.Exceptions;
using System;

namespace Blog.Domain.Entities
{
    public class Comment : AuditableEntity<int>
    {
        private string content;

        public Comment(string content, string createdBy)
        {
            this.Content = content;
            this.CreatedBy = createdBy;
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidEntityException("Comment content cannot be null.");
                }

                this.content = value;
            }
        }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}