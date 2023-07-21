using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpatialCoordinatesDomain;
using SpatialCoordinatesDomain.RepositoryContracts;

namespace SpatialCoordinatesInfrastructure.Data.CoordinatesRepository
{
    
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private readonly string _localDbFullPath;

        public CoordinatesRepository()
        {
            _localDbFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalFiles", "Coordinates.txt");
        }
        public void Insert(Coordinates coords)
        {
            List<string> dbASList = File.ReadAllLines(_localDbFullPath).ToList();

            string dataToInsert = $"Coords [{coords.coordX}, {coords.coordY}, {coords.coordZ}] added on {DateTime.UtcNow}";

            dbASList.Add(dataToInsert);

            File.AppendAllLines(_localDbFullPath, dbASList);
        }
    }
}
