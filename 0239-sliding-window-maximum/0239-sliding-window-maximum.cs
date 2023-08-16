public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var heap = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y - x));
        var ans = new int[nums.Length - k + 1];
        for (var i = 0; i < k; i++) {
            if(!heap.TryAdd(nums[i], 1))
                heap[nums[i]]++;
        }
        var ansId = 0;
        ans[ansId++] = heap.First().Key;
        var iToRemove = 0;
        for (var i = k; i < nums.Length; i++) {
            if (!heap.TryAdd(nums[i], 1))
                heap[nums[i]]++;
            heap[nums[iToRemove]]--;
            if (heap[nums[iToRemove]] == 0)
                heap.Remove(nums[iToRemove]);
            iToRemove++;
            ans[ansId++] = heap.First().Key;
        }
        return ans;
    }
}