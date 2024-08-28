public class Solution {
    public int[] PlusOne(int[] digits) {
        var res = new List<int>();
        var carry = 1;
        for(var i = digits.Length - 1; i >= 0; i--)
        {
            var newD = digits[i] + carry;
            res.Add(newD % 10);
            carry = newD / 10;
        }
        if(carry > 0)
            res.Add(carry);
        res.Reverse();
        return res.ToArray();
    }
}