namespace Blog.Domain.Common
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}
