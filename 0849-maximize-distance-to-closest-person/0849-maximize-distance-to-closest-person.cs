public class Solution {
    public int MaxDistToClosest(int[] seats) {
        var len = seats.Length;
        var zerosCount = new List<int>();
        var prevOneId = -1;
        for(var i = 0; i < len; i++)
        {
            if(seats[i] == 1)
            {
                var count = i - prevOneId - 1;
                if(prevOneId < 0)
                    count *= 2;
                zerosCount.Add(count);
                prevOneId = i;
                continue;
            }
            if(i == len - 1)
            {
                var count = (i - prevOneId) * 2;
                zerosCount.Add(count);
            }
        }
        var maxDistance = (zerosCount.Max() + 1) / 2;
        return maxDistance;
    }
}