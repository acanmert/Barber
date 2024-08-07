﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int BarberId { get; set; }
        public Barber? Barber { get; set; }
        public int ServiceId { get; set; }
        public SalonService? Service { get; set; }
    }
}
