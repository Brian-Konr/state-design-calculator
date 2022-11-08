using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 左括號
    /// </summary>
    public class LeftParenthesis : OperatorNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">左括號的符號</param>
        public LeftParenthesis(string value) : base(value, Weights.LEFT_PARENTHESIS)
        {
        }
        
        /// <summary>
        /// 無意義，回傳 0
        /// </summary>
        /// <param name="firstValue">first number</param>
        /// <param name="secondValue">second number</param>
        /// <returns>0</returns>
        public override double Calculate(double firstValue, double secondValue)
        {
            return 0;
        }
    }
}
