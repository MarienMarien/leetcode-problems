public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length == 0 && nums2.Length == 0)
            return 0;
        decimal nums1Len = nums1.Length == 0 ? -1 : nums1.Length;
        decimal nums2Len = nums2.Length == 0 ? -1 : nums2.Length;
        var mergedArrayLen = nums1.Length + nums2.Length;
        var medianLastIndex = mergedArrayLen % 2 == 0 ? mergedArrayLen / 2 + 1 : (mergedArrayLen + 1) / 2;
        int i1 = 0, i2 = 0;
        var mergedArrIdx = 0;
        double res = 0;
        double resPart = 0;
        while (mergedArrIdx < medianLastIndex) {
            if (i1 < nums1Len) {
                if (i2 < nums2Len)
                {
                    if (nums1[i1] <= nums2[i2]) {
                        res = nums1[i1++];
                    } else
                        res = nums2[i2++];
                }
                else
                    res = nums1[i1++];
            }
            else if (i2 < nums2Len) {
                res = nums2[i2++];
            }
            if (mergedArrIdx == medianLastIndex - 2 && mergedArrayLen % 2 == 0)
                resPart = res;
            mergedArrIdx++;
        }


        return resPart > 0 ? (res + resPart) / 2 : res;
    }
}