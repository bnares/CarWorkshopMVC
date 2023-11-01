using CarWorkshopMVC.Domain.Entities;
using CarWorkshopMVC.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var mazdaAso = new CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwius mazda",
                        ContactDetails = new()
                        {
                            City = "Rzeszów",
                            Street = "Podkarpacka",
                            PostalCode = "30-001",
                            PhoneNumber = "+48509345678"
                        }
                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshops.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
