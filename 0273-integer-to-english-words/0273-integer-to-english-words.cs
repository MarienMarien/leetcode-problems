public class Solution {
    public string NumberToWords(int num) {
        if (num == 0)
            return "Zero";

        var digits = new Dictionary<int, string> {
            { 1, "One"},
            { 2, "Two"},
            { 3, "Three"},
            { 4, "Four"},
            { 5, "Five"},
            { 6, "Six"},
            { 7, "Seven"},
            { 8, "Eight"},
            { 9, "Nine"}
        };

        var unique = new Dictionary<int, string> {
            { 10, "Ten"},
            { 11, "Eleven" },
            { 12, "Twelve" },
            { 13, "Thirteen" },
            { 14, "Fourteen" },
            { 15, "Fifteen" },
            { 16, "Sixteen" },
            { 17, "Seventeen" },
            { 18, "Eighteen" },
            { 19, "Nineteen"}
        };

        var tens = new Dictionary<int, string> {
            { 2, "Twenty" },
            { 3, "Thirty" },
            { 4, "Forty" },
            { 5, "Fifty" },
            { 6, "Sixty" },
            { 7, "Seventy" },
            { 8, "Eighty" },
            { 9, "Ninety" }
        };

        var largeNums = new Dictionary<int, string>
        {
            { 100, "Hundred" },
            { 1000, "Thousand" },
            { 1000000, "Million" },
            { 1000000000, "Billion" }
        };

        var res = new List<string>();
        var counter = 1;
        var digitRang = 1;
        var number = num;

        while (number > 0)
        {
            var currDigit = number % 10;
            if (largeNums.ContainsKey(counter) && number % 1000 != 0 && !(counter == 100 && currDigit == 0)) {
                res.Add(largeNums[counter]);
                digitRang = 1;
            }

            if (counter == 1 || (largeNums.ContainsKey(counter) && counter > 100)) {
                var checkDigits = number % 100;
                if (unique.ContainsKey(checkDigits))
                {
                    res.Add(unique[checkDigits]);
                    number /= 100;
                    digitRang *= 100;
                    counter *= 100;
                    continue;
                }
            }
            
            if (currDigit != 0)
            {
                if (digitRang == 100)
                {
                    res.Add(largeNums[100]);
                    digitRang = 1;
                }

                if (digitRang == 10)
                {
                    res.Add(tens[currDigit]);
                }
                else
                {
                    res.Add(digits[currDigit]);
                }
            }

            number /= 10;
            counter *= 10;
            digitRang *= 10;
        }

        res.Reverse();
        return string.Join(" ", res);
    }
}