using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }

        // İlişkiler
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        // Fotoğraf
        public string? ProfilePictureUrl { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? RefreshToken { get; set; }
        public DateTime RefreshTokenExpriyTime { get; set; }
    }
}
