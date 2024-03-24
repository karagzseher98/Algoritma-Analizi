using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selection
{
    internal class Program
    {
        public static int[] selection(int[]a)
        {
            int temp;
            int min;
            for (int i = 0; i <= a.Length - 1; i++)
            {
                min = i;
                for (int j=0; j <= a.Length - 1; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                    temp = a[i];
                    a[i] = a[min];
                    a[min] = temp;
                }
                
            }
            return a;
        }
        static void Main(string[] args)
        {
                int[] dizi = { 5, 9, 7, 1, 25, 34,12};
                selection(dizi);
                int n=dizi.Length;
            for(int i = 0;i <= n; i++)
            {
                Console.WriteLine(dizi[i]);
            }
                
        }
    }
}
