public class Solution {
    public long CountPairs(int[] nums1, int[] nums2) {
        if (nums1.Length != nums2.Length)
            return 0;

        var diff = new int[nums1.Length];
        
        for (var i = 0; i < nums1.Length; i++) { 
            diff[i] = nums1[i] - nums2[i];
        }

        Array.Sort(diff);
        long cnt = 0;
        int start = 0;
        int end = diff.Length - 1;
        while (start < end) {
            if (diff[start] + diff[end] > 0)
            {
                cnt += end - start;
                end--;
            }
            else
                start++;
        }
        return cnt;
    }
}