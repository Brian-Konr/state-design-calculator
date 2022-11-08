using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CalculatorWebAPI.TreeNodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CalculatorWebAPI.Controllers
{
    /// <summary>
    /// controller class
    /// </summary>
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        /// <summary>
        /// 當有新用戶 (計算機) 開啟時會 call 此函數向後端註冊一個新計算機，後端會新增一筆紀錄並回傳對應的 calculator id
        /// </summary>
        /// <returns>新用戶的 calculator id</returns>
        // POST api/<controller>
        [HttpPost] 
        [Route("create")]
        public string CreateNewCalculator()
        {
            Console.WriteLine("init client!");
            CalculatorProperties newProperty = new CalculatorProperties();

            string randomID = Guid.NewGuid().ToString();
            if (!CalculatorDictionary.Database.TryAdd(randomID, newProperty))
            {
                Console.WriteLine("failed to init a new client");
            }
            return randomID;
        }

        /// <summary>
        /// 當使用者按下數字時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <param name="value">按下的數字</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressNumber/{value}")]
        public Dictionary<string, string> PressNumber(string id, string value)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressNumber(value, calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下加時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressAdd")]
        public Dictionary<string, string> PressAdd(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressAdd(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下減時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressMinus")]
        public Dictionary<string, string> PressMinus(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressMinus(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下乘時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressMultiply")]
        public Dictionary<string, string> PressMultiply(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressMultiply(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下除時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressDivide")]
        public Dictionary<string, string> PressDivide(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressDivide(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下左括號時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressLeftParenthesis")]
        public Dictionary<string, string> PressLeftParenthesis(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressLeftParenthesis(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下右括號時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressRightParenthesis")]
        public Dictionary<string, string> PressRightParenthesis(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressRightParenthesis(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下小數點時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressDot")]
        public Dictionary<string, string> PressDot(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressDot(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下倒退鍵時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressBack")]
        public Dictionary<string, string> PressBack(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressBack(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下正負號時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressPositiveOrNegative")]
        public Dictionary<string, string> PressPositiveOrNegative(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressPositiveOrNegative(calculatorObject);

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下清空計算機時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressClear")]
        public Dictionary<string, string> PressClear(string id)
        {
            // clear all and change state to no input
            CalculatorProperties newProperty = new CalculatorProperties();
            CalculatorDictionary.Database[id] = newProperty;
            return GenerateResponse(CalculatorDictionary.Database[id]);
        }

        /// <summary>
        /// 當使用者按下開根號時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressRoot")]
        public Dictionary<string, string> PressRoot(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressRoot(calculatorObject);
            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者按下 CE 時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressClearEntry")]
        public Dictionary<string, string> PressClearEntry(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressClearEntry(calculatorObject);
            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當執行完動作後，更新 Response Dictionary 的函數
        /// </summary>
        /// <param name="calculatorObject">計算機屬性</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        private Dictionary<string, string> GenerateResponse(CalculatorProperties calculatorObject)
        {
            calculatorObject.ResponseDictionary[Constants.PROCESS_STRING_KEY] = calculatorObject.ProcessString;
            calculatorObject.ResponseDictionary[Constants.CURRENT_STRING_KEY] = calculatorObject.CurrentString;
            calculatorObject.ResponseDictionary[Constants.PREORDER_STRING_KEY] = calculatorObject.PreorderString;
            calculatorObject.ResponseDictionary[Constants.INORDER_STRING_KEY] = calculatorObject.InorderString;
            calculatorObject.ResponseDictionary[Constants.POSTORDER_STRING_KEY] = calculatorObject.PostorderString;
            return calculatorObject.ResponseDictionary;
        }

        /// <summary>
        /// 當使用者按下等於時所呼叫的 endpoint
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>計算機與前端溝通的 Response Dictionary</returns>
        [HttpPost]
        [Route("{id}/pressEqual")]
        public Dictionary<string, string> EqualsTo(string id)
        {
            CalculatorProperties calculatorObject = CalculatorDictionary.Database[id];
            calculatorObject.CalculatorState.PressEqualPreprocess(calculatorObject);

            int operatorStackCount = calculatorObject.OperatorStack.Count;

            for (int i = 0; i < operatorStackCount; i++)
            {
                // if operator stack still contains left parenthesis, there is missing pairs, thus data should be cleaned and immediately return
                OperatorNode topNode = calculatorObject.OperatorStack.Pop();
                if (topNode.Value == Signs.LEFT_PARENTHESIS)
                {
                    calculatorObject.CurrentString = $"{calculatorObject.ProcessString}: {Constants.MISSING_PAIR_WARNING}";
                    calculatorObject.ProcessString = string.Empty;
                    calculatorObject.CurrentValue = 0;
                    calculatorObject.OperatorStack.Clear();
                    calculatorObject.PostfixQueue.Clear();
                    return GenerateResponse(calculatorObject);
                }
                calculatorObject.PostfixQueue.Enqueue(topNode);
            }

            // turn postfix queue to tree and traverse
            Stack<TreeNode> stack = ConstructTree(calculatorObject.PostfixQueue);
            Traversal(stack, calculatorObject);

            // calculate computation result
            double answer = stack.Peek().Evaluate();

            // update current string and current value
            calculatorObject.CurrentString = answer.ToString();
            calculatorObject.CurrentValue = answer;

            // change state to appending for next operation
            calculatorObject.CalculatorState = calculatorObject.Appending;

            return GenerateResponse(calculatorObject);
        }

        /// <summary>
        /// 當使用者結束使用 (離開) 時所呼叫的 endpoint，後端會將此 id 的資料刪除並回傳成功訊息
        /// </summary>
        /// <param name="id">呼叫此 endpoint 的計算機 id</param>
        /// <returns>成功離開的 message</returns>
        [HttpPost]
        [Route("{id}/leave")]
        public string LeaveAndRelease(string id)
        {
            CalculatorDictionary.Database.TryRemove(id, out CalculatorProperties ignored);
            return "calculator properties deleted successfully!";
        }

        /// <summary>
        /// 將傳入的 postfix queue 轉成 Tree 的過程，最後會回傳轉換完成的 stack
        /// </summary>
        /// <param name="postfixQueue">要轉成 Tree 的 postfix queue</param>
        /// <returns>轉換完成的 stack</returns>
        private Stack<TreeNode> ConstructTree(Queue<TreeNode> postfixQueue)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            int queueCount = postfixQueue.Count;
            for (int i = 0; i < queueCount; i++)
            {
                TreeNode node = postfixQueue.Dequeue();
                node.ToTree(stack);
            }

            return stack;
        }

        /// <summary>
        /// 針對 Tree 進行 preorder traversal，並更新計算機屬性中 preorderString 的內容
        /// </summary>
        /// <param name="root">要 traverse 的 Tree 的根節點</param>
        /// <param name="result">要更新的計算機屬性</param>
        private void Preorder(TreeNode root, CalculatorProperties result)
        {
            if (root == null)
            {
                return;
            }

            result.PreorderString = $"{result.PreorderString}{root.Value}";
            Preorder(root.LeftChild, result);
            Preorder(root.RightChild, result);
        }

        /// <summary>
        /// 針對 Tree 進行 inorder traversal，並更新計算機屬性中 inorderString 的內容
        /// </summary>
        /// <param name="root">要 traverse 的 Tree 的根節點</param>
        /// <param name="result">要更新的計算機屬性</param>
        private void Inorder(TreeNode root, CalculatorProperties result)
        {
            if (root == null)
            {
                return;
            }

            Inorder(root.LeftChild, result);
            result.InorderString = $"{result.InorderString}{root.Value}";
            Inorder(root.RightChild, result);
        }

        /// <summary>
        /// 針對 Tree 進行 postorder traversal，並更新計算機屬性中 postorderString 的內容
        /// </summary>
        /// <param name="root">要 traverse 的 Tree 的根節點</param>
        /// <param name="result">要更新的計算機屬性</param>
        private void Postorder(TreeNode root, CalculatorProperties result)
        {
            if (root == null)
            {
                return;
            }

            Postorder(root.LeftChild, result);
            Postorder(root.RightChild, result);
            result.PostorderString = $"{result.PostorderString}{root.Value}";
        }

        /// <summary>
        /// 執行三種 Traverse 方式的進入點，會在裡面呼叫 pre, in, post 的 traverse 方式並更新傳入的計算機屬性
        /// </summary>
        /// <param name="stack">轉換成 tree 的 stack</param>
        /// <param name="calculatorObject">要更新的計算機屬性</param>
        private void Traversal(Stack<TreeNode> stack, CalculatorProperties calculatorObject)
        {
            // first clean the pre, in, post order string
            calculatorObject.PreorderString = string.Empty;
            calculatorObject.InorderString = string.Empty;
            calculatorObject.PostorderString = string.Empty;

            // pick the root node
            stack.TryPeek(out TreeNode rootNode);

            Preorder(rootNode, calculatorObject);
            Inorder(rootNode, calculatorObject);
            Postorder(rootNode, calculatorObject);
        }
    }
}
