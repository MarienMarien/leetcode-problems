public class Solution {
    IDictionary<char, int> romanToInt = new Dictionary<char, int>() {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };
    public int RomanToInt(string s) {
        var currentChar = s[s.Length - 1];
        var lastVal = romanToInt[currentChar];
        var total = lastVal;
        for (var i = s.Length - 2; i >= 0; i--) {
            currentChar = s[i];
            var currVal = romanToInt[currentChar];
            if (currVal < lastVal)
                total -= currVal;
            else
                total += currVal;
            lastVal = currVal;
        }
        return total;
    }
}