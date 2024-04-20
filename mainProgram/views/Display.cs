using System;
using models;
using services;

namespace views
{
    public  class Display
    {
        string cle = string.Empty;
        string cleWelcom = string.Empty;

        ReservationService serviceReservation = new ReservationService();
        ParkingService parkingService = new ParkingService();
        ParkingSpot ParkingSpot1 = new ParkingSpot(1, "SUD", 100, false);
        ParkingSpot ParkingSpot2 = new ParkingSpot(2, "NORD", 500, false);
        ParkingSpot ParkingSpot3 = new ParkingSpot(1, "EST", 900, true);

        public Display()
        {
            parkingService.AddParkingSpot(ParkingSpot1);
            parkingService.AddParkingSpot(ParkingSpot2);
            parkingService.AddParkingSpot(ParkingSpot3);
        }
        public void Show()
        {

            Random random = new Random();
            int valeurAleatoire = random.Next(10000, 1000001);

            // Récupérons la date et l'heure actuelles
            DateTime dateDebut = DateTime.Now;

            // Configuration de la date et l'heure de fin (ajoutons 3 heures à la date de début)
            DateTime dateFin = dateDebut.AddHours(3);
            //Template project
            
            
            
            if (Welcom() == "u")
            {
                DisplayUsersTemplate(valeurAleatoire, dateDebut);
            }
        }

        public string Welcom()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("        ------------------------------ Bienvenue dans notre system ----------------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Users ? tapez 'u' ");
                Console.WriteLine();
                Console.WriteLine("2. Admin ? tapez 'a' ");
                Console.WriteLine();
                Console.WriteLine("3. Quitter ? tapez 'q' ");

                Console.WriteLine("        ---------------------------------------Reponse ici--------------------------------------------");
                cleWelcom = Console.ReadLine();

            } while (cleWelcom == "");

            return cleWelcom;
        }

        public void DisplayUsersTemplate(int idReservation, DateTime begin)
        {
            
            Console.WriteLine("             ---------------------------------------Mode User---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Faire une Reservation ? tapez 'r' ");
            Console.WriteLine();
            Console.WriteLine("Pour une Annulation ? tapez 'c' ");
            Console.WriteLine();
            Console.WriteLine("Liste de nos places de parking ? tapez 'place' ");
            Console.WriteLine();
            Console.WriteLine("Back <-- ? tapez 'b' ");
            Console.WriteLine();
            Console.WriteLine("Quittez ? tapez 'q' ");
            Console.WriteLine();

            Console.WriteLine("Reponses ici :");
            cle = Console.ReadLine();
            while (cle != "q" && cle != "b") 
            {
                if (cle == "r")
                {
                    FormulaireReservations(idReservation, begin);
                    cle = " ";
                }
                else if (cle == "c")
                {
                    FormulaireAnnulation();
                    cle = " ";
                }
                else if (cle == "place")
                {
                    Console.WriteLine();
                    Console.WriteLine("         ------------------------------Nos place de parking-------------------------------------");
                    for (int i = 0; i < parkingService.ListParkingSpots.Count; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine(parkingService.ListParkingSpots[i]);
                    }
                    cle = " ";

                }
            }

            if(cle == "b") {
                Welcom();
                cle = " ";
            }
            
        }

        public void FormulaireReservations(int idReservation, DateTime begin)
        {
            Console.Clear();
            Console.Write("Entrer votre nom : ");
            string name = Console.ReadLine();
            Console.Write("Entrer la durée de reservation en Heure : ");
            string duree = Console.ReadLine();

            Console.WriteLine("Avez vous une place de preference ? tapez 'y' pour yes et 'n' pour non");
            Console.WriteLine("Reponses ici :");
            string cle = Console.ReadLine();
            if (cle == "y")
            {
                Console.Clear();
                Console.WriteLine("Entrez l'identifiant de la place");
                string id = Console.ReadLine();
                Reservation reservation = new Reservation(idReservation, name, int.Parse(id), begin, begin.AddHours(int.Parse(duree)));
                serviceReservation.MakeReservation(reservation);
                Console.Clear();
                Console.WriteLine(reservation);
                Console.WriteLine("Reservation effectuer avec succee");
            }

        }

        public void FormulaireAnnulation()
        {
            Console.Clear();
            Console.WriteLine("------------ Attention cette action est definitive (!) -------------");
            Console.WriteLine("Voulez-vous continuez ? 't' continuer 'q' quitter ");
            Console.WriteLine("Reponses ici :");
            string cle = Console.ReadLine();
            if (cle == "t")
            {
                Console.Clear();
                Console.WriteLine("Entrez l'identifiant de votre reservation");
                string idRes = Console.ReadLine();
                serviceReservation.CancelReservation(int.Parse(idRes));
            } else
                Console.Clear() ;
        }
    }
}