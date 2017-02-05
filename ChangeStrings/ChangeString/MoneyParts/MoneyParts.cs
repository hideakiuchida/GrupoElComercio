using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyParts
{
    public class MoneyParts
    {
        decimal[] amounts = { 0.05m, 0.1m, 0.2m, 0.5m, 1.0m, 2.0m, 5.0m, 10.0m, 20.0m, 50.0m, 100.0m, 200.0m };
        public List<decimal[]> Build(decimal amount)
        {
            List<decimal[]> combinationsAlpha = new List<decimal[]>();
            List<decimal[]> combinationsBeta = new List<decimal[]>();
            foreach (decimal item in amounts)
            {
               decimal times = amount / item;
               if (times < 1)
                    break;
               int count = Convert.ToInt16(times);

               decimal[] values = GetValues(item, count);
               decimal y = amount - (item * count);
                if (y > 0)
                {
                    combinationsBeta = Build(y);
                    foreach (decimal[] valueArray in combinationsBeta)
                    {
                        decimal[] valuesX = values.Concat(valueArray).ToArray();
                        combinationsAlpha.Add(valuesX);
                    }
                }
                else
                    combinationsAlpha.Add(values);

            }
            return combinationsAlpha;
        }

        decimal[] GetValues(decimal value, int count)
        {
            decimal[] values = new decimal[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = value;
            }
            return values;
        }
    }
}
