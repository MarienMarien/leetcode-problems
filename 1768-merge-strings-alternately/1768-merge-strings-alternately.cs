public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var minLen = Math.Min(word1.Length, word2.Length);
        var sb = new StringBuilder();
        for (var i = 0; i < minLen; i++) {
            sb.Append(word1[i]).Append(word2[i]);
        }
        var maxLen = Math.Max(word1.Length, word2.Length);
        var diff = maxLen - minLen;
        if(diff > 0){
            var longerStr = word1.Length > word2.Length ? word1 : word2;
            sb.Append(longerStr, minLen, diff);
        }

        return sb.ToString();
    }
}