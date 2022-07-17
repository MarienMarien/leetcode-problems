public class Solution {
    private static Dictionary<char, char> _Parentheses = new Dictionary<char, char>() { { ']', '[' }, { ')', '(' }, { '}', '{' } };
    public bool IsValid(string s) {
        var checkStack = new Stack<char>();
            foreach (var symbol in s) {
                // check if it is opening bracket
                if (_Parentheses.Values.Contains(symbol))
                {
                    checkStack.Push(symbol);
                    continue;
                }
                // if symbol is closing bracket
                if (checkStack.Count > 0 && checkStack.Peek() == _Parentheses[symbol])
                    checkStack.Pop();
                else
                    return false;
            }
            return checkStack.Count == 0;
    }
}