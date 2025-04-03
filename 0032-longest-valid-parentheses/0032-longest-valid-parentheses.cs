public class Solution {
    public int LongestValidParentheses(string s) {
        var stack = new Stack<int>();
        var maxLen = 0;
        var currProcessed = 0;
        for(var i = 0; i < s.Length; i++)
        {
            if(s[i] == '(')
            {
                stack.Push(i - currProcessed);
                currProcessed = 0;
                continue;
            }
            if(stack.Count == 0)
            {
                currProcessed = 0;
                continue;
            }
            var lastValidId = stack.Pop();
            currProcessed = i - lastValidId + 1;
            maxLen = Math.Max(maxLen, currProcessed);

        }

        return maxLen;
    }
}