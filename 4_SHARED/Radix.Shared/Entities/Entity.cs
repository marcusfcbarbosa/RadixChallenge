using System;

namespace Radix.Shared.Entities
{
    public class Entity
    {
        public Entity()
        {
            this.CreatedAt = DateTime.Now;
            identifyer = Guid.NewGuid().ToString();
        }
        public long Id { get; set; }
        public string identifyer { get; set; }
        public DateTime CreatedAt { get; set; }   
    }
}