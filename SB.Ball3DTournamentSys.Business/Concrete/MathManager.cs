using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public static class MathManager
    {
        public static int FindSmallestPowerOf2AsLargeAsParam(int param)
        {
            int counter = param;
            while (true)
            {
                if (isPowerOfTwo(counter))
                    return counter;

                counter++;
            }
        }

        public static bool isPowerOfTwo(int n)
        {
            return (int)(Math.Ceiling((Math.Log(n) / Math.Log(2))))
                  == (int)(Math.Floor(((Math.Log(n) / Math.Log(2)))));
        }
    }
}
