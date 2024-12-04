public class Solution {
    public bool CanMakeSubsequence(string str1, string str2) {
        if(str1.Length < str2.Length)
            return false;
        
        const char Z = 'z';
        var s2Id = 0;
        foreach(var ch in str1)
        {
            var incremented = ch == Z ? (int)'a' : ch + 1;
            if(str2[s2Id] == ch || incremented == (int)str2[s2Id])
                s2Id++;
            if(s2Id >= str2.Length)
                return true;
        }

        return false;
    }
}