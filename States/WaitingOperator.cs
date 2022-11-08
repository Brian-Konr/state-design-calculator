using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes;
using CalculatorWebAPI.TreeNodes.OperatorNodes;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 當按下 ) 時，就會進入等待 opeator 的狀態
    /// </summary>
    public class WaitingOperator : IState
    {
        /// <summary>
        /// 按下 Add 要對 operator stack, postfix queue 做更動
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressAdd(CalculatorProperties calculatorObject)
        {
            // pop all operators with higher precedence first
            PreprocessForPlusAndMinus(calculatorObject);

            // push add operator to stack
            calculatorObject.OperatorStack.Push(new PlusNode(Signs.ADD_SIGN));

            // postprocess
            PostprocessForAll(calculatorObject, Signs.ADD_SIGN);
        }

        /// <summary>
        /// 按下除號要對 operator stack, postfix queue 做更動
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDivide(CalculatorProperties calculatorObject)
        {
            // push add operator to stack
            calculatorObject.OperatorStack.Push(new DivideNode(Signs.DIVIDE_SIGN));

            // postprocess
            PostprocessForAll(calculatorObject, Signs.DIVIDE_SIGN);
        }

        /// <summary>
        /// 在等待運算子狀態下，按 ( 不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressLeftParenthesis(CalculatorProperties calculatorObject)
        {
        }

        /// <summary>
        /// 按下減號要對 operator stack, postfix queue 做更動
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMinus(CalculatorProperties calculatorObject)
        {
            // preprocess for minus operator
            PreprocessForPlusAndMinus(calculatorObject);

            // push minus operator to stack
            calculatorObject.OperatorStack.Push(new MinusNode(Signs.MINUS_SIGN));
        }

        /// <summary>
        /// 按下乘號要對 operator stack, postfix queue 做更動
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMultiply(CalculatorProperties calculatorObject)
        {
            // push add operator to stack
            calculatorObject.OperatorStack.Push(new MultiplyNode(Signs.MULTIPLY_SIGN));

            // postprocess
            PostprocessForAll(calculatorObject, Signs.MULTIPLY_SIGN);
        }

        /// <summary>
        /// 在等待運算子狀態下，按數字不會有任何動作
        /// </summary>
        /// <param name="pressedNumber">使用者按下的數字</param>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressNumber(string pressedNumber, CalculatorProperties calculatorObject)
        {
        }

        /// <summary>
        /// 在等待運算子狀態下，會接受 )，因為可能是處理更前面的 (，此時的動作會跟 appending 時按下 ) 一樣，因此會 new 一個 appending state 並執行動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRightParenthesis(CalculatorProperties calculatorObject)
        {
            // same action when in the appending state, thus for preventing duplicate codes, we first change state to appending and execute press right parenthesis again
            IState appendingState = new Appending();
            appendingState.PressRightParenthesis(calculatorObject);
        }

        /// <summary>
        /// 當運算子是加或減時，需要 run Shunting Yard Algorithm，因此會使用到 if-else
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        private void PreprocessForPlusAndMinus(CalculatorProperties calculatorObject)
        {
            // if stack contains other nodes, we need to check first
            if (calculatorObject.OperatorStack.Count > 0)
            {
                // clear all higher precedence node to queue
                while (calculatorObject.OperatorStack.TryPeek(out OperatorNode topNode) && topNode.Weight > Weights.PLUS)
                {
                    calculatorObject.OperatorStack.Pop();
                    calculatorObject.PostfixQueue.Enqueue(topNode);
                }
            }
        }

        /// <summary>
        /// 實作按下運算子後對 process string 的更動邏輯，並會將 state change to No Input
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        /// <param name="sign">符號</param>
        private void PostprocessForAll(CalculatorProperties calculatorObject, string sign)
        {
            // update process string
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{sign}";

            // change state to no input
            calculatorObject.CalculatorState = calculatorObject.NoInput;
        }

        /// <summary>
        /// 因為目前算式的結尾是 )，因此不需要新增加任何東西到 stack or queue。但需要更新 Process string
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressEqualPreprocess(CalculatorProperties calculatorObject)
        {
            // do nothing about operator stack or postfix queue because ) can be an end of an expression

            // update process string
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{Signs.EQUAL_SIGN}";
        }

        /// <summary>
        /// 在等待運算子狀態下，按 . 不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDot(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在等待運算子狀態下，按 Clear Entry 不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressClearEntry(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在等待運算子狀態下，按 back 不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressBack(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在等待運算子狀態下，按正負號不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressPositiveOrNegative(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在等待運算子狀態下，按開根號不會發生任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRoot(CalculatorProperties calculatorObject)
        {
            // do nothing
        }
    }
}
