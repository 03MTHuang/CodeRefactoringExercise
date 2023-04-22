using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExercise;

public class GeneratePrimes
{
    /// <summary>
    /// 產生一個包含質數的陣列
    /// </summary>
    /// <param name="maxValue">產生的最大值</param>
    /// <returns></returns>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue >= 2)
        {
            // 宣告
            int s = maxValue + 1; // 陣列大小
            bool[] f = new bool[s];
            int i;

            // 將陣列元素初始為 true
            for (i = 0; i < s; i++)
            {
                f[i] = true;
            }

            // 去掉已知的非質數
            f[0] = f[1] = false;

            // 篩選過濾
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                // 如果 i 未被劃掉，就劃掉其倍數
                if (f[i])
                {
                    for (j = 2 * i; j < s; j += i)
                    {
                        f[j] = false; // 倍數不是質數
                    }
                }
            }

            // 有多少個質數?
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i])
                {
                    count++; // 累加 count
                }
            }

            int[] primes = new int[count];

            // 把質數轉移到結果陣列中
            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i]) // 若為質數
                {
                    primes[j++] = i;
                }
            }

            return primes; // 回傳 primes 結果陣列
        }
        else // maxValue < 2
        {
            return new int[0]; // 若輸入不合理的值，則回傳空陣列
        }
    }
}
