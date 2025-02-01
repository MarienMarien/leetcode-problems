public class Solution {
    public bool IsArraySpecial(int[] nums) {
        var parity = nums[0] & 1;
        foreach(var n in nums)
        {
            if((n & 1) != parity)
                return false;
            parity = (parity + 1) % 2;
        }
        return true;
    }
}