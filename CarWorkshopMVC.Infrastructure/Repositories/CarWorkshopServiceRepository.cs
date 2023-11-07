
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
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopServiceRepository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Create(CarWorkshopService carWorkshopService)
        {
            _context.Services.Add(carWorkshopService);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName)
        {
          return await _context.Services.Where(s=>s.CarWorkshop.EncodedName == encodedName).ToListAsync();
        }
    }
}
