public class Solution {
    public int ShareCandies(int[] candies, int k) {
        var flavors = new Dictionary<int, int>();
        foreach (var c in candies)
        {
            if(!flavors.TryAdd(c, 1))
                flavors[c]++;
        }

        var totalFlavors = flavors.Count;
        var maxFlavors = 0;
        var currFlavors = totalFlavors;
        for (var i = 0; i < candies.Length; i++)
        {
            var notShareId = i - k;

            flavors[candies[i]]--;
            if (flavors[candies[i]] == 0)
                currFlavors--;
            if (notShareId >= 0)
            {
                if (flavors[candies[notShareId]] == 0)
                    currFlavors++;
                flavors[candies[notShareId]]++;
            }
            if(i >= k - 1)
                maxFlavors = Math.Max(maxFlavors, currFlavors);
        }

        return maxFlavors;
    }
}