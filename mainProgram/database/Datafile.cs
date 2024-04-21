using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace database
{
    public static class Database
    {

        public static void GetData(string filepath, ref string[][] data)
        {
            

            try
            {
                if (File.Exists(filepath))
                {
                    List<string[]> dataList = new List<string[]>();

                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        string tmpLine;
                        while ((tmpLine = sr.ReadLine()) != null)
                        {
                            // Vérifie si la ligne n'est pas vide ou nulle
                            if (!string.IsNullOrEmpty(tmpLine))
                            {
                                string[] lineData = tmpLine.Split(' ');
                                dataList.Add(lineData);
                            }
                        }
                    }

                    // Convertir la liste en tableau 2D
                    data = dataList.ToArray();
                }
                else
                {
                    throw new FileNotFoundException("Fichier non trouvé : " + filepath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur s'est produite : " + e.Message);
            }

        }


        public static void SetData(string filepath, string[] lineSplit)
        {
           
            
            string line = string.Join(" ", lineSplit);

            //true parcequ'on souhaite ajouter une nouvelle ligne sans ecraser le contenu ancien
            try
            {
                if (File.Exists(filepath))
                {
                    
                    using (StreamWriter writer = new StreamWriter(filepath, true))
                    {
                        writer.WriteLine(line);
                    }
                } else
                    throw new Exception("Impossible d'ecrire dans le fichier");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}