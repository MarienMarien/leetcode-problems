public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        var memo = new Dictionary<int, int>();
        var maxGaps = 0;
        var height = wall.Count;
        foreach(var bricks in wall)
        {
            var sum = 0;
            for(var i = 0; i < bricks.Count - 1; i++)
            {
                sum += bricks[i];
                if(!memo.TryAdd(sum, 1))
                    memo[sum]++;
                maxGaps = Math.Max(maxGaps, memo[sum]);
            }
            
        }

        return height - maxGaps;
    }
}