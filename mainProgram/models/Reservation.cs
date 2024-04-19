using System;

namespace models
{
    public class Reservation
    {
       public int ReservationId { get; set; }
       public string NameUser { get; set; }
       public int ParkingSpotId { get; set; }
       public DateTime BeginReservationDateTime { get; set; }
       public DateTime EndReservationDateTime {  get; set; }

       public Reservation(int reservationId, string userName, int parkingSpotId, DateTime begin, DateTime end) { 
            ReservationId = reservationId;
            NameUser = userName;
            ParkingSpotId = parkingSpotId;
            BeginReservationDateTime = begin;
            EndReservationDateTime = end;
       }

        public override string ToString()
        {
            return ($"Reservation {ReservationId} de {NameUser}, place reserver {ParkingSpotId} duree : {BeginReservationDateTime} à {EndReservationDateTime}");
        }
    }
}