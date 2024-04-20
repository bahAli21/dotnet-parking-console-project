using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace database
{
    public static class Database
    {
        public static string[][] GetData(string filepath)
        {
            // List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            string[][] data = {};
            try
            {
                Trace.Assert(filepath != "");
                int i = 0;

                if (File.Exists(filepath))
                {
                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        string tmpLine = string.Empty;
                        while ((tmpLine = sr.ReadLine()) != null)
                        {
                            data[i] = tmpLine.Split(" ");
                            i++;
                        }
                    }

                }
                else
                    throw new Exception("Erreur Lors de l'ouverture du fichier");

            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
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