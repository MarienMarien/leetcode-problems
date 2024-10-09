public class Solution {
    public int MinAddToMakeValid(string s) {
        const char CLOSING = ')';
        const char OPENING = '(';
        var stack = new Stack<char>();
        foreach(var ch in s)
        {
            if(ch == CLOSING && stack.Count > 0 && stack.Peek() == OPENING)
            {
                stack.Pop();
                continue;
            }
            stack.Push(ch);
        }

        return stack.Count();
    }
}