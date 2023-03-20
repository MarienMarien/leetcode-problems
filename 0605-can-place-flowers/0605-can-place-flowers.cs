public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        if (flowerbed.Length == 0)
            return n == 0;
        if (n == 0)
            return true;
        var flowersCanBePlanted = 0;
        var i = 0;
        while (i < flowerbed.Length) {
            if (flowerbed[i] == 1) {
                i++;
                continue;
            }
            var allowedFromLeft = i == 0 || flowerbed[i - 1] == 0;
            var allowedFromRight = i == flowerbed.Length - 1 || flowerbed[i + 1] == 0;
            if(allowedFromLeft && allowedFromRight )
            {
                flowersCanBePlanted++;
                i++;
            }
            i++;
            if (flowersCanBePlanted == n)
                return true;
        }
        return false;
    }
}