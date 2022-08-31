using System;
using System.IO;
using System.Linq;

namespace Ticketing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            string[] header = { "TicketID", "Summary", "Status", "Priority", "Submitter", "Assigned", "Watching" };


            do
            {
                Console.WriteLine("1. Read Data from file.");
                Console.WriteLine("2. Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();
                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);

                        while (!sr.EndOfStream)
                        {   
                            sr.ReadLine();
                            string line = sr.ReadLine();
                           
                            string[] arr = line.Split(',');

                            string comma = "";
                            for(int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(comma);
                                Console.Write(arr[i]);
                                comma = ", ";

                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            
                        }

                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file);
                    string name = "";
    
                    Console.WriteLine("Enter TicketID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Summary: ");
                    string sum = Console.ReadLine();

                    Console.WriteLine("Status (Open or Closed): ");
                    string stat = Console.ReadLine();

                    Console.WriteLine("Priority (Low, Medium, High, or Urgent)");
                    string pri = Console.ReadLine();

                    Console.WriteLine("Submitted by: ");
                    string sub = Console.ReadLine();

                    Console.WriteLine("Assigned to: ");
                    string ass = Console.ReadLine();

                    Console.WriteLine("How many are watching the ticket: ");
                    int watch = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < watch; i++)
                    {
                        Console.WriteLine("Enter name of watcher. ");
                        name += (Console.ReadLine() + '|');
                       

                  
                    }

                    string watchList = name.Remove(name.Length - 1);
                    sw.WriteLine(string.Join(", ", header));
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", id, sum, stat, pri, sub, ass, watchList);
                    sw.Close();
                }

            } while (choice == "1" || choice == "2");
        }
    }
}
