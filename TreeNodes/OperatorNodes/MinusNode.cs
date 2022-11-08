using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 減號節點
    /// </summary>
    public class MinusNode : OperatorNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">減號</param>
        public MinusNode(string value) : base(value, Weights.MINUS)
        {
        }

        /// <summary>
        /// 實作減號邏輯
        /// </summary>
        /// <param name="firstValue">first number</param>
        /// <param name="secondValue">second number</param>
        /// <returns>first number - second number</returns>
        public override double Calculate(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }
    }
}
