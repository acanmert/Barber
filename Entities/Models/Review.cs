

namespace Entities.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }  
        public User User { get; set; }
        public int ServiceId { get; set; }  
        public SalonService Service { get; set; }
        public int? BarberId { get; set; }  
        public Barber Barber { get; set; }
    }
}
