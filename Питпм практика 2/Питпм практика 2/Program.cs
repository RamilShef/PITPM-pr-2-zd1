using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Питпм_практика_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите длины трех сторон :");

                Console.Write("Сторона a: ");
                double a = GetValidSideLength();

                Console.Write("Сторона b: ");
                double b = GetValidSideLength();

                Console.Write("Сторона c: ");
                double c = GetValidSideLength();

                if (!IsTriangle(a, b, c))
                {
                    Console.WriteLine("Треугольник с такими сторонами не может существовать.");
                    return;
                }

                string triangleType = GetTriangleType(a, b, c);
                double area = CalculateArea(a, b, c);

                Console.WriteLine($"Вид треугольника: {triangleType}");
                Console.WriteLine($"Площадь треугольника: {area:F2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введены некорректные данные. Пожалуйста, введите численные значения.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }
       

        static double GetValidSideLength()
        {
            double length;
            while (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.WriteLine("Ошибка: длина стороны должна быть положительным числом. Попробуйте еще раз:");
            }
            return length;
        }

        static bool IsTriangle(double a, double b, double c)
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        static string GetTriangleType(double a, double b, double c)
        {
            if (a == b && b == c)
                return "равносторонний";
            else if (a == b || b == c || a == c)
                return "равнобедренный";
            else
                return "разносторонний";
        }

        static double CalculateArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); //  Герон

        }

        
    }

}
