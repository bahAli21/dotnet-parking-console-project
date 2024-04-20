using System;
using System.Collections.Generic;
using models;
using System.Diagnostics;

namespace services
{
    public class ReservationService
    {
        public List<Reservation> FileReservation { get; set; }

        public ReservationService() => FileReservation = new List<Reservation>();

        public void MakeReservation(Reservation reservation)
        {
            FileReservation.Add(reservation);
        }

        public void CancelReservation(int reservationID)
        {
            Trace.Assert(FileReservation.Count > 0);
            for (int i = 0; i < FileReservation.Count; i++)
            {
                if (FileReservation[i].ReservationId == reservationID)
                {
                    FileReservation.Remove(FileReservation[i]);
                }
            }
            
        }

        public Reservation GetReservationsByParkingSpot(int parkingSpotId)
        {
            Trace.Assert(FileReservation.Count > 0);
            Reservation reservation = new Reservation();
            for (int i = 0; i < FileReservation.Count; i++) 
            {
                if (FileReservation[i].ParkingSpotId == parkingSpotId)
                    reservation = FileReservation[i];
            }

            return reservation;
        }

    }
}