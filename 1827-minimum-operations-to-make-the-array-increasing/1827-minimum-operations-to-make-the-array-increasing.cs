public class Solution {
    public int MinOperations(int[] nums) {
        int operationsCount = 0;
        int prevNumber = 0;
        foreach (int n in nums) {
            if (n <= prevNumber && prevNumber > 0) {
                prevNumber++;
                operationsCount += prevNumber - n;
                continue;
            }
            prevNumber = n;
        }
        return operationsCount;
    }
}