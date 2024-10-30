public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var len = nums.Length;
        var mins = new PriorityQueue<int, int>();
        var maxs = new PriorityQueue<int, int>(
            Comparer<int>.Create((x, y) => {
                if (x > y)
                    return -1;
                return 1;

            }));
        var longest = 1;
        var subseqStart = 0;

        for (var i = 0; i < len; i++)
        {
            if (len - subseqStart < longest)
                break;
            while(mins.Count > 0 && mins.Peek() < subseqStart)
                mins.Dequeue();
            while (maxs.Count > 0 && maxs.Peek() < subseqStart)
                maxs.Dequeue();

            mins.Enqueue(i, nums[i]);
            maxs.Enqueue(i, nums[i]);
            if (nums[maxs.Peek()] - nums[mins.Peek()] > limit)
            {
                longest = Math.Max(longest, i - subseqStart);
                subseqStart++;
            }
        }

        longest = Math.Max(longest, len - subseqStart);

        return longest;
    }
}