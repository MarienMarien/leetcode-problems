public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var nums = new int[1001];
        foreach(var n in nums1)
        {
            nums[n] = 1;
        }
        var intersection = new List<int>();
        foreach(var n in nums2)
        {
            if(nums[n] == 1)
                intersection.Add(n);
            nums[n] = 2;
        }
        return intersection.ToArray();
    }
}