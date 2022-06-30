namespace Calculator;

public partial class CalculatorForm : Form
{
    public string FirstOperand { get; private set; } = "";
    public string SecondOperand { get; private set; } = "";
    public char CurrentOperator { get; private set; } = '\0';

    public CalculatorForm()
    {
        InitializeComponent();
    }

    public void OperandClick(object sender, EventArgs e)
    {
        if (CurrentOperator != '\0')
        {
            SecondOperand += (sender as Button)!.Text;
        }
        else
        {
            FirstOperand += (sender as Button)!.Text;
        }
    }

    public void OperatorClick(object sender, EventArgs e)
    {
        if (FirstOperand == "")
        {
            return;
        }
        if (SecondOperand == "")
        {
            if ((sender as Button)!.Text == "√")
            {
                FirstOperand = Math.Sqrt(double.Parse(FirstOperand)).ToString("G29");
                return;
            }
            CurrentOperator = Convert.ToChar((sender as Button)!.Text);
        }
        else
        {
            decimal decimalFirstOperand = (decimal)double.Parse(FirstOperand);
            decimal decimalSecondOperand = (decimal)double.Parse(SecondOperand);
            if ((sender as Button)!.Text == "√")
            {
                SecondOperand = Math.Sqrt((double)decimalSecondOperand).ToString("G29");
                return;
            }
            switch (CurrentOperator)
            {
                case '+':
                {
                    FirstOperand = (decimalFirstOperand + decimalSecondOperand).ToString("G29");
                    break;
                }
                case '-':
                {
                    FirstOperand = (decimalFirstOperand - decimalSecondOperand).ToString("G29");
                    break;
                }
                case '✕':
                {
                    FirstOperand = (decimalFirstOperand * decimalSecondOperand).ToString("G29");
                    break;
                }
                case '÷':
                {
                    FirstOperand = (decimalFirstOperand / decimalSecondOperand).ToString("G29");
                    break;
                }
            }
            CurrentOperator = (sender as Button)!.Text == "=" ? '\0' : Convert.ToChar((sender as Button)!.Text);
            SecondOperand = "";
        }
    }

    public void ButtonBackspaceClick(object sender, EventArgs e)
    {
        if (SecondOperand != "")
        {
            SecondOperand = SecondOperand.Remove(SecondOperand.Length - 1);
        }
        else if (CurrentOperator != '\0')
        {
            CurrentOperator = '\0';
        }
        else if (FirstOperand != "")
        {
            FirstOperand = FirstOperand.Remove(FirstOperand.Length - 1);
        }
    }

    public void ButtonNegationClick(object sender, EventArgs e)
    {
        if (SecondOperand != "")
        {
            if (SecondOperand[0] == '-')
            {
                SecondOperand = SecondOperand.Substring(1);
                return;
            }
            SecondOperand = "-" + SecondOperand;
        }
        else if (FirstOperand != "")
        {
            if (FirstOperand[0] == '-')
            {
                FirstOperand = FirstOperand.Substring(1);
                return;
            }
            FirstOperand = "-" + FirstOperand;
        }
    }

    public void ButtonDecimalPointClick(object sender, EventArgs e)
    {
        if (SecondOperand != "")
        {
            SecondOperand += SecondOperand.Contains(',') ? "" : ',';
        }
        else if (FirstOperand != "")
        {
            FirstOperand += FirstOperand.Contains(',') ? "" : ',';
        }
    }

    public void ButtonClearClick(object sender, EventArgs e)
    {
        SecondOperand = "";
        CurrentOperator = '\0';
        FirstOperand = "";
    }
}