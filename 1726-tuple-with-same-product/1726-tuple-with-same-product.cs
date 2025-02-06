public class Solution {
    public int TupleSameProduct(int[] nums) {
        var productFreq = new Dictionary<int, int>();
        for(var first = 0; first < nums.Length - 1; first++)
        {
            for(var second = first + 1; second < nums.Length; second++)
            {
                var product = nums[first] * nums[second];
                if(!productFreq.TryAdd(product, 1))
                    productFreq[product]++;
            }
        }
        var tuplesCount = 0;
        foreach(var product in productFreq)
        {
            var pairs = (product.Value - 1) * product.Value / 2;
            tuplesCount += 8 * pairs;
        }

        return tuplesCount;
    }
}