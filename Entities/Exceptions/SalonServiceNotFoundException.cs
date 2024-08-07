using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SalonServiceNotFoundException : NotFoundException
    {
        public SalonServiceNotFoundException(int id) 
            : base($"The service with id: {id} could not found")
        {
        }
    }
}
