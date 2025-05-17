public class Solution {
    public string ReverseWords(string s) {
        var wordStarts = new List<int>();
        for(var i = 0; i < s.Length; i++)
        {
            var currCh = s[i];
            if(currCh == ' ')
                continue;
            if(i == 0 || s[i - 1] == ' ')
            {
                wordStarts.Add(i);
            }
        }

        var sLen = s.Length;
        var sb = new StringBuilder();
        for(var i = wordStarts.Count - 1; i >= 0; i--)
        {
            var wordId =  wordStarts[i];
            while(wordId < sLen && s[wordId] != ' ')
            {
                sb.Append(s[wordId]);
                wordId++;
            }
            if(i > 0)
                sb.Append(' ');
        }

        return sb.ToString();
    }
}