using System;

/*

Fare una funzione che prenda in input una parabola con asse di simmetria parallelo all'asse delle y e una retta e che restituisca
1. (per valore ossia con return) quante intersezioni ci sono tra la parabola e la retta
2. (per riferimento) i due punti di intersezione ossia le quattro coordinate (usa il più corretto tra ref e out)

Fare un'applicazione console che chieda in input 
* una parabola, 
* una retta 
e che, utilizzando la funzione appena scritta stampi
* le informazioni relative all'intersezione (nessuna intersezione, una intersezione nel punto ..., due intersezioni nei punti ..., ...)

 */

namespace IntersezioneRettaParabola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci a, b e c della parabola");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Inserisci m e q della retta");
            double m = double.Parse(Console.ReadLine());
            double q = double.Parse(Console.ReadLine());

            double x1;
            double x2;
            double y1;
            double y2;

            int numeroSoluzioni = Intersezione(a, b, c, m, q, out x1, out x2, out y1, out y2);

            if (numeroSoluzioni == 0)
                Console.WriteLine("La retta non interseca la parabola");
            else if (numeroSoluzioni == 1)
                Console.WriteLine("La retta interseca la parabola nel punto P({0},{1})", x1, y1);
            else // if (numeroSoluzioni == 2)
                Console.WriteLine("La retta interseca la parabola nel punto P1({0},{1}) e nel punto P2({2},{3})", x1, y1, x2, y2);

        }

        private static int Intersezione(double a, double b, double c, double m, double q, out double x1, out double x2, out double y1, out double y2)
        {
            double delta = Math.Pow(b - m, 2) - 4 * (c - q);
            if (delta < 0)
            {
                x1 = 0;
                x2 = 0;
                y1 = 0;
                y2 = 0;
                return 0;
            }

            x1 = ((-b + m) + Math.Sqrt(delta)) / (2 * a);
            x2 = ((-b + m) - Math.Sqrt(delta)) / (2 * a);
            y1 = m * x1 + q;
            y2 = m * x2 + q;

            if (delta == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
