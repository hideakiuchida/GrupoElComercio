using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    public class ChangeString
    {
        char[] abecedarioArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o',
                                    'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public string build(string cadena)
        {
            StringBuilder stringBuilder = new StringBuilder(cadena);

            for (int i = 0; i < stringBuilder.Length; i++)
            {
                for (int j = 0; j < abecedarioArray.Length; j++)
                {
                    int indice = (j == abecedarioArray.Length - 1) ? 0 : j + 1;
                    if (String.Compare(stringBuilder[i].ToString(), abecedarioArray[j].ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        stringBuilder[i] = stringBuilder[i].ToString().Any(char.IsUpper) ? Char.ToUpper(abecedarioArray[indice]) : abecedarioArray[indice];
                        break;
                    }
                }
            }
            return stringBuilder.ToString();

        }
    }
}
