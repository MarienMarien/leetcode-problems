public class Solution {
    public long[] MaximumCoins(int[] heroes, int[] monsters, int[] coins) {
        Array.Sort(monsters, coins);
        var coinsSoFar = new long[coins.Length];
        coinsSoFar[0] = coins[0];
        for (var i = 1; i < coins.Length; i++)
        {
            coinsSoFar[i] = coinsSoFar[i - 1] + coins[i];
        }

        var sortedHeroes = new SortedDictionary<int, ISet<int>>(Comparer<int>.Create((x, y) => y - x));
        for (var i = 0; i < heroes.Length; i++)
        {
            if (!sortedHeroes.TryAdd(heroes[i], new HashSet<int> { i })) {
                sortedHeroes[heroes[i]].Add(i);
            }
        }

        var heroCoins = new long[heroes.Length];
        var monsterId = monsters.Length - 1;
        foreach (var health in sortedHeroes)
        {
            while (monsterId >= 0 && monsters[monsterId] > health.Key)
                monsterId--;
            foreach (var id in health.Value)
            {
                heroCoins[id] = monsterId < 0 ? 0 : coinsSoFar[monsterId];
            }
        }

        return heroCoins;
    }
}