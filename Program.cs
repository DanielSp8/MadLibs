using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MadLibs
{
    class Program
    {

        static void Main(string[] args)
        {
            int getSymbolNum, counter = 0;
            string line;

            if (File.Exists(@"C:\Temp\MadLibs\SpeechSymbols.txt"))
            {
                getSymbolNum = GetSymbolNumber();

            string[] arraySymbols = new String[getSymbolNum];
                StreamReader file =
                    new StreamReader(@"C:\Temp\MadLibs\SpeechSymbols.txt");
                while ((line = file.ReadLine()) != null)
                {
                    arraySymbols[counter] = line;
                    counter++;
                }

                file.Close();

                MainMenu(arraySymbols);
            }
            else
            {
                Console.WriteLine("A file is not found.");
                Console.WriteLine("Make sure the needed files are in the following directory:");
                Console.WriteLine("C:\\Temp\\MadLibs\\");
            }

        }

        static void MainMenu(string[] arraySymbols)
        {
            int getNum;
            string getFileNameFromUser;
            ConsoleKeyInfo getUserInput;

            do
            { 
                Console.Clear();
                Console.WriteLine("1) A Day at the Zoo");
                Console.WriteLine("2) First Day of School");
                Console.WriteLine("3) In the Jungle");
                Console.WriteLine("4) A Love Letter");
                Console.WriteLine("5) The Fun Park");
                Console.WriteLine("6) Vacations");
                Console.WriteLine("7) Enter a Different MadLib FileName");
                Console.WriteLine("Press Escape to exit this program.");
                getUserInput = Console.ReadKey();

                if (getUserInput.KeyChar == '1')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\dayatthezoo.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\dayatthezoo.txt");
                    }
                }
                else if (getUserInput.KeyChar == '2')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\firstdayofschool.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\firstdayofschool.txt");
                    }

                }
                else if (getUserInput.KeyChar == '3')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\inthejungle.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\inthejungle.txt");
                    }
                }
                else if (getUserInput.KeyChar == '4')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\loveletter.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\loveletter.txt");
                    }
                }
                else if (getUserInput.KeyChar == '5')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\thefunpark.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\thefunpark.txt");
                    }
                }
                else if (getUserInput.KeyChar == '6')
                {
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\vacations.txt", arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\vacations.txt");
                    }
                }
                else if (getUserInput.KeyChar == '7')
                {
                    Console.WriteLine("Enter the MadLib filename: ");
                    getFileNameFromUser = Console.ReadLine();
                    getNum = GetFileNumber(@"C:\Temp\MadLibs\" + getFileNameFromUser, arraySymbols);
                    if (getNum != 0)
                    {
                        RunMadLib(arraySymbols, getNum, @"C:\Temp\MadLibs\" + getFileNameFromUser);
                    }
                }
                else if (getUserInput.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nExiting Program...");
                }
            } while (getUserInput.Key != ConsoleKey.Escape);
        }
        static int GetSymbolNumber()
        {
            int s = 0;
            string lineTake;
            StreamReader symbolFile =
                new StreamReader(@"C:\Temp\MadLibs\SpeechSymbols.txt");

            while ((lineTake = symbolFile.ReadLine()) != null)
            {
                s++;
            }
            symbolFile.Close();
            return s;
        }
        static int GetFileNumber(string madLibFileName, string[] arraySymbols)     //This method returns the number of lines in the MadLib text file.
        {
            int c = 0;
            string lineGrab;
                       
            if (File.Exists(madLibFileName))
            {
                Console.WriteLine("The file exists!");
                StreamReader madLibberFile =
                    new StreamReader(madLibFileName);

                while ((lineGrab = madLibberFile.ReadLine()) != null)
                {
                    c++;
                }
                madLibberFile.Close();
                return c;
            }
            else
            {
                FileErrorMsg();
                MainMenu(arraySymbols);
                return 0;
            }
        }
        static void FileErrorMsg()
        {
            Console.WriteLine("\nThe file does NOT exist!");
            Console.WriteLine("\n\nTry entering a different option...");
            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
        }
        static void RunMadLib(string[] arraySymbols, int getNum, string madLibFile)
        {
            int c = 0;
            string[] wordsEnter = new string[getNum];
            string lineGrab;
            string[] lineTouchUp = new string[getNum];

            StreamReader madLibbingFile =
                new StreamReader(madLibFile);

            // Copy the file information to an array.
            while ((lineGrab = madLibbingFile.ReadLine()) != null)
            {
                lineTouchUp[c] = lineGrab;
                c++;
            }
            madLibbingFile.Close();

            Console.Clear();
            Console.WriteLine("Get ready to enter different types of words for this MadLib!\n");
            

            for(int count=0; count<getNum; count++)
            {
                if (lineTouchUp[count].Contains("*") == true)
                {
                    for(c=0; c < arraySymbols.Length; c++)
                    {
                        if(lineTouchUp[count].Contains(arraySymbols[c]))
                        {
                            Console.WriteLine("{0}", arraySymbols[c+1]);
                            wordsEnter[count] = Console.ReadLine();
                            lineTouchUp[count]=lineTouchUp[count].Replace(arraySymbols[c], wordsEnter[count]);
                        }                       
                    }
                }
            }

            Console.Clear();

            for (int count = 0; count < getNum; count++)
            {
                Console.WriteLine("{0}", lineTouchUp[count]);
            }

            Console.WriteLine("Press the Escape key to return to the Main Menu...");
            ConsoleKeyInfo info;
            
            do
            {
                info = Console.ReadKey();
                if (info.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("You pressed Escape!");
                    MainMenu(arraySymbols);
                }
            } while (info.Key != ConsoleKey.Escape);    
        }
    }
}



