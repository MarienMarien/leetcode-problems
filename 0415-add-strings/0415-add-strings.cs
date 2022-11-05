public class Solution {
    public string AddStrings(string num1, string num2) {
        if (num1.Length < num2.Length)
            return AddStrings(num2, num1);
        var res = new List<int>();
        var carry = 0;
        var n1Id = num1.Length - 1;
        var n2Id = num2.Length - 1;
        while (n1Id >= 0) {
            var curr = num1[n1Id] - '0' + (n2Id >= 0 ? num2[n2Id] - '0' : 0) + carry;
            carry = curr / 10;
            res.Add(curr % 10);
            Console.Write($"{curr % 10} ");
            n1Id--;
            n2Id--;
        }
        if (carry > 0)
            res.Add(carry);

        var sb = new StringBuilder();
        for(var i = res.Count - 1; i >= 0; i--)
            sb.Append(res[i]);
        return sb.ToString();
    }
}