public class Solution {
    public int UnhappyFriends(int n, int[][] preferences, int[][] pairs) {
       var map = new Dictionary<int, int>();
        foreach (var p in pairs)
        {
            map.Add(p[0], p[1]);
            map.Add(p[1], p[0]);
        }
        var count = 0;
        foreach (var p in pairs)
        {
            count += IsUnhappy(p[0], p[1], preferences, map);
            count += IsUnhappy(p[1], p[0], preferences, map);
        }
        return count;
    }

    private static int IsUnhappy(int x, int y, int[][] preferences, Dictionary<int, int> map)
    {
        foreach (var friend in preferences[x]) {
            if (friend == y)
                return 0;
            var friend1 = map[friend];
            foreach (var friend2 in preferences[friend]) {
                if (friend2 == x)
                    return 1;
                else if (friend2 == friend1)
                    break;
            }
        }
        return 0;
    }
}