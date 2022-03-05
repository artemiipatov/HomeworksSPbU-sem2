using System.Collections.Immutable;

namespace StackCalculator;

/// <summary>
///  Stack calculator implementation
/// </summary>
public static class StackCalculator
{
    /// <summary>
    /// Evaluates given expression. Input expression should be in reverse polish notation. Returns the result of calculations if input is correct. Returns null if input is incorrect.
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static double? Evaluate(string expression)
    {
        IStack stack = new ListBasedStack();
        var splitExp = expression.Split(' ');
        foreach (var t in splitExp)
        {
            if (!(t.Equals(" ")))
            {
                switch (t)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    {
                        var firstOperand = stack.Pop();
                        if (firstOperand == null)
                        {
                            return null;
                        }
                        var secondOperand = stack.Pop();
                        if (secondOperand == null)
                        {
                            return null;
                        }
                        switch (t)
                        {
                            case "+":
                                stack.Push((double) firstOperand + (double)secondOperand);
                                break;
                            case "-":
                                stack.Push((double)secondOperand - (double)firstOperand);
                                break;
                            case "*":
                                stack.Push((double)firstOperand * (double)secondOperand);
                                break;
                            case "/" when firstOperand.Equals((double)0):
                                return null;
                            case "/":
                                stack.Push((double)secondOperand / (double)firstOperand);
                                break;
                        }
                        break;
                    }
                    default:
                    {
                        if (!double.TryParse(t, out var number))
                        {
                            return null;
                        }
                        stack.Push(number);
                        break;
                    }
                }
            }
        }

        var result = stack.Pop();
        return (!stack.IsEmpty()) ? null : result;
    }
}