public class Solution {
    public bool Check(int[] nums) {
        var arrStartInMid = false;
        var isSorted = false;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0 || nums[i] >= nums[i - 1])
                continue;
            if (arrStartInMid)
                return false;
            arrStartInMid = true;
        }

        return !arrStartInMid || nums[0] >= nums[^1];
    }
}