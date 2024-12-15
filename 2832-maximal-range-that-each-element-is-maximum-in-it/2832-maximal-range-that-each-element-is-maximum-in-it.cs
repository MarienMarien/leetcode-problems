public class Solution {
    public int[] MaximumLengthOfRanges(int[] nums) {
        var leftBounds = new int[nums.Length];
        var stack = new Stack<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                stack.Pop();
            }

            var leftBound = 0;
            if (stack.Count > 0)
            {
                leftBound = stack.Peek() + 1;
            }
            leftBounds[i] = leftBound;
            stack.Push(i);
        }

        var rightBounds = new int[nums.Length];
        stack = new Stack<int>();
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
            {
                stack.Pop();
            }
            var rightBound = nums.Length;
            if (stack.Count > 0)
            {
                rightBound = stack.Peek();
            }
            rightBounds[i] = rightBound;
            stack.Push(i);
        }

        var ranges = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            ranges[i] = rightBounds[i] - leftBounds[i];
        }

        return ranges;
    }
}