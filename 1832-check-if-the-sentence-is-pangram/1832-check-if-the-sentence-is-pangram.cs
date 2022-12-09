public class Solution {
    public bool CheckIfPangram(string sentence) {
        var alphabet = new int[26];
        foreach(var ch in sentence)
            alphabet[ch - 'a'] = 1;
        foreach(var letterCount in alphabet)
            if(letterCount == 0)
            return false;
        return true;
    }

    /*public bool CheckIfPangram(string sentence) {
        var set = new HashSet<char>();
        foreach(var ch in sentence){
            if(!set.Contains(ch))
                set.Add(ch);
        }
        return set.Count() == 26;
    }
    */
}