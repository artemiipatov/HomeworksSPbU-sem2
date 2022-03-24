namespace ParseTree;

public interface IParseTree
{
    enum NodeType
    {
        Operator,
        Operand
    }

    void AddNode(int value, NodeType operandOrOperator);

    void Parse(string path);

    int Eval();

    void Print();
}