using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes
{
    /// <summary>
    /// TreeNode 中的數字節點
    /// </summary>
    public class NumberNode : TreeNode
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">number value</param>
        public NumberNode(string value) : base(value)
        {
        }

        /// <summary>
        /// 數字節點的 evaluate 邏輯
        /// </summary>
        /// <returns>return 此節點的 value</returns>
        public override double Evaluate()
        {
            return double.Parse(Value);
        }

        /// <summary>
        /// 數字節點放到 tree 上的邏輯
        /// </summary>
        /// <param name="stack">tree stack</param>
        public override void ToTree(Stack<TreeNode> stack)
        {
            stack.Push(this);
        }
    }
}
