public class Solution {
    public long FindScore(int[] nums) {
        var pq = new PriorityQueue<int, (int id, int val)>(Comparer<(int id, int val)>
            .Create((x, y) => x.val == y.val ? x.id.CompareTo(y.id) : x.val.CompareTo(y.val)));
        for(var i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, (i, nums[i]));
        }

        var sum = 0L;
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            if (nums[curr] < 0)
                continue;
            sum += nums[curr];
            nums[curr] = -nums[curr];
            if (curr > 0 && nums[curr - 1] > 0)
                nums[curr - 1] = -nums[curr - 1];
            if (curr < nums.Length - 1 && nums[curr + 1] > 0)
                nums[curr + 1] = -nums[curr + 1];

        }
        return sum;
    }
}