namespace CalculatorTests;

using NUnit.Framework;
using System.Windows.Forms;
using Calculator;

public class Tests
{
    private CalculatorForm testForm;
    private Button button0;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button9;
    private Button buttonMultiplication;
    private Button buttonDecimalPoint;
    private Button buttonNegation;
    private Button buttonEquals;
    private Button buttonPlus;
    private Button buttonMinus;
    private Button buttonDivision;
    private Button buttonSqrt;
    private Button buttonClear;
    private Button buttonBackspace;

    [SetUp]
    public void Setup()
    {
        testForm = new CalculatorForm();
        button0 = new System.Windows.Forms.Button()
        {
            Text = "0"
        };
        button1 = new System.Windows.Forms.Button()
        {
            Text = "1"
        };
        button2 = new System.Windows.Forms.Button()
        {
            Text = "2"
        };
        button3 = new System.Windows.Forms.Button()
        {
            Text = "3"
        };
        button4 = new System.Windows.Forms.Button()
        {
            Text = "4"
        };
        button5 = new System.Windows.Forms.Button()
        {
            Text = "5"
        };
        button6 = new System.Windows.Forms.Button()
        {
            Text = "6"
        };
        button7 = new System.Windows.Forms.Button()
        {
            Text = "7"
        };
        button8 = new System.Windows.Forms.Button()
        {
            Text = "8"
        };
        button9 = new System.Windows.Forms.Button()
        {
            Text = "9"
        };
        buttonNegation = new System.Windows.Forms.Button()
        {
            Text = "+/-"
        };
        buttonDecimalPoint = new System.Windows.Forms.Button()
        {
            Text = ","
        };
        buttonEquals = new System.Windows.Forms.Button()
        {
            Text = "="
        };
        buttonPlus = new System.Windows.Forms.Button()
        {
            Text = "+"
        };
        buttonMinus = new System.Windows.Forms.Button()
        {
            Text = "-"
        };
        buttonMultiplication = new System.Windows.Forms.Button()
        {
            Text = "✕"
        };
        buttonDivision = new System.Windows.Forms.Button()
        {
            Text = "÷"
        };
        buttonSqrt = new System.Windows.Forms.Button()
        {
            Text = "√"
        };
        buttonBackspace = new System.Windows.Forms.Button()
        {
            Text = "⌫"
        };
        buttonClear = new System.Windows.Forms.Button()
        {
            Text = "C"
        };
        button1.Click += new System.EventHandler(testForm.OperandClick!);
        button2.Click += new System.EventHandler(testForm.OperandClick!);
        button3.Click += new System.EventHandler(testForm.OperandClick!);
        button4.Click += new System.EventHandler(testForm.OperandClick!);
        button5.Click += new System.EventHandler(testForm.OperandClick!);
        button6.Click += new System.EventHandler(testForm.OperandClick!);
        button7.Click += new System.EventHandler(testForm.OperandClick!);
        button8.Click += new System.EventHandler(testForm.OperandClick!);
        button9.Click += new System.EventHandler(testForm.OperandClick!);
        button0.Click += new System.EventHandler(testForm.OperandClick!);
        buttonPlus.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonMinus.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonDivision.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonMultiplication.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonEquals.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonSqrt.Click += new System.EventHandler(testForm.OperatorClick!);
        buttonNegation.Click += new System.EventHandler(testForm.ButtonNegationClick!);
        buttonDecimalPoint.Click += new System.EventHandler(testForm.ButtonDecimalPointClick!);
        buttonClear.Click += new System.EventHandler(testForm.ButtonClearClick!);
        buttonBackspace.Click += new System.EventHandler(testForm.ButtonBackspaceClick!);
    }

    [Test]
    public void TestPressingDigitButtons()
    {
        button1.PerformClick();
        button2.PerformClick();
        button3.PerformClick();
        button4.PerformClick();
        button5.PerformClick();
        button6.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button0.PerformClick();
        Assert.AreEqual("1234567890", testForm.firstOperand);

        buttonPlus.PerformClick();
        button9.PerformClick();
        button8.PerformClick();
        button7.PerformClick();
        button6.PerformClick();
        button5.PerformClick();
        button4.PerformClick();
        button3.PerformClick();
        button2.PerformClick();
        button1.PerformClick();
        button0.PerformClick();
        Assert.AreEqual("9876543210", testForm.secondOperand);
    }

    [Test]
    public void TestOperatorAdd()
    {
        button4.PerformClick();
        button8.PerformClick();
        button3.PerformClick();
        button5.PerformClick();
        button9.PerformClick();
        buttonPlus.PerformClick();
        button3.PerformClick();
        button8.PerformClick();
        button2.PerformClick();
        button0.PerformClick();
        button1.PerformClick();
        button7.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("430376", testForm.firstOperand);
    }

    [Test]
    // +, -, *, /
    public void TestOperatorSubstract()
    {
        button2.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button5.PerformClick();
        button0.PerformClick();
        buttonMinus.PerformClick();
        button7.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        button0.PerformClick();
        button1.PerformClick();
        button3.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("-763063", testForm.firstOperand);
    }

    [Test]
    public void TestOperatorDivide()
    {
        button6.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button4.PerformClick();
        button7.PerformClick();
        button2.PerformClick();
        buttonDivision.PerformClick();
        button6.PerformClick();
        button3.PerformClick();
        button8.PerformClick();
        button4.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("108", testForm.firstOperand);
    }

    [Test]
    public void TestOperatorMultiply()
    {
        button6.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button4.PerformClick();
        button7.PerformClick();
        button2.PerformClick();
        buttonMultiplication.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        button4.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("689419600128", testForm.firstOperand);
    }

    [Test]
    public void TestDecimalPoint()
    {
        button4.PerformClick();
        button7.PerformClick();
        button2.PerformClick();
        buttonDecimalPoint.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        button4.PerformClick();
        button7.PerformClick();
        button9.PerformClick();
        buttonMultiplication.PerformClick();
        button2.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button5.PerformClick();
        button0.PerformClick();
        buttonDecimalPoint.PerformClick();
        button7.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("13693722,43861093368", testForm.firstOperand);
    }

    [Test]
    public void TestClearButton()
    {
        button4.PerformClick();
        button7.PerformClick();
        button2.PerformClick();
        buttonDecimalPoint.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        button4.PerformClick();
        button7.PerformClick();
        button9.PerformClick();
        buttonMultiplication.PerformClick();
        button2.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button5.PerformClick();
        button0.PerformClick();
        buttonDecimalPoint.PerformClick();
        button7.PerformClick();
        button9.PerformClick();
        button2.PerformClick();
        buttonClear.PerformClick();
        Assert.AreEqual("", testForm.firstOperand);
        Assert.AreEqual('\0', testForm.currentOperator);
        Assert.AreEqual("", testForm.secondOperand);
    }
    
    [Test]
    public void TestClearButtonOnEmptyExpression()
    {
        buttonClear.PerformClick();
        Assert.AreEqual("", testForm.firstOperand);
        Assert.AreEqual('\0', testForm.currentOperator);
        Assert.AreEqual("", testForm.secondOperand);
    }

    [Test]
    // sqrt, plus/minus
    public void TestSqrtOperator()
    {
        button7.PerformClick();
        button3.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        buttonDecimalPoint.PerformClick();
        button8.PerformClick();
        button1.PerformClick();
        buttonSqrt.PerformClick();
        Assert.AreEqual("85,9", testForm.firstOperand);
        buttonClear.PerformClick();

        button2.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        buttonPlus.PerformClick();
        button7.PerformClick();
        button3.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        buttonDecimalPoint.PerformClick();
        button8.PerformClick();
        button1.PerformClick();
        buttonSqrt.PerformClick();
        Assert.AreEqual("85,9", testForm.secondOperand);
        buttonEquals.PerformClick();
        Assert.AreEqual("374,9", testForm.firstOperand);
    }

    [Test]
    public void TestBackspaceButton()
    {
        button1.PerformClick();
        button2.PerformClick();
        button3.PerformClick();
        button4.PerformClick();
        button5.PerformClick();
        button6.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        button0.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("1234567", testForm.firstOperand);
        buttonDecimalPoint.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        Assert.AreEqual("1234567,78", testForm.firstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("12345", testForm.firstOperand);
        buttonPlus.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("8", testForm.secondOperand);
        Assert.AreEqual('+', testForm.currentOperator);
        Assert.AreEqual("12345", testForm.firstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("", testForm.secondOperand);
        Assert.AreEqual('\0', testForm.currentOperator);
        Assert.AreEqual("1234", testForm.firstOperand);
    }

    [Test]
    public void TestDoubleNegation()
    {
        button9.PerformClick();
        buttonNegation.PerformClick();
        Assert.AreEqual("-9", testForm.firstOperand);
        buttonNegation.PerformClick();
        Assert.AreEqual("9", testForm.firstOperand);
    }

    [Test]
    public void TestOnLongExpressions()
    {
        button7.PerformClick();
        button3.PerformClick();
        buttonDecimalPoint.PerformClick();
        button3.PerformClick();
        buttonPlus.PerformClick();
        button5.PerformClick();
        button5.PerformClick();
        buttonDivision.PerformClick();
        button2.PerformClick();
        buttonMultiplication.PerformClick();
        button8.PerformClick();
        button6.PerformClick();
        buttonDecimalPoint.PerformClick();
        button4.PerformClick();
        buttonMinus.PerformClick();
        Assert.AreEqual("5542,56", testForm.firstOperand);
        button1.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("-4457,44", testForm.firstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("-445", testForm.firstOperand);
        buttonNegation.PerformClick();
        Assert.AreEqual("445", testForm.firstOperand);
        buttonMinus.PerformClick();
        button4.PerformClick();
        buttonEquals.PerformClick();
        buttonSqrt.PerformClick();
        Assert.AreEqual("21", testForm.firstOperand);
    }

    [Test]
    public void TestFewOperatorsInput()
    {
        buttonPlus.PerformClick();
        buttonMultiplication.PerformClick();
        buttonMinus.PerformClick();
        buttonDivision.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual('\0', testForm.currentOperator);
        button9.PerformClick();
        buttonPlus.PerformClick();
        Assert.AreEqual('+', testForm.currentOperator);
        buttonMultiplication.PerformClick();
        buttonMinus.PerformClick();
        Assert.AreEqual('-', testForm.currentOperator);
    }

    [Test]
    public void TestDoubleDecimalPointInput()
    {
        button9.PerformClick();
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.firstOperand);
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.firstOperand);
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.firstOperand);
    }

    [Test]
    public void TestUsingBackspaceOnEmptyExpression()
    {
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.Pass();
    }
}