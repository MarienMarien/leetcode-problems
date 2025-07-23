public class Solution {
    public int[] CanSeePersonsCount(int[] heights) {
        var len = heights.Length;
        var counts = new int[len];
        var stack = new Stack<int>();
        
        for(var i = len - 1; i >= 0; i--)
        {
            var curr = heights[i];
            if(stack.Count == 0 || curr < heights[stack.Peek()])
            {
                counts[i] = stack.Count == 0 ? 0 : 1;
                stack.Push(i);
                continue;
            }
            var countSeen = 0;
            while(stack.Count > 0 && heights[stack.Peek()] < curr)
            {
                countSeen++;
                stack.Pop();
            }
            if(stack.Count > 0)
                countSeen += 1;
            counts[i] = countSeen;
            stack.Push(i);
        }


        return counts;
    }
}