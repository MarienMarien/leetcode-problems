public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0)
            return false;

        var map = new Dictionary<int, int>();

        foreach (var h in hand) {
            if (!map.TryAdd(h, 1))
            {
                map[h]++;
            }
        }

        var unique = map.Keys.Order().ToList();

        var uniqueId = 0;
        var isStraightHand = true;

        while (uniqueId < unique.Count) { 
            var curr = unique[uniqueId];
            if (!map.ContainsKey(curr))
            {
                uniqueId++;
                continue;
            }

            for (var i = 0; i < groupSize; i++) {
                var key = curr + i;
                if (map.ContainsKey(key))
                {
                    map[key]--;
                }
                else {
                    isStraightHand = false;
                    break;
                }
                if (map[key] == 0)
                    map.Remove(key);
            }
            if (!map.ContainsKey(curr) || map[curr] == 0)
                uniqueId++;
            if (!isStraightHand)
                break;
        }

        return isStraightHand;
    }
}