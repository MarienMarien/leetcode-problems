public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var min = new PriorityQueue<(int val, int id), int>();
        var max = new PriorityQueue<(int val, int id), int>(Comparer<int>.Create((x, y) => y - x));
        var longest = 1;
        var left = 0;
        for(var right = 0; right < nums.Length; right++)
        {
            while(min.Count > 0 && min.Peek().id < left)
                min.Dequeue();
            while(max.Count > 0 && max.Peek().id < left)
                max.Dequeue();
            min.Enqueue((nums[right], right), nums[right]);
            max.Enqueue((nums[right], right), nums[right]);
            var currMin = min.Peek().val;
            var currMax = max.Peek().val;
            if(currMax - currMin > limit)
            {
                longest = Math.Max(longest, right - left);
                left++;
            }
        }
        longest = Math.Max(longest, nums.Length - left);
        return longest;
    }
}