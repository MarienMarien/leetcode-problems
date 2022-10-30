public class Solution {
    public int[] FindOriginalArray(int[] changed) {
        if (changed.Length % 2 != 0)
            return Array.Empty<int>();
        Array.Sort(changed);
        var set = new Dictionary<int, int>();
        var ans = new List<int>();
        foreach (var c in changed) {
            if (set.ContainsKey(c))
            {
                ans.Add(c / 2);
                if (set[c] == 1)
                    set.Remove(c);
                else
                    set[c]--;
            }
            else { 
                if(!set.ContainsKey(c * 2))
                    set.Add(c * 2, 0);
                set[c * 2]++;
            }

        }
        return ans.Count == changed.Length / 2 ? ans.ToArray() : Array.Empty<int>();
    }
}