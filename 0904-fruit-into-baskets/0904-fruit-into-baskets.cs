public class Solution {
    public int TotalFruit(int[] fruits) {
        var maxFruits = 0;
        if(fruits.Length == 0)
            return maxFruits;
        var fruit1 = fruits[0];
        var fruit2 = -1;
        var start = 0;
        var nextStart = 0;
        for (var i = 1; i < fruits.Length; i++) {
            if (fruits[i] != fruit1 && fruit2 < 0) { 
                fruit2 = fruits[i];
            }
            else if (fruits[i] != fruit1 && fruits[i] != fruit2) {
                maxFruits = Math.Max(maxFruits, i - start);
                start = nextStart;
                nextStart = i;
                fruit1 = fruits[start];
                fruit2 = fruits[i];
                continue;
            }
            if (fruits[i] != fruits[i - 1])
                nextStart = i;
        }
        maxFruits = Math.Max(maxFruits, fruits.Length - start);
        return maxFruits;
    }
}