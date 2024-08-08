public class Solution {
    public string KthDistinct(string[] arr, int k) {
        var set = new Dictionary<string, int>();
        foreach (var str in arr)
        {
            if (!set.TryAdd(str, 1))
                set[str]++;
        }

        foreach (var str in arr)
        {
            if (set.ContainsKey(str) && set[str] == 1)
                k--;
            if (k == 0)
                return str;
        }

        return string.Empty;
    }
}