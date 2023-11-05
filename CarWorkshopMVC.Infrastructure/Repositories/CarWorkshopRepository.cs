using CarWorkshopMVC.Domain.Entities;
using CarWorkshopMVC.Domain.Interfaces;
using CarWorkshopMVC.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(CarWorkshop carWorkshop)
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshop?>> GetByAll()
        {
            var repositories =await _dbContext.CarWorkshops.ToListAsync();
            return repositories;
        }

        public Task<CarWorkshop> GetByEncodedName(string encodedName)
        => _dbContext.CarWorkshops.FirstOrDefaultAsync(x=>x.EncodedName== encodedName);

        public Task<CarWorkshop?> GetByName(string name)
        => _dbContext.CarWorkshops.FirstAsync(c => c.Name.ToLower() == name.ToLower());
    }
}
