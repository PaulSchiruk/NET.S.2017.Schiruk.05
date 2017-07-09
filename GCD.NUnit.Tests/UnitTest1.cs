using System;
using System.Collections;
using NUnit.Framework;
using GCD;


namespace GCD.NUnit.Tests
{

    [TestFixture()]
    public class GCDTests
    {
        [TestCase(51, 17, ExpectedResult = 17)]
        [TestCase(56, 88, 14, ExpectedResult = 2)]
        [TestCase(256, 1024, 2048, 512, ExpectedResult = 256)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(-56, 88, -14, ExpectedResult = 2)]
        public  int Insertion_PositiveTests(params int[] check)
        {
            (string s, int res) = Algorithm.EuclideanAlgorithm(check);
            return res;
        }

        [TestCase()]
        [TestCase(1)]
        public void InsertNumber_ThrowsArgumentException(params int[] check)
        {
            Assert.Throws<ArgumentException>(
                () => Algorithm.EuclideanAlgorithm(check));
        }
    }

    [TestFixture()]
    public class GCDBinTests
    {
        [TestCase(51, 17, ExpectedResult = 17)]
        [TestCase(56, 88, 14, ExpectedResult = 2)]
        [TestCase(256, 1024, 2048, 512, ExpectedResult = 256)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(-56, 88, -14, ExpectedResult = 2)]
        public int Insertion_PositiveTests(params int[] check)
        {
            (string s, int res) = Algorithm.BinaryAlgorithm(check);
            return res;
        }

        [TestCase()]
        [TestCase(1)]
        public void InsertNumber_ThrowsArgumentException(params int[] check)
        {
            Assert.Throws<ArgumentException>(
                () => Algorithm.BinaryAlgorithm(check));
        }
    }




    [TestFixture()]
    public class BinDoubleTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]

        public static string DoubleConvert_PositiveTests(double check)
        {
            return BinDouble.DoubleToIEEE754(check);
        }

    }



    [TestFixture()]
    public class PolynomTests
    {
        [TestCase(ExpectedResult = true)]
        public static bool OperarorPlus_PositiveTests()
        {
            Polynom first = new Polynom(25, 89, -54, 0, 3, 17);
            Polynom second = new Polynom(42, 17, 22);
            Polynom plusRes = new Polynom(67, 106, -32, 0, 3, 17);
            int[] check = new int[plusRes.Length()];
            for (int i = 0; i < plusRes.Length(); i++)
            {
                check[i] = plusRes.Coefficents[i];
            }
            Polynom third = first + second;
            int[] check2 = new int[third.Length()];
            for (int i = 0; i < third.Length(); i++)
            {
                check2[i] = third.Coefficents[i];
            }
            IStructuralEquatable a = check;
            return a.Equals(check2, StructuralComparisons.StructuralEqualityComparer);
        }


        [TestCase(ExpectedResult = true)]
        public static bool OperarorMultiply_PositiveTests()
        {
            Polynom first = new Polynom(25, 89, -54, 0, 3, 17);
            Polynom second = new Polynom(42, 17, 22);
            Polynom multiplyRes = new Polynom(1050, 4163, -205, 1040, -1062, 765, 355, 374);
            int[] check = new int[multiplyRes.Length()];
            for (int i = 0; i < multiplyRes.Length(); i++)
            {
                check[i] = multiplyRes.Coefficents[i];
            }
            Polynom third = first * second;
            int[] check2 = new int[third.Length()];
            for (int i = 0; i < third.Length(); i++)
            {
                check2[i] = third.Coefficents[i];
            }
            IStructuralEquatable a = check;
            return a.Equals(check2,StructuralComparisons.StructuralEqualityComparer);
        }

        [TestCase(ExpectedResult = true)]
        public static bool OperarorMinus_PositiveTests()
        {
            Polynom first = new Polynom(25, 89, -54, 0, 3, 17);
            Polynom second = new Polynom(42, 17, 22);
            Polynom plusRes = new Polynom(-17, 72, -76, 0, 3, 17);
            int[] check = new int[plusRes.Length()];
            for (int i = 0; i < plusRes.Length(); i++)
            {
                check[i] = plusRes.Coefficents[i];
            }
            Polynom third = first - second;
            int[] check2 = new int[third.Length()];
            for (int i = 0; i < third.Length(); i++)
            {
                check2[i] = third.Coefficents[i];
            }
            IStructuralEquatable a = check;
            return a.Equals(check2, StructuralComparisons.StructuralEqualityComparer);
        }

    }
}