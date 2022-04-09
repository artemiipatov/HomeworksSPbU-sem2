namespace ParseTree;

public interface IParseTree
{
    enum NodeType
    {
        Operator,
        Operand
    }

    /// <summary>
    /// Creates node with given value.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="operandOrOperator"></param>
    void AddNode(int value, NodeType operandOrOperator);

    /// <summary>
    /// Creates parse tree using input from the file with given path.
    /// </summary>
    /// <param name="path"></param>
    void Parse(string path);

    /// <summary>
    /// Evaluates given parsed expression.
    /// </summary>
    /// <returns></returns>
    int Eval();

    /// <summary>
    /// Prints tree using preorder traversal algorithm.
    /// </summary>
    void Print();
}