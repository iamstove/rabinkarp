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
        public static int R = 256; //size of ascii
        static void Main(string[] args)
        {
            
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
            double pathorners = horners(pattern);

            using(FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read)){ //do everything with the file in here, in this case it's everything
                //first read is size pattern.length, everything after is just 1 to compute the rolling hash. 
                byte[] buffer = new byte[(int)pattern.Length];

            }
        }

        public static double horners(string instring)
        {
            double hhash = 0;
            for (int i = 0; i < (int)instring.Length; i++)
            { //use horner's method on the pattern to create a hash for the string
                //Console.WriteLine("R ^ (len-i) = " + Math.Pow(R, ((int)instring.Length - i)));
                //Console.WriteLine("char = " + (int)instring[i]);
                double letter = (double)((int)instring[i] * Math.Pow(R, ((int)instring.Length - i)));
                //Console.WriteLine(letter);
                hhash += letter;
            }
            return hhash;
        }

        public static double rollhash(double hash, char oldchar, char newchar, int len) //removes the front of the oldchar from the front and appends newchar to the end
        {
            hash = hash - ((int)oldchar * Math.Pow(R, len));
            hash *= R;
            hash = hash + (int)newchar;
            return hash;
        }
    }
}
