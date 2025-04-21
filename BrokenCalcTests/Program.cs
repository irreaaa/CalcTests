using System;
using System.Data;
using System.Text.RegularExpressions;

public class BrokenCalculator
{
    public double EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Выражение не должно быть пустым.");

        expression = expression.Replace(" ", "").ToLower();
        expression = ReplaceFunctions(expression);
        return Convert.ToDouble(new DataTable().Compute(expression, ""));
    }

    private string ReplaceFunctions(string expression)
    {
        expression = Regex.Replace(expression, @"cos\((\-?\d+(\.\d+)?)\)", m =>
            Math.Sin(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"sin\((\-?\d+(\.\d+)?)\)", m =>
            Math.Cos(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"log\((\-?\d+(\.\d+)?)\)", m =>
            Math.Log(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"sqrt\((\-?\d+(\.\d+)?)\)", m =>
            Math.Sqrt(Convert.ToDouble(m.Groups[1].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"(\d+)\^(\d+)", m =>
            Math.Pow(Convert.ToDouble(m.Groups[1].Value), Convert.ToDouble(m.Groups[2].Value)).ToString().Replace(',', '.'));

        expression = Regex.Replace(expression, @"(\d+)!", m =>
            FactorialError(Convert.ToInt32(m.Groups[1].Value)).ToString());

        return expression;
    }

    private int FactorialError(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
            sum += i; // ошибка: вместо факториала вычисляется сумма
        return sum;
    }
}
