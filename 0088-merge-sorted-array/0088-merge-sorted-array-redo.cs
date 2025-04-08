public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var n1Id = m - 1;
        var n2Id = n - 1;
        for(var i = nums1.Length - 1; i >= 0; i--)
        {
            if(n2Id < 0 || (n1Id >= 0 && nums1[n1Id] >= nums2[n2Id]))
            {
                nums1[i] = nums1[n1Id];
                n1Id--;
                continue;
            }
            nums1[i] = nums2[n2Id];
            n2Id--;
        }
    }
}