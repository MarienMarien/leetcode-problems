public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1Nums = version1.Split('.');
        var v2Nums = version2.Split('.');
        for (var i = 0; i < Math.Max(v1Nums.Length, v2Nums.Length); i++) { 
            var n1 = i < v1Nums.Length ? Int32.Parse(v1Nums[i]) : 0;
            var n2 = i < v2Nums.Length ? Int32.Parse(v2Nums[i]) : 0;
            if (n1 != n2)
                return n1 > n2 ? 1 : -1;
        }
        return 0;
    }
}