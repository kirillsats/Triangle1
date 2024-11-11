using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle1
{
    class Triangle1
    {
        public double A;
        public double B;
        public double C;
        public double H;

        public Triangle1() { }

        public Triangle1(double a)
        {
            A = a;
            B = a;
            C = a;
        }


        public Triangle1(double A, double B, double C) // Конструктор с тремя сторонами
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle1(double a, double ha)
        {
            A = a;
            H = ha;
            B = a; // Прямоугольный треугольник с двумя равными сторонами
            C = Math.Sqrt(A * A + H * H); // Используем Пифагора для нахождения гипотенузы
        }

        public string GetTriangleType()
        {
            if (A == B && B == C) return "Võrdkülgne";
            if (A == B || B == C || A == C) return "Võrdhaarsed";
            if (Math.Pow(A, 2) + Math.Pow(B, 2) == Math.Pow(C, 2)) return "Ristkülikukujuline";
            if (Math.Pow(A, 2) + Math.Pow(B, 2) < Math.Pow(C, 2)) return "nüri";
            if (Math.Pow(A, 2) + Math.Pow(B, 2) > Math.Pow(C, 2)) return "Teravnurkne";
            return "Mitmekülgne"; // по умолчанию
        }


        public string OutputA()  // Метод для вывода стороны A
        {
            return Convert.ToString(A); // Возвращаем значение стороны A в виде строки
        }

        public string OutputB() // Метод для вывода стороны B
        {
            return Convert.ToString(B); // Возвращаем значение стороны B в виде строки
        }

        public string OutputC() // Метод для вывода стороны C
        {
            return Convert.ToString(C); // Возвращаем значение стороны C в виде строки
        }

        public double Perimeter()
        {
            return A + B + C;
        }

        public double Area() // Метод для вычисления площади треугольника
        {
            if (H > 0) // Проверка, задана ли высота
            {
                return (A * H) / 2;
            }
            else
            {
                // Если высота не задана
                double s = (A + B + C) / 2;
                return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
            }
        }

        // Свойства для доступа к сторонам
        public double GetSetA // Свойство для установки и получения значения стороны A
        {
            get { return A; }
            set { A = value; }
        }

        public double GetSetB // Свойство для установки и получения значения стороны B
        {
            get { return B; }
            set { B = value; }
        }

        public double GetSetC // Свойство для установки и получения значения стороны C
        {
            get { return C; }
            set { C = value; }
        }

        public bool ExistTriangle  // Свойство для проверки существования треугольника
        {
            get
            {
                // Проверяем, что все стороны положительные и что сумма любых двух сторон больше третьей
                return (A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A));
            }
        }

        public bool ExistTriangle1
        {
            get
            {
                // Проверяем, что стороны A и высота H положительные числа
                return A > 0 && H > 0;
            }
        }

    }
}