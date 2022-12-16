public class Solution {
    public int MinSteps(string s, string t) {
        var map = new Dictionary<char, int>();
        foreach(var ch in s){
            if(!map.TryAdd(ch, 1))
                map[ch]++;
        }
        var count = 0;
        foreach(var ch in t){
            if(!map.ContainsKey(ch) || map[ch] == 0)
                count++;
            else{
                map[ch]--;
            }
        }
        return count;
    }
}