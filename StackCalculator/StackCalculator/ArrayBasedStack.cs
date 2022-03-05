namespace StackCalculator;

/// <summary>
/// Stack implementation using array.
/// </summary>
public class ArrayBasedStack : IStack
{
    private double[] mainArray = new double[100];
    private int _headPosition = 0;

    /// <summary>
    /// Pushes value to stack.
    /// </summary>
    /// <param name="value"></param>
    public void Push(double value)
    {
        mainArray[_headPosition] = value;
        ++_headPosition;
    }

    /// <summary>
    /// Returns value of the stack head and removes it.
    /// </summary>
    /// <returns></returns>
    public double? Pop()
    {
        if (_headPosition == 0)
        {
            return null;
        }
        --_headPosition;
        var value = mainArray[_headPosition];
        mainArray[_headPosition] = 0;
        return value;
    }

    /// <summary>
    /// Returns true if stack is empty, returns false if stack is not empty.
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => _headPosition == 0;
}