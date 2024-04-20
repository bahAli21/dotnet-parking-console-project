using System;
using System.Collections.Generic;
using models;
using System.Diagnostics;
using database;

namespace services
{
    public class ReservationService
    {
        public List<Reservation> FileReservation { get; set; }

        public ReservationService() => FileReservation = new List<Reservation>();

        public void MakeReservation(Reservation reservation)
        {
            FileReservation.Add(reservation);
            string[] arrReservation =
            {
                reservation.ReservationId.ToString(),
                reservation.NameUser,
                reservation.ParkingSpotId.ToString(),
                reservation.BeginReservationDateTime.ToString(),
                reservation.EndReservationDateTime.ToString()
            };
            Database.SetData("db.txt", arrReservation);
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