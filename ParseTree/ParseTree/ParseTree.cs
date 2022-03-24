using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace ParseTree;

public class ParseTree : IParseTree
{
    public enum NodeType
    {
        Operator,
        Operand
    }

    private INode? root = null;
    private INode? currentNode = null;
    
    public void AddNode(int value, NodeType operandOrOperator)
    {
        if (operandOrOperator == NodeType.Operator)
        {
            switch ((char)value)
            {
                case ')':
                {
                    if (currentNode == null)
                    {
                        throw new Exception("Wrong input");
                    }
                    currentNode = ((Operator)currentNode).Parent ?? currentNode;
                    break;
                }
                case '*':
                {
                    if (currentNode == null)
                    {
                        root = new OperatorMultiply();
                        currentNode = root;
                    }
                    else if (((Operator)currentNode).LeftSon == null)
                    {
                        ((Operator)currentNode).LeftSon = new OperatorMultiply() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).LeftSon;
                    }
                    else if (((Operator)currentNode).RightSon == null)
                    {
                        ((Operator)currentNode).RightSon = new OperatorMultiply() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).RightSon;
                    }
                    break;
                }
                case '/':
                {
                    if (currentNode == null)
                    {
                        root = new OperatorDivide();
                        currentNode = root;
                    }
                    else if (((Operator)currentNode).LeftSon == null)
                    {
                        ((Operator)currentNode).LeftSon = new OperatorDivide() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).LeftSon;
                    }
                    else if (((Operator)currentNode).RightSon == null)
                    {
                        ((Operator)currentNode).RightSon = new OperatorDivide() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).RightSon;
                    }
                    break;
                }
                case '-':
                {
                    if (currentNode == null)
                    {
                        root = new OperatorSubstract();
                        currentNode = root;
                    }
                    else if (((Operator)currentNode).LeftSon == null)
                    {
                        ((Operator)currentNode).LeftSon = new OperatorSubstract() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).LeftSon;
                    }
                    else if (((Operator)currentNode).RightSon == null)
                    {
                        ((Operator)currentNode).RightSon = new OperatorSubstract() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).RightSon;
                    }
                    break;
                }
                case '+':
                {
                    if (currentNode == null)
                    {
                        root = new OperatorAdd();
                        currentNode = root;
                    }
                    else if (((Operator)currentNode).LeftSon == null)
                    {
                        ((Operator)currentNode).LeftSon = new OperatorAdd() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).LeftSon;
                    }
                    else if (((Operator)currentNode).RightSon == null)
                    {
                        ((Operator)currentNode).RightSon = new OperatorAdd() { Parent = currentNode };
                        currentNode = ((Operator)currentNode).RightSon;
                    }
                    break;
                }
            }
        }
        else
        {
            if (currentNode == null)
            {
                throw new Exception("Wrong input");
            }
            Operand newNode = new Operand(value) { Parent = currentNode };
            if (((Operator)currentNode).LeftSon == null)
            {
                ((Operator)currentNode).LeftSon = newNode;
            }
            else if (((Operator)currentNode).RightSon == null)
            {
                ((Operator)currentNode).RightSon = newNode;
            }
            else
            {
                throw new Exception("Wrong input"); // уточнить
            }
        }
    }

    public void Parse(string path)
    {
        // Вместо того, чтобы считывать посимвольно из файла, можно считать сразу весь файл и при помощи итератора пробегать по строке
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
                        AddNode(expression[iter], NodeType.Operator);
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
                    AddNode(int.Parse(number), NodeType.Operand);
                    break;
                }
            }
        }
    }

    public int Eval()
    {
        return root.Eval();
    }

    public void Print()
    {
        root.Print();
    }
}