using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] case1 = { 2, 1, 4, 5 };
            int[] case2 = { 4, 2, 9 };
            int[] case3 = { 58, 60, 55 };
            CompleteRange completeRange = new CompleteRange();
            Console.WriteLine(string.Join(",",completeRange.build(case1)));
            Console.WriteLine(string.Join(",", completeRange.build(case2)));
            Console.WriteLine(string.Join(",", completeRange.build(case3)));
            Console.ReadLine();
        }
    }
}
