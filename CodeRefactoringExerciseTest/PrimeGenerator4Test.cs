using CodeRefactoringExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExerciseTest;

[TestFixture]
public class PrimeGenerator4Test
{
    [Test]
    public void GeneratePrimeNumbers_傳入0()
    {
        int[] nullArray = PrimeGenerator4.GeneratePrimeNumbers(0);
        Assert.That(nullArray, Is.Empty);
    }

    [Test]
    public void GeneratePrimeNumbers_傳入2()
    {
        int[] minArray = PrimeGenerator4.GeneratePrimeNumbers(2);
        Assert.That(minArray, Has.Length.EqualTo(1));
        Assert.That(minArray[0], Is.EqualTo(2));
    }

    [Test]
    public void GeneratePrimeNumbers_傳入3()
    {
        int[] threeArray = PrimeGenerator4.GeneratePrimeNumbers(3);
        Assert.That(threeArray, Has.Length.EqualTo(2));
        Assert.That(threeArray[0], Is.EqualTo(2));
        Assert.That(threeArray[1], Is.EqualTo(3));
    }

    [Test]
    public void GeneratePrimeNumbers_傳入100()
    {
        int[] centArray = PrimeGenerator4.GeneratePrimeNumbers(100);
        Assert.That(centArray, Has.Length.EqualTo(25));
        Assert.That(centArray[24], Is.EqualTo(97));
    }

    /// <summary>
    /// Exhaustive：徹底的、詳盡的
    /// (這個測試要跑 10 幾秒)
    /// </summary>
    [Test]
    public void TestExhaustive()
    {
        // 2~500 每個都傳入方法測一遍
        for (int i = 2; i < 500; i++)
        {
            VerifyPrimeList(PrimeGenerator4.GeneratePrimeNumbers(i));
        }
    }

    /// <summary>
    /// 檢查陣列裡的每個數字是不是都是質數
    /// </summary>
    /// <param name="list"></param>
    private void VerifyPrimeList(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            VerifyPrime(list[i]);
        }
    }

    /// <summary>
    /// 檢查數字是否為質數
    /// </summary>
    /// <param name="n"></param>
    private void VerifyPrime(int n)
    {
        // 小於自己的數，每個都除一遍看餘數有沒有不等於 0
        for (int factor = 2; factor < n; factor++)
        {
            Assert.That(n % factor, Is.Not.Zero);
        }
    }
}
