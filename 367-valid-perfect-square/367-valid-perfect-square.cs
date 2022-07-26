public class Solution {
    public bool IsPerfectSquare(int num) {
         var sqare = num / 2 + 1;
        while (sqare > 0) {
            if (sqare * sqare == num)
                return true;
            sqare--;
        }
        return false;
    }
}