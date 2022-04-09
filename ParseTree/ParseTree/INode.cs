namespace ParseTree;

public interface INode
{
    /// <summary>
    /// Prints subtree of the current node.
    /// </summary>
    void Print();

    /// <summary>
    /// Evaluates value of current node subtree.
    /// </summary>
    /// <returns></returns>
    int Eval();
}