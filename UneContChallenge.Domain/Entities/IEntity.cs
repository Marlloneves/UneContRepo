namespace UneContChallenge.Domain.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
