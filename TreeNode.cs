using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI
{
    /// <summary>
    /// Tree structure 中的節點 class
    /// </summary>
    public abstract class TreeNode
    {
        /// <summary>
        /// Node 的值
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Node 的 left child
        /// </summary>
        public TreeNode LeftChild { get; set; }

        /// <summary>
        /// Node 的 right child
        /// </summary>
        public TreeNode RightChild { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">node value</param>
        public TreeNode(string value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }

        /// <summary>
        /// Evaluate function for nodes
        /// </summary>
        /// <returns>return evaluated value</returns>
        public abstract double Evaluate();

        /// <summary>
        /// tree node 變成 tree 的過程
        /// </summary>
        /// <param name="stack">tree stack</param>
        public abstract void ToTree(Stack<TreeNode> stack);
    }
}
