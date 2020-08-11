using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelecomColorCoder
{
    class ColorCoder
    {
        private static Color[] colorMapMajor;
        private static Color[] colorMapMinor;


        static ColorCoder()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet};
            colorMapMinor = new Color[] {Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        public Color[] GetColorFromPairNumber(int pairNumber)
        {
            int majorSize = colorMapMajor.Length;
            int minorSize = colorMapMinor.Length;

            int majorIndex = pairNumber / majorSize;
            int minorIndex = (pairNumber % minorSize) == 0 ? minorSize-1 : (pairNumber % 5) - 1;
            return new Color[] { colorMapMajor[majorIndex], colorMapMinor[minorIndex] };
        }

        public int GetPairNumberFromColor(Color major, Color minor)
        {
            int majorIndex = -1;
            for(int i = 0; i < colorMapMajor.Length; i++)
            {
                if(colorMapMajor[i] == major)
                {
                    majorIndex = i;
                    break;
                }
            }

            int minorIndex = -1;
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == minor)
                {
                    minorIndex = i;
                    break;
                }
            }

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }

        public override string ToString()
        {
            string retValue = string.Empty;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                for (int j = 0; j < colorMapMinor.Length; j++)
                {
                    int pairNumber = GetPairNumberFromColor(colorMapMajor[i], colorMapMinor[j]);

                    retValue = retValue + string.Format("{0} === {1} === {2}\n",pairNumber, colorMapMajor[i].Name, colorMapMinor[j].Name);
                }
                retValue = retValue + "\n";
            }

            return retValue;
        }
    }
}
