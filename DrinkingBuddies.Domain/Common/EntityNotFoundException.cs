namespace DrinkingBuddies.Domain.Common
{
    public class EntityNotFoundException : Exception
    {
        public int Id { get; set; }
        public EntityNotFoundException(int id) : base($"Сущность с ID {id} не найдена")
        {
            Id = id;
        }
    }
}
