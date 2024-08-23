namespace Entities
{
    public class SharedEntity
    {
        public SharedEntity()
        {
            Entity = new Entity();
        }

        public Guid Id { get; set; }
        public Entity Entity { get; set; }
    }
}
