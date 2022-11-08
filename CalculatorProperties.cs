using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorWebAPI.TreeNodes;

namespace CalculatorWebAPI
{
    /// <summary>
    /// 計算機會擁有的所有屬性
    /// </summary>
    public class CalculatorProperties
    {
        /// <summary>
        /// 結果 Box 應該輸出的字串
        /// </summary>
        public string ProcessString { get; set; }

        /// <summary>
        /// 當 append CurrentString 時，會確保 string 數值的合法性並將合法的 double 存入此屬性
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// 使用者持續輸入的字串
        /// </summary>
        public string CurrentString { get; set; }

        /// <summary>
        /// 實作 Shunting Yard Algorithm 所需使用的 operator stack
        /// </summary>
        public Stack<OperatorNode> OperatorStack { get; set; }

        /// <summary>
        /// 目前計算機的狀態
        /// </summary>
        public IState CalculatorState { get; set; }

        /// <summary>
        /// Appending 狀態的 instance
        /// </summary>
        public IState Appending { get; set; }

        /// <summary>
        /// Noinput 狀態的 instance
        /// </summary>
        public IState NoInput { get; set; }

        /// <summary>
        /// NegativeAppending 狀態的 instance
        /// </summary>
        public IState NegativeAppending { get; set; }

        /// <summary>
        /// WaitingOperator 狀態的 instance
        /// </summary>
        public IState WaitingOperator { get; set; }

        /// <summary>
        /// WaitingNumber 狀態的 instance
        /// </summary>
        public IState WaitingNumber { get; set; }

        /// <summary>
        /// Initial 狀態的 instance
        /// </summary>
        public IState Initial { get; set; }

        /// <summary>
        /// 實作 Shunting Yard Algorithm 所需使用的 queue
        /// </summary>
        public Queue<TreeNode> PostfixQueue { get; set; }

        /// <summary>
        /// 展示前序的字串
        /// </summary>
        public string PreorderString { get; set; }

        /// <summary>
        /// 展示中序的字串
        /// </summary>
        public string InorderString { get; set; }

        /// <summary>
        /// 展示後序的字串
        /// </summary>
        public string PostorderString { get; set; }

        /// <summary>
        /// 與前端來回溝通所使用的 dictionary
        /// </summary>
        public Dictionary<string, string> ResponseDictionary { get; set; }

        /// <summary>
        /// constructor，將 properties 定義成 initial value
        /// </summary>
        public CalculatorProperties()
        {
            CalculatorState = new States.Initial();
            CurrentValue = Constants.ZERO_VALUE;
            CurrentString = Signs.ZERO;
            ProcessString = string.Empty;
            OperatorStack = new Stack<OperatorNode>();
            PostfixQueue = new Queue<TreeNode>();
            PreorderString = string.Empty;
            InorderString = string.Empty;
            PostorderString = string.Empty;
            Appending = new States.Appending();
            Initial = new States.Initial();
            NegativeAppending = new States.NegativeAppending();
            NoInput = new States.NoInput();
            WaitingOperator = new States.WaitingOperator();
            WaitingNumber = new States.WaitingNumber();
            ResponseDictionary = new Dictionary<string, string>
            {
                [Constants.PROCESS_STRING_KEY] = ProcessString,
                [Constants.CURRENT_STRING_KEY] = CurrentString,
                [Constants.PREORDER_STRING_KEY] = PreorderString,
                [Constants.INORDER_STRING_KEY] = InorderString,
                [Constants.POSTORDER_STRING_KEY] = PostorderString
            };
        }
    }
}
