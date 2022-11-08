using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes.OperatorNodes;
using CalculatorWebAPI.TreeNodes;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 定義按下 ( 後等待數字或 ( 的邏輯
    /// </summary>
    public class WaitingNumber : IState
    {
        /// <summary>
        /// 在此狀態下按下加不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressAdd(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下 Back 不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressBack(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下 CE 不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressClearEntry(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下除不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressDivide(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下點視為使用者輸入數字，會更新數值並將 state 轉到 Appending
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
        /// 在此狀態下按下等於要把剛放進去的 ( pop 掉
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressEqualPreprocess(CalculatorProperties calculatorObject)
        {
            calculatorObject.OperatorStack.Pop();

            // update process string
            calculatorObject.ProcessString = calculatorObject.ProcessString.Remove(calculatorObject.ProcessString.Length - 1);
        }

        /// <summary>
        /// 在此狀態下按下 ( 就繼續讓他正常輸入
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressLeftParenthesis(CalculatorProperties calculatorObject)
        {
            calculatorObject.OperatorStack.Push(new LeftParenthesis(Signs.LEFT_PARENTHESIS));
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{Signs.LEFT_PARENTHESIS}";
        }

        /// <summary>
        /// 在此狀態下按下減不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMinus(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下乘不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressMultiply(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下數字即切換到 appending state
        /// </summary>
        /// <param name="pressedNumber">使用者按下的數字</param>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressNumber(string pressedNumber, CalculatorProperties calculatorObject)
        {
            calculatorObject.NoInput.PressNumber(pressedNumber, calculatorObject);
        }

        /// <summary>
        /// 在此狀態下按正負號不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressPositiveOrNegative(CalculatorProperties calculatorObject)
        {
            // do nothing
        }

        /// <summary>
        /// 在此狀態下按下 ) 就直接把剛輸入的 ( 抵銷掉
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRightParenthesis(CalculatorProperties calculatorObject)
        {
            // 把剛放進去的 ( pop 掉
            calculatorObject.OperatorStack.Pop();

            // update process string
            calculatorObject.ProcessString = calculatorObject.ProcessString.Remove(calculatorObject.ProcessString.Length - 1);
        }

        /// <summary>
        /// 在此狀態下按下開根號不做任何事
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public void PressRoot(CalculatorProperties calculatorObject)
        {
            // do nothing
        }
    }
}
