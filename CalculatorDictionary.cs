using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace CalculatorWebAPI
{
    /// <summary>
    /// 存放不同使用者計算機屬性的字典 class
    /// </summary>
    public static class CalculatorDictionary
    {
        /// <summary>
        /// 存放不同使用者計算機屬性的 concurrent dictionary
        /// </summary>
        public static ConcurrentDictionary<string, CalculatorProperties> Database { get; set; }
    }
}
