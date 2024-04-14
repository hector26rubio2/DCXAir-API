using Domain.Interfaces;

namespace Domain.Entities
{
    public class Flight : IEntityWithId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TransportId { get; set; } 
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

       
        public virtual Transport Transport { get; set; } 
    }
}
