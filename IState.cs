using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI
{
    /// <summary>
    /// 計算機各種 state 的父介面
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 使用者按下數字的動作
        /// </summary>
        /// <param name="pressedNumber">使用者按下的數字</param>
        /// <param name="calculatorObject">計算機的屬性</param>
        void PressNumber(string pressedNumber, CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下加號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressAdd(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下減號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressMinus(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下乘號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressMultiply(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下除號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressDivide(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 ( 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressLeftParenthesis(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 ) 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressRightParenthesis(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 = 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressEqualPreprocess(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 . 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressDot(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 CE 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressClearEntry(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下 back 的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressBack(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下正負號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressPositiveOrNegative(CalculatorProperties calculatorObject);

        /// <summary>
        /// 按下開根號的動作
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        void PressRoot(CalculatorProperties calculatorObject);
    }
}
