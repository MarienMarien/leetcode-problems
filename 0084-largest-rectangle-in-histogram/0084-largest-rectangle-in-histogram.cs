public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var stack = new Stack<int>();
        stack.Push(-1);
        int len = heights.Length;
        int maxSq = 0;
        for (int i = 0; i < len; i++)
        {
            while (stack.Peek() != -1 && (heights[stack.Peek()] >= heights[i]))
            {
                int currH = heights[stack.Pop()];
                int currW = i - stack.Peek() - 1;
                maxSq = Math.Max(maxSq, currH * currW);
            }
            stack.Push(i);
        }
        while (stack.Peek() != -1)
        {
            int currH = heights[stack.Pop()];
            int currW = len - stack.Peek() - 1;
            maxSq = Math.Max(maxSq, currH * currW);
        }
        return maxSq;
    }
}