using System;
using System.Text;
using System.Collections;
using System.Globalization;

namespace BOSERP.Utilities
{
    public class Formula
    {
        #region Contanst
        public const string SpaceString = " ";
        public const string Plus = "+";
        public const string Minus = "-";
        public const string Multiply = "*";
        public const string Division = "/";
        public const string LeftBracket = "(";
        public const string RightBracket = ")";
        public const char CharSpace = ' ';
        public const char LeftBracketChar = '(';
        #endregion

        #region Private Variables

        #endregion

        #region Constructor
        public Formula()
        {

        }
        #endregion

        #region Check value includes: {+,-,*,/,),(}
        /// <summary>
        /// Check value is Operator
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True or false</returns>
        public bool IsOperator(string value)
        {
            if (value == Plus || value == Minus || value == Multiply || value == Division)
                return true;
            return false;
        }

        /// <summary>
        /// Check value is a number
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True of false</returns>
        public bool IsOperand(string value)
        {
            bool check = true;
            double checkValue;
            if (double.TryParse(value, out checkValue))
            {
                check = true;
            }
            else
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] >= Convert.ToChar(48) && value[i] <= Convert.ToChar(57)) || value[i] == Convert.ToChar(46))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }
            return check;
        }

        /// <summary>
        /// Check value is bracket ")" or "("
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>True or false</returns>
        public bool IsBracket(string value)
        {
            if (value == LeftBracket || value == RightBracket)
                return true;
            return false;

        }

        /// <summary>
        /// Compare priority of value
        /// </summary>
        ///<param name="value">Value to compare</param>
        /// <returns>Priority of value</returns>
        private int CheckPriority(string value)
        {
            if (value == Plus || value == Minus)
                return 1;
            if (value == Multiply || value == Division)
                return 2;
            return 0;
        }

        #endregion

        #region Check Formula
        /// <summary>
        /// Check Formula includes: operation, operand and bracket
        /// </summary>
        /// <param name="formula">Formula string</param>
        /// <returns>True or false</returns>
        public bool CheckFormula(string formula)
        {
            bool check = true;
            string exp = formula;
            int countLeftBracket = 0;
            int countRightBracket = 0;
            exp = exp.Replace(SpaceString, String.Empty);
            if (!IsOperator(Convert.ToString(exp[exp.Length - 1])))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    if (!IsOperand(Convert.ToString(exp[i])))
                    {
                        if (!IsOperator(Convert.ToString(exp[i])))
                        {
                            if (!IsBracket(Convert.ToString(exp[i])))
                            {
                                check = false;
                                break;
                            }
                        }
                    }
                    if (Convert.ToString(exp[i]) == LeftBracket)
                        countLeftBracket = countLeftBracket + 1;
                    if (Convert.ToString(exp[i]) == RightBracket)
                        countRightBracket = countRightBracket + 1;

                }
            }
            else
                check = false;
            if (countLeftBracket != countRightBracket)
                check = false;
            if (!CheckFormulaByOperator(exp))
                check = false;
            return check;
        }
        #endregion

        #region Convert to Formula
        /// <summary>
        /// Convert to Formula
        /// </summary>
        /// <param name="formula">Formula string</param>
        /// <returns>Formula string after convert</returns>
        public string ConvertFormula(string formula)
        {
            string exp = formula;
            string value = String.Empty;
            StringBuilder expBuilder = new StringBuilder();
            if (CheckFormula(formula))
            {
                exp = exp.Replace(SpaceString, String.Empty);
                for (int i = 0; i < exp.Length; i++)
                {
                    char charTest = exp[i];
                    if (IsOperand(Convert.ToString(exp[i])))
                    {
                        value += Convert.ToString(exp[i]);
                        if (i == exp.Length - 1)
                        {
                            if (value != String.Empty)
                                expBuilder.Append(value);
                        }
                    }
                    else
                    {
                        if (value != String.Empty)
                        {
                            expBuilder.Append(value);
                            expBuilder.Append(SpaceString);
                        }
                        if (IsOperator(Convert.ToString(exp[i])) || IsBracket(Convert.ToString(exp[i])))
                        {
                            expBuilder.Append(Convert.ToString(exp[i]));
                            expBuilder.Append(SpaceString);
                        }
                        value = String.Empty;
                    }
                }
            }
            return expBuilder.ToString();

        }

        #endregion

        #region Convert formula to RPN formula
        /// <summary>
        /// Convert from formula to RPN Formula
        /// </summary>
        /// <param name="formula">Formula that user want to convert</param>
        /// <returns>RPN formula</returns>
        public string ConvertToRPN(string formula)
        {
            string exp = ConvertFormula(formula);
            Stack expStack = new Stack();
            StringBuilder expBuilder = new StringBuilder();
            if (exp != String.Empty)
            {
                string[] expArray = exp.Split(new char[] { CharSpace });
                for (int i = 0; i < expArray.Length; i++)
                {
                    if (expArray[i] != String.Empty)
                    {
                        string value = expArray[i];
                        if (IsOperand(expArray[i]))
                        {
                            expBuilder.Append(expArray[i]);
                            expBuilder.Append(SpaceString);
                        }
                        else
                        {
                            if (IsOperator(expArray[i]))
                            {
                                if (expArray[i].ToString() == Minus)
                                {
                                    if (i == 0)
                                    {
                                        expBuilder.Append(expArray[i].ToString());
                                    }
                                    else
                                    {
                                        int j = i - 1;
                                        if (IsOperator(expArray[j]))
                                        {
                                            expBuilder.Append(expArray[i].ToString());
                                        }
                                        else if (expArray[j] == LeftBracket)
                                        {
                                            expBuilder.Append(expArray[i].ToString());
                                        }
                                        else
                                        {
                                            while (expStack.Count > 0 && (CheckPriority(expArray[i]) <= CheckPriority(expStack.Peek().ToString())))
                                            {
                                                string top = Convert.ToString(expStack.Peek());
                                                if (top.Equals(LeftBracket))
                                                    break;
                                                expBuilder.Append(Convert.ToString(expStack.Pop()));
                                                expBuilder.Append(SpaceString);
                                            }
                                            expStack.Push(expArray[i]);
                                        }
                                    }

                                }
                                else
                                {
                                    while (expStack.Count > 0 && (CheckPriority(expArray[i]) <= CheckPriority(expStack.Peek().ToString())))
                                    {
                                        string top = Convert.ToString(expStack.Peek());
                                        if (top.Equals(LeftBracket))
                                            break;
                                        expBuilder.Append(Convert.ToString(expStack.Pop()));
                                        expBuilder.Append(SpaceString);
                                    }
                                    expStack.Push(expArray[i]);
                                }

                            }
                            else
                            {
                                if (IsBracket(expArray[i]))
                                {
                                    if (expArray[i] == LeftBracket)
                                    {
                                        expStack.Push(expArray[i]);
                                    }
                                    else
                                    {
                                        while (expStack.Count > 0 && (Convert.ToString(expStack.Peek()) != LeftBracket))
                                        {
                                            expBuilder.Append(expStack.Pop());
                                            expBuilder.Append(SpaceString);
                                        }
                                        expStack.Pop();
                                    }

                                }
                            }
                        }
                    }
                }
                while (expStack.Count > 0)
                {
                    expBuilder.Append(expStack.Pop());
                    expBuilder.Append(SpaceString);
                }
            }
            return expBuilder.ToString();
        }
        #endregion

        #region Calculate RPN
        /// <summary>
        /// Calculate formula by RPN algorithm
        /// </summary>
        /// <param name="formula">Formula to calculate</param>
        /// <returns>Result of formula</returns>
        public double Calculate(string formula)
        {
            string exp = ConvertToRPN(formula);
            double value = 0.0;
            Stack resultStack = new Stack();
            if (exp != String.Empty)
            {
                string[] expArray = exp.Split(new char[] { CharSpace });
                for (int i = 0; i < expArray.Length; i++)
                {
                    if (expArray[i] != String.Empty)
                    {
                        if (IsOperand(expArray[i]))
                        {
                            resultStack.Push(Convert.ToDouble(expArray[i]));
                        }
                        else
                        {
                            double leftValue = Convert.ToDouble(resultStack.Pop());
                            double rightValue = Convert.ToDouble(resultStack.Pop());
                            if (expArray[i] == Plus)
                                resultStack.Push(rightValue + leftValue);
                            else if (expArray[i] == Minus)
                                resultStack.Push(rightValue - leftValue);
                            else if (expArray[i] == Multiply)
                                resultStack.Push(rightValue * leftValue);
                            else
                                resultStack.Push(rightValue / leftValue);
                        }
                    }
                }
            }
            if (resultStack.Count > 0)
                value = Convert.ToDouble(resultStack.Pop());
            return value;

        }
        #endregion

        #region Check Formula By Operator
        /// <summary>
        /// Compare operators and operands
        /// </summary>
        /// <param name="formula">formula</param>
        /// <returns>True or false</returns>
        public bool CheckFormulaByOperator(string formula)
        {
            string operandString = String.Empty;
            int numberOperator = 0;
            int numberOperand = 0;
            for (int i = 0; i < formula.Length; i++)
            {

                if (IsOperator(formula[i].ToString()))
                {
                    int j = i - 1;
                    if (formula[i].ToString() == Minus)
                    {
                        if (i > 0)
                        {
                            if (!IsOperator(formula[j].ToString()) && formula[j].ToString() != LeftBracket)
                                numberOperator++;
                        }
                    }
                    else
                    {
                        numberOperator++;
                    }
                }
                else
                {
                    if (IsOperand(formula[i].ToString()))
                    {
                        int j = i;
                        operandString = String.Empty;
                        while (j < formula.Length)
                        {
                            if (IsOperator(formula[j].ToString()) || IsBracket(formula[j].ToString()))
                                break;
                            operandString += formula[j];
                            j++;
                        }
                        if (j == formula.Length - 1 && IsOperand(formula[j].ToString()))
                            i = j;
                        else
                            i = j - 1;
                        if (IsOperand(operandString))
                        {
                            numberOperand++;
                        }
                    }
                }

            }
            if (numberOperand - 1 == numberOperator)
                return true;
            else
                return false;
        }
        #endregion
    }
}
