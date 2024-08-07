using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ReviewDtoForInsertion
    {
        public string Content { get; set; }
        public int Rating { get; set; } // 1 ile 5 arasında bir puan
        public DateTime Date { get; set; }=DateTime.Now;
        public int UserId { get; set; }  // Yorumu yazan kullanıcı

        public int ServiceId { get; set; } // Yorumun hangi hizmete ait olduğu
       
        public int? BarberId { get; set; }  // (Opsiyonel) Yorumun hangi berbere ait olduğu
    }
}
