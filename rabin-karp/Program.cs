using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace rabin_karp
{
    class Program
    {
        public static int R = 256; //size of ascii
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rabin Karp!");
            string path = Directory.GetCurrentDirectory();
            Console.Write("Please enter the name of a text file you want to search through: ");
            string fname = Console.ReadLine();
            path += "/" + fname;
            Console.Write("Enter what you're searching for: ");
            string pattern = Console.ReadLine();
            pattern.Trim(); //we won't want to search for leading or trailing whitespace
            //hash the pattern
            BigInteger pathorners = horners(pattern);

            using(FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read)){ //do everything with the file in here, in this case it's everything
                //first read is size pattern.length, everything after is just 1 to compute the rolling hash. 
                string subtext = "";
                int counter = 0;
                for (int i = 0; i < (int)pattern.Length; i++)
                {
                    subtext += (char)fs.ReadByte();
                    counter++;
                } //subtext is now ready to be hashed
<<<<<<< HEAD
                BigInteger txthorners = horners(subtext);
                Console.WriteLine(txthorners);
                if (txthorners == pathorners)
                {
                    Console.WriteLine("Match found at location " + counter);
                    Environment.Exit(0);
                }
                else //no match, we must roll it baby
                {
                    while (txthorners != pathorners)
                    {
                        char next = (char)fs.ReadByte(); //read in the new byte
                        counter++;
                        if ((int)next == -1)
                        {
                            Console.WriteLine("Pattern not found");
                            break;
                        }
                        //Console.Write();
                        txthorners = rollhash(txthorners, subtext[0], next, (int)subtext.Length); //roll the hash
                        subtext = subtext.Remove(0, 1); //change the string in the text
                        subtext += next;
                        //BigInteger txthorners2 = horners(subtext);
                        Console.WriteLine(subtext + " = " + txthorners);
                        //System.Threading.Thread.Sleep(500);
                    }
=======
                BigInteger txthorners = horners(subtext);                
                do{ 
>>>>>>> c55e6e17adbfeb79e341472e530aad7077b2e320
                    if (txthorners == pathorners)
                    {
                        Console.WriteLine("Match found at location " + counter);
                        //Environment.Exit(0);
                    }
                    int next = fs.ReadByte(); //read in the new byte
                    counter++;
                    if (next == -1)
                    {                            
                        Console.WriteLine("End of file reached");
                        break;
                    }
                    txthorners = rollhash(txthorners, subtext[0], (char)next, (int)subtext.Length); //roll the hash
                    subtext = subtext.Remove(0, 1); //change the string in the text
                    subtext += (char)next;

                    //Console.WriteLine(subtext + " = " + txthorners);
                    //System.Threading.Thread.Sleep(500);                    
                }while(true);
            }
            Console.Read();
        }

        public static BigInteger horners(string instring)
        {
            BigInteger hhash = 0;
            for (int i = 0; i < (int)instring.Length; i++)
            { //use horner's method on the pattern to create a hash for the string
                BigInteger letter = (BigInteger)((int)instring[i] * Math.Pow(R, ((int)instring.Length - (i+1))));
                hhash += letter;
            }
            return hhash;
        }

        public static BigInteger rollhash(BigInteger hash, char oldchar, char newchar, int len) //removes the front of the oldchar from the front and appends newchar to the end
        {
            BigInteger rollnum = (BigInteger)((int)oldchar * Math.Pow(R, len-1));
            hash = hash - rollnum;
            hash = hash * R;
            hash = hash + (int)newchar;
            return hash;
        }
    }
}
