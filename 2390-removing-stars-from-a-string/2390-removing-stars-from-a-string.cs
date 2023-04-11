public class Solution {
    public string RemoveStars(string s) {
        var stack = new Stack<char>();
        var starPresent = false;
        foreach (var ch in s) {
            if (ch == '*')
            {
                if(stack.Count > 0)
                    stack.Pop();
                starPresent = true;
                continue;
            }
            stack.Push(ch);
        }
        if (!starPresent)
            return s;
        var res = stack.ToArray();
        Array.Reverse(res);
        return new string(res);
    }
}