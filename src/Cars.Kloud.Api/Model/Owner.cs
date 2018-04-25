using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Kloud.Api.Model
{
    public class Owner
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
