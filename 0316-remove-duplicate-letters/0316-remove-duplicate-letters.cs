public class Solution {
    public string RemoveDuplicateLetters(string s) {
        var lastOccur = new Dictionary<char, int>();
        for (var i = 0; i < s.Length; i++) {
            lastOccur[s[i]] = i;
        }

        var seen = new HashSet<char>();
        var ans = new char[lastOccur.Count];
        var stack = new Stack<char>();
        for (var i = 0; i < s.Length; i++) 
        {
            if(!seen.Contains(s[i]))
            {
                while(stack.Count > 0 && stack.Peek() > s[i] && i < lastOccur[stack.Peek()]) 
                {
                    seen.Remove(stack.Pop());
                }
                stack.Push(s[i]);
                seen.Add(s[i]);
            }
        }

        var ansId = ans.Length - 1;
        while (stack.Count > 0) 
        {
            ans[ansId--] = stack.Pop();
        }
        return new string(ans);
    }
}