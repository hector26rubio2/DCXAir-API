﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Journey : IEntityWithId
    {
        public Guid Id { get; set; }
     
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
