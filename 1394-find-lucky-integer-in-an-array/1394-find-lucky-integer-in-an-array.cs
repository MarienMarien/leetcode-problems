public class Solution {
    public int FindLucky(int[] arr) {
        var lucky = -1;
        var nums = new int[500 + 1];
        foreach(var a in arr)
        {
            nums[a]++;
        }

        for(var i = nums.Length - 1; i > 0; i--)
        {
            if(nums[i] == i)
                return nums[i];
        }
        return -1;
    }
}