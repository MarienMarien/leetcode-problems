public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        var result = new int[spells.Length];
        for(var i = 0; i < spells.Length; i++) { 
            var minPotion = Math.Ceiling(success / (decimal)spells[i]);
            if (minPotion > potions[^1])
                result[i] = 0;
            else {
                var firstSuccessfulPotion = FindFirstSuccessful(minPotion, potions);
                result[i] = potions.Length - firstSuccessfulPotion;
            }
        }
        return result;
    }

    private int FindFirstSuccessful(decimal minPotion, int[] potions)
    {
        var start = 0;
        var end = potions.Length;
        while (start < end) {
            var mid = (start + end) / 2;
            if (potions[mid] < minPotion)
            {
                start = mid + 1;
            }
            else {
                end = mid;
            }
        }
        return start;
    }
}