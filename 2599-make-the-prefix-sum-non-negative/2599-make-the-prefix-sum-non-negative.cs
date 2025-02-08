public class Solution {
    public int MakePrefSumNonNegative(int[] nums) {
        var opCount = 0;
        var prefSum = 0L;
        var negatives = new PriorityQueue<int, int>();
        foreach(var n in nums)
        {
            if(n < 0)
                negatives.Enqueue(n, n);
            prefSum += n;
            if(prefSum < 0)
            {
                var moved = negatives.Dequeue();
                prefSum -= moved;
                opCount++;
            }
        }
        return opCount;
    }
}