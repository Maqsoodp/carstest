using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Domain.Models
{
    public class Owner
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    }
}
