public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        
        for (var i = 0; i < nums.Length; i++) {
            if (!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], 0);
            dict[nums[i]]++;
        }
        var heap = new PriorityQueue<int, int>();
        foreach (var it in dict) {
            heap.Enqueue(it.Key, it.Value * -1);
        }
        var top = new int[k];
        for (int i = k - 1; i >= 0; --i)
        {
            top[i] = heap.Dequeue();
        }
        return top;
    }
}