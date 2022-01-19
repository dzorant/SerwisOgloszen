using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisOgloszen.Models
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly AppDbContext _appDbContext;

        public MotorcycleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Motorcycle> DownloadAllMotorcycles()
        {
            return _appDbContext.Motorcycles;
        }
        public Motorcycle DownloadMotorcycleWithId(int motorcycleId)
        {
            return _appDbContext.Motorcycles.FirstOrDefault(m => m.Id == motorcycleId);
        }

        public void AddMotorcycle(Motorcycle motorcycle)
        {
            _appDbContext.Motorcycles.Add(motorcycle);
            _appDbContext.SaveChanges();
        }
        public void EditMotorcycle(Motorcycle motorcycle)
        {
            _appDbContext.Motorcycles.Update(motorcycle);
            _appDbContext.SaveChanges();
        }
        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            _appDbContext.Motorcycles.Remove(motorcycle);
            _appDbContext.SaveChanges();
        }
    }
}
