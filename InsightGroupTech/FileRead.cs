using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightGroupTech
{
    class FileRead
    {
        // ArrayList is required because the data in the text file can shift
        public ArrayList coordValue()
        {

            string path = @"c:\Users/joona/source/repos/InsightGroup_Assign1/InsightGroupTech/coordtext.txt";

            ArrayList arr = new ArrayList();

            try
            {
                // just in case, no file or incorrect path exists 
                if (!File.Exists(path))
                {
                    Console.WriteLine("File does not exist");
                }

                StreamReader objReader = new StreamReader(path);

                string sLine = "";

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                    {

                        arr.Add(sLine);
                    }
                    else
                    {
                        break;
                    }
                }

                objReader.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e + ": The process failed.");
            }

            return arr;
        }

    }
}
