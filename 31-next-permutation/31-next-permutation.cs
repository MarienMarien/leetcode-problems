public class Solution {
    public void NextPermutation(int[] nums) {
        var i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) {
            i--;
        }
        if (i >= 0) {
            var j = BSearch(nums, i + 1, nums.Length - 1, nums[i]) ;
            if (j >= 0)
            {
                var tmp = nums[j];
                nums[j] = nums[i];
                nums[i] = tmp;
            }
        }
        Array.Reverse(nums, i + 1, nums.Length - (i + 1));
    }

    private static int BSearch(int[] nums, int start, int end, int swapItem)
    {
        int index = -1;
        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            if (nums[mid] <= swapItem)
                end = mid - 1;
            else
            {
                start = mid + 1;
                if (index == -1 || nums[index] >= nums[mid])
                    index = mid;
            }
        }
        return index;
    }
}