public class Solution {
    public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB) {
        var dpA = new long[energyDrinkA.Length];
        dpA[0] = energyDrinkA[0];
        dpA[1] = energyDrinkA[1] + energyDrinkA[0];

        var dpB = new long[energyDrinkB.Length];
        dpB[0] = energyDrinkB[0];
        dpB[1] = energyDrinkB[1] + energyDrinkB[0];

        for (var i = 2; i < energyDrinkA.Length; i++)
        {
            dpA[i] = Math.Max(dpA[i - 1], dpB[i - 2]) + energyDrinkA[i];
            dpB[i] = Math.Max(dpA[i - 2], dpB[i - 1]) + energyDrinkB[i];
        }

        return Math.Max(dpA[^1], dpB[^1]);
    }
}