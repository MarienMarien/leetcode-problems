public class Solution {
    public int MinOperations(int[] nums, int k) {
        var unique = new HashSet<int>();
        foreach(var n in nums)
        {
            if(n < k)
                return -1;
            if(!unique.Contains(n) && n != k)
                unique.Add(n);
        }
        return unique.Count;
    }
}