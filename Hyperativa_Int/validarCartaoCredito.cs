using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hyperativa_Interface
{
    public static class validarCartaoCredito
    {
        private static bool modulo10(string val)
        {

            int currentDigit;
            int valSum = 0;
            int currentProcNum = 0;

            for (int i = val.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(val.Substring(i, 1), out currentDigit))
                    return false;

                currentProcNum = currentDigit << (1 + i & 1);
                valSum += (currentProcNum > 9 ? currentProcNum - 9 : currentProcNum);
            }
            return (valSum > 0 && valSum % 10 == 0);
        }

        public static bool validarCC(string sCC)
        {
            if (sCC.All(Char.IsDigit) == false)
            {
                return false;
            }
            
            if (12 > sCC.Length || sCC.Length > 19)
            {
                return false;
            }
            
            return modulo10(sCC);
        }
    }
}
