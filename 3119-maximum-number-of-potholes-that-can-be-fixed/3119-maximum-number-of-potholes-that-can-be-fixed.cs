public class Solution {
    public int MaxPotholes(string road, int budget) {
        var candidates = new List<int>();
        var count = 0;
        const char HOLE = 'x';
        foreach(var r in road)
        {
            if(r == HOLE)
            {
                count++;
                continue;
            }

            if(count > 0)
                candidates.Add(count + 1);
            count = 0;
        }
        if(count > 0)
            candidates.Add(count + 1);

        candidates = candidates.OrderDescending().ToList();
        var maxFixed = 0;
        foreach(var c in candidates)
        {
            if(budget == 0)
                break;
            var budgetSpent = Math.Min(c, budget);
            budget -= budgetSpent;
            maxFixed += budgetSpent - 1;
        }

        return maxFixed;
    }
}