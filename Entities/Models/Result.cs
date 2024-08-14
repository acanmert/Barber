using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
