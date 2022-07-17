public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var ans = new int[2];
            
            var complements = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) {
                if (complements.ContainsKey(nums[i]))
                {
                    ans[0] = complements[nums[i]];
                    ans[1] = i;
                    break;
                }
                else {
                    if (complements.ContainsKey(target - nums[i]))
                        continue;
                    complements.Add(target - nums[i], i);
                }
            }
            
            return ans;
    }
}