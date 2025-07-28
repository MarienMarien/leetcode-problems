public class Solution {
    public int[] DiStringMatch(string s) {
        var n = s.Length;
        var str = new int[n + 1];
        for(var j = 0; j <= n; j++)
            str[j] = j;
        
        var i = 0;
        const char D = 'D';
        while(i < n)
        {
            if(s[i] != D)
            {
                if(str[i] > str[i+1])
                    Reverse(str, i, i+1);
                i++;
                continue;
            }
            var revStart = i;
            while(i < n && s[i] == D)
            {
                i++;
            }
            
            var revEnd = i < n ? i + 1 : i;
            if(revStart == revEnd)
            {
                Reverse(str, i, i+1);
                continue;
                
            }
            
            Reverse(str, revStart, revEnd);
        }
        return str;
    }
    
    private void Reverse(int[] str, int from, int to)
    {
        var start = from;
        var end = to;
        while(start < end)
        {
            var tmp = str[start];
            str[start] = str[end];
            str[end] = tmp;
            start++;
            end--;
        }
    }
}