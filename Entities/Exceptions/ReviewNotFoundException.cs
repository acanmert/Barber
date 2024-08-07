using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ReviewNotFoundException:NotFoundException
    {
        public ReviewNotFoundException(int id) : base($"The review with id: {id} could not found")
        {
                
        }
    }
}
