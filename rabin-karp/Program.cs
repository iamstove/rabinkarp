using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabin_karp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rabin Karp!");
            Console.Write("Please enter the name of a text file you want to search through: ");
            string fname = Console.ReadLine();
            string path = Directory.GetCurrentDirectory();

            using(FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read){ //do everything with the file in here, in this case it's everything
                Console.Write("Enter what you're searching for: ");
                string pattern = Console.ReadLine();
                //hash the pattern
                for(int i = 0; i < (int)pattern.Length; i++){

                }
                //first read is size pattern.length, everything after is just 1 to compute the rolling hash. 
            }
        }
    }
}
