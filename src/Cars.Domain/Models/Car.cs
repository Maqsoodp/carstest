using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Domain.Models
{
    public class Car
    {
        public virtual Owner Owner { get; set; }

        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
    }
}
