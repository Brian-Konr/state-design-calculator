using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 除號節點
    /// </summary>
    public class DivideNode : OperatorNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">除號</param>
        public DivideNode(string value) : base(value, Weights.DIVIDE)
        {
        }

        /// <summary>
        /// 實作除號邏輯
        /// </summary>
        /// <param name="firstValue">first number</param>
        /// <param name="secondValue">second number</param>
        /// <returns>first number / second number</returns>
        public override double Calculate(double firstValue, double secondValue)
        {
            return firstValue / secondValue;
        }
    }
}
