using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AppointmentNotFoundException : NotFoundException
    {
        public AppointmentNotFoundException(int id)
            : base($"The appointment with id: {id} could not found")
        {
        }
    }
}
