using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static double Linear(double alpha)
        {
            double z1;
            z1 = (Math.Sin(2 * alpha) + Math.Sin(5 * alpha) - Math.Sin(2 * alpha)) / (Math.Cos(alpha) - Math.Cos(3 * alpha) + Math.Cos(5 * alpha));
            return z1;
        }


        static double Piecewise(double x)
        {
            double y;
            if (x < -10 && x > 6)
                Console.WriteLine("Unknown value");
            return 0;
            if (x > -10 && x < 0)
                y = -2 * x - 6;
            return y;
            if (x > 0 && x < 3)
                y = -Math.Sqrt(9 - Math.Pow(x, 2));
            return y;
            if (x > 3 && x < 6)
                y = Math.Sqrt(9 - Math.Pow(x + 6, 2));
            return y;
        }


        static void Point(double R, double x, double y)
        {


            if (y < 0 && y > -R && x < 0)
                if (Math.Abs(x) + Math.Abs(y - R) <= R)
                    Console.WriteLine("Right on target");
                else
                    Console.WriteLine("Loser");
            if (y < 0 && x > 0)
                Console.WriteLine("Loser");
            if (y > 0)
                if (y <= Math.Sqrt(Math.Pow(R, 2) - Math.Pow(x, 2)))
                    Console.WriteLine("Right on target");
                else
                    Console.WriteLine("Loser");
        }



        static void Taylor(double a, double b, double d, double E)
        {

            double x = a;
            float N = 10000;
            while (x <= b)
            {
                int n = 0;
                double sum = 0;
                double e = 0;
                do
                {
                    sum += Math.Pow(-1.0, n) * Math.Pow(x, 2 * n + 1) / (2 * n + 1);
                    ++n;
                    e = 1.0 / (2 * n + 1);
                } while (E >= e);
                sum = Math.Round((sum * N + 0.5f) / N);
                Console.WriteLine(x);
                Console.WriteLine(" ");
                Console.WriteLine(sum);
                Console.WriteLine(" ");
                Console.WriteLine(n);
                Console.WriteLine(" ");
                x += d;
            }
        }


        static void Rank1()

        {
            Console.WriteLine("enter number of elements");
            int length = int.Parse(Console.ReadLine());
            int[] mas = new int[length];
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                int c = 0;
                c = int.Parse(Console.ReadLine());
                mas[i] = c;

            }
            for (int k = 0; k < length; k++)
            {
                if (mas[k] % 2 == 1)
                    sum += mas[k];
                Console.WriteLine(sum);

            }

            int s2 = 0, otr1 = 0, otr2 = 0;
            for (int i = 0; i < length; i++)
            {
                if (mas[i] < 0)
                {
                    otr1 = mas[i];
                    Console.WriteLine("Первый отрицательный элемент= {0}", otr1);
                    for (i = length - 1; i > -1; --i)// последний отрицательный элемент 
                    {
                        if (mas[i] < 0)
                        {
                            otr2 = mas[i];
                            Console.WriteLine("Последний отрицательный элемент= {0}", otr2);
                            for (i = otr1 + 1; i < otr2; i++)
                                s2 = s2 + mas[i];
                            Console.WriteLine("Сумма={0}", s2);
                        }
                    }
                }
            }
        }


        static void Rank2()
        {
            Console.WriteLine("enter number of rows");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("enter number of columns");
            int columns = int.Parse(Console.ReadLine());
            int[,] mas = new int[row, columns];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    int c = 0;
                    c = int.Parse(Console.ReadLine());
                    mas[j, i] = c;
                }
            }
            int sum = 0;
            for (int f = 0; f < columns; f++)
            {
                for (int g = 0; g < row;)
                {
                    if (mas[g, f] < 0)
                        g++;
                    else
                        sum += mas[g, f];
                }

            }
            Console.WriteLine(sum);

            int principal = 0, secondary = 0;

            for (int i = 0; i < columns; i++)
            {

                for (int j = 0; j < row; j++)
                {



                    // Условие для главной диагонали

                    if (i == j)

                        principal += mas[j, i];



                    // Условие для вторичной диагонали

                    if ((i + j) == (columns - 1))

                        secondary += mas[j, i];

                }
                Console.WriteLine(principal);
                Console.WriteLine(secondary);

            }




        }

       




            static void Main(string[] args)
            {

                Console.WriteLine("1 - Linear programs ");
                Console.WriteLine("2-  Piecewise-defined function ");
                Console.WriteLine("3 extra- Hit point ");
                Console.WriteLine("5 extra- Taylor series  ");
                Console.WriteLine("6- 1 of rank 1  ");
                Console.WriteLine("7- 2 of rank 2  ");
                Console.WriteLine("8-  Strings   ");
                Console.WriteLine("9 extra-  Simple data structures   ");
                Console.WriteLine("10-  Simple classes   ");
                Console.WriteLine("11-   Standard collections   ");
                int filter = int.Parse(Console.ReadLine());
                switch (filter)
                {
                    case 1:
                        double alpha = Convert.ToDouble(Console.ReadLine());
                        double z1 = Linear(alpha);
                        Console.WriteLine(z1);
                        break;
                    case 2:
                        double x = Convert.ToDouble(Console.ReadLine());
                        double y = Piecewise(x);
                        Console.WriteLine(y);
                        break;
                    case 3:
                        double R = Convert.ToDouble(Console.ReadLine());
                        double x1 = Convert.ToDouble(Console.ReadLine());
                        double y1 = Convert.ToDouble(Console.ReadLine());
                        Point(R, x1, y1);
                        break;

                    case 5:
                        double x11 = Convert.ToDouble(Console.ReadLine());
                        double x22 = Convert.ToDouble(Console.ReadLine());
                        double dx = Convert.ToDouble(Console.ReadLine());
                        double E = Convert.ToDouble(Console.ReadLine());
                        Taylor(x11, x22, dx, E);
                        break;

                    case 6:
                        Rank1();
                        break;

                    case 7:
                        break;

                }
            }



        }


    }

