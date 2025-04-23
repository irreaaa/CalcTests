using NUnit.Framework;


[TestFixture]
public class ProgramTests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Calculate_SimpleAddition_ReturnsCorrectResult()
    {
        var result = _calculator.Main("2+3");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_Power_ReturnsBrokenResult()
    {
        var result = _calculator.Main("2^3");
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Calculate_Subtraction_ReturnsCorrectResult()
    {
        var result = _calculator.Main("10-4");
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Calculate_Multiplication_ReturnsCorrectResult()
    {
        var result = _calculator.Main("3*5");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_Division_ReturnsCorrectResult()
    {
        var result = _calculator.Main("10/2");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_Sqrt_ReturnsCorrectResult()
    {
        var result = _calculator.Main("sqrt(16)");
        Assert.AreEqual(4, result);
    }

    [Test]
    public void Calculate_Sin_ReturnsBrokenResult()
    {
        var result = _calculator.Main("sin(0)");
        Assert.AreEqual(1, result, 0.0001);
    }

    [Test]
    public void Calculate_Cos_ReturnsBrokenResult()
    {
        var result = _calculator.Main("cos(0)");
        Assert.AreEqual(0, result, 0.0001);
    }

    [Test]
    public void Calculate_MultipleFactorials_ReturnsBrokenResult()
    {
        var result = _calculator.Main("3!+4!");
        Assert.AreEqual(6 + 10, result);
    }

    [Test]
    public void Calculate_Log_ReturnsCorrectResult()
    {
        var result = _calculator.Main("log(100)");
        Assert.AreEqual(Math.Log(100), result, 0.0001);
    }

    [Test]
    public void Calculate_FactorialError_ReturnsSummedResult()
    {
        var result = _calculator.Main("5!");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_ComplexBrokenExpression_ReturnsCorrectlyBrokenResult()
    {
        var result = _calculator.Main("2+cos(0)+sin(0)+5!");
        Assert.AreEqual(2 + 0 + 1 + 15, result);
    }

    [Test]
    public void Calculate_ExpressionWithSpacesAndUppercase_ReturnsCorrectly()
    {
        var result = _calculator.Main("  SQRT(  9  ) + LOG(10)");
        Assert.AreEqual(5.3026, result, 0.0001);
    }

    [Test]
    public void Calculate_FactorialOfZero_ReturnsZero()
    {
        var result = _calculator.Main("0!");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_FactorialOfOne_ReturnsOne()
    {
        var result = _calculator.Main("1!");
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Calculate_ExponentiationWithZero_ReturnsOne()
    {
        var result = _calculator.Main("5^0");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_ExponentiationZeroPowerZero_ReturnsOne()
    {
        var result = _calculator.Main("0^0");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_EmptyExpression_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main(""));
    }

    [Test]
    public void Calculate_InvalidExpressionLetters_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("abc+1"));
    }

    [Test]
    public void Calculate_InvalidMathFunction_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("exp(2)"));
    }

    [Test]
    public void Calculate_SqrtNegative_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("sqrt(-4)"));
    }

    [Test]
    public void Calculate_LogNegative_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("(2+3"));
    }

    [Test]
    public void Calculate_BrokenParentheses_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("(2+3"));
    }

    [Test]
    public void Calculate_DivideByZero_ReturnsInfinity()
    {
        var result = _calculator.Main("10/0");
        Assert.IsTrue(double.IsInfinity(result));
    }

    [Test]
    public void Calculate_UnclosedBrackets_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("(2+3"));
    }

    [Test]
    public void Calculate_ExtraOperator_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("2++3"));
    }

    [Test]
    public void Calculate_EmptyBrackets_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("()"));
    }

    [Test]
    public void Calculate_OnlyOperator_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("()"));
    }
}
