using System;
using views;
using System.IO;

namespace App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //---------------------------------------Je cree un fichier -------------------------------------
            // Vérifions si un argument de ligne de commande a été fourni
           /* if (args.Length == 0)
            {
                Console.WriteLine("Veuillez fournir un nom de fichier en argument.");
                return;
            }

            // Récupération du nom du fichier à partir des arguments de la ligne de commande
            string nomFichier = args[0];

            // Création du chemin complet du fichier en concaténant le nom du fichier avec le chemin de la racine du projet
            string cheminFichier = Path.Combine(Directory.GetCurrentDirectory(), nomFichier);

            // Vérifions si le fichier existe déjà
            if (File.Exists(cheminFichier))
            {
                Console.WriteLine("Le fichier existe déjà.");
                return;
            }

            // Créons le fichier
            File.Create(cheminFichier); */

            //-----------------------------------------------Fin de la creation du fichier ------------------------------

            //Console.WriteLine($"Le fichier \"{nomFichier}\" a été créé avec succès à la racine du projet.");
            Display display = new Display();
            display.Show();

        }
    }
}