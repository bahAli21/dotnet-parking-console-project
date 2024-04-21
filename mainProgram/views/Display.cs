using System;
using database;
using models;
using services;

namespace views
{
    public  class Display
    {
        string cle = string.Empty;
        string cleWelcom = string.Empty;

        string appKey = string.Empty;

        ReservationService serviceReservation = new ReservationService();
        ParkingService parkingService = new ParkingService();

        public Display()
        {

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
            //appKey = " ";
            do
            {
                Console.Clear();
                Console.WriteLine("        ------------------------------ Bienvenue dans notre système ----------------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Utilisateurs ? Tapez 'u'");
                Console.WriteLine();
                Console.WriteLine("2. Administrateurs ? Tapez 'a'");
                Console.WriteLine();
                Console.WriteLine("3. Quitter ? Tapez 'q'");

                Console.WriteLine("        ---------------------------------------Réponse ici--------------------------------------------");
                appKey = Console.ReadLine();

            } while (appKey != "u" && appKey != "a" && appKey != "q");

            return appKey;
        }

        public void DisplayUsersTemplate(int idReservation, DateTime begin)
        {

            Console.WriteLine("             ---------------------------------------Mode Utilisateur---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Faire une Réservation ? Tapez 'r' ");
            Console.WriteLine();
            Console.WriteLine("Pour une Annulation ? Tapez 'c' ");
            Console.WriteLine();
            Console.WriteLine("Liste de nos places de parking ? Tapez 'place' ");
            Console.WriteLine();
            Console.WriteLine("Retour <-- ? Tapez 'b' ");
            Console.WriteLine();
            Console.WriteLine("Quitter ? Tapez 'q' ");
            Console.WriteLine();

            Console.WriteLine("Réponses ici :");
            string appKey = Console.ReadLine(); // Utilisation de appKey au lieu de cle

            while (appKey != "q" && appKey != "b")
            {
                if (appKey == "r")
                {
                    FormulaireReservations(idReservation, begin);
                }
                else if (appKey == "c")
                {
                    FormulaireAnnulation();
                }
                else if (appKey == "place")
                {
                    Console.WriteLine();
                    Console.WriteLine("         ------------------------------Nos places de parking-------------------------------------");

                    string[][] data = { };
                    Database.GetData("dbParkingSpot.txt", ref data);
                    // Lire les données du fichier et les afficher
                    DisplayDataFromFile(data);
                }

                Console.WriteLine("Réponses ici :"); 
                appKey = Console.ReadLine(); // Mise à jour de appKey avec la nouvelle entrée utilisateur
            }

        }

        
        public void DisplayDataFromFile(string[][] data, int status = 0)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (status == 0)
                {
                    if (data[i][3] == "true")
                    {
                        Console.WriteLine($"ID -> {data[i][0]}, Categorie -> {data[i][1]}, Taille -> {data[i][2]}, status -> Occupée");
                    }
                    else
                    {
                        Console.WriteLine($"ID -> {data[i][0]}, Categorie -> {data[i][1]}, Taille -> {data[i][2]}, status -> Libre");
                    }
                }
                else
                {
                    if (data[i][3] == "false")
                        Console.WriteLine($"ID -> {data[i][0]}, Categorie -> {data[i][1]}, Taille -> {data[i][2]}, status -> Libre");
                }
            }

        }

        public void FormulaireReservations(int idReservation, DateTime begin)
        {
            Console.WriteLine("Voici la liste de nos place disponibles");

            Console.WriteLine();
            Console.WriteLine("******************************************************");

            string[][] data = { };
            Database.GetData("dbParkingSpot.txt", ref data);
            // Lire les données du fichier et les afficher
            DisplayDataFromFile(data, 1); //1 pour indiquer qu'on souhaite aficher que les places disponibles
            Console.WriteLine();
            Console.WriteLine("******************************************************");
            Console.Write("Entrer votre nom : ");
            string name = Console.ReadLine();
            Console.Write("Entrer la durée de reservation en Heure : ");
            string duree = Console.ReadLine();

            Console.WriteLine("Saisir L'identifiant de la place de parking");
           
            string id = Console.ReadLine();
            Reservation reservation = new Reservation(idReservation, name, int.Parse(id), begin, begin.AddHours(int.Parse(duree)));
            serviceReservation.MakeReservation(reservation);

            //ParkingSpot
            string[][] dataParking = { };
            Database.GetData("dbParkingSpot.txt", ref dataParking);
            File.WriteAllText("dbParkingSpot.txt", string.Empty);
            for (int i = 0; i < dataParking.Length; ++i)
            {
                if (dataParking[i][0] == id)
                {
                    dataParking[i][3] = "true";
                }
                Database.SetData("dbParkingSpot.txt", dataParking[i]); //Oui vide le contenue avant
            }
            Console.WriteLine(reservation);
            Console.WriteLine("Reservation effectuer avec succee, vous aurez besoin de l'identifiant");
        }

        public void FormulaireAnnulation()
        {
            Console.WriteLine("--------------------- Attention cette action est definitive (!) -------------");
            Console.WriteLine("Voulez-vous continuez ? 't' continuer 'q' quitter ");
            Console.WriteLine("Reponses ici :");
            string cle = Console.ReadLine();
            if (cle == "t")
            {
                Console.WriteLine("Entrez l'identifiant de votre reservation");
                string idRes = Console.ReadLine();
                string[][] data = {};
                int idx = -1;
                Database.GetData("dbReservation.txt", ref data);
                File.WriteAllText("dbReservation.txt", string.Empty);
                for (int i = 0; i<data.Length; ++i)
                {
                    if (data[i][0] != idRes)
                    {
                        Database.SetData("dbReservation.txt", data[i]);

                    }
                    else
                        idx = i;

                }

                //ParkingSpot
                string[][] dataParking = { };
                Database.GetData("dbParkingSpot.txt", ref dataParking);
                File.WriteAllText("dbParkingSpot.txt", string.Empty);
                for (int i = 0; i < dataParking.Length; ++i)
                {
                    if (dataParking[i][0] == data[idx][2])
                    {
                        dataParking[i][3] = "false";
                    }
                            

                    Database.SetData("dbParkingSpot.txt", dataParking[i]); //Oui vide le contenue avant
                }

            }
        }
    }
}