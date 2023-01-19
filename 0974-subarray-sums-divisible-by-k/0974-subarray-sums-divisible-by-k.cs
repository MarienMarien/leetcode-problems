public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        var res = 0;
        var mod = new int[k];
        mod[0] = 1;
        var currMod = 0;
        foreach (var n in nums) {
            currMod = (currMod + n % k + k) % k;
            res += mod[currMod];
            mod[currMod]++;
        }
        return res;
    }
}