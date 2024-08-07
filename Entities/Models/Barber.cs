using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }  
        public string Location { get; set; }  
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
