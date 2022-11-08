using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes.OperatorNodes
{
    /// <summary>
    /// 運算子權重的常數類別
    /// </summary>
    public static class Weights
    {
        /// <summary>
        /// 加號的權重
        /// </summary>
        public const int PLUS = 1;

        /// <summary>
        /// 減號的權重
        /// </summary>
        public const int MINUS = 2;

        /// <summary>
        /// 乘號的權重
        /// </summary>
        public const int MULTIPLY = 3;

        /// <summary>
        /// 除號的權重
        /// </summary>
        public const int DIVIDE = 3;

        /// <summary>
        /// 左括號的權重
        /// </summary>
        public const int LEFT_PARENTHESIS = 0;
    }
}
