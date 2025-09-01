namespace EssentialCore.Entities.Core
{

    public class Entity : EntityBase, IEntityBase
    {
        public Entity() : base(Entity.Informer)
        {

        }

        protected static Info Informer { get; private set; } = new Info("Core", "Entity", "Entity");

        public string Schema { get; set; }

        public string Name { get; set; }

        public string Synonym { get; set; }

        public string IndexUrl { get; set; }

        public bool IsActive { get; set; }

    }
}