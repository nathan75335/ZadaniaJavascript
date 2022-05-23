using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"C:\Users\NATHAN KALENGA\Downloads\File.txt", FileMode.OpenOrCreate);

            StreamWriter writer = new StreamWriter(stream);

            DirectoryInfo dInfo = new DirectoryInfo(@"C:\Users\NATHAN KALENGA\Documents");

            var files = dInfo.GetFiles("*.txt" , SearchOption.AllDirectories);

            var list = (from file in files
                       orderby file.FullName
                       select file).ToList();

            foreach (var file in list)
            {
                var lines = File.ReadAllText(file.FullName);

                Console.WriteLine(file.FullName);

                writer.WriteLine(lines);
            }
            stream.Close();

            var listOfFiles = from file in files
                              group file.FullName by System.IO.Path.GetDirectoryName(file.FullName) into grp
                              select new
                              {
                                  FileName = grp.ToList() ,
                                  Parent = grp.Key
                              };
            
            foreach (var file in listOfFiles)
            {
                Console.WriteLine(file.Parent);
                foreach(var child in file.FileName)
                {
                    Console.WriteLine("\t" + child);
                }
            }
            Console.ReadLine();
        }
    }
}
