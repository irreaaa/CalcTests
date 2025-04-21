using NUnit.Framework;
using System;
using System.Data;

[TestFixture]
public class BrokenCalculatorTests
{
    private BrokenCalculator _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new BrokenCalculator();
    }

    [Test]
    public void Calculate_SimpleAddition_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("2+3");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_Power_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("2^3");
        Assert.AreEqual(8, result);
    }

    [Test]
    public void Calculate_Sqrt_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("sqrt(16)");
        Assert.AreEqual(4, result);
    }

    [Test]
    public void Calculate_Sin_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("sin(0)");
        Assert.AreEqual(0, result, 0.0001);
    }

    [Test]
    public void Calculate_Cos_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("cos(0)");
        Assert.AreEqual(1, result, 0.0001);
    }

    [Test]
    public void Calculate_Log_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("log(100)");
        Assert.AreEqual(2, result, 0.0001);
    }

    [Test]
    public void Calculate_FactorialError_ReturnsSummedResult()
    {
        var result = _calculator.EvaluateExpression("5!");
        Assert.AreEqual(15, result); 
    }

    [Test]
    public void Calculate_InvalidExpression_ReturnException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.EvaluateExpression(""));
    }

    [Test]
    public void Calculate_InvalidExpressionLetters_ReturnException()
    {
        Assert.Throws<SyntaxErrorException>(() => _calculator.EvaluateExpression("abc+1"));
    }

    [Test]
    public void Calculate_InvalidMathFunction_ReturnException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.EvaluateExpression("exp(2)"));
    }
}
