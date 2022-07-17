public class Solution {
     IDictionary<char, string> letterMatch = new Dictionary<char, string>() {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
        };
    public IList<string> LetterCombinations(string digits) {
       IList<string> res = new List<string>();
        if (digits == null || digits.Length == 0)
            return res;
        var startString = letterMatch[digits[0]];
        for (var i = 0; i < startString.Length; i++) {
            res = BuildResult(res, startString[i].ToString(), 1, digits);
        }
        return res;
    }

    private IList<string> BuildResult(IList<string> res, string prevLetters, int digitIdx, string digits)
    {
        if (digitIdx >= digits.Length)
        {
            res.Add(prevLetters);
            return res;
        }
        var currentString = letterMatch[digits[digitIdx]];
        for (var i = 0; i < currentString.Length; i++) {
            res = BuildResult(res, prevLetters + currentString[i], digitIdx +1, digits);
        }
        return res;
    }
}