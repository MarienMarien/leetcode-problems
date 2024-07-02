public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var n1Id = 0;
        var n2Id = 0;
        var res = new List<int>();

        while (n1Id < nums1.Length && n2Id < nums2.Length)
        {
            if (nums1[n1Id] == nums2[n2Id])
            {
                res.Add(nums1[n1Id]);
                n1Id++;
                n2Id++;
                continue;
            }

            if (nums1[n1Id] > nums2[n2Id]) 
            {
                n2Id++;
            }
            else 
            {
                n1Id++;
            }
        }

        return res.ToArray();
    }
}