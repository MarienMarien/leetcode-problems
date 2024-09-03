public class Solution {
    public int GetLucky(string s, int k) {
        var converted = 0;
        foreach(var ch in s)
        {
            var ascii = ch - 'a' + 1;
            converted += ascii / 10 + ascii % 10;
        }

        while(k > 1)
        {
            var curr = 0;
            while(converted > 0)
            {
                curr += converted % 10;
                converted /= 10;
            }
            converted = curr;
            if(converted < 10)
                break;
            k--;
        }

        return converted;
    }
}