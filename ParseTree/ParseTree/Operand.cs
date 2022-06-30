namespace ParseTree;

public class Operand : INode
{
    public int Value { get; set; }
    public INode? Parent { get; set; }
    
    public Operand(int value)
    {
        Value = value;
    }

    public void Print() => Console.Write(Value + " ");

    public int Eval() => Value;
}
