namespace StackCalculator;

/// <summary>
/// Stack implementation using array.
/// </summary>
public class ArrayBasedStack : IStack
{
    private int _size = 100;
    private double[] _mainArray = new double[100];
    private int _headPosition = 0;
    public bool IsEmpty => _headPosition == 0;

    public void Push(double value)
    {
        if (_headPosition >= _mainArray.Length)
        {
            Resize();
        }

        _mainArray[_headPosition] = value;
        ++_headPosition;
    }

    private void Resize()
    {
        var newArray = new double[_size * 2];
        for (int i = 0; i < _mainArray.Length; i++)
        {
            newArray[i] = _mainArray[i];
        }
        _mainArray = newArray;
    }

    public double? Pop()
    {
        if (_headPosition == 0)
        {
            return null;
        }

        --_headPosition;
        var value = _mainArray[_headPosition];
        return value;
    }
}