using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI
{
    /// <summary>
    /// 所有會較常使用的常數
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// 當 value 需要重複地被設為 0 時，可以使用此 const 做 assign，就不需要 new 一個新的數值
        /// </summary>
        public const double ZERO_VALUE = 0;

        /// <summary>
        /// one of the keys for returned dictionary from backend
        /// </summary>
        public const string PROCESS_STRING_KEY = "processString";

        /// <summary>
        /// one of the keys for returned dictionary from backend
        /// </summary>
        public const string CURRENT_STRING_KEY = "currentString";

        /// <summary>
        /// one of the keys for returned dictionary from backend
        /// </summary>
        public const string PREORDER_STRING_KEY = "preorderString";

        /// <summary>
        /// one of the keys for returned dictionary from backend
        /// </summary>
        public const string INORDER_STRING_KEY = "inorderString";

        /// <summary>
        /// one of the keys for returned dictionary from backend
        /// </summary>
        public const string POSTORDER_STRING_KEY = "postorderString";

        /// <summary>
        /// 當發生 missing pairs 問題時所跳出的警告字串
        /// </summary>
        public const string MISSING_PAIR_WARNING = "Missing Pairs!!!";
    }
}
