using System;
using System.Collections.Generic;
using System.IO;

namespace SurfSequence
{
    class Program
    {
        public static void run(string path)
        {
            List<String[]> listContest = new List<String[]>();
            string[] info = { };

            if (File.Exists(path)) //validator 
            {
               info = File.ReadAllLines(path); //file reader
            }

            else //alternative flow 
            {
                Console.WriteLine("Incorrect file path, please enter a valid path.");
            }


            int counter = 0;
            int minor = 0;
            foreach (string i in info) //names and scores splitter 
            {
                string[] names = i.Split(' ');

                listContest.Add(names);
                if (int.Parse(listContest[counter][1]) < int.Parse(listContest[minor][1]))
                {
                    minor = counter;
                }

                counter++;
            }

            //Sorter
            int firstPlace = minor;
            int secondPlace = minor;
            int thirdPlace = minor;


            for (int i = 1; i < listContest.Count; i++)
            {
                if (int.Parse(listContest[firstPlace][1]) < int.Parse(listContest[i][1]))
                {
                    thirdPlace = secondPlace;
                    secondPlace = firstPlace;
                    firstPlace = i;
                }
            }

            //Output display
            Console.WriteLine("The first place is " + listContest[firstPlace][0] + " with " + listContest[firstPlace][1]);
            Console.WriteLine("The second place is " + listContest[secondPlace][0] + " with " + listContest[secondPlace][1]);
            Console.WriteLine("The third place is " + listContest[thirdPlace][0] + " with " + listContest[thirdPlace][1]);
        }
       



        static void Main(string[] args)
        {

            run(@"C:\Users\Alejandro Perez G\Desktop\scores.txt");

        }
    }
}


//Original file path: @"C:\Users\Alejandro Perez G\Desktop\scores.txt"