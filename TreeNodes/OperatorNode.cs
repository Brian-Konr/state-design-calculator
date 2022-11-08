using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorWebAPI.TreeNodes
{
    /// <summary>
    /// Tree structure 中的運算子節點父類別
    /// </summary>
    public abstract class OperatorNode : TreeNode
    {
        /// <summary>
        /// 存放每個運算子的權重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Constructor for Operator Node
        /// </summary>
        /// <param name="value">運算子符號</param>
        /// <param name="weight">運算子權重</param>
        public OperatorNode(string value, int weight) : base(value)
        {
            Weight = weight;
        }

        /// <summary>
        /// 運算子 node 在 run Evaluate 時的邏輯，會先得到 childs 的 value 再透過自己的 Calculate 做運算回傳
        /// </summary>
        /// <returns></returns>
        public override double Evaluate()
        {
            double leftValue = LeftChild.Evaluate();
            double rightValue = RightChild.Evaluate();

            return Calculate(leftValue, rightValue);
        }

        /// <summary>
        /// 運算子都需要有的 Calculate 方式
        /// </summary>
        /// <param name="firstValue">left child value</param>
        /// <param name="secondValue">right child value</param>
        /// <returns></returns>
        public abstract double Calculate(double firstValue, double secondValue);

        /// <summary>
        /// 運算子在建構成樹的邏輯，使用的是 GeeksforGeeks 對於 Postfix to Expression Tree 的演算法教學
        /// </summary>
        /// <param name="stack">演算法使用的 stack</param>
        public override void ToTree(Stack<TreeNode> stack)
        {
            // operator node will first pop two nodes from stack, make them become its child, and then push back to stack
            stack.TryPop(out TreeNode rightChild);
            stack.TryPop(out TreeNode leftChild);

            LeftChild = leftChild;
            RightChild = rightChild;

            stack.Push(this);
        }
    }
}
