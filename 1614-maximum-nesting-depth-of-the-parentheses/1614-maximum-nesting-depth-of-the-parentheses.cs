public class Solution {
    public int MaxDepth(string s) {
        var maxDepth = 0;
        var stack = new Stack<char>();
        var currDepth = 0;
        foreach(var ch in s){
            if(ch == '(')
                stack.Push(ch);
            else if(ch == ')'){
                maxDepth = Math.Max(maxDepth, stack.Count);
                stack.Pop();
            }
        }
        return maxDepth;
    }
}