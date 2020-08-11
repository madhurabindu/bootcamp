using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomColorCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorCoder cd = new ColorCoder();
            Console.WriteLine(  cd.ToString());
            ColorChecker();
            PairChecker();
        }

        static void ColorChecker()
        { 
            ColorCoder colorCoder = new ColorCoder();
            bool loop = true;
            while (loop)
            {
                Console.Write("Enter the pair number between 1-25: ");
                string input = Console.ReadLine();
                int pairNumber;
                if (int.TryParse(input, out pairNumber))
                {
                    if (pairNumber > 0 && pairNumber <= 25)
                    {
                        var ret = colorCoder.GetColorFromPairNumber(pairNumber);
                        Console.WriteLine();
                        Console.WriteLine("{0},{1}", ret[0], ret[1]);
                    }
                    else if(pairNumber ==0)
                    {
                        loop = false;
                    }
                    else
                    {

                    }
                }
            }
        }

        static void PairChecker()
        {
            ColorCoder colorCoder = new ColorCoder();
            bool loop = true;
            while (loop)
            {
                Console.Write("Enter the Major Color : ");
                string input = Console.ReadLine();
                Color majorColor = Color.FromName(input);

                Console.Write("Enter the Minor Color : ");
                input = Console.ReadLine();
                Color minorColor = Color.FromName(input);

                if (majorColor.IsKnownColor && minorColor.IsKnownColor)
                {
                    var ret = colorCoder.GetPairNumberFromColor(majorColor, minorColor);
                    Console.WriteLine();
                    Console.WriteLine("PairNumber: {0}", ret);
                }
                else
                {
                    if (majorColor == Color.Pink || minorColor == Color.Pink)
                    {
                        loop = false;
                    }
                }
            }
        }
    }
}
