namespace Business.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public TimeSpan CreatedBefore { get; set; }
    }
}
