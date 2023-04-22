using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExercise;

public class PrimeGenerator4
{
    private static bool[] crossedOut; // 將 isCrossed 再改名
    private static int[] result;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
        {
            return new int[0];
        }
        else
        {
            UncrossIntegersUpto(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();
            return result;
        }
    }

    /// <summary>
    /// 保留所有相關的整數，以便接下來能夠過濾掉他們的倍數
    /// (比原本名字更好，原本也不是真的初始化整數陣列，但改成初始化布林陣列也不會比較看得懂)
    /// </summary>
    /// <param name="maxValue"></param>
    private static void UncrossIntegersUpto(int maxValue)
    {
        // 宣告
        crossedOut = new bool[maxValue + 1];
        int i;

        // 不初始化陣列前兩個元素了，改從 index = 2 開始存取
        for (i = 2; i < crossedOut.Length; i++)
        {
            crossedOut[i] = false;
        }
    }

    /// <summary>
    /// cross out：劃掉，劃掉倍數
    /// </summary>
    private static void CrossOutMultiples()
    {
        int limit = DetermineIterationLimit();
        for (int i = 2; i < limit + 1; i++)
        {
            // 如果 i 未被劃掉，就劃掉其倍數
            if (NotCrossed(i))
            {
                CrossOutputMultiplesOf(i);
            }
        }
    }

    /// <summary>
    /// 陣列計算的上限
    /// (作者發現他搞錯了，這哪是在計算最大質因數，所以重新修改註解和命名。
    /// 陣列中的每個倍數都有一個小於或等於陣列大小平方根的質因數，
    /// 因此我們不用劃掉那些比這個平方根還大的數的倍數。)
    /// </summary>
    /// <returns></returns>
    private static int DetermineIterationLimit()
    {
        double iterationLimit = Math.Sqrt(crossedOut.Length);
        return (int)iterationLimit;
    }

    private static void CrossOutputMultiplesOf(int i)
    {
        // multiple：倍數
        for (int multiple = 2 * i;
                multiple < crossedOut.Length;
                multiple += i)
        {
            crossedOut[multiple] = true;
        }
    }

    /// <summary>
    /// 是否沒被劃掉
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private static bool NotCrossed(int i)
    {
        return crossedOut[i] == false;
    }

    /// <summary>
    /// 把沒被劃掉的數放進結果陣列中
    /// </summary>
    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int j = 0, i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
            {
                result[j++] = i;
            }
        }
    }

    /// <summary>
    /// 沒被劃掉的數有幾個
    /// </summary>
    /// <returns></returns>
    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
            {
                count++; // 累加 count
            }
        }
        return count;
    }
}
