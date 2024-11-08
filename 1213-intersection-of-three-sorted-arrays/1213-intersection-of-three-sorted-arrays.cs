public class Solution {
    public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3) {
        var nums = new int[2001];
        var maxLen = Math.Max(arr1.Length, Math.Max(arr2.Length, arr3.Length));
        for (var i = 0; i < maxLen; i++)
        {
            if (i < arr1.Length)
                nums[arr1[i]]++;
            if (i < arr2.Length)
                nums[arr2[i]]++;
            if (i < arr3.Length)
                nums[arr3[i]]++;
        }

        var res = new List<int>();
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == 3)
                res.Add(i);
        }

        return res;
    }
}