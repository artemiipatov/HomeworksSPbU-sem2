namespace StackCalculator;

public interface IStack
{
    void Push(double value);

    double? Pop();

    bool IsEmpty();
}