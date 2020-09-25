using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObligatoryClassLibrary;

namespace CykelRest.Managers
{
    public class BicycleManager
    {
        private static int _bicycleId = 1;
        private static readonly List<Cykel> Bicycles = new List<Cykel>
        {
            new Cykel(BicycleIdGenerator(), "Blå", (decimal)2999.95, 14),
            new Cykel(BicycleIdGenerator(), "Sort", (decimal)6999.95, 32),
            new Cykel(BicycleIdGenerator(), "Sølv", (decimal)1999.95, 12),
            new Cykel(BicycleIdGenerator(), "Grå", (decimal)1195.95, 3),
            new Cykel(BicycleIdGenerator(), "Sølv", (decimal)3999.95, 21),
        };
        

        public IList<Cykel> GetAll()
        {
            return Bicycles;
        }

        public Cykel GetOne(int id)
        {
            return Bicycles.Find(cykel => cykel.Id == id);
        }

        public string Post(Cykel bicycle)
        {
            Bicycles.Add(bicycle);
            return $"Cykel med id {bicycle.Id} tilføjet.";
        }

        public string Put(int id, Cykel newBicycle)
        {
            Cykel bicycleToUpdate = GetOne(id);
            bicycleToUpdate.Farve = newBicycle.Farve;
            bicycleToUpdate.Gear = newBicycle.Gear;
            bicycleToUpdate.Pris = newBicycle.Pris;

            return $"Cykel med id {id} er blevet opdateret.";
        }

        public string Delete(int id)
        {
            Bicycles.Remove(GetOne(id));
            return $"Cykel med id {id} er blevet fjernet.";
        }

        private static int BicycleIdGenerator() => _bicycleId++;
    }
}
