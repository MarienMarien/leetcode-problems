public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
                return res;
            Array.Sort(nums);
            const int target = 0;
            for (var i = 0; i < nums.Length; i++) {
                if (nums[i] > 0)
                    break;
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                var start = i + 1;
                var end = nums.Length - 1;
                while (start < end) {
                    if (start > i + 1 && nums[start] == nums[start - 1])
                    {
                        start++;
                        continue;
                    }
                    var sum = nums[i] + nums[start] + nums[end];
                    if (target == sum)
                    {
                        IList<int> newItem = new List<int> { nums[i], nums[start], nums[end]};
                        res.Add(newItem);
                        start++;
                        end--;
                        continue;
                    }
                    if (sum < target)
                        start++;
                    if (sum > target)
                        end--;

                }
            }
            
            return res;
        }
}