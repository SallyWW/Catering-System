using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class FileAccess
    {
        private Catering totalMenu = new Catering(); // <--- might need to move

        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.
        private string filePath = @"C:\Catering";


       public void ReadInMenuFile()
        {
            string temp = "";
            string[] objectInfo = new string[4];

            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    while(!reader.EndOfStream)
                    {
                        temp = reader.ReadLine();
                        objectInfo = temp.Split("|");
                        CateringItem toAdd = new CateringItem(objectInfo[0], objectInfo[1], double.Parse(objectInfo[2]), objectInfo[3]);
                        totalMenu.addCateringItem(toAdd);
                    }
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }


        }
    }
}
