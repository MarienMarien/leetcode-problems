public class Solution {
    public string AddStrings(string num1, string num2) {
        var num1Id = num1.Length - 1;
        var num2Id = num2.Length - 1;
        var carry = 0;
        var sb = new StringBuilder();

        for (; num1Id >= 0 || num2Id >= 0; num1Id--, num2Id--)
        {
            var n1 = num1Id < 0 ? 0 : Int32.Parse(num1[num1Id].ToString());
            var n2 = num2Id < 0 ? 0 : Int32.Parse(num2[num2Id].ToString());
            var curr = n1 + n2 + carry;
            sb.Append(curr % 10);
                carry = curr / 10;
        }

        var reversed = string.Join("", sb.ToString().Reverse());

        return carry > 0 ? $"{carry}{reversed}" : reversed;
    }
}