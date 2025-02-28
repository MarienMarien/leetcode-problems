public class Solution {
    public string MinWindow(string s, string t) {
        if(t.Length > s.Length)
            return string.Empty;

        var tDictionary = new Dictionary<char, int>();
        foreach(var ch in t)
        {
            if(!tDictionary.TryAdd(ch, 1))
                tDictionary[ch]++;
        }
        var allTChars = tDictionary.Count;
        var coveredChars = 0;
        var dict = new Dictionary<char, int>();
        var start = 0;
        var end = 0;
        var minWindowStart = 0;
        var minWindowEnd = 0;
        var minWindow = int.MaxValue;
        while(end < s.Length)
        {
            if(tDictionary.ContainsKey(s[end]))
            {
                if(!dict.TryAdd(s[end], 1))
                    dict[s[end]]++;
                if(dict[s[end]] == tDictionary[s[end]])
                    coveredChars++;
               
                while(coveredChars == allTChars && start <= end)
                {
                    if(end - start + 1 < minWindow)
                    {
                        minWindow = end - start + 1;
                        minWindowStart = start;
                        minWindowEnd = end;
                    }
                    
                    if(dict.ContainsKey(s[start]))
                    {
                        dict[s[start]]--;
                        if(dict[s[start]] < tDictionary[s[start]])
                            coveredChars--;
                    }
                    start++;
                }
            }

            end++;
        }

        if(minWindow == int.MaxValue)
            return string.Empty;

        var resChars = new char[minWindow];
        for(var i = 0; i < resChars.Length; i++)
        {
            resChars[i] = s[i + minWindowStart];
        }

        return new string(resChars);
    }
}