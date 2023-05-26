namespace SparseVector;

/// <summary>
/// Class that realize operations on sparse vectors.
/// </summary>
public static class SparseVector
{
    /// <summary>
    /// Method that adds two sparse vectors.
    /// </summary>
    /// <param name="firstVector">First sparse vector.</param>
    /// <param name="secondVector">Second sparse vector.</param>
    /// <returns>Result of addition of two sparse vectors.</returns>
    public static List<(int, int)> Add(List<(int, int)> firstVector, List<(int, int)> secondVector)
    {
        List<(int, int)> result = new();

        var lastPosOfFirstVector = firstVector.Last().Item1;
        var lastPosOfSecondVector = secondVector.Last().Item1;

        if (lastPosOfFirstVector != lastPosOfSecondVector)
        {
            throw new ArgumentException("Different dimensions!");
        }

        var currentFirstPos = firstVector[0].Item1;
        var currentSecondPos = secondVector[0].Item1;
        var firstPointer = 0;
        var secondPointer = 0;

        for (int i = 0; i < lastPosOfFirstVector; ++i)
        {
            if (currentFirstPos > i && currentSecondPos > i)
            {
            }
            else if (currentFirstPos == i && currentSecondPos > i)
            {
                result.Add((i, firstVector[firstPointer].Item2));
                currentFirstPos = firstVector[++firstPointer].Item1;
            }
            else if (currentFirstPos > i && currentSecondPos == i)
            {
                result.Add((i, secondVector[secondPointer].Item2));
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
            else
            {
                result.Add((i, firstVector[firstPointer].Item2 + secondVector[secondPointer].Item2));
                currentFirstPos = firstVector[++firstPointer].Item1;
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
        }

        result.Add((lastPosOfFirstVector, firstVector.Last().Item2 + secondVector.Last().Item2));

        return result;
    }

    /// <summary>
    /// Method that subtract two sparse vectors.
    /// </summary>
    /// <param name="firstVector">First sparse vector.</param>
    /// <param name="secondVector">Second sparse vector.</param>
    /// <returns>Result of subtraction of two sparse vectors.</returns>
    public static List<(int, int)> Subtract(List<(int, int)> firstVector, List<(int, int)> secondVector)
    {
        List<(int, int)> result = new();

        var lastPosOfFirstVector = firstVector.Last().Item1;
        var lastPosOfSecondVector = secondVector.Last().Item1;

        if (lastPosOfFirstVector != lastPosOfSecondVector)
        {
            throw new ArgumentException("Different dimensions!");
        }

        var currentFirstPos = firstVector[0].Item1;
        var currentSecondPos = secondVector[0].Item1;
        var firstPointer = 0;
        var secondPointer = 0;

        for (int i = 0; i < lastPosOfFirstVector; ++i)
        {
            if (currentFirstPos > i && currentSecondPos > i)
            {
            }
            else if (currentFirstPos == i && currentSecondPos > i)
            {
                result.Add((i, firstVector[firstPointer].Item2));
                currentFirstPos = firstVector[++firstPointer].Item1;
            }
            else if (currentFirstPos > i && currentSecondPos == i)
            {
                result.Add((i, -secondVector[secondPointer].Item2));
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
            else
            {
                result.Add((i, firstVector[firstPointer].Item2 - secondVector[secondPointer].Item2));
                currentFirstPos = firstVector[++firstPointer].Item1;
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
        }

        result.Add((lastPosOfFirstVector, firstVector.Last().Item2 - secondVector.Last().Item2));

        return result;
    }

    /// <summary>
    /// Method that scalar multiply two sparse vectors.
    /// </summary>
    /// <param name="firstVector">First sparse vector.</param>
    /// <param name="secondVector">Second sparse vector.</param>
    /// <returns>Result of scalar multiplication of two sparse vectors.</returns>
    public static int ScalarMultiplicate(List<(int, int)> firstVector, List<(int, int)> secondVector)
    {
        var result = 0;

        var lastPosOfFirstVector = firstVector.Last().Item1;
        var lastPosOfSecondVector = secondVector.Last().Item1;

        if (lastPosOfFirstVector != lastPosOfSecondVector)
        {
            throw new ArgumentException("Different dimensions!");
        }

        var currentFirstPos = firstVector[0].Item1;
        var currentSecondPos = secondVector[0].Item1;
        var firstPointer = 0;
        var secondPointer = 0;

        for (int i = 0; i < lastPosOfFirstVector; ++i)
        {
            if (currentFirstPos > i && currentSecondPos > i)
            {
            }
            else if (currentFirstPos == i && currentSecondPos > i)
            {
                currentFirstPos = firstVector[++firstPointer].Item1;
            }
            else if (currentFirstPos > i && currentSecondPos == i)
            {
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
            else
            {
                result += firstVector[firstPointer].Item2 * secondVector[secondPointer].Item2;
                currentFirstPos = firstVector[++firstPointer].Item1;
                currentSecondPos = secondVector[++secondPointer].Item1;
            }
        }

        result += firstVector.Last().Item2 * secondVector.Last().Item2;

        return result;
    }

    /// <summary>
    /// Method for checking if vector is zero.
    /// </summary>
    /// <param name="vector">Sparse vector to check on being zero.</param>
    /// <returns>True - if vector is zero, false - if vector isn't zero.</returns>
    public static bool IsZero(List<(int, int)> vector)
        => vector.Last().Item1 == 0 && vector.Last().Item2 == 0;
}