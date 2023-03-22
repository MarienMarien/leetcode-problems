public class Solution {
    public int FindSmallestInteger(int[] nums, int value) {
        var valueMod = new Dictionary<int, int>();
        foreach (var n in nums) {
            var mod = n % value;
            if (mod < 0)
                mod += value;
            if (!valueMod.TryAdd(mod, 1))
                valueMod[mod]++;
        }
        var res = 0;
        while (true) {
            if (!valueMod.ContainsKey(res % value))
                break;
            var key = res % value;
            valueMod[key]--;
            if (valueMod[key] == 0)
                valueMod.Remove(key);
            res++;
        }
        return res;
    }
}