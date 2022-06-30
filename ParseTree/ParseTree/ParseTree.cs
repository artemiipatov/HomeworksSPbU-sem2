namespace ParseTree;

public class ParseTree
{
    private INode? _root;
    private INode? _currentNode;

    private void AddOperand(int value)
    {
        if (_currentNode == null)
        {
            throw new Exception("Wrong input");
        }
        
        Operand newNode = new Operand(value) { Parent = _currentNode };
        
        if (((Operator)_currentNode).LeftSon == null)
        {
            ((Operator)_currentNode!).LeftSon = newNode;
        }
        else if (((Operator)_currentNode).RightSon == null)
        {
            ((Operator)_currentNode!).RightSon = newNode;
        }
        else
        {
            throw new InvalidOperationException("Wrong input");
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
                        INode? newNode = null;
                        switch (expression[iter])
                        {
                            case ')':
                            {
                                if (_currentNode == null)
                                {
                                    throw new InvalidOperationException("Wrong input");
                                }
                                _currentNode = ((Operator)_currentNode).Parent ?? _currentNode;
                                break;
                            }
                            case '*':
                            {
                                newNode = new OperatorMultiply() {Parent = _currentNode};
                                break;
                            }
                            case '/':
                            {
                                newNode = new OperatorDivide() {Parent = _currentNode};
                                break;
                            }
                            case '+':
                            {
                                newNode = new OperatorAdd() {Parent = _currentNode};
                                break;
                            }
                            case '-':
                            {
                                newNode = new OperatorSubstract() {Parent = _currentNode};
                                break;
                            }
                        }
                        
                        ++iter;

                        if (newNode == null)
                        {
                            continue;
                        }
                        
                        if (_currentNode == null)
                        {
                            _root = newNode;
                            _currentNode = _root;
                        }
                        else if (((Operator)_currentNode).LeftSon == null)
                        {
                            ((Operator)_currentNode!).LeftSon = newNode;
                            _currentNode = ((Operator)_currentNode).LeftSon;
                        }
                        else if (((Operator)_currentNode).RightSon == null)
                        {
                            ((Operator)_currentNode!).RightSon = newNode;
                            _currentNode = ((Operator)_currentNode).RightSon;
                        }

                        continue;
                    }
                    
                    string number = "";
                    while ('0' <= expression[iter] && expression[iter] <= '9' || expression[iter] == '-')
                    {
                        number += expression[iter];
                        ++iter;
                    }
                    AddOperand(int.Parse(number));
                    break;
                }
                default:
                {
                    string number = "";
                    while ('0' <= expression[iter] && expression[iter] <= '9')
                    {
                        number += expression[iter];
                        ++iter;
                    }
                    AddOperand(int.Parse(number));
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