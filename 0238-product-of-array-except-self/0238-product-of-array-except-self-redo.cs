public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var l2r = new int[nums.Length];
        l2r[0] = nums[0];
        var r2l = new int[nums.Length];
        var lastId = nums.Length - 1;
        r2l[lastId] = nums[lastId];
        for(var i = 1; i < nums.Length; i++)
        {
            l2r[i] = l2r[i - 1] * nums[i];
            r2l[lastId - i] = r2l[lastId - i + 1] * nums[lastId - i];
        }
        var result = new int[nums.Length];
        for(var i = 0; i < result.Length; i++)
        {
            result[i] = 1;
            if(i > 0)
                result[i] *= l2r[i - 1];
            if(i < lastId)
                result[i] *= r2l[i + 1];
        }

        return result;
    }
}