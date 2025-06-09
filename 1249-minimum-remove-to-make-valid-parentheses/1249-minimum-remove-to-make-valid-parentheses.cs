public class Solution {
    public string MinRemoveToMakeValid(string s) {
        if (s == null || s.Length == 0)
            return s;
        var parenthesesStack = new Stack<KeyValuePair<int, char>>();
        var openPar = '(';
        var closingPar = ')';
        var i = 0;
        while (i < s.Length) {
            if (s[i] == closingPar) 
            {
                KeyValuePair<int, char> stackTop;
                var isEmpty = !parenthesesStack.TryPeek(out stackTop);
                if (isEmpty || stackTop.Value == closingPar) {
                    s = s.Remove(i, 1);
                    continue;
                }
                if (stackTop.Value == openPar) {
                    parenthesesStack.Pop();
                }
            }
            if (s[i] == openPar) {
                parenthesesStack.Push(new KeyValuePair<int, char>(i, s[i]));
            }
            i++;
        }
        KeyValuePair<int, char> item;
        while (parenthesesStack.Count > 0) {
            item = parenthesesStack.Pop();
            s = s.Remove(item.Key, 1);
        }

        return s;
    }
}