public class Solution {
    public int[] DistinctNumbers(int[] nums, int k) {
        var numbers = new Dictionary<int, int>();
        var distinctCount = 0;
        var distinctNumbers = new int[nums.Length - k + 1];
        for(var i = 0; i < nums.Length; i++)
        {
            if(!numbers.ContainsKey(nums[i]))
            {
                numbers.Add(nums[i], 0);
                distinctCount++;
            }
            numbers[nums[i]]++;
            if(i >= k)
            {
                numbers[nums[i - k]]--;
                if(numbers[nums[i - k]] == 0)
                {
                    distinctCount--;
                    numbers.Remove(nums[i - k]);
                }
            }
            if(i >= k - 1)
            {
                distinctNumbers[i - k + 1] = distinctCount;
            }
        }

        return distinctNumbers;
    }
}