using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRange
{
    public class CompleteRange
    {
        public int[] build(int[] numbers)
        {
            numbers = numbers.OrderBy(i => i).ToArray();
            List<int> newNumbers = new List<int>();
            for (int i = 1; i <= numbers[numbers.Length - 1]; i++)
            {
                newNumbers.Add(i);
            }
            return newNumbers.ToArray();
        }
    }
}
