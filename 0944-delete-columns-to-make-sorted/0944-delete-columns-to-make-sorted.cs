public class Solution {
    public int MinDeletionSize(string[] strs) {
        var count = 0;
        for (var chId = 0; chId < strs[0].Length; chId++) {
            for (var strId = 1; strId < strs.Length; strId++) { 
                if (strs[strId][chId] < strs[strId - 1][chId]) {
                    count++;
                    break;
                }
            }
        }
        return count;
    }
}