public class Solution {
    public int MajorityElement(int[] nums) {
       var majority = Math.Ceiling(nums.Length / 2.0);
        var dictionary = new Dictionary<int, int>();
        foreach (var n in nums) { 
            if(!dictionary.ContainsKey(n))
                dictionary.Add(n, 0);
            dictionary[n]++;
        }
        var res = 0;
        foreach (var n in dictionary.Keys)
        {
            if (dictionary[n] >= majority)
            {
                res = n;
                break;
            }
        }
        return res;
    }
}