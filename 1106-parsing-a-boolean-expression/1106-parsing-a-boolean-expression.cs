public class Solution {
    public bool ParseBoolExpr(string expression) {
        var parenthesis = new HashSet<char> { '(', ')' };
        var operators = new HashSet<char> { '!', '&', '|' };
        var vals = new Dictionary<char, bool> { { 't', true }, { 'f', false } };
        var valsStr = new Dictionary<bool, char> { { true, 't' }, { false, 'f' } };
        var stack = new Stack<char>();

        foreach (var el in expression)
        {
            if (el == ',' || el == '(')
                continue;

            if (el != ')')
            {
                stack.Push(el);
                continue;
            }

            var hasTrue = false;
            var hasFalse = false;

            while (!operators.Contains(stack.Peek()))
            {
                var curr = stack.Pop();
                if (vals[curr] == true)
                    hasTrue = true;
                else
                    hasFalse = true;
            }

            var currOp = stack.Pop();
            switch (currOp) {
                case '!':
                    stack.Push(valsStr[!hasTrue]);
                    break;
                case '&':
                    stack.Push(valsStr[!hasFalse]);
                    break;
                default:
                    stack.Push(valsStr[hasTrue]);
                    break;
            }
        }

        return vals[stack.Peek()];
    }
}