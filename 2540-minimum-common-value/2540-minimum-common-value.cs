public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        var n1Id = 0;
        var n2Id = 0;
        var res = -1;
        while (n1Id < nums1.Length && n2Id < nums2.Length) {
            if (nums1[n1Id] == nums2[n2Id]) {
                res = nums1[n1Id];
                break;
            }
            if (nums1[n1Id] < nums2[n2Id])
            {
                n1Id++;
            }
            else {
                n2Id++;
            }
        }
        return res;
    }
}