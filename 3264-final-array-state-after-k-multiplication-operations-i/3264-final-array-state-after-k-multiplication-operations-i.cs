public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        var pq = new PriorityQueue<int, (int, int)>(Comparer<(int, int)>.Create((x, y) => {
            if (x.Item1 == y.Item1)
                return x.Item2.CompareTo(y.Item2);
            return x.Item1.CompareTo(y.Item1);
        }));
        for(var i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }
        for(var i = 0; i < k; i++)
        {
            var currNumsId = pq.Dequeue();
            nums[currNumsId] *= multiplier;
            pq.Enqueue(currNumsId, (nums[currNumsId], currNumsId));
        }

        return nums;
    }
}