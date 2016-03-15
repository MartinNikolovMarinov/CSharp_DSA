using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public static class SumAndAverage
    {
        public static double Sum(List<double> list)
        {
            double sum = 0;
            
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i]; 
            }

            return sum;
        }

        public static double Average(List<double> list)
        {
            double sum = Sum(list);

            if (sum == 0)
            {
                return sum;
            }

            return sum / list.Count;
        }
    }
}
