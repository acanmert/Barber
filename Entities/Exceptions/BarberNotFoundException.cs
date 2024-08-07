using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class BarberNotFoundException : NotFoundException
    {
        public BarberNotFoundException(int id) : base($"The barber with id: {id} could not found")
        {

        }
    }
}
