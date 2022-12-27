public class Solution {
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) {
        var rocksLeft = new int[capacity.Length];
        for(var i = 0; i < capacity.Length; i++) {
            rocksLeft[i] = capacity[i] - rocks[i];
        }
        var count = 0;
        Array.Sort(rocksLeft);
        foreach(var r in rocksLeft){
            if(additionalRocks == 0 || additionalRocks < r)
                break;
            additionalRocks -= r;
            count++;
        }
        return count;
    }
}