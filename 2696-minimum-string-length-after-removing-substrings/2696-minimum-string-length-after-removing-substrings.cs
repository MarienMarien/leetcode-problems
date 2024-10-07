public class Solution {
    public int MinLength(string s) {
        var map = new Dictionary<char, char>{
            { 'B', 'A' },
            { 'D', 'C' }
        };
        var stack = new Stack<char>();
        foreach(var ch in s)
        {
            if(map.ContainsKey(ch) && stack.Count > 0 && stack.Peek() == map[ch])
            {
                stack.Pop();
                continue;
            }
            stack.Push(ch);
        }

        return stack.Count();
    }
}