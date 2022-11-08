using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.States
{
    /// <summary>
    /// 使用者在 append 的字串目前是負數時的狀態
    /// </summary>
    public class NegativeAppending : Appending
    {
        /// <summary>
        /// 當在負數狀態下按下正負號，會 change state back to Appending
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public override void PressPositiveOrNegative(CalculatorProperties calculatorObject)
        {
            // change state to appending and execute function
            calculatorObject.CalculatorState = calculatorObject.Appending;
            calculatorObject.CalculatorState.PressPositiveOrNegative(calculatorObject);
        }

        /// <summary>
        /// 負數情況下不能開根號，因此 do nothing
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        public override void PressRoot(CalculatorProperties calculatorObject)
        {
            // do nothing
        }
    }
}
