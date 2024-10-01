public class Solution {
    public bool CanArrange(int[] arr, int k) {
        var remCount = new Dictionary<int, int>();
        foreach (var a in arr)
        {
            var rem = ((a % k) + k) % k;
            if(!remCount.TryAdd(rem, 1))
                remCount[rem]++;
        }

        foreach (var rC in remCount)
        {
            if (rC.Key == 0)
            {
                if (rC.Value % 2 != 0)
                    return false;
            }
            else if(!remCount.ContainsKey(k - rC.Key) || rC.Value != remCount[k - rC.Key])
            {
                return false;
            }
        }
        return true;
    }
}