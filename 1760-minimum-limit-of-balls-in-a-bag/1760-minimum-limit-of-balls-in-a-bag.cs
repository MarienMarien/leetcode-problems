public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        var maxBag = nums.Max();
        int start = 1;
        int end = maxBag;
        while(start < end){
            int mid = (end + start) / 2;
            var n = GetNumber(nums, mid);
            if(n > maxOperations)
                start = mid + 1;
            else
                end = mid;
        }
        return end;
    }

    private int GetNumber(int[] nums, int divider){
        var sum = 0;
        foreach(var n in nums){
            sum += (n - 1) / divider;
        }
        return sum;
    }
}