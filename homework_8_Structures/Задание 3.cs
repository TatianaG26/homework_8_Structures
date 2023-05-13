using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_8_Structures
{
    internal class Задание_3
    {
        /* Задание 3
        Создайте структуру «RGB цвет». 
        Определите внутри неё необходимые поля и методы. 
        Реализуйте следующую функциональность:
        ■ Перевод в HEX формат;
        ■ Перевод в HSL;
        ■ Перевод в CMYK. */
        struct RGBColor
        {
            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }

            public RGBColor(byte red, byte green, byte blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }
            public string ToHex() // перевод в HEX формат
            {
                // Цвет в формате HEX — это ни что иное, как шестнадцатеричное представление RGB
                return $"#{Red:X2}{Green:X2}{Blue:X2}";
            }
            public (int hue, double saturation, double lightness) ToHsl() // перевод в HSL формат
            {
                // HSL формат - цветовая модель, в которой цветовыми координатами являются тон, насыщенность и светлота

                double r = (double)Red / 255;
                double g = (double)Green / 255;
                double b = (double)Blue / 255;

                double max = Math.Max(r, Math.Max(g, b));
                double min = Math.Min(r, Math.Min(g, b));
                double hue = 0;
                double saturation = 0;
                double lightness = (max + min) / 2;

                if (max != min)
                {
                    double delta = max - min;
                    saturation = lightness > 0.5 ? delta / (2 - max - min) : delta / (max + min);

                    if (r == max)
                    {
                        hue = (g - b) / delta + (g < b ? 6 : 0);
                    }
                    else if (g == max)
                    {
                        hue = (b - r) / delta + 2;
                    }
                    else if (b == max)
                    {
                        hue = (r - g) / delta + 4;
                    }

                    hue /= 6;
                }

                int hueDegrees = (int)Math.Round(hue * 360);
                double saturationPercent = Math.Round(saturation * 100);
                double lightnessPercent = Math.Round(lightness * 100);

                return (hueDegrees, saturationPercent, lightnessPercent);
            }
            public (double cyan, double magenta, double yellow, double key) ToCmyk()  // перевода в CMYK формат
            {
                // CMYK (Cyan, Magenta, Yellow, Key или Black) — субтрактивная схема формирования цвета, используемая прежде всего в полиграфии для стандартной триадной печати.
                // Она использует голубой, пурпурный и жёлтый цвета в роли основных, а также чёрный цвет.

                double r = (double)Red / 255;
                double g = (double)Green / 255;
                double b = (double)Blue / 255;

                double k = 1 - Math.Max(r, Math.Max(g, b));
                double c = (1 - r - k) / (1 - k);
                double m = (1 - g - k) / (1 - k);
                double y = (1 - b - k) / (1 - k);

                return (Math.Round(c * 100), Math.Round(m * 100), Math.Round(y * 100), Math.Round(k * 100));
            }
            public override string ToString()
            {
                return $"RGB ({Red}, {Green}, {Blue})" + Environment.NewLine +
                       $"HEX {ToHex()}" + Environment.NewLine +
                       $"HSL {ToHsl().hue}, {ToHsl().saturation}%, {ToHsl().lightness}%" + Environment.NewLine +
                       $"CMYK {ToCmyk().cyan}%, {ToCmyk().magenta}%, {ToCmyk().yellow}%, {ToCmyk().key}%\n";
            }
        } 
        static void Main(string[] args)
        {
            RGBColor color1 = new RGBColor(255, 0, 0); // Красный
            RGBColor color2 = new RGBColor(0, 128, 0); // Зеленый
            RGBColor color3 = new RGBColor(0, 0, 255); // Синий

            Console.WriteLine(color1);
            Console.WriteLine(color2);
            Console.WriteLine(color3);

        }

    }
}
