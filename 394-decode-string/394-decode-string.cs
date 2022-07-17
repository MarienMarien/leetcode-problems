public class Solution {
    public string DecodeString(string s) {
        var res = new StringBuilder();
        var i = 0;

        while (i < s.Length)
        {
            if (char.IsDigit(s[i]))
            {
                string subS;
                (subS, i) = Decode(s, i);
                res.Append(subS);
                continue;
            }
            res.Append(s[i]);
            i++;
        }
        return res.ToString();
    }

    private (string, int) Decode(string s, int i) {
        var substring = new StringBuilder();
        var numberStartId = i;
        while (s[i] != '[')
        {
            i++;
        }
        var currRepetitions = i > numberStartId ? Int32.Parse(s[numberStartId..i]) : 1;
        var toAdd = "";
        i++;// move forward from [
        while (s[i] != ']') {
            if (Char.IsDigit(s[i]))
            {
                var tmp = "";
                (tmp, i) = Decode(s, i);
                toAdd += tmp;
                continue;
            }
            toAdd += s[i];
            i++;
        }
        substring.Insert(0, toAdd, currRepetitions);
        i++;
        return (substring.ToString(), i);
    }
}