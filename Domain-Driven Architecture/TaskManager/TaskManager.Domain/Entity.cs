namespace TaskManager.Domain
{
    public class Entity<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
