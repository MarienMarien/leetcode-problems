public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var start = 0;
        var end = numbers.Length - 1;
        var ans = new int[2];
        while (start < end) { 
            var currSum = numbers[start] + numbers[end];
            if (currSum == target)
                break;
            else if (currSum > target)
            {
                end--;
            }
            else {
                start++;
            }
        }
        ans[0] = start + 1;
        ans[1] = end + 1;
        return ans;
    }
}