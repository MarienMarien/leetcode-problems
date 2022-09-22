public class Solution {
    public int SingleNumber(int[] nums) {
        var set = new HashSet<int>();
        foreach (var n in nums) {
            if (set.Contains(n))
                set.Remove(n); 
            else
                set.Add(n);
        }
        return set.First();
    }
}