public class Solution {
    public int[][] SeePeople(int[][] heights) {
        var res = new int[heights.Length][];
        for (var row = 0; row < heights.Length; row++)
        {
            var stack = new Stack<int>();
            res[row] = new int[heights[0].Length];
            for (var col = heights[0].Length - 1; col >= 0; col--)
            {
                if (col == heights[0].Length - 1)
                {
                    stack.Push(heights[row][col]);
                    continue;
                }
                if (heights[row][col] > stack.Peek())
                {
                    var seenCnt = 0;
                    var prevStackTop = stack.Peek();
                    while (stack.Count > 0 && stack.Peek() <= heights[row][col])
                    {
                        prevStackTop = stack.Pop();
                        seenCnt++;
                    }
                    if (stack.Count > 0 && prevStackTop < heights[row][col])
                        seenCnt++;
                    res[row][col] = seenCnt;
                    stack.Push(heights[row][col]);
                }
                else
                {
                    if (heights[row][col] == stack.Peek()) {
                        stack.Pop();
                    }
                    res[row][col] = 1;
                    stack.Push(heights[row][col]);
                }
            }
        }

        for (var col = heights[0].Length - 1; col >= 0; col--)
        {
            var stack = new Stack<int>();
            for (var row = heights.Length - 1; row >= 0; row--)
            {
                if (row == heights.Length - 1)
                {
                    stack.Push(heights[row][col]);
                    continue;
                }
                if (heights[row][col] > stack.Peek())
                {
                    var seenCnt = 0;
                    var prevStackTop = stack.Peek();
                    while (stack.Count > 0 && stack.Peek() <= heights[row][col])
                    {
                        prevStackTop = stack.Pop();
                        seenCnt++;
                    }
                    if (stack.Count > 0 && prevStackTop < heights[row][col])
                        seenCnt++;
                    res[row][col] += seenCnt;
                    stack.Push(heights[row][col]);
                }
                else
                {
                    if (heights[row][col] == stack.Peek())
                    {
                        stack.Pop();
                    }
                    res[row][col] += 1;
                    stack.Push(heights[row][col]);
                }
            }
        }
        return res;
    }
}