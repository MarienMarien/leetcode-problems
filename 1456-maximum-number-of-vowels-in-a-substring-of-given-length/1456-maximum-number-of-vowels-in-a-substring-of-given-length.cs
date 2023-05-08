public class Solution {
    public int MaxVowels(string s, int k) {
        ISet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
        int vowelCount = 0;
        for (int i = 0; i < k; i++) {
            if (vowels.Contains(s[i]))
                vowelCount++;
        }
        int maxVowelCount = vowelCount;
        for (int i = k; i < s.Length; i++) {
            if (vowels.Contains(s[i - k]))
                vowelCount--;
            if (vowels.Contains(s[i]))
                vowelCount++;
            maxVowelCount = Math.Max(maxVowelCount, vowelCount);
            if (maxVowelCount == k)
                break;
        }
        return maxVowelCount;
    }
}