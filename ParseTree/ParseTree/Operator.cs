namespace ParseTree;

public abstract class Operator : INode
{
    public INode? Parent { get; set; }
    public INode? RightSon { get; set; }
    public INode? LeftSon { get; set; }

    public abstract void Print();
    
    public abstract int Eval();
}
