using System;
using System.Linq;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Domain
{
    public class DbInit
    {

        private readonly CarsDbContext _dbContext;
        public DbInit(CarsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Load()
        {
            this._dbContext.Database.EnsureCreated();

            if (this._dbContext.Owners.Any())
            {
                return;
            }

            var owners = new Owner[]
            {
                new Owner{Id = Guid.Parse("8b2546a4-9af4-4dca-94c6-babbd6724600"),  Name = "Bradley"},
                new Owner{Id = Guid.Parse("5ed5b2bc-5d8c-4cc3-8d66-ca48ee935a37"),  Name = "Demetrios"},
                new Owner{Id = Guid.Parse("ae59a48b-2b96-4f42-864e-028a90527d3f"),  Name = "Brooke"},
                new Owner{Id = Guid.Parse("0c98abe2-4da4-42e0-943d-88f0fdfc908e"),  Name = "Kristin"},
                new Owner{Id = Guid.Parse("1e332c39-00b4-4c13-ad7b-a3902b4beba5"),  Name = "Andre"},
                new Owner{Id = Guid.Parse("03c412c8-6055-4c79-801f-f0a0ba57d22a"),  Name = "Matilda"},
                new Owner{Id = Guid.Parse("e108436e-c236-4afb-ab8b-ff822263812d"),  Name = "Iva"},
            };
            foreach (var o in owners)
            {
                this._dbContext.Owners.Add(o);
            }
            this._dbContext.SaveChanges();

            var cars = new Car[]
            {
                

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("1e332c39-00b4-4c13-ad7b-a3902b4beba5"), Brand = "BMW", Colour="Green"},
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("1e332c39-00b4-4c13-ad7b-a3902b4beba5"), Brand = "Holden", Colour="Black"},

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("03c412c8-6055-4c79-801f-f0a0ba57d22a"), Brand = "Holden", Colour=null},
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("03c412c8-6055-4c79-801f-f0a0ba57d22a"), Brand = "BMW", Colour="Black"},

                // new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse(""), Brand = "Holden", Colour="Blue"},
                // new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse(""), Brand = "Mercedes", Colour="Blue"},

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("ae59a48b-2b96-4f42-864e-028a90527d3f"), Brand = "Holden", Colour=""},

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("0c98abe2-4da4-42e0-943d-88f0fdfc908e"), Brand = "Mercedes", Colour="Green"},
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("0c98abe2-4da4-42e0-943d-88f0fdfc908e"), Brand = "Mercedes", Colour="Yellow"},
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("0c98abe2-4da4-42e0-943d-88f0fdfc908e"), Brand = "Toyota", Colour="Blue"},

                // new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse(""), Brand = "Mercedes", Colour="Red"},
                
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("8b2546a4-9af4-4dca-94c6-babbd6724600"), Brand = "MG", Colour="Blue"},

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("5ed5b2bc-5d8c-4cc3-8d66-ca48ee935a37"), Brand = "Toyota", Colour="Blue"},
                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("5ed5b2bc-5d8c-4cc3-8d66-ca48ee935a37"), Brand = "Toyota", Colour="Green"},

                new Car{Id= Guid.NewGuid(), OwnerId = Guid.Parse("e108436e-c236-4afb-ab8b-ff822263812d"), Brand = "Toyota", Colour="Purple"},

            };
            foreach (var c in cars)
            {
                this._dbContext.Cars.Add(c);
            }
            this._dbContext.SaveChanges();


        }
    }
}
