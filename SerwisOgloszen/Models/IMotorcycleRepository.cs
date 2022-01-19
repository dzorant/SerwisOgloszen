using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisOgloszen.Models
{
    public interface IMotorcycleRepository
    {
        IEnumerable<Motorcycle> DownloadAllMotorcycles();
        Motorcycle DownloadMotorcycleWithId(int motorcycleId);

        void AddMotorcycle(Motorcycle motorcycle);
        void EditMotorcycle(Motorcycle motorcycle);
        void RemoveMotorcycle(Motorcycle motorcycle);
    }
}
