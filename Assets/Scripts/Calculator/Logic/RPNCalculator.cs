using System;
using System.Collections.Generic;
using static Calculator.StaticData.Operators;

public class RPNCalculator
{
    public bool TryCalculate(string input, out double result)
    {
        result = 0;
        if (TryConvertToPostfixNotation(input, out string output))
        {
            if (TryCounting(output, out result))
                return true;
        }
        return false;
    }

    public bool TryConvertToPostfixNotation(string input, out string result)
    {
        string output = string.Empty;
        Stack<Operator> operStack = new Stack<Operator>();
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == Space)
                    continue;

                if (char.IsDigit(input[i]))
                    output += ReadNumber(input, ref i) + Space.Name.ToString();

                if (TryGetOperatorWith(input[i], out Operator oper))
                {
                    if (IsUminus(input, i))
                    {
                        output += "0" + Space.Name.ToString();
                        operStack.Push(UMinus);
                        continue;
                    }
                    else if (oper == LeftParenthesis)
                    {
                        operStack.Push(oper);
                    }
                    else if (oper == RightParenthesis)
                    {
                        output = InsertOperationsFromStack(output, operStack);
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (oper.Priority <= operStack.Peek().Priority)
                                output += operStack.Pop().Name.ToString() + Space.Name.ToString();

                        operStack.Push(oper);
                    }
                }
            }

            while (operStack.Count > 0)
                output += operStack.Pop().Name.ToString() + Space.Name.ToString();
            result = output;
            return true;
        }
        catch
        {
            result = output;
            return false;
        }
    }

    private string InsertOperationsFromStack(string output, Stack<Operator> operStack)
    {
        Operator s = operStack.Pop();

        while (s != LeftParenthesis)
        {
            output += s.Name.ToString() + Space.Name.ToString();
            s = operStack.Pop();
        }

        return output;
    }

    private bool IsUminus(string input, int i)
    {
        bool uminus = false;

        if (TryGetOperatorWith(input[i], out Operator oper1))
        {
            if (i == 0)
                uminus = oper1 == Minus;
            else if (i > 0)
            {
                bool hasLastOperator = TryGetOperatorWith(input[i - 1], out Operator oper2);
                if (hasLastOperator)
                    uminus = oper1 == Minus && oper2 != Space;
            }
        }

        return uminus;
    }

    private bool TryCounting(string input, out double result)
    {
        result = 0;
        Stack<double> temp = new Stack<double>();
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    string a = ReadNumber(input, ref i);
                    temp.Push(double.Parse(a));
                }
                else if (TryGetOperatorWith(input[i], out Operator oper))
                {
                    if (oper == Space)
                        continue;

                    double a = temp.Pop();
                    double b = temp.Pop();

                    result = MakeOperation(result, oper, a, b);

                    temp.Push(result);
                }
            }
            result = temp.Peek();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private string ReadNumber(string input, ref int i)
    {
        string result = string.Empty;
        bool readNumber = true;
        while (readNumber)
        {
            result += input[i];
            i++;

            if (i == input.Length) break;

            readNumber = input[i] != Space && !HasOperatorWith(input[i]);
            if (TryGetOperatorWith(input[i], out Operator probablyDot))
                readNumber = probablyDot == Dot;
        }
        i--;
        return result;
    }

    private double MakeOperation(double result, Operator oper, double a, double b)
    {
        if (oper == Plus)
            result = b + a;
        else if (oper == Minus)
            result = b - a;
        else if (oper == Multyply)
            result = b * a;
        else if (oper == Division)
            result = b / a;
        else if (oper == Power)
            result = Math.Pow(b, a);
        return result;
    }
}
