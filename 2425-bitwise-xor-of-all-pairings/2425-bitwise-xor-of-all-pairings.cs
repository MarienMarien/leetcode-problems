public class Solution {
    public int XorAllNums(int[] nums1, int[] nums2) {
        var res = 0;
        if(nums2.Length % 2 == 1)
        {    
            foreach(var n in nums1)
                res ^= n;
        }
        if(nums1.Length % 2 == 1)
        {
            foreach(var n in nums2)
                res ^= n;
        }
        return res;
    }
}