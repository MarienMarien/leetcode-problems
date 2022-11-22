public class Solution {
    public int HIndex(int[] citations) {
        Array.Sort(citations);
        var i = 0;
        while (i < citations.Length && citations[citations.Length - 1 - i] > i) { 
            i++;
        }
        return i;
    }
}