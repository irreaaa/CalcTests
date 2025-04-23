using System;
using System.Data;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

class Calculator
{
    public double Main(string input)
    {

        while (true)
        {
            try
            {

                if (string.IsNullOrEmpty(input.Trim()))
                {
                    throw new Exception("Выражение не может быть пустым или содержать только пробелы.");
                }
                CheckForConsecutiveOperators(input);
                double result = EvaluateExpression(input);
                return Math.Round(result, 4);
            }
            catch (Exception ex)
            {
                throw new Exception("qe");
            }
        }
    }

    static void CheckForConsecutiveOperators(string expression)
    {
        const string pattern = @"([+\-\*/]{2,})";
        Match match = Regex.Match(expression, pattern);
        if (match.Success)
        {
            throw new Exception("Недопустимые последовательные операторы.");
        }
    }

    static double EvaluateExpression(string expression)
    {
        expression = expression.Replace(" ", "").ToLower();
        expression = ReplaceFunctions(expression);
        return Convert.ToDouble(new DataTable().Compute(expression, ""));
    }

    static string ReplaceFunctions(string expression)
    {
        expression = Regex.Replace(expression, @"cos\((\-?\d+(\.\d+)?)\)",
            m => Math.Sin(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));
        expression = Regex.Replace(expression, @"sin\((\-?\d+(\.\d+)?)\)",
            m => Math.Cos(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));
        expression = Regex.Replace(expression, @"log\((\-?\d+(\.\d+)?)\)",
            m => Math.Log(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));
        expression = Regex.Replace(expression, @"sqrt\((\-?\d+(\.\d+)?)\)",
           m => Math.Sqrt(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"(\d+)\!",
            m => FactorialError(Convert.ToInt32(m.Groups[1].Value)).ToString());

        expression = expression.Replace("^", "*");

        expression = Regex.Replace(expression, @"(\d+)\*\*(\d+)",
            m => Math.Pow(Convert.ToDouble(m.Groups[1].Value), Convert.ToDouble(m.Groups[2].Value)).ToString().Replace(',', '.'));

        return expression;
    }

    static int FactorialError(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
            sum += i;
        return sum;
    }
}