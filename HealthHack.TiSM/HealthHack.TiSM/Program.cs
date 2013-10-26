using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using HealthHack.TiSM.Model;

namespace HealthHack.TiSM
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string fileContent = "";
                try
                {
                    using (StreamReader reader = new StreamReader(File.OpenRead(args[0].ToString())))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    Manager manager = new Manager();
                    List<Mutation> list = manager.GetMutationList(fileContent);
                    foreach (Mutation mutation in list)
                    {
                        if (args[1] != string.Empty)
                        {
                            try
                            {
                                using (StreamReader reader = new StreamReader(File.OpenRead(mutation.getCDNAFileName(args[1].ToString()) )))
                                {
                                    fileContent = reader.ReadToEnd();
                                    fileContent = fileContent.Replace("\n", "");
                                    manager.GetMutationPattern(mutation, fileContent);

                                }
                            }
                            catch (FileNotFoundException e)
                            {
                                mutation.ProcessOutput = e.Message;
                            }
                        }
                    }
                    manager.PersistToDB(list);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Console.Read();
                }
            }
        }
    }
}
