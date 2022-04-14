using Exceptions;
using System.Collections.Generic;
using NUnit.Framework;

namespace SparseVectorTests;

public class Tests
{
    [Test]
    public void AddMethodShouldSuccessfullyAddTwoVectors()
    {
        var dictionary1 = new Dictionary<int, int>
        {
            {1, 2},
            {5, 8},
            {1000000000, 9},
            {9, 4}
        };
        var vector1 = new SparseVector.SparseVector(dictionary1, 2000000000);
        var dictionary2 = new Dictionary<int, int>()
        {
            {3, 2},
            {9, 5},
            {5, 10},
            {1500000000, 9},
        };
        var vector2 = new SparseVector.SparseVector(dictionary2, 2000000000);
        var result = vector1.Add(vector2);

        var dictionary3 = new Dictionary<int, int>()
        {
            {1, 2},
            {5, 18},
            {1000000000, 9},
            {9, 9},
            {3, 2},
            {1500000000, 9},
        };
        var correctResult = new SparseVector.SparseVector(dictionary3, 2000000000);
        Assert.IsTrue(result.Equals(correctResult));
    }

    [Test]
    public void SubstactMethodShouldSuccessfullySubstractTheFirstVectorFromTheSecond()
    {
        var dictionary1 = new Dictionary<int, int>
        {
            {1, 2},
            {5, 8},
            {1000000000, 9},
            {9, 4}
        };
        var vector1 = new SparseVector.SparseVector(dictionary1, 2000000000);
        var dictionary2 = new Dictionary<int, int>()
        {
            {3, 2},
            {9, 5},
            {5, 10},
            {1500000000, 9},
        };
        var vector2 = new SparseVector.SparseVector(dictionary2, 2000000000);
        var result = vector1.Substract(vector2);

        var dictionary3 = new Dictionary<int, int>()
        {
            {1, 2},
            {5, -2},
            {1000000000, 9},
            {9, -1},
            {3, -2},
            {1500000000, -9},
        };
        var correctResult = new SparseVector.SparseVector(dictionary3, 2000000000);
        Assert.IsTrue(result.Equals(correctResult));
    }

    [Test]
    public void ScalarMultiplyShouldSuccessfullyMultiplyTwoVectors()
    {
        var dictionary1 = new Dictionary<int, int>
        {
            {1, 2},
            {5, 8},
            {1000000000, 9},
            {9, 4}
        };
        var vector1 = new SparseVector.SparseVector(dictionary1, 2000000000);
        var dictionary2 = new Dictionary<int, int>()
        {
            {3, 2},
            {9, 5},
            {5, 10},
            {1500000000, 9},
        };
        var vector2 = new SparseVector.SparseVector(dictionary2, 2000000000);
        var result = vector1.ScalarMultiply(vector2);
        Assert.AreEqual(100, result);
    }

    [Test]
    public void IsNullMethodShouldSuccessfullyDetermineWhetherTheVectorIsNullOrNot()
    {
        var vector = new SparseVector.SparseVector(new Dictionary<int, int>(), 100000000);
        Assert.IsTrue(vector.IsNull());

        vector = new SparseVector.SparseVector(new Dictionary<int, int>() {{4, 0}, {1000, 0}}, 100000000);
        Assert.IsTrue(vector.IsNull());

        vector = new SparseVector.SparseVector(new Dictionary<int, int>() {{4, 1}, {1000, 0}}, 100000000);
        Assert.IsFalse(vector.IsNull());
    }

    [Test]
    public void MethodsThrowExceptionsIfVectorsHaveDifferentLengths()
    {
        var dictionary1 = new Dictionary<int, int>
        {
            {1, 2},
            {5, 8},
            {1000000000, 9},
            {9, 4}
        };
        var vector1 = new SparseVector.SparseVector(dictionary1, 1999999999);
        var dictionary2 = new Dictionary<int, int>()
        {
            {3, 2},
            {9, 5},
            {5, 10},
            {1500000000, 9},
        };
        var vector2 = new SparseVector.SparseVector(dictionary2, 2000000000);
        Assert.Throws<DifferentLengthsException>(() => vector1.Add(vector2));
        Assert.Throws<DifferentLengthsException>(() => vector1.Substract(vector2));
        Assert.Throws<DifferentLengthsException>(() => vector1.ScalarMultiply(vector2));

    }
}