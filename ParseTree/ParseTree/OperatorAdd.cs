namespace ParseTree;

public class OperatorAdd : Operator
{
    public override int Eval()
    {
        if (LeftSon != null && RightSon != null) return LeftSon.Eval() + RightSon.Eval();
        throw new NullReferenceException("Wrong input");
    }

    public override void Print()
    {
        Console.Write("+ ");
        if (LeftSon == null || RightSon == null) throw new NullReferenceException("Wrong input");
        if (LeftSon is Operator)
        {
            Console.Write("( ");
            LeftSon.Print();
            Console.Write(") ");
        }
        else
        {
            LeftSon.Print();
        }

        if (RightSon is Operator)
        {
            Console.Write("( ");
            RightSon.Print();
            Console.Write(") ");
        }
        else
        {
            RightSon.Print();
        }
    }
}