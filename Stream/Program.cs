using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Dir";
            string subpath = "program\\test";        
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            int Id=0;
            string PassportSeria=null;
            int PassportNumber=0;
            double Debt=0;
            link1:
            Console.WriteLine("For read line from file press 1 for adding new client press 2 for reading existing file press 3 for splitted line press 4");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    ReadLine();
                    goto link1;
                case "2":
                    Writetofile();
                    goto link1;
                case "3":
                    Readfile();
                    goto link1;
                case "4":
                    Splitline();
                    goto link1;
                default:
                    Console.WriteLine("Choose from 1,2,3 or 4");
                    goto link1;
            }
            void Writetofile()
            {
                Console.WriteLine("Enter the ID");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Passport Seria");
                PassportSeria = Console.ReadLine();
                Console.WriteLine("Enter the Passport Number");
                PassportNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Debt");
                Debt = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the new or existing file name");
                string note = Console.ReadLine();
                using (FileStream fstream = new FileStream($"{path}\\{subpath}\\{note}.txt", FileMode.OpenOrCreate)) { }
                using (StreamWriter sw = new StreamWriter($"{path}\\{subpath}\\{note}.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(Id.ToString("000") + ";" + PassportSeria + PassportNumber.ToString("00000000") + ";" + Debt);
                }
                Client clientwrite = new Client(Id, PassportSeria, PassportNumber, Debt);
                string line = clientwrite.ToString();
                Console.WriteLine(line);
            }

            void Readfile()
            {
                Console.WriteLine("Enter the file name");
                string note = Console.ReadLine();
                using (StreamReader sr = new StreamReader($"{path}\\{subpath}\\{note}.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                
            }
            void ReadLine()
            {
                Console.WriteLine("Enter the file name");
                string note = Console.ReadLine();
                using (StreamReader sr = new StreamReader($"{path}\\{subpath}\\{note}.txt", System.Text.Encoding.Default))
                {
                    string line;
                    line = sr.ReadLine();
                    
                        Console.WriteLine(line);
                    
                }
            }
            void Splitline ()
            {
                Console.WriteLine("Enter the file name");
                string note = Console.ReadLine();
                using (StreamReader sr = new StreamReader($"{path}\\{subpath}\\{note}.txt", System.Text.Encoding.Default))
                {
                    string line;
                    line = sr.ReadLine();
                    string[] splitted = line.Split(';');
                    foreach ( string s3 in splitted)
                    {
                        Console.WriteLine(s3);
                    }
                }
            }
            Console.ReadKey();

        }

        
        
    }
    [Serializable]
    public class Client
    {
        public int id { get; set; }
        public string passportseria { get; set; }
        public int pasportnumber {get;set;}
        public double debt { get; set; }

        public Client(int Id, string PassportSeria,int PassportNumber, double Debt ) { id = Id;passportseria = PassportSeria;pasportnumber = PassportNumber;debt = Debt;}
        public override string ToString()
        {
            return $"{id};{passportseria};{pasportnumber};{debt}";
        }
    }
}
