namespace Domain.Entities
{
    public class Apartment
    {
        public Guid EstateId { get; set; }
        public decimal RoomNumber { get; set; }
        public decimal FloorNumber { get; set; }

        public decimal FullySeparated { get; set; }

    }
}
