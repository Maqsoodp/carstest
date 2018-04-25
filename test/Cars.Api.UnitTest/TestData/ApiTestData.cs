using System;
using System.Collections.Generic;
using System.Text;
using Cars.Kloud.Api.Model;

namespace Cars.Api.UnitTest
{
    public class ApiTestData
    {
        public static List<Owner> GetTestOwnerData()
        {
            var owners = new List<Owner>
                {
                    new Owner
                    {
                        Name = "Bob1",
                        Cars = new List<Car>
                        {
                            new Car
                            {
                                Brand = "Toyota",
                                Colour = "Green"
                            },
                            new Car
                            {
                                Brand = "BMW",
                                Colour = "Silver"
                            }
                        }
                    },
                    new Owner
                    {
                        Name = "Bob2",
                        Cars = null
                    },
                    new Owner
                    {
                        Name = "Bob3",
                        Cars = new List<Car>
                        {
                            new Car
                            {
                                Brand = "Audi",
                                Colour = ""
                            },
                            new Car
                            {
                                Brand = "Mercedes",
                                Colour = "Black"
                            }
                        }
                    },
                };
            return owners;
        }
    }
}
