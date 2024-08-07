using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class AppointmentDtoForInsertion
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
    }
}
