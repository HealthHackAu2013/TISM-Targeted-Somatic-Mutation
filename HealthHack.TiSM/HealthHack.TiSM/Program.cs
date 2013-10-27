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
                    /*  args[0] refers to the csv list of mutations
                     *  we need to verify the structure is correct as per the applications expectations
                     */

                    using (StreamReader reader = new StreamReader(File.OpenRead(args[0].ToString())))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    Manager manager = new Manager();
                    List<Mutation> list = manager.GetMutationList(fileContent);
                    foreach (Mutation mutation in list)
                    {
                        /*
                         *  args[1] refers to the folder which contains the specific gene transcripts to look up
                         *  we need to verify that the actual gene transcript file opened looks correct.
                         */
                        if (args[1] != string.Empty)
                        {
                            try
                            {
                                string CDNAFullPath = mutation.getCDNAFileName(args[1].ToString());
                                //string CDNAFileName = Path.GetFileName(CDNAFullPath);
                                //string filePrefix = ">" + CDNAFileName.Remove(CDNAFileName.IndexOf("_cdna.")); 

                                using (StreamReader reader = new StreamReader(File.OpenRead(CDNAFullPath)))
                                {
                                    fileContent = reader.ReadToEnd();
                                    
                                    /* Need to trim start fo file, remove gene name, and transcript ID if it is there as well.
                                     *                                      
                                     */
                                    fileContent = fileContent.Substring(fileContent.IndexOf("\n")+1);
                                    fileContent = fileContent.Replace("\n", "");
                                    if (fileContent.Substring(0, 3).ToUpper() == "ATG")
                                    {   // Valid files start with ATG
                                        manager.GetMutationPattern(mutation, fileContent);
                                    }
                                    else
                                    {
                                        /*
                                         * We need to present to the user some information on which genes we could not find a valid file for
                                         *                                          
                                        Console.Write("Invalid file found, not begining with 'ATG'." + Environment.NewLine
                                            + "File began with:" + fileContent.Substring(0, 3) + Environment.NewLine
                                            + "For Gene: " + mutation.Gene
                                            );
                                         * * */

                                    }

                                }
                            }
                            catch (FileNotFoundException e)
                            {
                                mutation.ProcessOutput = e.Message;

                                throw e;
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
