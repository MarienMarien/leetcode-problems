public class Solution {
    public void Rotate(int[] nums, int k) {
        if(nums.Length < 2)
            return;
        var lastId = nums.Length - 1;
        k = k % nums.Length;
        Rotate(nums, 0, lastId);
        Rotate(nums, 0, k - 1);
        Rotate(nums, k, lastId);
    }

    private void Rotate(int[] nums, int start, int end)
    {
        while(start < end)
        {
            var tmp = nums[start];
            nums[start] = nums[end];
            nums[end] = tmp;
            start++;
            end--;
        }
    }
}