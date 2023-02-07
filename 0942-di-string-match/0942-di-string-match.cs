public class Solution {
    public int[] DiStringMatch(string s) {
        var perm = new int[s.Length + 1];
        var max = s.Length;
        var min = 0;
        var id = 0;
        foreach (var ch in s) { 
            if(ch == 'D')
                perm[id] = max--;
            else
                perm[id] = min++;
            id++;
        }
        perm[id] = min;
        return perm;
    }
}