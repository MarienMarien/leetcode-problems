public class Solution {
    public bool IsValid(string s) {
        var validityMap = new Dictionary<char, char>{
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        var stack = new Stack<char>();
        foreach(var p in s)
        {
            if(validityMap.ContainsKey(p))
            {
                if(stack.Count == 0 || validityMap[p] != stack.Peek())
                    return false;
                stack.Pop();
                continue;
            }
            stack.Push(p);
        }
        return stack.Count == 0;
    }
}