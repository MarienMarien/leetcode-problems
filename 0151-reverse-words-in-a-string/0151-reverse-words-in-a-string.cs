public class Solution {
    public string ReverseWords(string s) {
        var stack = new Stack<string>();
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++) {
            if (s[i] == ' ')
            {
                if (sb.Length > 0)
                    stack.Push(sb.ToString());
                sb.Clear();
                continue;
            }
            sb.Append(s[i]);
        }
        while (stack.Count > 0) {
            if (sb.Length > 0)
                sb.Append(' ');
            sb.Append(stack.Pop());
        }
        return sb.ToString();
    }
}