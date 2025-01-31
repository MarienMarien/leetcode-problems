public class Solution {
    public int EvalRPN(string[] tokens) {
        var operations = new Dictionary<string, Func<int, int, int>> { 
            { "+", (x, y) => x + y },
            { "-", (x, y) => x - y },
            { "*", (x, y) => x * y },
            { "/", (x, y) => x / y }
        };
        var midResultStack = new Stack<int>();
        foreach(var token in tokens)
        {
            if(!operations.ContainsKey(token))
            {
                var num = Int32.Parse(token);
                midResultStack.Push(num);
                continue;
            }
            var right = midResultStack.Pop();
            var left = midResultStack.Pop();
            var operation = operations[token];
            midResultStack.Push(operation(left, right));

        }
        return midResultStack.Pop();
    }
}