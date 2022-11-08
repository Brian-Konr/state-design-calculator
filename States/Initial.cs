using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes.OperatorNodes;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 定義 Initial State 各 Action 的邏輯
    /// </summary>
    public class Initial : Appending
    {
        /// <summary>
        /// 在此狀態下按下數字會更新屬性並將 state 轉成 appending
        /// </summary>
        /// <param name="pressedNumber">使用者按下的數字</param>
        /// <param name="calculatorObject">計算機屬性</param>
        public override void PressNumber(string pressedNumber, CalculatorProperties calculatorObject)
        {
            base.PressNumber(pressedNumber, calculatorObject);
            calculatorObject.CalculatorState = calculatorObject.Appending;
        }

        /// <summary>
        /// 在此狀態下按左括號會直接將 ( 推到 operator stack 並更新 process string，並更新狀態成 waiting number
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public override void PressLeftParenthesis(CalculatorProperties calculatorObject)
        {
            calculatorObject.OperatorStack.Push(new LeftParenthesis(Signs.LEFT_PARENTHESIS));
            calculatorObject.ProcessString = $"{calculatorObject.ProcessString}{Signs.LEFT_PARENTHESIS}";
            calculatorObject.CalculatorState = calculatorObject.WaitingNumber;
        }
    }
}
