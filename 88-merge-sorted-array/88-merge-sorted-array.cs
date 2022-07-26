public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var insertPos = nums1.Length - 1;
        var nums1Id = m - 1;
        var nums2Id = n - 1;
        while (nums2Id >= 0) {
            if (nums1Id < 0 ||nums2[nums2Id] >= nums1[nums1Id] || insertPos == 0)
            {
                nums1[insertPos] = nums2[nums2Id];
                nums2Id--;
            }
            else {
                nums1[insertPos] = nums1[nums1Id];
                nums1Id--;
            }
            insertPos--;
        }
    }
}