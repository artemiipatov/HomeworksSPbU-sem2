namespace ParseTree;

public class OperatorMultiply : Operator
{
    public override int Eval()
    {
        return LeftSon.Eval() * RightSon.Eval();
    }

    public override void Print()
    {
        Console.Write("* ");
        if (LeftSon is Operator)
        {
            Console.Write("( ");
        }
        LeftSon.Print();
        if (LeftSon is Operator)
        {
            Console.Write(") ");
        }

        if (RightSon is Operator)
        {
            Console.Write("( ");
        }
        RightSon.Print();
        if (RightSon is Operator)
        {
            Console.Write(") ");
        }
    }
}