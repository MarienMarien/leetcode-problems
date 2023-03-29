public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        Array.Sort(satisfaction);
        var sum = 0;
        for (var i = 0; i < satisfaction.Length; i++) {
            sum += satisfaction[i] * (i + 1);
        }
        var start = 0;
        int currSum = sum;
        do
        {
            sum = currSum;
            for (var i = start; i < satisfaction.Length; i++)
            {
                currSum -= satisfaction[i];
            }
            start++;
        } while (currSum > sum || start == satisfaction.Length);
        return sum;
    }
}