using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //wait for user to hit first enter key with do while loop
            ConsoleKeyInfo keyRead;
            do
            {
                Console.WriteLine("Upon pressing 'enter', this application will count as high as it can until you press 'enter' again.");
                keyRead = Console.ReadKey();
            } while (keyRead.Key != ConsoleKey.Enter);

            //start threads
            System.Threading.Thread threadA = new Thread(ThreadA);
            System.Threading.Thread threadB = new Thread(ThreadB);
            threadA.Start();
            threadB.Start();

            //check for second enter key hit
            ConsoleKeyInfo keyRead2;
            keyRead2 = Console.ReadKey();
            if (keyRead2.Key == ConsoleKey.Enter)
            {

                //find the two numbers in the list
                int finalnumber2 = entries[entries.Count - 1];
                int finalnumber1 = entries.Last();

                //print the last two numbers in the list
                Console.WriteLine(finalnumber2);
                Console.WriteLine(finalnumber1);

            }
            Console.ReadLine();

        }

        private static bool continueCounting = true;
        static void ThreadA()
        {
            int count1 = 0;
            for (int i = 0; i < 1000000; i++)
            {
                count1++;
            }
            entries.Add(count1);
            continueCounting = false;
        }

        static void ThreadB()
        {
            int count = 0;
            while (continueCounting)
            {
                count++;
            }
            entries.Add(count);
        }
        //list to store the totals from threadA and threadB
        static List<int> entries = new List<int>();

    }
}

