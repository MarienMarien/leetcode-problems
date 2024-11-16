public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        var powers = new int[nums.Length - k + 1];
        var pId = 0;
        var sortedItemsCount = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] - nums[i - 1] == 1)
                sortedItemsCount = Math.Min(sortedItemsCount + 1, k);
            else
                sortedItemsCount = 1;
            if (i >= k - 1)
            {
                powers[pId] = sortedItemsCount == k ? nums[i] : -1;
                pId++;
            }
        }

        return powers;
    }
}