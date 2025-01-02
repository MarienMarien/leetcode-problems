public class Solution {
    public int[] VowelStrings(string[] words, int[][] queries) {
        var vowelStrs = new int[words.Length];
        var vowels = new HashSet<char>{ 'a', 'e', 'i', 'o', 'u' };
        for(var i = 0; i < words.Length; i++)
        {
            vowelStrs[i] = i == 0 ? 0 : vowelStrs[i - 1];
            if(vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
                vowelStrs[i]++;
        }

        var ans = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            var right = queries[i][1];
            var left = queries[i][0];
            if(left == 0)
            {
                ans[i] = vowelStrs[right];
            } else 
            {
                ans[i] = vowelStrs[right] - vowelStrs[left - 1];
            }
        }
        return ans;
    }
}