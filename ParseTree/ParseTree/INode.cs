namespace ParseTree;

/// <summary>
/// Parse tree node interface
/// </summary>
public interface INode
{
    /// <summary>
    /// Prints subtree of the current node.
    /// </summary>
    void Print();

    /// <summary>
    /// Evaluates value of current node subtree.
    /// </summary>
    int Eval();
}