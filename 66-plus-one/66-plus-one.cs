public class Solution {
    public int[] PlusOne(int[] digits) {
        var carry = 0;
        for (var i = digits.Length - 1; i >= 0; i--) {
            var newNum = digits[i] + 1;
            digits[i] = newNum % 10;
            carry = newNum / 10;
            if (carry == 0)
                break;
        }
        if (carry != 0) {
            var res = new LinkedList<int>(digits);
            res.AddFirst(carry);
            digits = res.ToArray();
        }

        return digits;
    }
}