using System;

namespace models
{
    public class ParkingSpot
    {
        public bool Status { get; set; }
        public string Emplacement { get; set; }
        public int ParkingSpotID { get; set; }
        public int Size { get; set; }

        public ParkingSpot(int id, string emplacement, int size, bool status) 
        {
            Status = status;
            Emplacement = emplacement;
            Size = size;
            ParkingSpotID = id;
        }

        public ParkingSpot() {
            Emplacement = string.Empty;
        }

        public override string ToString()
        {
            if (Status)
            {
                return $"Parking Place {ParkingSpotID} , Emplacement {Emplacement} de taille {Size} est occupé";
            }
            return $"Parking Place {ParkingSpotID} , Emplacement {Emplacement} de taille {Size} est libre";
        }

    }
}