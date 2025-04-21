using NUnit.Framework;
using System;

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
    public void Calculate_Power_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("2^3");
        Assert.AreEqual(8, result);
    }

    [Test]
    public void Calculate_Subtraction_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("10-4");
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Calculate_Multiplication_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("3*5");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_Division_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("10/2");
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Calculate_Sqrt_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("sqrt(16)");
        Assert.AreEqual(4, result);
    }

    [Test]
    public void Calculate_Sin_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("sin(0)");
        Assert.AreEqual(1, result, 0.0001); 
    }

    [Test]
    public void Calculate_Cos_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("cos(0)");
        Assert.AreEqual(0, result, 0.0001); 
    }

    [Test]
    public void Calculate_SinPi_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("sin(3.141)");
        Assert.AreEqual(-1, Math.Round(result), 0.0001); 
    }

    [Test]
    public void Calculate_CosPi_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("cos(3.141)");
        Assert.AreEqual(0, Math.Round(result), 0.0001); 
    }

    [Test]
    public void Calculate_SqrtNegative_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("sqrt(-4)");
        Assert.IsTrue(double.IsNaN(result)); 
    }

    [Test]
    public void Calculate_LogNegative_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("log(-10)");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_MultipleFactorials_ReturnsBrokenResult()
    {
        var result = _calculator.EvaluateExpression("3!+4!");
        Assert.AreEqual(6 + 10, result); 
    }

    [Test]
    public void Calculate_Log_ReturnsCorrectResult()
    {
        var result = _calculator.EvaluateExpression("log(100)");
        Assert.AreEqual(Math.Log(100), result, 0.0001);
    }

    [Test]
    public void Calculate_FactorialError_ReturnsSummedResult()
    {
        var result = _calculator.EvaluateExpression("5!");
        Assert.AreEqual(15, result);
    }

    [Test]
    public void Calculate_ComplexBrokenExpression_ReturnsCorrectlyBrokenResult()
    {
        var result = _calculator.EvaluateExpression("2+cos(0)+sin(0)+5!");
        Assert.AreEqual(2 + 0 + 1 + 15, result);
    }

    [Test]
    public void Calculate_ExpressionWithSpacesAndUppercase_ReturnsCorrectly()
    {
        var result = _calculator.EvaluateExpression("  SQRT(  9  ) + LOG(10)");
        Assert.AreEqual(3 + Math.Log(10), result, 0.0001);
    }

    [Test]
    public void Calculate_FactorialOfZero_ReturnsZero()
    {
        var result = _calculator.EvaluateExpression("0!");
        Assert.AreEqual(0, result); 
    }

    [Test]
    public void Calculate_FactorialOfOne_ReturnsOne()
    {
        var result = _calculator.EvaluateExpression("1!");
        Assert.AreEqual(1, result); 
    }

    [Test]
    public void Calculate_ExponentiationWithZero_ReturnsOne()
    {
        var result = _calculator.EvaluateExpression("5^0");
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Calculate_ExponentiationZeroPowerZero_ReturnsOne()
    {
        var result = _calculator.EvaluateExpression("0^0");
        Assert.AreEqual(1, result); 
    }

    [Test]
    public void Calculate_EmptyExpression_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_InvalidExpressionLetters_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("abc+1");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_InvalidMathFunction_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("exp(2)");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_BrokenParentheses_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("(2+3");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_DivideByZero_ReturnsInfinity()
    {
        var result = _calculator.EvaluateExpression("10/0");
        Assert.IsTrue(double.IsInfinity(result));
    }

    #[Test]
    public void Calculate_UnclosedBrackets_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("(2+3");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_ExtraOperator_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("2++2");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_EmptyBrackets_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("()");
        Assert.IsTrue(double.IsNaN(result));
    }

    [Test]
    public void Calculate_OnlyOperator_ReturnsNaN()
    {
        var result = _calculator.EvaluateExpression("+");
        Assert.IsTrue(double.IsNaN(result));
    }

 }