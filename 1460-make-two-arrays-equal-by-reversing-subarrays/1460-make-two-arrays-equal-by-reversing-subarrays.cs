public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < arr.Length; i++)
        {
            if (!dict.TryAdd(arr[i], 1))
                dict[arr[i]] += 1;
            if (!dict.TryAdd(target[i], -1))
                dict[target[i]] -= 1;
        }

        foreach (var n in dict)
        {
            if (n.Value != 0)
                return false;
        }

        return true;
    }
}