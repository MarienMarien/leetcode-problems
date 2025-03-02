public class Solution {
    public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
        var res = new List<int[]>();
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var n1 = 0;
        var n2 = 0;
        while(n1 < len1 && n2 < len2)
        {
            if(nums1[n1][0] == nums2[n2][0])
            {
                res.Add(new int[] { nums1[n1][0], nums1[n1][1] + nums2[n2][1] });
                n2++;
                n1++;
                continue;
            }
            if(nums1[n1][0] < nums2[n2][0])
            {
                res.Add(nums1[n1]);
                n1++;
            } 
            else 
            {
                res.Add(nums2[n2]);
                n2++;
            }
        }

        while(n1 < len1)
        {
            res.Add(nums1[n1++]);
        }

        while(n2 < len2)
        {
            res.Add(nums2[n2++]);
        }
        
        return res.ToArray();
    }
}