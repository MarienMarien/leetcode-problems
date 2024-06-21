public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        var totalCustomers = 0;
        var totalGrumpy = 0;

        for (var i = 0; i < customers.Length; i++)
        {
            totalCustomers += customers[i];
            if (grumpy[i] == 1)
            {
                totalGrumpy += customers[i];
            }
        }

        var maxSatisfied = totalCustomers - totalGrumpy;
        var currNeutralized = 0;
        
        for (var j = 0; j < minutes; j++)
        {
            if (grumpy[j] == 1)
            {
                currNeutralized += customers[j];
            }
        }

        var maxNeutralized = currNeutralized;

        for (var i = minutes; i < customers.Length; i++)
        {
            if (grumpy[i] == 1)
            {
                currNeutralized += customers[i];
            }
            
            if (grumpy[i - minutes] == 1)
            {
                currNeutralized -= customers[i - minutes];
            }

            maxNeutralized = Math.Max(maxNeutralized, currNeutralized);
        }

        return maxSatisfied + maxNeutralized;
    }
}