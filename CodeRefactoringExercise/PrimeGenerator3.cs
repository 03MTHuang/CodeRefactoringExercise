using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExercise;

public class PrimeGenerator3
{
    private static bool[] isCrossed; // 將 f 重新改名，而且是改成正面意思，然後也更改了布林值的意義(原本的 true 代表是質數，現在的 true 代表被劃掉的數)
    private static int[] result;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
        {
            return new int[0];
        }
        else
        {
            InitializeArrayOfIntegers(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();
            return result;
        }
    }

    /// <summary>
    /// 初始化陣列
    /// </summary>
    /// <param name="maxValue"></param>
    private static void InitializeArrayOfIntegers(int maxValue)
    {
        // 宣告
        isCrossed = new bool[maxValue + 1];
        int i;

        // 不初始化陣列前兩個元素了，改從 index = 2 開始存取
        for (i = 2; i < isCrossed.Length; i++)
        {
            isCrossed[i] = false;
        }
    }

    /// <summary>
    /// cross out：劃掉，劃掉倍數
    /// </summary>
    private static void CrossOutMultiples()
    {
        int maxPrimeFactor = CalcMaxPrimeFactor();
        for (int i = 2; i < maxPrimeFactor + 1; i++)
        {
            // 如果 i 未被劃掉，就劃掉其倍數
            if (NotCrossed(i))
            {
                CrossOutputMultiplesOf(i);
            }
        }
    }

    /// <summary>
    /// 計算最大質因數
    /// (我們劃掉質數p的所有倍數，那麼被劃掉的所有倍數都有p和q兩個因數。
    /// 如果p大於陣列大小的平方根，那麼q就不可能再大於1了。
    /// 因此p就是陣列中最大的質因數，也是所需反覆執行次數的上限
    /// </summary>
    /// <returns></returns>
    private static int CalcMaxPrimeFactor()
    {
        double maxPrimeFactor = Math.Sqrt(isCrossed.Length) + 1;
        return (int)maxPrimeFactor;
    }

    private static void CrossOutputMultiplesOf(int i)
    {
        // multiple：倍數
        for (int multiple = 2 * i;
                multiple < isCrossed.Length;
                multiple += i)
        {
            isCrossed[multiple] = true;
        }
    }

    /// <summary>
    /// 是否沒被劃掉
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private static bool NotCrossed(int i)
    {
        return isCrossed[i] == false;
    }

    /// <summary>
    /// 把沒被劃掉的數放進結果陣列中
    /// </summary>
    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int j = 0, i = 2; i < isCrossed.Length; i++)
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
        for (int i = 2; i < isCrossed.Length; i++)
        {
            if (NotCrossed(i))
            {
                count++; // 累加 count
            }
        }
        return count;
    }
}
