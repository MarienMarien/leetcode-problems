public class Solution {
    public int PartitionString(string s) {
        var alphabet = new int[26];
        for (var i = 0; i < 26; i++)
            alphabet[i] = -1;
        var count = 1;
        var currStart = 0;
        for(var i = 0; i < s.Length; i++) {
            var key = s[i] - 'a';
            if (alphabet[key] >= 0 && alphabet[key] >= currStart) { 
                count++;
                currStart = i;
            }
            alphabet[key] = i;
        }
        return count;
    }
}