using Exceptions;

namespace SparseVector;

/// <summary>
/// Sparse vector implementation
/// </summary>
public class SparseVector
{
    /// <summary>
    /// Keys are indexes of elements given by user, values are elements themselves
    /// </summary>
    public Dictionary<int, int> Vector { get; }

    /// <summary>
    /// Length of vector
    /// </summary>
    public int Length { get; }

    public SparseVector(Dictionary<int, int> vector, int length)
    {
        Vector = vector;
        Length = length;
    }

    /// <summary>
    /// Adds first vector to the second
    /// </summary>
    /// <param name="vector2"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public SparseVector Add(SparseVector vector2)
    {
        if (Length != vector2.Length)
        {
            throw new DifferentLengthsException("vectors have different lengths");
        }
        var result = new Dictionary<int, int>();
        foreach (var key in Vector.Keys)
        {
            result.Add(key, Vector[key] + (vector2.Vector.ContainsKey(key) ? vector2.Vector[key] : 0));
        }

        foreach (var key in vector2.Vector.Keys)
        {
            if (!result.ContainsKey(key))
            {
                result.Add(key, vector2.Vector[key]);
            }
        }

        return new SparseVector(result, Length);
    }

    /// <summary>
    /// Susbtracts first vector from the second
    /// </summary>
    /// <param name="vector2"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Throws if vectors have different lengths</exception>
    public SparseVector Substract(SparseVector vector2)
    {
        if (Length != vector2.Length)
        {
            throw new DifferentLengthsException("vectors have different lengths");
        }

        var negativeVector = new Dictionary<int, int>();
        foreach (var key in vector2.Vector.Keys)
        {
            negativeVector.Add(key, -vector2.Vector[key]);
        }

        return Add(new SparseVector(negativeVector, vector2.Length));
    }

    /// <summary>
    /// Scalar multiply two vectors
    /// </summary>
    /// <param name="vector2"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Throws if vectors have different lengths</exception>
    public int ScalarMultiply(SparseVector vector2)
    {
        if (Length != vector2.Length)
        {
            throw new DifferentLengthsException("vectors have different lengths");
        }

        int scalarProduct = 0;
        List<int> indexes = new List<int> {};
        foreach (var key in Vector.Keys)
        {
            if (vector2.Vector.ContainsKey(key))
            {
                scalarProduct += vector2.Vector[key] * Vector[key];
            }
        }

        return scalarProduct;
    }

    /// <summary>
    /// Returns true if all elements of the vector are null, false if any elements are not null
    /// </summary>
    public bool IsNull() => Vector.Keys.All(key => Vector[key] == 0);

    /// <summary>
    /// Returns true if the first vector equals to the second one, false, if some elements of the first vector differs from elements of the second
    /// </summary>
    /// <param name="vector2"></param>
    public bool Equals(SparseVector vector2)
    {
        if (Length != vector2.Length)
        {
            return false;
        }
        foreach (var key in Vector.Keys)
        {
            if (!(vector2.Vector.ContainsKey(key) && vector2.Vector[key] == Vector[key]))
            {
                return false;
            }
        }

        return true;
    }
}