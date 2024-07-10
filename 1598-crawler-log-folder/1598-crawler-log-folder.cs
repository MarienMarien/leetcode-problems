public class Solution {
    public int MinOperations(string[] logs) {
        const string up = "../";
        const string same = "./";
        var stack = new Stack<string>();
        foreach(var l in logs)
        {
            if(l.Equals(same))
                continue;
            if(l.Equals(up))
            {
                if(stack.Count > 0)
                    stack.Pop();
            }
            else
            {
                stack.Push(l);
            }
        }
        return stack.Count;
    }
}