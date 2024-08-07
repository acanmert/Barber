using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; } 
        public string Email { get; set; } 
        public string PasswordHash { get; set; } 
        public string? Role { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime? LastLogin { get; set; } 
        public bool IsActive { get; set; } 

        // İlişkiler
        public ICollection<Appointment>? Appointments { get; set; } 
        public ICollection<Review>? Reviews { get; set; } 

        //Fotoğraf
        public string? ProfilePictureUrl { get; set; }
    }
}
