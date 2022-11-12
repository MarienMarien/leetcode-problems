public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        var ans = 0;
        // start can be 2, 4, 6
        var rows = new Dictionary<int, HashSet<int>>();
        foreach (var row in reservedSeats)
        {
            if (!rows.ContainsKey(row[0]))
            {
                rows.Add(row[0], new HashSet<int>(){ row[1] });
            }
            else
            {
                rows[row[0]].Add(row[1]);
            }
        }
        ans += (n - rows.Count) * 2;
        foreach(var k in rows.Keys)
        {
            var hasSideSeats = false;
            var row = rows[k];
            if (!row.Contains(2) && !row.Contains(3) && !row.Contains(4) && !row.Contains(5))
            {
                hasSideSeats = true;
                ans++;
            }
            if (!row.Contains(6) && !row.Contains(7) && !row.Contains(8) && !row.Contains(9))
            {
                hasSideSeats = true;
                ans++;
            }

            if (!hasSideSeats && !row.Contains(4) && !row.Contains(5) && !row.Contains(6) && !row.Contains(7))
            {
                ans++;
            }

        }

        return ans;
    }
}