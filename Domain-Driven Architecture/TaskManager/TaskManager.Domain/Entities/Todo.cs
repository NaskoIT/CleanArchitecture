using System;

namespace TaskManager.Domain.Entities
{
    public class Todo : Entity<int>
    {
        private const int TitleMaxLength = 40;
        private string title;
        private string content;

        public Todo(string title, string content, string userId)
        {
            this.Title = title;
            this.Content = content;
            this.UserId = userId;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("TODO title cannot be null.");
                }

                if (value.Length > TitleMaxLength)
                {
                    throw new AggregateException($"TODO title cannot be more than {TitleMaxLength} symbols.");
                }

                this.title = value;
            }
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("TODO content cannot be null.");
                }

                this.content = value;
            }
        }

        public string UserId { get; set; }

        public bool Done { get; set; }

        public void Finish() => Done = true;
    }
}
