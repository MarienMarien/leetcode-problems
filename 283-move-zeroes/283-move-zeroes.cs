public class Solution {
    public void MoveZeroes(int[] nums) {
        var arrLen = nums.Length;
            var currentIndex = 0;
            var switchedIndex = 0;
            while (currentIndex < arrLen) {
                if (nums[currentIndex] != 0) {
                    if (currentIndex != switchedIndex) {
                        var tmp = nums[currentIndex];
                        nums[currentIndex] = nums[switchedIndex];
                        nums[switchedIndex] = tmp;
                    }
                    currentIndex++;
                    switchedIndex++;
                    continue;
                }
                currentIndex++;
            }
    }
}