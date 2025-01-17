public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        var xorSum = 0;
        foreach(var d in derived)
            xorSum ^= d;
        return xorSum == 0;
    }
}