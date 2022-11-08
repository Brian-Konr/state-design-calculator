using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 加號節點
    /// </summary>
    public class PlusNode : OperatorNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">加號</param>
        public PlusNode(string value) : base(value, Weights.PLUS)
        {
        }

        /// <summary>
        /// 實作加號邏輯
        /// </summary>
        /// <param name="firstValue">first number</param>
        /// <param name="secondValue">second number</param>
        /// <returns>first number + second number</returns>
        public override double Calculate(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }
    }
}
