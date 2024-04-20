using System;
using models;
using System.Collections.Generic;

namespace services
{
    public class ParkingService
    {
       public List<ParkingSpot> ListParkingSpots { get; set; }
       public ParkingService() => ListParkingSpots = new List<ParkingSpot>();

       public void AddParkingSpot(ParkingSpot parkingSpot)
       {
            ListParkingSpots.Add(parkingSpot);
       }

       public void RemoveParkingSpot(ParkingSpot parkingSpot)
       {
            ListParkingSpots.Remove(parkingSpot);
       }

       public List<ParkingSpot> GetAvailableParkingSpots() 
       {
            List<ParkingSpot> availableSpot = new List<ParkingSpot> ();
            for (int i = 0; i < ListParkingSpots.Count; i++)
            {
                if (!ListParkingSpots[i].Status)
                    availableSpot.Add(ListParkingSpots[i]);
            }
            
            return availableSpot; 
       }

        public List<ParkingSpot> GetOccupiedParkingSpots()
        {
            List<ParkingSpot> occupiedSpot = new List<ParkingSpot>();
            for (int i = 0; i < ListParkingSpots.Count; i++)
            {
                if (ListParkingSpots[i].Status)
                    occupiedSpot.Add(ListParkingSpots[i]);
            }

            return occupiedSpot;
        }




    }
}