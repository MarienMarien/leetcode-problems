public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length)
            return false;
        var alphabet = new Dictionary<char, int>();
        for(var i = 0; i < s.Length; i++)
        {
            if(!alphabet.TryAdd(s[i], 1))
                alphabet[s[i]]++;
            if(!alphabet.TryAdd(t[i], -1))
                alphabet[t[i]]--;
        }

        foreach(var a in alphabet)
        {
            if(a.Value != 0)
                return false;
        }

        return true;
    }
}