namespace ParseTree;

public class OperatorAdd : Operator
{
    public override int Eval()
    {
        if (LeftSon != null && RightSon != null)
        {
            return LeftSon.Eval() + RightSon.Eval();
        }
        throw new InvalidOperationException("Wrong input");
    }

    public override void Print()
    {
        Console.Write("(");
        Console.Write("+ ");
        if (LeftSon == null || RightSon == null)
        {
            throw new InvalidOperationException();
        }
        LeftSon.Print();
        RightSon.Print();
        Console.Write(")");
    }
}