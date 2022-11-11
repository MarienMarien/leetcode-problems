public class Solution {
    public int MaxNumberOfBalloons(string text) {
        var dict = new Dictionary<char, int>() { 
            { 'b', 0 }, { 'a', 0 }, { 'l', 0 }, { 'o', 0 }, { 'n', 0 }
        };
        foreach (var ch in text) {
            if (dict.ContainsKey(ch))
                dict[ch]++;
        }
        var count = Int32.MaxValue;
        foreach (var k in dict.Keys) {
            var curr = k == 'l' || k == 'o' ? dict[k] / 2 : dict[k];
            count = Math.Min(count, curr);
        }
        return count;
    }
}