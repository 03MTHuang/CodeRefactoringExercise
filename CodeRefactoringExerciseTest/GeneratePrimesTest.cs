using CodeRefactoringExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRefactoringExerciseTest;

[TestFixture]
public class GeneratePrimesTest
{
    [Test]
    public void GeneratePrimeNumbers_傳入0()
    {
        int[] nullArray = GeneratePrimes.GeneratePrimeNumbers(0);
        Assert.That(nullArray, Is.Empty);
    }

    [Test]
    public void GeneratePrimeNumbers_傳入2()
    {
        int[] minArray = GeneratePrimes.GeneratePrimeNumbers(2);
        Assert.That(minArray, Has.Length.EqualTo(1));
        Assert.That(minArray[0], Is.EqualTo(2));
    }

    [Test]
    public void GeneratePrimeNumbers_傳入3()
    {
        int[] threeArray = GeneratePrimes.GeneratePrimeNumbers(3);
        Assert.That(threeArray, Has.Length.EqualTo(2));
        Assert.That(threeArray[0], Is.EqualTo(2));
        Assert.That(threeArray[1], Is.EqualTo(3));
    }

    [Test]
    public void GeneratePrimeNumbers_傳入100()
    {
        int[] centArray = GeneratePrimes.GeneratePrimeNumbers(100);
        Assert.That(centArray, Has.Length.EqualTo(25));
        Assert.That(centArray[24], Is.EqualTo(97));
    }
}
