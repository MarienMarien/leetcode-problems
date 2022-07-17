public class Solution {
    IDictionary<int, char> numbersMatch = new Dictionary<int, char>() {
                { 1, 'I'},
                { 5, 'V'},
                { 10, 'X'},
                { 50, 'L'},
                { 100, 'C'},
                { 500, 'D'},
                { 1000, 'M'}
            };
    public string IntToRoman(int num) {
       var res = new StringBuilder();
            var div = 1;
            while (num >= div) {
                div *= 10;
            }
            div /= 10;
            while (num > 0) {
                var currentDigit = num / div;
                switch (currentDigit) {
                    case <= 3:
                        res.Append(numbersMatch[div], currentDigit);
                        break;
                    case <= 4 and >= 4:
                        res.Append(numbersMatch[div]).Append(numbersMatch[div * 5]);
                        break;
                    case >= 5 and <= 8:
                        res.Append(numbersMatch[div * 5]).Append(numbersMatch[div], (currentDigit - 5));
                        break;
                    case <= 9 and >= 9:
                        res.Append(numbersMatch[div]).Append(numbersMatch[div * 10]);
                        break;
                    default:
                        break;
                }
                num = (int)Math.Floor((decimal)num % div);
                div /= 10;
            }
            return res.ToString();
    }
}