namespace StackCalculator;

public interface ICalculator
{
    double? Evaluate(string expression, IStack stack);
}