

namespace Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid EstateId { get; set; }
        public string Extenstion { get; set; }
    }
}
