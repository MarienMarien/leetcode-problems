public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1.Length == 0 || num2.Length == 0 || num1.Equals("0") || num2.Equals("0"))
            return "0";
        var resultParts = new List<int>();
        var listId = 0;
        for (var i = num1.Length - 1; i >= 0; i--) {
            var carry = 0;
            var currListId = listId;
            for (var j = num2.Length - 1; j >= 0; j--) {
                var currRes = (num1[i] - '0') * (num2[j] - '0') + carry;
                var currResD = currRes % 10;
                carry = currRes / 10;
                if (currListId < resultParts.Count)
                {
                    carry += (resultParts[currListId] + currResD) / 10;
                    resultParts[currListId] = (resultParts[currListId] + currResD) % 10;
                }
                else {
                    resultParts.Add(currResD);
                }
                currListId++;
            }
            if (carry > 0)
                resultParts.Add(carry);
            listId++;
        }

        var res = new StringBuilder();
        for (var i = resultParts.Count - 1; i >= 0; i--) {
            res.Append(resultParts[i]);
        }

        return res.ToString();
    }
}