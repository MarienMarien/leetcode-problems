public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        var poppedId = 0;
        var stack = new Stack<int>();
        foreach(var p in pushed) {
            if(stack.Count > 0){
                while(stack.Count > 0 && stack.Peek() == popped[poppedId]){
                    stack.Pop();
                    poppedId++;
                }
            }
            stack.Push(p);
        }
        while(stack.Count > 0 && stack.Peek() == popped[poppedId]){
            stack.Pop();
            poppedId++;
        }
        return stack.Count == 0;
    }
}