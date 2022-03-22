namespace ParseTree;

public class ParseTree : IParseTree
{
    public enum ValueType
    {
        Operator,
        Operand
    }
    private class Node
    {
        public Node? Parent { get; set; } = null;
        public Node? RightSon { get; set; } = null;
        public Node? LeftSon { get; set; } = null;
        public int Value { get; set; }
        public ValueType OperandOrOperator { get; set; }
        
        public Node(int value, ValueType operandOrOperator)
        {
            this.Value = value;
            this.OperandOrOperator = operandOrOperator;
        }
    }

    private Node? currentNode = null;
    
    public void AddNode(int value, ValueType operandOrOperator)
    {
        if (operandOrOperator == ValueType.Operator)
        {
            switch (value)
            {
                case ')':
                {
                    if (currentNode == null)
                    {
                        throw new Exception(); // уточнить
                    }
                    currentNode = currentNode.Parent ?? currentNode;
                    break;
                }
                case '*':
                case '/':
                case '-':
                case '+':
                {
                    if (currentNode == null)
                    {
                        currentNode = new Node(value, ValueType.Operator);
                    }
                    else if (currentNode.LeftSon == null)
                    {
                        Node newNode = new Node(value, ValueType.Operator);
                        currentNode.LeftSon = newNode;
                        currentNode = newNode;
                    }
                    else if (currentNode.RightSon == null)
                    {
                        Node newNode = new Node(value, ValueType.Operator);
                        currentNode.RightSon = newNode;
                        currentNode = newNode;
                    }

                    break;
                }
                
            }
        }
        else
        {
            if (currentNode == null)
            {
                throw new Exception(); // уточнить
            }
            Node newNode = new Node(value, ValueType.Operand);
            newNode.Parent = currentNode;
            if (currentNode.LeftSon == null)
            {
                currentNode.LeftSon = newNode;
            }
            else if (currentNode.RightSon == null)
            {
                currentNode.RightSon = newNode;
            }
            else
            {
                throw new Exception(); // уточнить
            }
        }
    }

    public int Eval()
    {
        return 0;
    }

    public void Parse(string path)
    {
        
    }
    
    public void PrintPreorder()
    {
        
    }
}