using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExercise;

public class PrimeGenerator2
{
    private static bool[] f;
    private static int[] primes;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
        {
            return new int[0];
        }
        else
        {
            InitializeArrayOfIntegers(maxValue);
            Sieve();
            LoadPrimes();
            return primes;
        }
    }

    /// <summary>
    /// 初始化陣列
    /// </summary>
    /// <param name="maxValue"></param>
    private static void InitializeArrayOfIntegers(int maxValue)
    {
        // 宣告
        f = new bool[maxValue + 1];
        int i;

        // 將陣列元素初始為 true
        for (i = 0; i < f.Length; i++)
        {
            f[i] = true;
        }

        // 去掉已知的非質數
        f[0] = f[1] = false;
    }

    private static void Sieve()
    {
        int i;
        int j;

        for (i = 2; i < Math.Sqrt(f.Length) + 1; i++)
        {
            // 如果 i 未被劃掉，就劃掉其倍數
            if (f[i])
            {
                for (j = 2 * i; j < f.Length; j += i)
                {
                    f[j] = false; // 倍數不是質數
                }
            }
        }
    }

    private static void LoadPrimes()
    {
        int i;
        int j;

        // 有多少個質數?
        int count = 0;
        for (i = 0; i < f.Length; i++)
        {
            if (f[i])
            {
                count++; // 累加 count
            }
        }

        primes = new int[count];

        // 把質數轉移到結果陣列中
        for (i = 0, j = 0; i < f.Length; i++)
        {
            if (f[i]) // 若為質數
            {
                primes[j++] = i;
            }
        }
    }
}
