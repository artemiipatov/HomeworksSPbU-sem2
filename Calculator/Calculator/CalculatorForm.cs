namespace Calculator;

public partial class CalculatorForm : Form
{
    public string firstOperand { get; private set; } = "";
    public string secondOperand { get; private set; } = "";
    public char currentOperator { get; private set; } = '\0';

    public CalculatorForm()
    {
        InitializeComponent();
    }

    public void OperandClick(object sender, EventArgs e)
    {
        if (currentOperator != '\0')
        {
            secondOperand += (sender as Button)!.Text;
        }
        else
        {
            firstOperand += (sender as Button)!.Text;
        }
    }

    public void OperatorClick(object sender, EventArgs e)
    {
        if (firstOperand == "")
        {
            return;
        }
        if (secondOperand == "")
        {
            if ((sender as Button)!.Text == "√")
            {
                firstOperand = Math.Sqrt(double.Parse(firstOperand)).ToString("G29");
                return;
            }
            currentOperator = Convert.ToChar((sender as Button)!.Text);
        }
        else
        {
            decimal decimalFirstOperand = (decimal)double.Parse(firstOperand);
            decimal decimalSecondOperand = (decimal)double.Parse(secondOperand);
            if ((sender as Button)!.Text == "√")
            {
                secondOperand = Math.Sqrt((double)decimalSecondOperand).ToString("G29");
                return;
            }
            switch (currentOperator)
            {
                case '+':
                {
                    firstOperand = (decimalFirstOperand + decimalSecondOperand).ToString("G29");
                    break;
                }
                case '-':
                {
                    firstOperand = (decimalFirstOperand - decimalSecondOperand).ToString("G29");
                    break;
                }
                case '✕':
                {
                    firstOperand = (decimalFirstOperand * decimalSecondOperand).ToString("G29");
                    break;
                }
                case '÷':
                {
                    firstOperand = (decimalFirstOperand / decimalSecondOperand).ToString("G29");
                    break;
                }
            }
            currentOperator = (sender as Button)!.Text == "=" ? '\0' : Convert.ToChar((sender as Button)!.Text);
            secondOperand = "";
        }
    }

    public void ButtonBackspaceClick(object sender, EventArgs e)
    {
        if (secondOperand != "")
        {
            secondOperand = secondOperand.Remove(secondOperand.Length - 1);
        }
        else if (currentOperator != '\0')
        {
            currentOperator = '\0';
        }
        else if (firstOperand != "")
        {
            firstOperand = firstOperand.Remove(firstOperand.Length - 1);
        }
    }

    public void ButtonNegationClick(object sender, EventArgs e)
    {
        if (secondOperand != "")
        {
            if (secondOperand[0] == '-')
            {
                secondOperand = secondOperand.Substring(1);
                return;
            }
            secondOperand = "-" + secondOperand;
        }
        else if (firstOperand != "")
        {
            if (firstOperand[0] == '-')
            {
                firstOperand = firstOperand.Substring(1);
                return;
            }
            firstOperand = "-" + firstOperand;
        }
    }

    public void ButtonDecimalPointClick(object sender, EventArgs e)
    {
        if (secondOperand != "")
        {
            secondOperand += secondOperand.Contains(',') ? "" : ',';
        }
        else if (firstOperand != "")
        {
            firstOperand += firstOperand.Contains(',') ? "" : ',';
        }
    }

    public void ButtonClearClick(object sender, EventArgs e)
    {
        secondOperand = "";
        currentOperator = '\0';
        firstOperand = "";
    }
}