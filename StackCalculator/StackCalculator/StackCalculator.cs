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
    /// <param name="stack"></param>
    /// <returns></returns>
    public static double? Evaluate(string expression, IStack stack)
    {
        var splitExpression = expression.Split(' ');
        foreach (var token in splitExpression)
        {
            switch (token)
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
                    switch (token)
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
                        // case "/" when (firstOperand - 0.0 < 0 ? 0.0 - firstOperand : firstOperand - 0.0) < 0.0000000000000000000001:
                        case "/" when Math.Abs(firstOperand.GetValueOrDefault() - 0.0) < 0.0000000000000000000001:
                            return null;
                        case "/":
                            stack.Push((double)secondOperand / (double)firstOperand);
                            break;
                    }
                    break;
                }
                default:
                {
                    if (!double.TryParse(token, out var number))
                    {
                        return null;
                    }
                    stack.Push(number);
                    break;
                }
            }
        }

        var result = stack.Pop();
        return !stack.IsEmpty ? null : result;
    }
}