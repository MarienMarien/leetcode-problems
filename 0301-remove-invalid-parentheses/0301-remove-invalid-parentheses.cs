public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        IList<string> result = new List<string>();
        if(s == null || s.Length == 0)
            return result;
        var visited = new HashSet<string>();
        var q = new Queue<string>();
        visited.Add(s);
        q.Enqueue(s);
        var found = false;
        while (q.Count > 0) { 
            s = q.Dequeue();
            if (IsValid(s)) {
                result.Add(s);
                found = true;
            }
            if (found)
                continue;
            for (var i = 0; i < s.Length; i++) {
                if (s[i] != ')' && s[i] != '(')
                    continue;
                var tmp = s[0..i] + s[(i + 1)..];
                if (!visited.Contains(tmp)) { 
                    q.Enqueue(tmp);
                    visited.Add(tmp);
                }
            }
        }
        return result;
    }

    private bool IsValid(string s) {
        var count = 0;
        foreach (var ch in s) {
            if (ch == '(')
                count++;
            if (ch == ')' && count-- == 0)
                return false;
        }
        return count == 0;
    }
}