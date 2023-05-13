using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_8_Structures
{
    internal class Задание_2
    {
        /*Создайте структуру «Десятичное число». 
        Определите внутри неё необходимые поля и методы. 
        Реализуйте следующую функциональность:
        ■ Перевод числа в двоичную систему;
        ■ Перевод числа в восьмеричную систему;
        ■ Перевод числа в шестнадцатеричную систему */
        public struct DecimalNumber
        {
            private decimal Value { get; }

            public DecimalNumber(decimal value)
            {
                Value = value;
            }
            public string ToBinary() // перевод числа в двоичную систему
            {
                return Convert.ToString((int)Value, 2);
            }
            public string ToOctal() // перевод числа в восьмеричную систему
            {
                return Convert.ToString((int)Value, 8);
            }
            public string ToHex() // перевод числа в шестнадцатеричную систему
            {
                return Convert.ToString((int)Value, 16);
            }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        static void Main(string[] args)
        {
            DecimalNumber number = new(200);

            Console.WriteLine("Десятичная форма: {0}", number);
            Console.WriteLine("Двоичная форма: {0}", number.ToBinary());
            Console.WriteLine("Восьмеричная форма: {0}", number.ToOctal());
            Console.WriteLine("Шестнадцатеричная форма: {0}", number.ToHex());
        }
    }
}
