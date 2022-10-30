public class Solution {
    public string RemoveDuplicateLetters(string s) {
        var sb = new StringBuilder();
        var seen = new HashSet<char>();
        var lastItems = new Dictionary<char, int>();
        var stack = new Stack<char>();
        for (var i = s.Length - 1; i >= 0; i--)
            if (!lastItems.ContainsKey(s[i]))
                lastItems.Add(s[i], i);
        for (var i = 0; i < s.Length; i++) { 
            var item = s[i];
            if (!seen.Contains(item)) {
                while (stack.Count > 0 && item < stack.Peek() && lastItems[stack.Peek()] > i)
                    seen.Remove(stack.Pop());
                stack.Push(item);
                seen.Add(item);
            }
        }
        while (stack.Count > 0) { 
            sb.Insert(0, stack.Pop());
        }
        
        return sb.ToString();
    }
}