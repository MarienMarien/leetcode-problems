public class Solution {
    public int MinSetSize(int[] arr) {
        var half = arr.Length / 2;
        var freq = new Dictionary<int, int>();
        foreach (var a in arr)
        {
            if(!freq.TryAdd(a, 1))
                freq[a]++;
        }

        var freqSorted = freq.Values.OrderDescending();
        var count = 0;
        var countRemoved = 0;

        foreach (var f in freqSorted)
        {
            countRemoved += f;
            count++;

            if (countRemoved >= half)
                break;
        }

        return count;
    }
}