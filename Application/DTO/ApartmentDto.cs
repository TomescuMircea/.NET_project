namespace Application.DTO
{
    public class ApartmentDto
    {
        public Guid EstateId { get; set; }
        public short RoomNumber { get; set; }
        public short FloorNumber { get; set; }
        public bool FullySeparated { get; set; }
    }
}
