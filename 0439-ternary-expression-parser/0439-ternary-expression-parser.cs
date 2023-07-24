public class Solution {
    private const char T = 'T';
    private const char F = 'F';
    private const char qMark = '?';
    private const char column = ':';
    public string ParseTernary(string expression)
    {
        var stack = new Stack<char>();
        for (var i = expression.Length - 1; i >= 0; i--) {
            if (expression[i] == column)
                continue;
            if (stack.Count > 0 && stack.Peek() == qMark) {
                stack.Pop();
                var curr = expression[i];
                var left = stack.Pop();
                var right = stack.Pop();
                var currRes = curr == T ? left : right;
                stack.Push(currRes);
            } else {
                stack.Push(expression[i]);
            }
        }
        return stack.Pop().ToString();
    }
}