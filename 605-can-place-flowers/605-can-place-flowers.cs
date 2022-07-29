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
            if (i == flowerbed.Length - 1 && (flowerbed.Length == 1 || flowerbed[i - 1] == 0))
            {
                flowersCanBePlanted++;
                i++;
            }
            else if (i == 0 && flowerbed[i + 1] == 0)
            {
                flowersCanBePlanted++;
                i++;
            }
            else if (i > 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0) {
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