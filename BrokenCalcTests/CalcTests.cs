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
    public void Calculate_SimpleAdditionNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("-2+3");
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Calculate_SimpleAdditionDoubleBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("4563562+3346347457");
        Assert.AreEqual(3350911019, result);
    }

    [Test]
    public void Calculate_SimpleAdditionBigNumDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("42342.4352+23.3");
        Assert.AreEqual(42365,7352, result);
    }

    [Test]
    public void Calculate_SimpleAdditionBothBigNumBeforeDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("423857542.4+35287.3");
        Assert.AreEqual(423892829,7, result);
    }

    [Test]
    public void Calculate_SimpleAdditionBigNumWithPoint_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("42342,4352+23,3"));
    }

    [Test]
    public void Calculate_Subtraction_ReturnsCorrectResult()
    {
        var result = _calculator.Main("10-4");
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Calculate_SubtractionBigNum_ReturnsCorrectNegResult()
    {
        var result = _calculator.Main("107626456-4456463786");
        Assert.AreEqual(-4348837330, result);
    }

    [Test]
    public void Calculate_SubtractionBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("107626456-44566378");
        Assert.AreEqual(63060078, result);
    }

    [Test]
    public void Calculate_SubtractionBothBigNumBeforeDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("423857542.4-35287.3");
        Assert.AreEqual(423822255,1, result);
    }

    [Test]
    public void Calculate_SubtractionBothBigNumAfterDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("42.385754-3.52873");
        Assert.AreEqual(38.857, result, 0.001);
    }

    [Test]
    public void Calculate_SubtractionBigNumDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("42342.4352-23.3");
        Assert.AreEqual(42319,1352, result);
    }

    [Test]
    public void Calculate_SubtractionBigNumDouble_ReturnsCorrectNegResult()
    {
        var result = _calculator.Main("23.3-42342.4352");
        Assert.AreEqual(-42319.1352, result, 0.0001);
    }

    [Test]
    public void Calculate_SubtractionBigNumWithPoint_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("42342,4352-23,3"));
    }

    [Test]
    public void Calculate_Multiplication_ReturnsCorrectResult()
    {
        var result = _calculator.Main("3*5");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_MultiplicationBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("34346*58758");
        Assert.AreEqual(2018102268, result);
    }

    [Test]
    public void Calculate_MultiplicationBothBigNumDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("34346.67*58758.79");
        Assert.AreEqual(2018168769,73, result);
    }

    [Test]
    public void Calculate_MultiplicationOneOfBigNumDouble_ReturnsCorrectResult()
    {
        var result = _calculator.Main("3434667*58758.79");
        Assert.AreEqual(201816876972,93, result);
    }

    [Test]
    public void Calculate_MultiplicationNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("-3*5");
        Assert.AreEqual(-15, result);
    }

    [Test]
    public void Calculate_MultiplicationBothNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("-3*(-5)");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_Division_ReturnsCorrectResult()
    {
        var result = _calculator.Main("10/2");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_DivisionBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("56345665/5");
        Assert.AreEqual(11269133, result);
    }

    [Test]
    public void Calculate_DivisionBigNumSelf_ReturnsCorrectResult()
    {
        var result = _calculator.Main("56345665/56345665");
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Calculate_DivisionBigNum_ReturnsCorrectFractionResult()
    {
        var result = _calculator.Main("1345134634/3452");
        Assert.AreEqual(389668,202202, result);
    }

    [Test]
    public void Calculate_DivisionNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("-10/2");
        Assert.AreEqual(-5, result);
    }

    [Test]
    public void Calculate_DivisionSecIsNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("10/(-2)");
        Assert.AreEqual(-5, result);
    }

    [Test]
    public void Calculate_DivisionBothNegNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("-10/(-2)");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_DivideByZero_ReturnsInfinity()
    {
        var result = _calculator.Main("10/0");
        Assert.IsTrue(double.IsInfinity(result));
    }

    [Test]
    public void Calculate_Sqrt_ReturnsCorrectResult()
    {
        var result = _calculator.Main("sqrt(16)");
        Assert.AreEqual(4, result);
    }

    [Test]
    public void Calculate_SqrtBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("sqrt(30858025)");
        Assert.AreEqual(5555, result);
    }

    [Test]
    public void Calculate_SqrtBigNum_ReturnsCorrectDoubleResult()
    {
        var result = _calculator.Main("sqrt(27)");
        Assert.AreEqual(5.1962, result, 0.0001);
    }

    [Test]
    public void Calculate_SqrtDouble_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("sqrt(0,027)"));
    }

    [Test]
    public void Calculate_SqrtNegative_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("sqrt(-4)"));
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
    public void Calculate_FactorialError_ReturnsSummedResult()
    {
        var result = _calculator.Main("5!");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_MultipleFactorials_ReturnsBrokenResult()
    {
        var result = _calculator.Main("3!+4!");
        Assert.AreEqual(6 + 10, result);
    }

    [Test]
    public void Calculate_FactorialsDouble_ReturnsBrokenResult()
    {
        var result = _calculator.Main("5.5!");
        Assert.AreEqual(5.15, result, 0.01);
    }

    [Test]
    public void Calculate_SqrtFactorialPoint_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("5,5!"));
    }

    [Test]
    public void Calculate_LogZero_ReturnsCorrect()
    {
        var result = _calculator.Main("log(1)");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_Log_ReturnsCorrectResult()
    {
        var result = _calculator.Main("log(100)");
        Assert.AreEqual(Math.Log(100), result, 0.0001);
    }

    [Test]
    public void Calculate_LogBigNum_ReturnsCorrectResult()
    {
        var result = _calculator.Main("log(10000000)");
        Assert.AreEqual(Math.Log(10000000), result, 0.0001);
    }

    [Test]
    public void Calculate_LogNegative_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("log(-3)"));
    }

    [Test]
    public void Calculate_LogDouble_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("log(10.10)"));
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
    public void Calculate_Power_ReturnsBrokenResult()
    {
        var result = _calculator.Main("2^3");
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Calculate_Exponentiation_ReturnsBrokenResult()
    {
        var result = _calculator.Main("5^5");
        Assert.AreEqual(25, result);
    }

    [Test]
    public void Calculate_ExponentiationBigFirstNum_ReturnsBrokenResult()
    {
        var result = _calculator.Main("123456789^4");
        Assert.AreEqual(493827156, result);
    }

    [Test]
    public void Calculate_ExponentiationBigSecNum_ReturnsBrokenResult()
    {
        var result = _calculator.Main("54^12345678");
        Assert.AreEqual(666666612, result);
    }

    [Test]
    public void Calculate_ExponentiationBigNum_ReturnsBrokenResult()
    {
        var result = _calculator.Main("34346^58758");
        Assert.AreEqual(2018102268, result);
    }

    [Test]
    public void Calculate_ExponentiationWithZero_ReturnsZero()
    {
        var result = _calculator.Main("5^0");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_ExponentiationZeroPowerZero_ReturnsOneZero()
    {
        var result = _calculator.Main("0^0");
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Calculate_SimpleAdditionFDoubleNum_ReturnsCorrectResult()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("45,63562+334,6347457"));
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
    public void Calculate_e_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("abc+1"));
    }

    [Test]
    public void Calculate_InvalidMathFunction_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("exp(2)"));
    }

    [Test]
    public void Calculate_BrokenBrackets_ReturnsError()
    {
        Assert.Throws(typeof(Exception), () => _calculator.Main("(2+3]"));
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
        Assert.Throws(typeof(Exception), () => _calculator.Main("+"));
    }
}
