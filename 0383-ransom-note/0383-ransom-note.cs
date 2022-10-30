public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote.Length > magazine.Length)
            return false;
        var alphabet = new Dictionary<char, int>();
        for (var i = 0; i < magazine.Length; i++) {
            if (!alphabet.ContainsKey(magazine[i]))
                alphabet.Add(magazine[i], 0);
            alphabet[magazine[i]]++;
        }

        foreach (var c in ransomNote) { 
            if(!alphabet.ContainsKey(c))
                return false;
            if (alphabet[c] == 0)
                return false;
            alphabet[c]--;
        }
        return true;
    }
}