public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var ransomAlphabet = new Dictionary<char, int>();
        foreach(var ch in ransomNote)
        {
            if(!ransomAlphabet.TryAdd(ch, 1))
                ransomAlphabet[ch]++;
        }

        var charsLeft = ransomNote.Length;
        foreach(var ch in magazine)
        {
            if(!ransomAlphabet.ContainsKey(ch))
                continue;
            ransomAlphabet[ch]--;
            if(ransomAlphabet[ch] == 0)
                ransomAlphabet.Remove(ch);
            charsLeft--;
            if(charsLeft == 0)
                return true;
        }
        return false;
    }
}