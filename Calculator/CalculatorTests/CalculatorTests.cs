namespace CalculatorTests;

using NUnit.Framework;
using System.Windows.Forms;
using Calculator;

public class Tests
{
    private CalculatorForm testForm = new();
    private Button button0 = new() { Text = "0" };
    private Button button1 = new() { Text = "1" };
    private Button button2 = new() { Text = "2" };
    private Button button3 = new() { Text = "3" };
    private Button button4 = new() { Text = "4" };
    private Button button5 = new() { Text = "5" };
    private Button button6 = new() { Text = "6" };
    private Button button7 = new() { Text = "7" };
    private Button button8 = new() { Text = "8" };
    private Button button9 = new() { Text = "9" };
    private Button buttonMultiplication = new() { Text = "✕" };
    private Button buttonDecimalPoint = new() { Text = "," };
    private Button buttonNegation = new() { Text = "+/-" };
    private Button buttonEquals = new() { Text = "=" };
    private Button buttonPlus = new() { Text = "+" };
    private Button buttonMinus = new() { Text = "-" };
    private Button buttonDivision = new() { Text = "÷" };
    private Button buttonSqrt = new() { Text = "√" };
    private Button buttonClear = new() { Text = "C" };
    private Button buttonBackspace = new() { Text = "⌫" };

    [SetUp]
    public void Setup()
    {
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
        Assert.AreEqual("1234567890", testForm.FirstOperand);

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
        Assert.AreEqual("9876543210", testForm.SecondOperand);
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
        Assert.AreEqual("430376", testForm.FirstOperand);
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
        Assert.AreEqual("-763063", testForm.FirstOperand);
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
        Assert.AreEqual("108", testForm.FirstOperand);
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
        Assert.AreEqual("689419600128", testForm.FirstOperand);
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
        Assert.AreEqual("13693722,43861093368", testForm.FirstOperand);
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
        Assert.AreEqual("", testForm.FirstOperand);
        Assert.AreEqual('\0', testForm.CurrentOperator);
        Assert.AreEqual("", testForm.SecondOperand);
    }
    
    [Test]
    public void TestClearButtonOnEmptyExpression()
    {
        buttonClear.PerformClick();
        Assert.AreEqual("", testForm.FirstOperand);
        Assert.AreEqual('\0', testForm.CurrentOperator);
        Assert.AreEqual("", testForm.SecondOperand);
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
        Assert.AreEqual("85,9", testForm.FirstOperand);
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
        Assert.AreEqual("85,9", testForm.SecondOperand);
        buttonEquals.PerformClick();
        Assert.AreEqual("374,9", testForm.FirstOperand);
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
        Assert.AreEqual("1234567", testForm.FirstOperand);
        buttonDecimalPoint.PerformClick();
        button7.PerformClick();
        button8.PerformClick();
        Assert.AreEqual("1234567,78", testForm.FirstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("12345", testForm.FirstOperand);
        buttonPlus.PerformClick();
        button8.PerformClick();
        button9.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("8", testForm.SecondOperand);
        Assert.AreEqual('+', testForm.CurrentOperator);
        Assert.AreEqual("12345", testForm.FirstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("", testForm.SecondOperand);
        Assert.AreEqual('\0', testForm.CurrentOperator);
        Assert.AreEqual("1234", testForm.FirstOperand);
    }

    [Test]
    public void TestDoubleNegation()
    {
        button9.PerformClick();
        buttonNegation.PerformClick();
        Assert.AreEqual("-9", testForm.FirstOperand);
        buttonNegation.PerformClick();
        Assert.AreEqual("9", testForm.FirstOperand);
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
        Assert.AreEqual("5542,56", testForm.FirstOperand);
        button1.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        button0.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual("-4457,44", testForm.FirstOperand);
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        buttonBackspace.PerformClick();
        Assert.AreEqual("-445", testForm.FirstOperand);
        buttonNegation.PerformClick();
        Assert.AreEqual("445", testForm.FirstOperand);
        buttonMinus.PerformClick();
        button4.PerformClick();
        buttonEquals.PerformClick();
        buttonSqrt.PerformClick();
        Assert.AreEqual("21", testForm.FirstOperand);
    }

    [Test]
    public void TestFewOperatorsInput()
    {
        buttonPlus.PerformClick();
        buttonMultiplication.PerformClick();
        buttonMinus.PerformClick();
        buttonDivision.PerformClick();
        buttonEquals.PerformClick();
        Assert.AreEqual('\0', testForm.CurrentOperator);
        button9.PerformClick();
        buttonPlus.PerformClick();
        Assert.AreEqual('+', testForm.CurrentOperator);
        buttonMultiplication.PerformClick();
        buttonMinus.PerformClick();
        Assert.AreEqual('-', testForm.CurrentOperator);
    }

    [Test]
    public void TestDoubleDecimalPointInput()
    {
        button9.PerformClick();
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.FirstOperand);
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.FirstOperand);
        buttonDecimalPoint.PerformClick();
        Assert.AreEqual("9,", testForm.FirstOperand);
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