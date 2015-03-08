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
            int R = 256; //size of ascii
            Console.WriteLine("Welcome to Rabin Karp!");
            string path = Directory.GetCurrentDirectory();
            //Console.WriteLine(path);
            Console.Write("Please enter the name of a text file you want to search through: ");
            string fname = Console.ReadLine();
            path += "/" + fname;
            //Console.WriteLine(path);
            Console.Write("Enter what you're searching for: ");
            string pattern = Console.ReadLine();
            pattern.Trim(); //we won't want to search for leading or trailing whitespace
            //hash the pattern
            double pathorners = 0;
            for(int i = 0; i < (int)pattern.Length; i++){ //use horner's method on the pattern to create a hash for the string
                Console.WriteLine("R ^ (len-i) = " + Math.Pow(R, ((int)pattern.Length - i)));
                Console.WriteLine("char = " + (int)pattern[i]);
                double letter = (double)((int)pattern[i] * Math.Pow(R,((int)pattern.Length - i)));
                //Console.WriteLine(letter);
                pathorners += letter;
            }

            using(FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read)){ //do everything with the file in here, in this case it's everything
                //first read is size pattern.length, everything after is just 1 to compute the rolling hash. 

            }
        }
    }
}
