public class Solution {
    public bool CanReorderDoubled(int[] arr) {
        var res = false;
        if (arr.Length % 2 != 0) {
            return res;
        }
        arr = arr.OrderBy(x => Math.Abs(x)).ToArray();
        var complementaries = new Dictionary<int, int>();
        for (var i = 0; i < arr.Length; i++) {
            if (complementaries.ContainsKey(arr[i]) && complementaries[arr[i]] > 0)
            {
                complementaries[arr[i]]--;
                continue;
            }
            if (complementaries.ContainsKey(arr[i] * 2))
            {
                complementaries[arr[i] * 2]++;
                continue;
            }
            complementaries.Add(arr[i] * 2, 1);
        }
        return complementaries.All(x => x.Value == 0);
    }
}