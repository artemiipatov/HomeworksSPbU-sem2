namespace ParseTree;

public abstract class Operator : INode
{
    /// <summary>
    /// Parent node of the current node.
    /// </summary>
    public INode? Parent { get; set; }

    /// <summary>
    /// Right son of the current node.
    /// </summary>
    public INode? RightSon { get; set; }

    /// <summary>
    /// Left son of the current node.
    /// </summary>
    public INode? LeftSon { get; set; }

    /// <summary>
    /// Abstract method for printing the value of the current node and values of its subtree.
    /// </summary>
    public abstract void Print();

    /// <summary>
    /// Abstract method for evaluating value of the current node subtree.
    /// </summary>
    /// <returns></returns>
    public abstract int Eval();
}
