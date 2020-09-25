using System;

namespace CykelLib
{
    public class CykelModel
    {
        private int _id;
        private string _farve;
        private int _gear;
        private decimal _pris;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set => _farve = value;
        }

        public int Gear
        {
            get => _gear;
            set => _gear = value;
        }

        public decimal Pris
        {
            get => _pris;
            set => _pris = value;
        }

        public CykelModel()
        {

        }
        public CykelModel(int id, string farve, decimal pris, int gear)
        {
            Id = id;
            Farve = farve;
            Gear = gear;
            Pris = pris;
        }

        public override string ToString()
        {
            return $"{Id}, {Farve}, {Gear}, {Pris}";
        }
    }
}
