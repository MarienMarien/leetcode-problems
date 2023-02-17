public class Solution {
    public int MinimumDeletions(string s) {
        var stack = new Stack<char>();
        var count = 0;
        for (var i = s.Length - 1; i >= 0; i--) {
            if (stack.Count > 0 && stack.Peek() < s[i])
            {
                count++;
                stack.Pop();
            }
            else {
                stack.Push(s[i]);
            }
        }
        return count;
    }
}