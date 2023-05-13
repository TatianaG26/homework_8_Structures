namespace homework_8_Structures
{
    internal class Задание_1
    {
        /*Задание 1
          Создайте структуру «Трёхмерный вектор». 
        Определите внутри неё необходимые поля и методы.
        Реализуйте следующую функциональность:
        ■ Умножение вектора на число;
        ■ Сложение векторов; 
        ■ Вычитание векторов.*/
        struct Vector3D
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public Vector3D(double x, double y, double z)  {
                X = x; 
                Y = y; 
                Z = z; 
            }
            public Vector3D MultiplyByNumber(double number) // умножение вектора на число
            {
                return new Vector3D(X * number, Y * number, Z * number);
            }
            public Vector3D Add(Vector3D vector) // сложение векторов
            {
                return new Vector3D(X + vector.X, Y + vector.Y, Z + vector.Z);
            }
            public Vector3D Subtract(Vector3D vector) // вычитание векторов
            {
                return new Vector3D(X - vector.X, Y - vector.Y, Z - vector.Z);
            }
        }

        static void Main(string[] args)
        {
            double n = 2.5;
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(3, 4, 5);

            Console.WriteLine("Первый вектор: ({0}, {1}, {2})", v1.X, v1.Y, v1.Z);
            Console.WriteLine("Второй вектор: ({0}, {1}, {2})\n", v2.X, v2.Y, v2.Z);

            Vector3D res = v1.MultiplyByNumber(n);
            Console.WriteLine("Умножения первого вектора на число {0}: ({1}, {2}, {3})", n, res.X, res.Y, res.Z);

            Vector3D add = v1.Add(v2);
            Console.WriteLine("Сложения векторов: ({0}, {1}, {2})", add.X, add.Y, add.Z);

            Vector3D subtract = v1.Subtract(v2);
            Console.WriteLine("Вычитания векторов: ({0}, {1}, {2})", subtract.X, subtract.Y, subtract.Z);

        }
    }
}