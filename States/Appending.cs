using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes;
using CalculatorWebAPI.TreeNodes.OperatorNodes;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 使用者在 append 目前字串時的狀態
    /// </summary>
    public class Appending : IState
    {
        /// <summary>
        /// 更新計算機屬性並將 state 變成 No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressAdd(CalculatorProperties calculatorObject)
        {
            PreprocessForPlusAndMinus(calculatorObject);
            calculatorObject.OperatorStack.Push(new PlusNode(Signs.ADD_SIGN));
            PostprocessForAll(calculatorObject, Signs.ADD_SIGN);
        }

        /// <summary>
        /// 更新計算機屬性並將 state 變成 No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMinus(CalculatorProperties calculatorObject)
        {
            PreprocessForPlusAndMinus(calculatorObject);
            calculatorObject.OperatorStack.Push(new MinusNode(Signs.MINUS_SIGN));
            PostprocessForAll(calculatorObject, Signs.MINUS_SIGN);
        }

        /// <summary>
        /// 更新計算機的 CurrentString 及 CurrentValue
        /// </summary>
        /// <param name="pressedNumber">此次要 append 的數字</param>
        /// <param name="calculatorObject">計算機屬性</param>
        public virtual void PressNumber(string pressedNumber, CalculatorProperties calculatorObject)
        {
            // 先 parse 讓 CurrentString 是合法的字串
            double.TryParse($"{calculatorObject.CurrentString}{pressedNumber}", out double appendValue);

            calculatorObject.CurrentValue = appendValue;

            // 將處理完的 value 更新成 CurrentString
            calculatorObject.CurrentString = $"{calculatorObject.CurrentValue}";
        }

        /// <summary>
        /// 當按加或減時，要根據 ShuntingYard Algorithm 做預處理。因為要 run 演算法，因此有使用 if-else 做判斷
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        private void PreprocessForPlusAndMinus(CalculatorProperties calculatorObject)
        {
            // push current value to queue
            calculatorObject.PostfixQueue.Enqueue(new NumberNode(calculatorObject.CurrentValue.ToString()));

            // clear all higher precedence node to queue
            while (calculatorObject.OperatorStack.TryPeek(out OperatorNode topNode) && topNode.Weight > Weights.PLUS)
            {
                calculatorObject.OperatorStack.Pop();
                calculatorObject.PostfixQueue.Enqueue(topNode);
            }
        }

        /// <summary>
        /// 更新計算機屬性並將 state 變成 No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMultiply(CalculatorProperties calculatorObject)
        {
            // push current value to queue
            calculatorObject.PostfixQueue.Enqueue(new NumberNode(calculatorObject.CurrentValue.ToString()));

            // push multiply button onto stack
            calculatorObject.OperatorStack.Push(new MultiplyNode(Signs.MULTIPLY_SIGN));

            // update string
            PostprocessForAll(calculatorObject, Signs.MULTIPLY_SIGN);
        }

        /// <summary>
        /// 更新計算機屬性並將 state 變成 No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDivide(CalculatorProperties calculatorObject)
        {
            // push current value to queue
            calculatorObject.PostfixQueue.Enqueue(new NumberNode(calculatorObject.CurrentValue.ToString()));

            // push multiply button onto stack
            calculatorObject.OperatorStack.Push(new DivideNode(Signs.DIVIDE_SIGN));

            // update string
            PostprocessForAll(calculatorObject, Signs.DIVIDE_SIGN);
        }

        /// <summary>
        /// 在 append state 時不應該讓使用者按 (，因此此函數不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public virtual void PressLeftParenthesis(CalculatorProperties calculatorObject)
        {
        }

        /// <summary>
        /// 當按下 ) 時，要根據 ShuntingYard Algorithm 更新 stack 及 queue。因為要 run 演算法，因此有使用 if-else 做判斷
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRightParenthesis(CalculatorProperties calculatorObject)
        {
            // push value to queue
            calculatorObject.PostfixQueue.Enqueue(new NumberNode(calculatorObject.CurrentValue.ToString()));

            // pop all operators and push to queue until we meet left parenthesis
            if (calculatorObject.OperatorStack.Count > 0)
            {
                while (calculatorObject.OperatorStack.TryPeek(out OperatorNode topNode) && topNode.Value != Signs.LEFT_PARENTHESIS)
                {
                    calculatorObject.OperatorStack.Pop();
                    calculatorObject.PostfixQueue.Enqueue(topNode);
                }
            }

            // pop left parenthesis
            if (!calculatorObject.OperatorStack.TryPop(out OperatorNode operatorNode))
            {
                // it means there is missing parenthesis pairs, we have to warn the situation
                calculatorObject.CurrentString = $"{calculatorObject.ProcessString}{Signs.RIGHT_PARENTHESIS}: {Constants.MISSING_PAIR_WARNING}";
                calculatorObject.ProcessString = string.Empty;
                calculatorObject.CurrentValue = 0;

                calculatorObject.OperatorStack.Clear();
                calculatorObject.PostfixQueue.Clear();

                // then change state to appending
                calculatorObject.CalculatorState = calculatorObject.Appending;
            }
            else
            {
                // update process string, clear current string and clear current value
                PostprocessForAll(calculatorObject, Signs.RIGHT_PARENTHESIS);

                // change state to waiting operator
                calculatorObject.CalculatorState = calculatorObject.WaitingOperator;
            }
        }

        /// <summary>
        /// 針對運算子，按下後會有共同的後處理要進行，會將這些動作包在此函數中
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        /// <param name="sign">此次運算子的符號</param>
        private void PostprocessForAll(CalculatorProperties calculatorObject, string sign)
        {
            // update process string
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{calculatorObject.CurrentValue}{sign}";

            // drop substring before the = sign
            string processString = calculatorObject.ProcessString;
            int equalIndex = processString.LastIndexOf(Signs.EQUAL_SIGN);
            calculatorObject.ProcessString = processString.Substring(equalIndex + 1);

            // clear current string and current value
            calculatorObject.CurrentString = Signs.ZERO;
            calculatorObject.CurrentValue = Constants.ZERO_VALUE;

            // change state from appending to no input
            calculatorObject.CalculatorState = calculatorObject.NoInput;
        }

        /// <summary>
        /// 當按下 = 時，要先將目前的 value push 到 queue
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressEqualPreprocess(CalculatorProperties calculatorObject)
        {
            // push current value to queue
            calculatorObject.PostfixQueue.Enqueue(new NumberNode(calculatorObject.CurrentValue.ToString()));

            // update process string
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{calculatorObject.CurrentValue}{Signs.EQUAL_SIGN}";
        }

        /// <summary>
        /// 按下小數點的數值更新
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDot(CalculatorProperties calculatorObject)
        {
            string currentString = $"{calculatorObject.CurrentString}{Signs.DOT_SIGN}";
            
            // after split values[0] will be integer part, and values[1] will be decimal part
            string[] values = currentString.Split(Signs.DOT_SIGN, StringSplitOptions.None);

            calculatorObject.CurrentString = $"{values[0]}{Signs.DOT_SIGN}{values[1]}";
            calculatorObject.CurrentValue = double.Parse(calculatorObject.CurrentString);
        }

        /// <summary>
        /// 將目前的 current string 變成 empty，並且將 state 變成 No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressClearEntry(CalculatorProperties calculatorObject)
        {
            // clear current string and change to no input state
            calculatorObject.CurrentString = Signs.ZERO;
            calculatorObject.CurrentValue = Constants.ZERO_VALUE;

            // change to no input
            calculatorObject.CalculatorState = calculatorObject.NoInput;
        }

        /// <summary>
        /// 更新 current string 及 current value
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressBack(CalculatorProperties calculatorObject)
        {
            string currentString = calculatorObject.CurrentString;

            // try remove last char
            currentString = currentString.Substring(0, Math.Max(0, currentString.Length - 1));

            // there may be a condition where current string become empty string
            double.TryParse(currentString, out double validValue);
            calculatorObject.CurrentValue = validValue;
            calculatorObject.CurrentString = validValue.ToString();
        }

        /// <summary>
        /// 按下正負號會 change state to NegativeAppending
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public virtual void PressPositiveOrNegative(CalculatorProperties calculatorObject)
        {
            calculatorObject.CurrentValue *= -1;
            calculatorObject.CurrentString = calculatorObject.CurrentValue.ToString();

            // go to negative state
            calculatorObject.CalculatorState = calculatorObject.NegativeAppending;
        }

        /// <summary>
        /// 對 current value 開根號並更新屬性
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public virtual void PressRoot(CalculatorProperties calculatorObject)
        {
            calculatorObject.CurrentValue = Math.Sqrt(calculatorObject.CurrentValue);
            calculatorObject.CurrentString = calculatorObject.CurrentValue.ToString();
        }
    }
}
