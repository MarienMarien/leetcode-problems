public class Solution {
    public bool ConfusingNumber(int n) {
        var map = new Dictionary<int, int>{{0, 0}, {1, 1}, {6, 9}, {8, 8}, {9, 6}};
        var newN = 0;
        var koef = 10;
        var curr = n;
        while(curr > 0){
            var digit = curr % 10;
            if(!map.TryGetValue(digit, out int newDigit))
                return false;
            newN = newN * koef + newDigit;
            curr /= 10;
        }
        return newN != n;
    }
}