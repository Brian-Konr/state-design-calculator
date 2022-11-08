using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 乘號節點
    /// </summary>
    public class MultiplyNode : OperatorNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">乘號</param>
        public MultiplyNode(string value) : base(value, Weights.MULTIPLY)
        {
        }

        /// <summary>
        /// 實作乘號邏輯
        /// </summary>
        /// <param name="firstValue">first number</param>
        /// <param name="secondValue">second number</param>
        /// <returns>first number * second number</returns>
        public override double Calculate(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }
    }
}
