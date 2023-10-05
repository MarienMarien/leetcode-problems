public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var ans = new List<int>();
        var majorityCount = nums.Length / 3;
        Array.Sort(nums);
        var currCount = 1;
        for (var i = 1; i < nums.Length; i++) {
            if (nums[i] != nums[i - 1])
            {
                if (currCount > majorityCount) {
                    ans.Add(nums[i - 1]);
                }
                currCount = 1;
            }
            else {
                currCount++;
            }
        }
        if (currCount > majorityCount)
        {
            ans.Add(nums[^1]);
        }

        return ans;
    }
}