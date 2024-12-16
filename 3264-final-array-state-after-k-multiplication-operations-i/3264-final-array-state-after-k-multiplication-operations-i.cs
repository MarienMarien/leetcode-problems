public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        var pq = new PriorityQueue<int, (int num, int id)>(Comparer<(int num, int id)>
            .Create((x, y) => x.num == y.num ? x.id.CompareTo(y.id) : x.num.CompareTo(y.num)));
        for(var i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        for(var i = 0; i < k; i++)
        {
            var currNumId = pq.Dequeue();
            nums[currNumId] *= multiplier;
            pq.Enqueue(currNumId, (nums[currNumId], currNumId));
        }

        return nums;
    }
}