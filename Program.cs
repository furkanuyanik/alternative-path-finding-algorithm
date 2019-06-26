using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectAlternativePathsOnGraph
{
    class Program
    {
        static int start = 3;
        static int finish = 4;

        static int count;

        static int[] row;
        static int[] column;
        static bool[,] data;

        static List<List<int>> output = new List<List<int>>();

        public static void findCount()
        {
            int[] total = new int[] { 1, 2, 3, 4, 5 };

            count = total.Count();

            row = total.ToArray();
            column = total.ToArray();
        }
        public static void create()
        {
            data = new bool[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    data[i, j] = false;
                }
            }
        }
        public static void setArray()
        {
            data[0, 2] = true;
            data[0, 3] = true;
            data[0, 4] = true;
            data[1, 2] = true;
            data[1, 4] = true;
            data[2, 0] = true;
            data[2, 1] = true;
            data[3, 0] = true;
            data[3, 4] = true;
            data[4, 0] = true;
            data[4, 1] = true;
            data[4, 3] = true;
        }
        public static void searchAlternatives()
        {
            for (int i = 0; i < count; i++)
            {
                if (column[i] == start)
                {
                    List<int> forbidden = new List<int>();
                    forbidden.Add(column[i]);

                    detectAlternative(i, forbidden);
                }
            }
        }
        public static void detectAlternative(int index, List<int> forbidden)
        {
            for (int i = 0; i < count; i++)
            {
                if (!forbidden.Contains(column[i]))
                {
                    if (data[i, index])
                    {
                        forbidden.Add(column[i]);

                        if (column[i] == finish)
                        {
                            output.Add(forbidden.ToList());
                            forbidden.Remove(forbidden.LastOrDefault());
                            continue;
                        }
                        else
                        {
                            detectAlternative(i, forbidden);
                            forbidden.Remove(forbidden.LastOrDefault());
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            findCount();
            create();
            setArray();
            searchAlternatives();

            foreach (List<int> path in output)
            {
                foreach (int item in path)
                {
                    Console.Write(item + " > ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
