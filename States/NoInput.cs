using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes;
using CalculatorWebAPI.TreeNodes.OperatorNodes;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 使用者沒輸入 (append) 任何數字時的狀態
    /// </summary>
    public class NoInput : IState
    {
        /// <summary>
        /// 切換上個運算子
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressAdd(CalculatorProperties calculatorObject)
        {
            // pop operator stack and push new opeator into it
            calculatorObject.OperatorStack.TryPop(out OperatorNode topNode);
            calculatorObject.OperatorStack.Push(new PlusNode(Signs.ADD_SIGN));

            // update process string
            UpdateProcessString(calculatorObject, Signs.ADD_SIGN);
        }

        /// <summary>
        /// 切換上個運算子
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMinus(CalculatorProperties calculatorObject)
        {
            // pop operator stack and push new opeator into it
            calculatorObject.OperatorStack.TryPop(out OperatorNode topNode);
            calculatorObject.OperatorStack.Push(new MinusNode(Signs.MINUS_SIGN));

            // update process string
            UpdateProcessString(calculatorObject, Signs.MINUS_SIGN);
        }

        /// <summary>
        /// 切換上個運算子
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMultiply(CalculatorProperties calculatorObject)
        {
            // pop operator stack and push new opeator into it
            calculatorObject.OperatorStack.TryPop(out OperatorNode topNode);
            calculatorObject.OperatorStack.Push(new MultiplyNode(Signs.MULTIPLY_SIGN));

            // update process string
            UpdateProcessString(calculatorObject, Signs.MULTIPLY_SIGN);
        }

        /// <summary>
        /// 切換上個運算子
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDivide(CalculatorProperties calculatorObject)
        {
            // pop operator stack and push new opeator into it
            calculatorObject.OperatorStack.TryPop(out OperatorNode topNode);
            calculatorObject.OperatorStack.Push(new DivideNode(Signs.DIVIDE_SIGN));

            // update process string
            UpdateProcessString(calculatorObject, Signs.DIVIDE_SIGN);
        }

        /// <summary>
        /// 使用者按下數字，因此要 change to Appending State
        /// </summary>
        /// <param name="pressedNumber">使用者按下的數字</param>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressNumber(string pressedNumber, CalculatorProperties calculatorObject)
        {
            calculatorObject.CurrentValue = double.Parse(pressedNumber);
            calculatorObject.CurrentString = pressedNumber;

            // change state to appending
            calculatorObject.CalculatorState = calculatorObject.Appending;
        }

        /// <summary>
        /// 切換運算子後要對 process string 做更新
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        /// <param name="sign">切換後的運算子符號</param>
        private void UpdateProcessString(CalculatorProperties calculatorObject, string sign)
        {
            // update process string
            string processString = calculatorObject.ProcessString;
            processString = processString.Substring(0, Math.Max(0, processString.Length - 1));
            calculatorObject.ProcessString = $"{processString}{sign}";
        }

        /// <summary>
        /// 按下 (，會直接 push onto operator stack 並更新 process string
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressLeftParenthesis(CalculatorProperties calculatorObject)
        {
            // directly push to operator stack
            calculatorObject.OperatorStack.Push(new LeftParenthesis(Signs.LEFT_PARENTHESIS));

            // update process string
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{Signs.LEFT_PARENTHESIS}";

            // change to waiting number
            calculatorObject.CalculatorState = calculatorObject.WaitingNumber;
        }

        /// <summary>
        /// 在 no input 時不應該可以按 )，因此此函數不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRightParenthesis(CalculatorProperties calculatorObject)
        {
        }

        /// <summary>
        /// 在 no input 狀態下按下 =，代表最後一個運算子沒有意義，會 pop 掉
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressEqualPreprocess(CalculatorProperties calculatorObject)
        {
            // try to pop the very last operator
            calculatorObject.OperatorStack.TryPop(out OperatorNode topNode);

            // update process string
            UpdateProcessString(calculatorObject, Signs.EQUAL_SIGN);
        }

        /// <summary>
        /// 在 no input 時按下小數點，會直接讓 current string 變 "0."
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDot(CalculatorProperties calculatorObject)
        {
            // make current string become "0."
            calculatorObject.CurrentString = $"{Signs.ZERO}{Signs.DOT_SIGN}";

            // change state to appending
            calculatorObject.CalculatorState = calculatorObject.Appending;
        }

        /// <summary>
        /// 在 no input 時按下 clear entry 不會改動任何屬性
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressClearEntry(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在 no input 時按下 back 不會改動任何屬性
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressBack(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在 no input 時按下正負號不會改動任何屬性
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressPositiveOrNegative(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在 no input 時按下開根號不會改動任何屬性
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRoot(CalculatorProperties calculatorObject)
        {
            // do nothing
        }
    }
}
