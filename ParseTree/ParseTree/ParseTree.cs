namespace ParseTree;

public class ParseTree : IParseTree
{
    private INode? _root;
    private INode? _currentNode;
    
    public void AddNode(int value, IParseTree.NodeType operandOrOperator)
    {
        if (operandOrOperator == IParseTree.NodeType.Operator)
        {
            switch ((char)value)
            {
                case ')':
                {
                    if (_currentNode == null)
                    {
                        throw new Exception("Wrong input");
                    }
                    _currentNode = ((Operator)_currentNode).Parent ?? _currentNode;
                    break;
                }
                case '*':
                {
                    if (_currentNode == null)
                    {
                        _root = new OperatorMultiply();
                        _currentNode = _root;
                    }
                    else if (((Operator)_currentNode).LeftSon == null)
                    {
                        (((Operator)_currentNode!)).LeftSon = new OperatorMultiply() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).LeftSon;
                    }
                    else if (((Operator)_currentNode).RightSon == null)
                    {
                        (((Operator)_currentNode!)).RightSon = new OperatorMultiply() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).RightSon;
                    }
                    break;
                }
                case '/':
                {
                    if (_currentNode == null)
                    {
                        _root = new OperatorDivide();
                        _currentNode = _root;
                    }
                    else if (((Operator)_currentNode).LeftSon == null)
                    {
                        (((Operator)_currentNode!)).LeftSon = new OperatorDivide() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).LeftSon;
                    }
                    else if (((Operator)_currentNode).RightSon == null)
                    {
                        (((Operator)_currentNode!)).RightSon = new OperatorDivide() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).RightSon;
                    }
                    break;
                }
                case '-':
                {
                    if (_currentNode == null)
                    {
                        _root = new OperatorSubstract();
                        _currentNode = _root;
                    }
                    else if (((Operator)_currentNode).LeftSon == null)
                    {
                        (((Operator)_currentNode!)).LeftSon = new OperatorSubstract() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).LeftSon;
                    }
                    else if (((Operator)_currentNode).RightSon == null)
                    {
                        (((Operator)_currentNode!)).RightSon = new OperatorSubstract() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).RightSon;
                    }
                    break;
                }
                case '+':
                {
                    if (_currentNode == null)
                    {
                        _root = new OperatorAdd();
                        _currentNode = _root;
                    }
                    else if (((Operator)_currentNode).LeftSon == null)
                    {
                        (((Operator)_currentNode!)).LeftSon = new OperatorAdd() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).LeftSon;
                    }
                    else if (((Operator)_currentNode).RightSon == null)
                    {
                        (((Operator)_currentNode!)).RightSon = new OperatorAdd() { Parent = _currentNode };
                        _currentNode = ((Operator)_currentNode).RightSon;
                    }
                    break;
                }
            }
        }
        else
        {
            if (_currentNode == null)
            {
                throw new Exception("Wrong input");
            }
            Operand newNode = new Operand(value) { Parent = _currentNode };
            if (((Operator)_currentNode).LeftSon == null)
            {
                (((Operator)_currentNode!)).LeftSon = newNode;
            }
            else if (((Operator)_currentNode).RightSon == null)
            {
                (((Operator)_currentNode!)).RightSon = newNode;
            }
            else
            {
                throw new Exception("Wrong input");
            }
        }
    }

    public void Parse(string path)
    {
        string expression = File.ReadAllText(path);
        int iter = 0;
        while (iter < expression.Length)
        {
            switch (expression[iter])
            {
                case '(':
                case ' ':
                {
                    ++iter;
                    continue;
                }
                case ')':
                case '*':
                case '/':
                case '+':
                case '-':
                {
                    if (iter + 1 == expression.Length || expression[iter + 1] == ' ' || expression[iter + 1] == ')')
                    {
                        AddNode(expression[iter], IParseTree.NodeType.Operator);
                        ++iter;
                        continue;
                    }
                    goto default;
                }
                default:
                {
                    string number = "";
                    while ('0' <= expression[iter] && expression[iter] <= '9' || expression[iter] == '-')
                    {
                        number += expression[iter];
                        ++iter;
                    }
                    AddNode(int.Parse(number), IParseTree.NodeType.Operand);
                    break;
                }
            }
        }
    }

    public int Eval()
    {
        if (_root != null) return _root.Eval();
        throw new NullReferenceException("Evaluation of empty expression");
    }

    public void Print() => _root?.Print();
}