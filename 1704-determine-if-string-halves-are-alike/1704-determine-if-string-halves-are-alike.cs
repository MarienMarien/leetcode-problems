public class Solution {
    public bool HalvesAreAlike(string s) {
        var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        var koef = s.Length / 2;
        var count1 = 0; 
        var count2 = 0;
        for(var id = 0; id < koef; id++){
            if(vowels.Contains(s[id]))
                count1++;
            if(vowels.Contains(s[id + koef]))
                count2++;
        }
        return count1 == count2;
    }
}