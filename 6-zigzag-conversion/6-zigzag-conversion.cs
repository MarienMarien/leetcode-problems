public class Solution {
    public string Convert(string s, int numRows) {
       if (s == null || s.Length <= 1 || numRows == 1 || numRows >= s.Length )
            return s;
        var res = new StringBuilder();
        for (var i = 0; i < numRows; i++)
        {
            for (var j = 0; j < Math.Ceiling((decimal)s.Length / numRows); j++)
            {
                if (i + numRows * j + (numRows - 2) * j >= s.Length) break;
                res.Append(s[i + numRows * j + (numRows - 2) * j]);
                if (i == 0 || i == numRows - 1)
                    continue;
                var nextTopIdx = numRows * (j + 1) + (numRows - 2) * (j + 1);
                if (nextTopIdx - i < s.Length)
                    res.Append(s[nextTopIdx - i]);
            }
        }
        return res.ToString();
    }
}